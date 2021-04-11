using AMSClientAPI.Base;
using AMSClientAPI.Services;

namespace AMSClientAPI.Client
{
    public class PostMethodAPI
    {
        private string _APIEndPoint = string.Empty;
        private string _ConnectionString = string.Empty;
        private bool _IsSupplyChain = false;
        private string _SiteCode = "";
        private long _SiteID = 0;

        public PostMethodAPI(string connString,string sitecode,long siteid, bool issupplychain, string endPoint)
        {
            _APIEndPoint = endPoint;
            _ConnectionString = connString;
            _IsSupplyChain = issupplychain;
            _SiteCode = sitecode;
            _SiteID = siteid;
        }

        /// <summary>
        /// Send Assigned Unit Picklist 
        /// </summary>
        /// <param name="lUnitUD"> UnitID </param>
        /// <param name="failOver">default value is true = calling from fastrax,
        /// false = when calling from the server from pending for updates in tmp_updates</param>
        /// <returns></returns>
        public bool sendAssignedUnit(long lUnitUD, bool failOver = true)
        {
            StandardEntriesService service = new StandardEntriesService();
            service.ConnectionString = this._ConnectionString;
            service.APIEndpoint = this._APIEndPoint;

            service.ReferenceID = lUnitUD;
            service.SiteCode = this._SiteCode;
            service.SiteID = this._SiteID;
            service.FailOver = failOver;
            service.HTTPMethod = Constant.POST;
            service.Code = Constant.picklist_assignedunit;
            service.Module = Constant.moduleEnum.AssignedUnit.ToString();
            service.WebURL = Constant.picklist_assignedunit_uri;
            service.IsSupplyChain = this._IsSupplyChain;

            return service.SendUpdateAssignedUnit();
        }

        /// <summary>
        /// Send Quotation
        /// Insert/Update Record to Web Portal
        /// </summary>
        /// <param name="sQuotationNo">Reference Quotation No</param>
        /// <param name="failOver">default value is true = calling from fastrax,
        /// false = when calling from the server from pending for updates in tmp_updates</param>
        /// <returns></returns>
        public bool SendQuotation(string sQuotationNo, bool failOver = true)
        {
            SalesService service = new SalesService();
            service.ConnectionString = this._ConnectionString;
            service.APIEndpoint = this._APIEndPoint;

            service.ReferenceNo = sQuotationNo;
            service.SiteCode = this._SiteCode;
            service.SiteID = this._SiteID;
            service.FailOver = failOver;
            service.HTTPMethod = Constant.POST;
            service.Code = Constant.sales_quotation;
            service.Module = Constant.moduleEnum.Quotation.ToString();
            service.WebURL = Constant.sales_quotation_uri;
            service.IsSupplyChain = this._IsSupplyChain;

            return service.SendUpdateQuotation();
        }

        /// <summary>
        /// Send Work Order
        /// New/Update to Web Portal
        /// </summary>
        /// <param name="sWoNo">Reference Work Order No</param>
        /// <param name="failOver">default value is true = calling from fastrax,
        /// false = when calling from the server from pending for updates in tmp_updates</param>
        /// <returns></returns>
        public bool SendWorkOrder(string sWoNo, bool failOver = true)
        {
            SalesService service = new SalesService();
            service.ConnectionString = this._ConnectionString;
            service.APIEndpoint = this._APIEndPoint;

            service.ReferenceNo = sWoNo;
            service.SiteCode = this._SiteCode;
            service.SiteID = this._SiteID;
            service.FailOver = failOver;
            service.HTTPMethod = Constant.POST;
            service.Code = Constant.sales_workorder;
            service.Module = Constant.moduleEnum.WorkOrder.ToString();
            service.WebURL = Constant.sales_workorder_uri;
            service.IsSupplyChain = this._IsSupplyChain;

            return service.SendUpdateWorkorder();
        }

        /// <summary>
        /// Send Sales Invoice
        /// New/Update Sales Invoice
        /// </summary>
        /// <param name="sWONo">Reference Work Order No</param>
        /// <param name="failOver">default value is true = calling from fastrax,
        /// false = when calling from the server from pending for updates in tmp_updates</param>
        /// <returns></returns>
        public bool SendSalesInvoice(string sWONo, bool failOver = true)
        {
            SalesService service = new SalesService();
            service.ConnectionString = this._ConnectionString;
            service.APIEndpoint = this._APIEndPoint;

            service.ReferenceNo = sWONo;
            service.SiteCode = this._SiteCode;
            service.SiteID = this._SiteID;
            service.FailOver = failOver;
            service.HTTPMethod = Constant.POST;
            service.Code = Constant.sales_sales_invoice;
            service.Module = Constant.moduleEnum.SalesInvoice.ToString();
            service.WebURL = Constant.sales_sales_invoice_uri;
            service.IsSupplyChain = this._IsSupplyChain;

            return service.SendSalesInvoice();
        }

    }
}
