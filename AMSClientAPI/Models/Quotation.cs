using System;
using System.Collections.Generic;
namespace AMSClientAPI.Models
{

    /// <summary>
    /// Customer Quotation
    /// </summary>
    public class Quotation
    {
        public string QuotationNo { get; set; }

        public DateTime? QuotationDate { get; set; }

        public string RefWONo { get; set; }

        public string NLID { get; set; }

        public string CusRefCode { get; set; }

        public string AccidentCaseNo { get; set; }

        public DateTime? ArrivalDate { get; set; }

        public string CurrencyCode { get; set; }

        public decimal? Rate { get; set; }

        public string Notes { get; set; }

        public string PricesBy { get; set; }

        public string PreparedBy { get; set; }

        public string VerifiedBy { get; set; }

        public DateTime? DateApproved { get; set; }

        public DateTime? DateRejected { get; set; }

        public long? Meter { get; set; }

        public decimal? Gross { get; set; }

        public decimal? GrossUSD { get; set; }

        public decimal? Discount { get; set; }

        public decimal? DiscountUSD { get; set; }

        public decimal? Net { get; set; }

        public decimal? NetUSD { get; set; }

        public string Reason { get; set; }

        public string Remarks { get; set; }

        public string Status { get; set; }

        public long? CServiceID { get; set; }

        public string UDF1 { get; set; }

        public string UDF2 { get; set; }

        public string UDF3 { get; set; }

        public string UDF4 { get; set; }

        public string UDF5 { get; set; }

        public string UDF6 { get; set; }

        public string LblUDF1 { get; set; }

        public string LblUDF2 { get; set; }

        public string LblUDF3 { get; set; }

        public string LblUDF4 { get; set; }

        public string LblUDF5 { get; set; }

        public string LblUDF6 { get; set; }

        public byte ForApproval { get; set; }

        public string Passkey { get; set; }

        public string AccessCode { get; set; }

        public string ReqEMail { get; set; }

        public string RefQuotationNo { get; set; }

        public string REPType { get; set; }

        public decimal? LaborCost { get; set; }

        public decimal? LaborCostUSD { get; set; }

        public decimal? LaborProfPerc { get; set; }

        public decimal? DiscPerc { get; set; }

        public string AppDecBy { get; set; }

        public string CTOCusRefCode { get; set; }

        public byte FromQuote { get; set; }

        public string SignatoryEmpCode { get; set; }

        public string ApproverEmpCode { get; set; }

        public long? SiteId { get; set; }

        public string SiteCode { get; set; }

        public DateTime? DateModified { get; set; }

        public string CreatedBy { get; set; }

        public string Modified { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual List<QuotationParts> QuotationParts { get; set; }

        public virtual List<QuotationServices> QuotationServices { get; set; }
    }

    /// <summary>
    /// Quotation Parts
    /// </summary>
    public class QuotationParts
    {

        public long QTPartID { get; set; }

        public string QuotationNo { get; set; }

        public int? PartsDeptID { get; set; }

        public long? PartID { get; set; }

        public string PartNo { get; set; }

        public string Name { get; set; }

        public string UnitType { get; set; }

        public int? Quantity { get; set; }

        public decimal? CostPrice { get; set; }

        public decimal? SalesPrice { get; set; }

        public decimal? CostPriceUSD { get; set; }

        public decimal? SalesPriceUSD { get; set; }

        public decimal? ProfitPercentage { get; set; }

        public byte IsPriceGroup { get; set; }

        public long? ServiceID { get; set; }

        public string Availability { get; set; }

        public string RFQNo { get; set; }

        public DateTime? ETA { get; set; }

        public long? PromoID { get; set; }

        public string Remarks { get; set; }

        public byte Approved { get; set; }

        public long? RefWOPartID { get; set; }

        public string ETD { get; set; }

        public byte Chargeable { get; set; }

        public long? WOPartID { get; set; }

        public string SiteCode { get; set; }
    }


    /// <summary>
    /// Quotation Sevices
    /// </summary>
    public class QuotationServices
    {

        public long QTServiceID { get; set; }

        public string QuotationNo { get; set; }

        public long? ServiceID { get; set; }

        public string ServiceCode { get; set; }

        public string ServiceDesc { get; set; }

        public string ServiceType { get; set; }

        public decimal? Hours { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? SalesPrice { get; set; }

        public decimal? SalesPriceUSD { get; set; }

        public byte IsPriceGroup { get; set; }

        public long? SServiceID { get; set; }

        public long? PromoID { get; set; }

        public byte TypeID { get; set; }

        public string Remarks { get; set; }

        public decimal? ProfitPercentage { get; set; }

        public decimal? CostPrice { get; set; }

        public decimal? CostPriceUSD { get; set; }

        public byte Approved { get; set; }

        public int? OperationID { get; set; }

        public long? CategoryID { get; set; }

        public long? RefWOServiceID { get; set; }

        public long? WOServiceID { get; set; }

        public int? MLevel { get; set; }

        public string Level { get; set; }

        public string Ordering { get; set; }

        public string SiteCode { get; set; }
    }
}
