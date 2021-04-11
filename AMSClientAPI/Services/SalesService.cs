using AMSClientAPI.Base;
using AMSClientAPI.Interface;
using AMSClientAPI.Models;
using AutoMapper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AMSClientAPI.Services
{
    public class SalesService : BaseRepository
    {
        private RestClientMessageSender _messageSender;

        /// <summary>
        /// Send Work Order Update 
        /// New/Update Record in Web Portal
        /// </summary>
        /// <returns></returns>
        public bool SendUpdateWorkorder()
        {
            bool result = false;
            try
            {
                DataTable table = getTable($"SELECT * FROM workorder WHERE WONo = '{this.ReferenceNo}'");
                if (table.Rows.Count > 0)
                {

                    DataTable parts = getTable($"SELECT * FROM workorderparts WHERE WONo = '{this.ReferenceNo}';");
                    DataTable services = getTable($"SELECT * FROM workorderservices WHERE WONo = '{this.ReferenceNo}';");
                    DataTable labor = getTable($"SELECT * FROM wo_laborers WHERE WONo = '{this.ReferenceNo}';");
                    DataTable damagedinfo = getTable($"SELECT * FROM workorder_damage_info WHERE WONo = '{this.ReferenceNo}';");
                    DataTable damagedrepairs = getTable($"SELECT * FROM workorder_repair_info  WHERE WONo = '{this.ReferenceNo}';");
                    DataTable damagedparts = getTable($"SELECT * FROM workorder_damparts WHERE WONo = '{this.ReferenceNo}';");

                    WorkOrder model = Mapper.DynamicMap<IDataReader, List<WorkOrder>>(table.CreateDataReader()).First();

                    DataTable deptloc = getTable("SELECT * FROM locdep WHERE NodeID = " + model.LocID + ";");
                    model.PicklistDepartmentLocation = Mapper.DynamicMap<IDataReader, List<PicklistDepartmentLocation>>(deptloc.CreateDataReader()).First();

                    model.WorkOrderParts = AutoMapper.Mapper.DynamicMap<IDataReader, List<WorkOrderParts>>(parts.CreateDataReader());
                    model.WorkOrderServices = AutoMapper.Mapper.DynamicMap<IDataReader, List<WorkOrderServices>>(services.CreateDataReader());
                    model.WorkOrderLaborers = AutoMapper.Mapper.DynamicMap<IDataReader, List<WorkOrderLaborers>>(labor.CreateDataReader());
                    model.WorkOrderDamagedInfo = AutoMapper.Mapper.DynamicMap<IDataReader, List<WorkOrderDamagedInfo>>(damagedinfo.CreateDataReader());
                    model.WorkOrderDamagedParts = AutoMapper.Mapper.DynamicMap<IDataReader, List<WorkOrderDamagedParts>>(damagedparts.CreateDataReader());
                    model.WorkOrderRepairInfo = AutoMapper.Mapper.DynamicMap<IDataReader, List<WorkOrderRepairInfo>>(damagedrepairs.CreateDataReader());

                    var json = JsonConvert.SerializeObject(model);

                    this.List = new SimpleModel();
                    this.List.Code = this.Code;
                    this.List.SiteCode = this.SiteCode;

                    this.List.IsSCMLocation = this.IsSupplyChain;
                    this.List.Name = json;

                    _messageSender = new RestClientMessageSender();
                    var response = (RestResponseBase)_messageSender.sendRequest<WorkOrder>(this);

                    if (response.Content != string.Empty)

                        result = ((response.Content == "true") ? true : false);

                    /**
                     * Insert / Queue value to tmp_update table to process by auto snyc when request failed
                     */
                    if (!result && this.FailOver)
                    {
                        queueFailedRequest(this.Module.ToString(), this.ReferenceNo.ToString());
                    }
                }
                else
                {
                    result = true;
                }

            }
            catch (Exception)
            {
                /**
                 * Insert / Queue value to tmp_update table to process by auto snyc when request failed
                 */
                if (!result && this.FailOver)
                {
                    queueFailedRequest(this.Module.ToString(), this.ReferenceNo.ToString());
                }
            }
            
            return result;
        }

        /// <summary>
        /// Send Quotation Update
        /// New/Update Record in Web Portal
        /// </summary>
        /// <returns></returns>
        public bool SendUpdateQuotation()
        {
            bool result = false;
            try
            {
                DataTable table = getTable($"SELECT * FROM quotation WHERE QuotationNo = '{this.ReferenceNo}'");
                if (table.Rows.Count > 0)
                {

                    DataTable parts = getTable($"SELECT * FROM quotationparts WHERE QuotationNo = '{this.ReferenceNo}';");
                    DataTable services = getTable($"SELECT * FROM quotationservices WHERE QuotationNo = '{this.ReferenceNo}';");
                   

                    Quotation model = Mapper.DynamicMap<IDataReader, List<Quotation>>(table.CreateDataReader()).First();                   
                    model.QuotationParts = AutoMapper.Mapper.DynamicMap<IDataReader, List<QuotationParts>>(parts.CreateDataReader());
                    model.QuotationServices = AutoMapper.Mapper.DynamicMap<IDataReader, List<QuotationServices>>(services.CreateDataReader());
                  
                    var json = JsonConvert.SerializeObject(model);

                    this.List = new SimpleModel();
                    this.List.Code = this.Code;
                    this.List.SiteCode = this.SiteCode;

                    this.List.IsSCMLocation = this.IsSupplyChain;
                    this.List.Name = json;

                    _messageSender = new RestClientMessageSender();
                    var response = (RestResponseBase)_messageSender.sendRequest<Quotation>(this);

                    if (response.Content != string.Empty)

                        result = ((response.Content == "true") ? true : false);

                    /**
                     * Insert / Queue value to tmp_update table to process by auto snyc when request failed
                     */
                    if (!result && this.FailOver)
                    {
                        queueFailedRequest(this.Module.ToString(), this.ReferenceNo.ToString());
                    }
                }
                else
                {
                    result = true;
                }

            }
            catch (Exception)
            {
                /**
                 * Insert / Queue value to tmp_update table to process by auto snyc when request failed
                 */
                if (!result && this.FailOver)
                {
                    queueFailedRequest(this.Module.ToString(), this.ReferenceNo.ToString());
                }
            }

            return result;
        }

        /// <summary>
        /// Send Sales Invoice Update
        /// New/Update Record in Web Portal
        /// </summary>
        /// <returns></returns>
        public bool SendSalesInvoice()
        {
            bool result = false;
            try
            {
                DataTable table = getTable($"SELECT * FROM workorderinvoices WHERE WONo = '{this.ReferenceNo}'");
                if (table.Rows.Count > 0)
                {

                    DataTable parts = getTable($"SELECT * FROM salesinvoice_parts WHERE WONo = '{this.ReferenceNo}';");
                    DataTable services = getTable($"SELECT * FROM salesinvoice_services WHERE WONo = '{this.ReferenceNo}';");


                    SalesInvoice model = Mapper.DynamicMap<IDataReader, List<SalesInvoice>>(table.CreateDataReader()).First();
                    model.SalesInvoiceParts = AutoMapper.Mapper.DynamicMap<IDataReader, List<SalesInvoiceParts>>(parts.CreateDataReader());
                    model.SalesInvoiceServices = AutoMapper.Mapper.DynamicMap<IDataReader, List<SalesInvoiceServices>>(services.CreateDataReader());

                    var json = JsonConvert.SerializeObject(model);

                    this.List = new SimpleModel();
                    this.List.Code = this.Code;
                    this.List.SiteCode = this.SiteCode;

                    this.List.IsSCMLocation = this.IsSupplyChain;
                    this.List.Name = json;

                    _messageSender = new RestClientMessageSender();
                    var response = (RestResponseBase)_messageSender.sendRequest<SalesInvoice>(this);

                    if (response.Content != string.Empty)

                        result = ((response.Content == "true") ? true : false);

                    /**
                     * Insert / Queue value to tmp_update table to process by auto snyc when request failed
                     */
                    if (!result && this.FailOver)
                    {
                        queueFailedRequest(this.Module.ToString(), this.ReferenceNo.ToString());
                    }
                }
                else
                {
                    result = true;
                }

            }
            catch (Exception)
            {
                /**
                 * Insert / Queue value to tmp_update table to process by auto snyc when request failed
                 */
                if (!result && this.FailOver)
                {
                    queueFailedRequest(this.Module.ToString(), this.ReferenceNo.ToString());
                }
            }

            return result;
        }
    }
}
