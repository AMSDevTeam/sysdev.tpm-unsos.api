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
    public class StandardEntriesService : BaseRepository
    {
        private RestClientMessageSender _messageSender;

        public bool SendUpdateAssignedUnit()
        {
            bool result = false;
            DataTable table = getTable($"SELECT * FROM armyunit WHERE UnitID = {this.ReferenceID}");
            if (table.Rows.Count > 0)
            {
               
                PicklistAssignedUnit dtSet = Mapper.DynamicMap<IDataReader, List<PicklistAssignedUnit>>(table.CreateDataReader()).First();              
                var json = JsonConvert.SerializeObject(dtSet);

                this.List = new SimpleModel();
                this.List.Code = this.Code;
                this.List.SiteCode = this.SiteCode;

                this.List.IsSCMLocation = this.IsSupplyChain;
                this.List.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<PicklistAssignedUnit>(this);

                if (response.Content != string.Empty)

                    result = ((response.Content == "true") ? true : false);

                /**
                 * Insert / Queue value to tmp_update table to process by auto snyc when request failed
                 */
                if (!result && this.FailOver)
                {
                    queueFailedRequest(this.Module.ToString(), this.ReferenceID.ToString());
                }
            }
            else
            {
                result = true;
            }

            return result;
        }
    }
}
