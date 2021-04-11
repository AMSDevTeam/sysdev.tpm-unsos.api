using System;
using System.Collections.Generic;
namespace AMSClientAPI.Models
{  
    /// <summary>
    /// Work Orders
    /// </summary>   
    public class WorkOrder
    {
        public string WONo { get; set; }

        public long WOID { get; set; }

        public string NLID { get; set; }

        public string RefWONo { get; set; }

        public string UNWONo { get; set; }

        public byte Notified { get; set; }

        public DateTime? NotificationDate { get; set; }

        public string ServiceOrderNo { get; set; }

        public string WOType { get; set; }

        public string CusRefCode { get; set; }

        public long DeptID { get; set; }

        public long LocID { get; set; }

        public DateTime? Issued { get; set; }

        public DateTime? Closed { get; set; }

        public DateTime? DtCompleted { get; set; }

        public DateTime? PostingDate { get; set; }

        public DateTime? ArrivalDate { get; set; }

        public string Status { get; set; }

        public string WorkPerformed { get; set; }

        public long? Meter { get; set; }

        public long? LastFleetMeter { get; set; }

        public string Notes { get; set; }

        public DateTime? ETC { get; set; }

        public string Udf1 { get; set; }

        public string Udf2 { get; set; }

        public string Udf3 { get; set; }

        public string Udf4 { get; set; }

        public string Udf5 { get; set; }

        public string Udf6 { get; set; }

        public string Udfl1 { get; set; }

        public string Udfl2 { get; set; }

        public string Udfl3 { get; set; }

        public string Udfl4 { get; set; }

        public string Udfl5 { get; set; }

        public string Udfl6 { get; set; }

        public string PricesBy { get; set; }

        public string InspectedBy1 { get; set; }

        public string InspectedBy2 { get; set; }

        public int? Fuel1 { get; set; }

        public int? Fuel2 { get; set; }

        public string InvoiceType { get; set; }

        public string CurrencyCode { get; set; }

        public decimal? Rate { get; set; }

        public decimal? Gross { get; set; }

        public decimal? GrossUSD { get; set; }

        public decimal? Discount { get; set; }

        public decimal? DiscountUSD { get; set; }

        public decimal? Net { get; set; }

        public decimal? NetUSD { get; set; }

        public string QuotationNo { get; set; }

        public string DamageCause { get; set; }

        public string PreventiveCause { get; set; }

        public byte Accidental { get; set; }

        public decimal? PartsCost { get; set; }

        public decimal? PartsCostUSD { get; set; }

        public decimal? Recovery { get; set; }

        public int? Labor { get; set; }

        public decimal? NoHour { get; set; }

        public decimal? Total { get; set; }

        public decimal? LaborCost { get; set; }

        public decimal? LaborCostUSD { get; set; }

        public decimal? LaborProfPerc { get; set; }

        public decimal? WOGross { get; set; }

        public decimal? WOGrossUSD { get; set; }

        public decimal? WODiscount { get; set; }

        public decimal? WODiscountUSD { get; set; }

        public decimal? WONet { get; set; }

        public decimal? WONetUSD { get; set; }

        public decimal? DiscPerc { get; set; }

        public string CTOCusRefCode { get; set; }

        public string VehStatus { get; set; }

        public byte TempClose { get; set; }

        public byte WOReopen { get; set; }

        public string SiteCode { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? DateModified { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? NextServiceDate { get; set; }

        public DateTime? DateCreated { get; set; }

        public long? SiteId { get; set; }

        public virtual List<WorkOrderParts> WorkOrderParts { get; set; }

        public virtual List<WorkOrderServices> WorkOrderServices { get; set; }

        public virtual List<WorkOrderLaborers> WorkOrderLaborers { get; set; }

        public virtual List<WorkOrderDamagedInfo> WorkOrderDamagedInfo { get; set; }

        public virtual List<WorkOrderDamagedParts> WorkOrderDamagedParts { get; set; }

        public virtual List<WorkOrderRepairInfo> WorkOrderRepairInfo { get; set; }

        public PicklistDepartmentLocation PicklistDepartmentLocation { get; set; }

    }


    /// <summary>
    /// Work Order Parts
    /// </summary>
    public class WorkOrderParts
    {

        public long WOPartID { get; set; }
               
        public string SiteCode { get; set; }

        public string WONo { get; set; }

        public long? WOID { get; set; }

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

        public long? QTPartID { get; set; }
    }


    /// <summary>
    /// Work Order Services
    /// </summary>
    public class WorkOrderServices
    {

        public long WOServiceID { get; set; }

        public string WONo { get; set; }

        public long? WOID { get; set; }

        public string SiteCode { get; set; }

        public long? ServiceID { get; set; }

        public string OperationalCode { get; set; }

        public string ServiceCode { get; set; }

        public string ServiceDesc { get; set; }

        public string ServiceType { get; set; }

        public decimal? Hours { get; set; }

        public decimal? Quantity { get; set; }

        public byte UseActual { get; set; }

        public decimal? CostPrice { get; set; }

        public decimal? CostPriceUSD { get; set; }

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

        public long? QTServiceID { get; set; }

        public int? MLevel { get; set; }

        public string Level { get; set; }

        public string Ordering { get; set; }
    }

    /// <summary>
    /// Work Order Mechanics/Laborers
    /// </summary>
    public  class WorkOrderLaborers
    {

        public long LaborID { get; set; }

        public string WONo { get; set; }

        public long? WOID { get; set; }

        public string SiteCode { get; set; }

        public string EmpCode { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public decimal? Hour { get; set; }

        public long? WOServiceID { get; set; }

        public byte NonBillableID { get; set; }

        public DateTime? LaborDate { get; set; }

        public TimeSpan? TimeIn { get; set; }

        public TimeSpan? TimeOut { get; set; }

        public byte Completed { get; set; }

        public DateTime? DateCompleted { get; set; }

        public string Remarks { get; set; }

        public long? ServiceID { get; set; }

        public int? OperationID { get; set; }

        public DateTime? LastUpdate { get; set; }
    }


    /// <summary>
    /// Work Order Damaged Information
    /// for ECOD Reports
    /// </summary>
    public  class WorkOrderDamagedInfo
    {
        public int DamRepID { get; set; }

        public string WONo { get; set; }

        public long? WOID { get; set; }

        public string SiteCode { get; set; }

        public string Name { get; set; }

        public byte Check { get; set; }
    }


    /// <summary>
    /// Work Order Damaged Parts
    /// </summary>
    public  class WorkOrderDamagedParts
    {

        public long PartsHistID { get; set; }

        public string WONo { get; set; }

        public long? WOID { get; set; }

        public string SiteCode { get; set; }

        public long? PartID { get; set; }

        public string PartName { get; set; }

        public string PartNo { get; set; }

        public string UOM { get; set; }

        public long? Qty { get; set; }

        public decimal? UnitCost { get; set; }
    }


    /// <summary>
    /// Work Order Repair Information
    /// </summary>
    public class WorkOrderRepairInfo
    {
        public int DamRepID { get; set; }

        public string WONo { get; set; }

        public long? WOID { get; set; }

        public string SiteCode { get; set; }

        public string Name { get; set; }

        public byte Check { get; set; }
    }


    public class RecordForDelete
    {
        public string ReferenceNo { get; set; }

        public string SiteCode { get; set; }

    }

    public class WPUpdateRetries
    {
        public long UpdateID { get; set; }
    }
}
