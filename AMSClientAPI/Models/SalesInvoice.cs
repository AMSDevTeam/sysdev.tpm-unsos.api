using System;
using System.Collections.Generic;

namespace AMSClientAPI.Models
{
    /// <summary>
    /// Work Order Sales Invoice
    /// </summary>
    public class SalesInvoice
    {
        public long WOInvID { get; set; }
               
        public string InvoiceNo { get; set; }

        public string WONo { get; set; }

        public long? WOID { get; set; }       

        public string Type { get; set; }

        public string Status { get; set; }

        public string INVCurrency { get; set; }

        public decimal? INVRate { get; set; }

        public DateTime? DateOpen { get; set; }

        public DateTime? DateClosed { get; set; }

        public DateTime? DateFinalized { get; set; }

        public DateTime? PostingDate { get; set; }

        public int? PrintCount { get; set; }

        public long? PaymentTermId { get; set; }

        public string BankAccountCode { get; set; }

        public string SiteCode { get; set; }

        public decimal? TotalPartsPrice { get; set; }

        public decimal? TotalPartsPriceUSD { get; set; }

        public decimal? TotalLaborPrice { get; set; }

        public decimal? TotalLaborPriceUSD { get; set; }

        public decimal? TotalGross { get; set; }

        public decimal? TotalGrossUSD { get; set; }

        public decimal? TotalDiscount { get; set; }

        public decimal? TotalVAT { get; set; }

        public decimal? TotalVATUSD { get; set; }

        public decimal? TotalDiscountUSD { get; set; }

        public decimal? TotalNet { get; set; }

        public decimal? TotalNetUSD { get; set; }

        public DateTime? DateModified { get; set; }

        public virtual List<SalesInvoiceParts> SalesInvoiceParts { get; set; }

        public virtual List<SalesInvoiceServices> SalesInvoiceServices { get; set; }
    }

    /// <summary>
    /// Sales Invoice Parts
    /// </summary>
    public class SalesInvoiceParts
    {
        public long SDetailID { get; set; }

        public string WONo { get; set; }

        public long WOPartID { get; set; }

        public long? WOID { get; set; }

        public string SiteCode { get; set; }

        public int? PartsDeptID { get; set; }

        public long? PartID { get; set; }

        public string PartNo { get; set; }

        public string Name { get; set; }

        public string UnitType { get; set; }

        public int? Quantity { get; set; }

        public decimal? CostPrice { get; set; }

        public decimal? CostPriceUSD { get; set; }

        public decimal? SalesPrice { get; set; }

        public decimal? SalesPriceUSD { get; set; }

        public decimal? ProfitPercentage { get; set; }

        public byte IsPriceGroup { get; set; }

        public long? ServiceID { get; set; }

        public byte Returned { get; set; }

        public string PONO { get; set; }

        public DateTime? ETA { get; set; }

        public byte Issued { get; set; }

        public string Remarks { get; set; }

        public DateTime? IssuedDate { get; set; }

        public string IssuedBy { get; set; }

        public byte Approved { get; set; }

        public long? RefWOPartID { get; set; }

        public string ETD { get; set; }

        public byte Chargeable { get; set; }

        public int? VATID { get; set; }

        public decimal? VATRate { get; set; }
    }

    /// <summary>
    /// Sales Invoice Services
    /// </summary>
    public class SalesInvoiceServices
    {
        public long SDetailID { get; set; }

        public string WONo { get; set; }

        public long WOServiceID { get; set; }

        public string OperationalCode { get; set; }

        public long WOID { get; set; }

        public string SiteCode { get; set; }

        public long? ServiceID { get; set; }

        public string ServiceCode { get; set; }

        public string ServiceDesc { get; set; }

        public string ServiceType { get; set; }

        public decimal? Hours { get; set; }

        public decimal? Quantity { get; set; }

        public byte UseActual { get; set; }

        public decimal? CostPriceUSD { get; set; }

        public decimal? CostPrice { get; set; }

        public decimal? ProfitPercentage { get; set; }

        public decimal? SalesPrice { get; set; }

        public decimal? SalesPriceUSD { get; set; }

        public byte IsPriceGroup { get; set; }

        public long? SServiceID { get; set; }

        public byte TypeID { get; set; }

        public string Remarks { get; set; }

        public byte Issued { get; set; }

        public DateTime? IssuedDate { get; set; }

        public string Status { get; set; }

        public string SubCategory { get; set; }

        public byte Approved { get; set; }

        public int? OperationID { get; set; }

        public long? CategoryID { get; set; }

        public long? RefWOServiceID { get; set; }

        public byte Chargeable { get; set; }

        public int? VATID { get; set; }

        public decimal? VATRate { get; set; }
    }

}

