using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using tq = TarsierEyes.MySQL;
using ts = TarsierEyes.Common.SQLStrings;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Drawing;

namespace AMSClientAPI.Base
{
    public class GenericStorage
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _ConnectionString = string.Empty;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _APIEndPoint = string.Empty;

        public string _ErrorMessage = "";

        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }

        public string APIEndpoint
        {
            get
            {
                return _APIEndPoint;
            }
            set
            {
                _APIEndPoint = value;
            }
        }

        public string HTTPMethod { get; set; }

        public DataTable getTable(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                tq.Que q = tq.Que.Execute(this.ConnectionString, sql, tq.Que.ExecutionEnum.ExecuteReader);
                if (q.Rows > 0)
                {
                    table = q.DataTable;
                }
            }
            catch (Exception e)
            {
                _ErrorMessage = e.Message; ;
            }

            return table;
        }

        public DataTable getDataTable(string sqlcommand)
        {
            tq.Que _q = tq.Que.Execute(this.ConnectionString, sqlcommand, TarsierEyes.MySQL.Que.ExecutionEnum.ExecuteReader);
            return _q.DataTable;
        }

        /**
         * temporary set to non blocking code.
         * always return boolean true
         */
        public bool queueFailedRequest(string module, string reference_id)
        {
            return queueFailedRequest(module, reference_id, 0, false);
        }


        /**
         * temporary set to non blocking code.
         * always return boolean true
         */
        public bool queueFailedRequest(string module, string reference_id, long lPartID, bool isdeleted)
        {

            bool response = true;

            tq.Que processSql = null;

            if (string.IsNullOrEmpty(module) || string.IsNullOrEmpty(reference_id))
                return response;

            string sql = "call usp_tmpUpdates('" + module + "','" + reference_id + "'," + lPartID + "," + Convert.ToInt16(isdeleted) + ",0)";

            processSql = tq.Que.Execute(this.ConnectionString.ToString(),
                    sql, tq.Que.ExecutionEnum.ExecuteNonQuery);

            return response;

        }

        /// <summary>
        /// Execute SQL Statement
        /// </summary>
        /// <param name="commandtext"></param>
        /// <returns></returns>
        public bool ExecuteSQLCommand(string commandtext)
        {
            bool result = true;
            MySqlConnection connection = new MySqlConnection(this.ConnectionString.ToString());
            try
            {
                using (MySqlCommand com = new MySqlCommand(commandtext))
                {
                    com.CommandTimeout = 500;
                    com.Connection = connection;
                    com.Connection.Open();
                    com.ExecuteNonQuery();
                    com.Connection.Close();
                    com.Dispose();
                }

            }
            catch (Exception)
            {
                result = false;
                if (connection.State == ConnectionState.Open) connection.Close();
                connection.Dispose();
            }

            return result;
        }

        /**
         * temporary set to non blocking code.
         * always return boolean true
         */
        public bool executeQuery(string sql)
        {

            bool response = true;


            if (string.IsNullOrEmpty(sql))
                return response;

            if (this.ExecuteSQLCommand(sql) == false) response = false;

            return response;

        }

        public double getSQLDoubleValue(string sql)
        {
            double value = 0;
            tq.Que _q = tq.Que.Execute(this.ConnectionString, sql, tq.Que.ExecutionEnum.ExecuteReader);
            if (_q.DataTable.Rows.Count > 0) value = (double)_q.DataTable.Rows[0][0];
            _q.Dispose();

            return value;

        }

        public decimal getSQLDecimalValue(string sql)
        {
            decimal value = 0;
            tq.Que _q = tq.Que.Execute(this.ConnectionString, sql, tq.Que.ExecutionEnum.ExecuteReader);
            if (_q.DataTable.Rows.Count > 0) value = (decimal)_q.DataTable.Rows[0][0];
            _q.Dispose();

            return value;

        }

        public string getSQLStringValue(string sql)
        {
            string value = "";
            tq.Que _q = tq.Que.Execute(this.ConnectionString, sql, tq.Que.ExecutionEnum.ExecuteReader);
            if (_q.DataTable.Rows.Count > 0) value = _q.DataTable.Rows[0][0].ToString();
            _q.Dispose();

            return value;

        }

        public long getSQLLongValue(string sql)
        {
            long value = 0;
            tq.Que _q = tq.Que.Execute(_ConnectionString, sql, tq.Que.ExecutionEnum.ExecuteReader);
            if (_q.DataTable.Rows.Count > 0) value = long.Parse(_q.DataTable.Rows[0][0].ToString());
            _q.Dispose();

            return value;

        }

        public int getSQLIntValue(string sql)
        {
            int value = 0;
            tq.Que _q = tq.Que.Execute(_ConnectionString, sql, tq.Que.ExecutionEnum.ExecuteReader);
            if (_q.DataTable.Rows.Count > 0) value = int.Parse(_q.DataTable.Rows[0][0].ToString());
            _q.Dispose();

            return value;

        }

        public object getQueryvalue(string sql)
        {

            object processSql = null;

            if (string.IsNullOrEmpty(sql))
                return processSql;

            processSql = tq.Que.GetValue(this.ConnectionString.ToString(), sql);

            return processSql;

        }

        public string ToSqlValidString(object text)
        {
            return ts.ToSqlValidString(text.ToString());
        }

        public string ToSqlValidString(string text)
        {
            return ts.ToSqlValidString(text.ToString());
        }

        public string ToSqlValidString(DateTime dated)
        {
            return ts.ToSqlValidString(dated);
        }
        public DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                try
                {
                    if (prop.PropertyType.Name.ToLower().Contains("nullable"))
                    {
                        Type _type = typeof(decimal);
                        if (prop.PropertyType.FullName.ToLower().Contains("datetime"))
                        {
                            _type = typeof(DateTime);
                        }
                        else if (prop.PropertyType.FullName.ToLower().Contains("decimal"))
                        {
                            _type = typeof(decimal);
                        }
                        else if (prop.PropertyType.FullName.ToLower().Contains("int64"))
                        {
                            _type = typeof(long);
                        }
                        else if (prop.PropertyType.FullName.ToLower().Contains("int32"))
                        {
                            _type = typeof(int);
                        }

                        table.Columns.Add(prop.Name, _type);
                    }
                    else table.Columns.Add(prop.Name, prop.PropertyType);

                }
                catch (Exception) { }
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (props[i].PropertyType == typeof(DateTime))
                    {
                        DateTime currDT = (DateTime)props[i].GetValue(item);
                        values[i] = currDT.ToUniversalTime();
                    }
                    else
                    {
                        values[i] = props[i].GetValue(item);
                    }
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public byte[] ShrinkImage(string filename)
        {

            System.IO.MemoryStream ScreenStream = new System.IO.MemoryStream();
            Bitmap from_bm = (Bitmap)Image.FromFile(filename);

            int _width = 322;
            int _height = 211;
            Bitmap to_bm = new Bitmap(_width, _height);
            Graphics _gr = Graphics.FromImage((Image)to_bm);

            _gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            _gr.DrawImage(from_bm, 0, 0, _width, _height);
            to_bm.Save(ScreenStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] _bytes = ScreenStream.ToArray();
            ScreenStream.Close();
            return _bytes;
        }

        public byte[] Compress(byte[] inputData)
        {
            int BUFFER_SIZE = 1024; //64kB

            if (inputData == null)
                throw new ArgumentNullException("inputData must be non-null");

            using (var compressIntoMs = new MemoryStream())
            {
                using (var gzs = new BufferedStream(new GZipStream(compressIntoMs,
                 CompressionMode.Compress), BUFFER_SIZE))
                {
                    gzs.Write(inputData, 0, inputData.Length);
                }
                return compressIntoMs.ToArray();
            }
        }

        public bool ArchiveFile(string filename)
        {
            string _directory = System.IO.Directory.GetCurrentDirectory() + @"\Resources";
            ProcessWindowStyle _processwinstyle = ProcessWindowStyle.Hidden;
            bool _directoryexists = false;
            if (System.IO.File.Exists(_directory + @"\7z.exe"))
            {
                _directoryexists = true;
            }
            else
            {
                _directory = System.IO.Directory.GetCurrentDirectory() + @"\FileReference";
                if (System.IO.File.Exists(_directory + @"\7z.exe")) _directoryexists = true;
            }

            if (_directoryexists ==true)
            {

                Process proc = new Process();

                proc.StartInfo.Arguments = @"a """ + filename.Replace(System.IO.Path.GetExtension(filename), ".7z") + @""" """ + filename + @"""";
                proc.StartInfo.FileName = _directory + @"\7z.exe";
                proc.StartInfo.CreateNoWindow = (_processwinstyle == ProcessWindowStyle.Hidden);
                proc.StartInfo.WindowStyle = _processwinstyle;
                proc.Start();
                proc.Refresh();
                do
                {
                    if (proc.HasExited ) break;

                } while (!proc.HasExited);
                proc.Dispose();

                return true;
            }
            else {
                return false;
            }

        }

        public FileInfo  ByteToArrayToFileObject(byte[] bytes, string fileextension, string outputdirectory)
        {
            FileInfo fi = null;

            if (!Directory.Exists(outputdirectory))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(outputdirectory);
                }
                catch (Exception) { }
            }

            if (Directory.Exists(outputdirectory))
            {
                if (File.Exists(outputdirectory + @"\file." + fileextension))
                {
                   System.IO.File.Delete(outputdirectory + @"\file." + fileextension);
                }
                
                File.WriteAllBytes(outputdirectory + @"\file." + fileextension, bytes);
                if (File.Exists(outputdirectory + @"\file." + fileextension))
                {
                    fi = new FileInfo(outputdirectory + @"\file." + fileextension);
                }
            }

            return fi;
        }

        public byte[] FileObjectToByteArray(string filename)
        {
            return TarsierEyes.Common.Simple.FileObjectToByteArray(filename);
        }
        public bool Decompress(string filename, string sDestination)
        {         
            string _directory = System.IO.Directory.GetCurrentDirectory() + @"\Resources";
            ProcessWindowStyle _processwinstyle = ProcessWindowStyle.Hidden;

            if (System.IO.File.Exists(_directory + @"\7z.exe"))
            {
                Process proc = new Process();
                proc.StartInfo.Arguments = @"e """ + filename + @""" -o""" + sDestination + @""" *.* -r";
                proc.StartInfo.FileName = _directory + @"\7z.exe";
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = _processwinstyle;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();
                do
                {
                    if (proc.HasExited) break;

                } while (!proc.HasExited);

                proc.Dispose();
                return true;
            }
            else {
                return false;
            }     
        }
      
    }

}