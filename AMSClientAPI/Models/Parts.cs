using System;
namespace AMSClientAPI.Models
{
    /// <summary>
    /// Parts Inventory
    /// </summary>
    public class Parts
    {

        public long PartID { get; set; }

        public string SiteCode { get; set; }

        public int? PartsDeptID { get; set; }

        public string PartNo { get; set; }

        public string Name { get; set; }

        public int? MakeID { get; set; }

        public int? ModelID { get; set; }

        public decimal? BaseQty { get; set; }

        public decimal? Qty { get; set; }

        public string BaseUnitType { get; set; }

        public int? BaseConversion { get; set; }

        public long? Conversion { get; set; }

        public string UnitType { get; set; }

        public long? Incoming { get; set; }

        public long? Outgoing { get; set; }

        public long? ReOrderPoint { get; set; }

        public long? ReOrderQty { get; set; }

        public decimal? BaseUnitCost { get; set; }

        public decimal? UnitCost { get; set; }

        public decimal? ProfitPercentage { get; set; }

        public decimal? BaseSalesPrice { get; set; }

        public decimal? SalesPrice { get; set; }

        public string PartType { get; set; }

        public decimal? PartsTotVal { get; set; }

        public decimal? SalesVAT { get; set; }

        public decimal? SalesVATFree { get; set; }

        public string SalesVATCode { get; set; }

        public decimal? PurchaseVAT { get; set; }

        public decimal? PurchaseVATFree { get; set; }

        public string PurchaseVATCode { get; set; }

        public string Location { get; set; }

        public string Shelf { get; set; }

        public string Notes { get; set; }

        public string Status { get; set; }

        public string Movement { get; set; }

        public string AccGrpID { get; set; }

        public long? PCatID { get; set; }

        public string UDFL1 { get; set; }

        public string UDFL2 { get; set; }

        public string UDFL3 { get; set; }

        public string UDFL4 { get; set; }

        public string UDFL5 { get; set; }

        public string UDF1 { get; set; }

        public string UDF2 { get; set; }

        public string UDF3 { get; set; }

        public string UDF4 { get; set; }

        public string UDF5 { get; set; }

        public int? ReservedQty { get; set; }

        public string OldPartNo { get; set; }

        public int? AdjustQtyIn { get; set; }

        public int? AdjustQtyOut { get; set; }

        public string SupersededParts { get; set; }

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public decimal? Height { get; set; }

        public string DimUOM { get; set; }

        public decimal? Volume { get; set; }

        public string VolUOM { get; set; }

        public DateTime DateModified { get; set; }
    }

}
