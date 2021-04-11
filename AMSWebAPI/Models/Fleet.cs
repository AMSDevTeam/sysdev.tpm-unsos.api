using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSWebAPI.Models
{

   /// <summary>
   ///  Fleet Inventory
   /// </summary>
    [Table("fleet")]
    public class Fleet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long FleetID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string NLID { get; set; }
     
        public string VIN { get; set; }
             
        public string PlateNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RegistrationDate { get; set; }
               
        public string RegistrationNo { get; set; }
               
        public string EngineNo { get; set; }
              
        public string EngineCode { get; set; }
              
        public string EngineType { get; set; }
               
        public string Year { get; set; }

        public int? MakeID { get; set; }

        public int? ModelID { get; set; }

        public int? SeriesID { get; set; }

        public int? ColorID { get; set; }

        public int? VehCatID { get; set; }

        public int? VehTypeID { get; set; }

        public int? NonVehTypeID { get; set; }
               
        public string ReqStatus { get; set; }
               
        public string UtilStatus { get; set; }
               
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastService { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NextServiceDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReleasedDate { get; set; }

        public int? Released { get; set; }

        public int? Mileage { get; set; }
             
        public string MeterType { get; set; }
              
        public string MileConversionValue { get; set; }
                
        public string FuelType { get; set; }
              
        public string Transmission { get; set; }

        public int? Doors { get; set; }
              
        public string TyreSize { get; set; }
              
        public string CusRefCode { get; set; }

        public int? ContractID { get; set; }

        public byte? Armored { get; set; }

        public string Notes { get; set; }

        public long? PassCap { get; set; }

        public int? RegID { get; set; }
                
        public string Province { get; set; }

        public int? UnitID { get; set; }
               
        public string OwnershipType { get; set; }

        public byte? Owned { get; set; }

        public byte? IncludeStatus { get; set; }
                
        public string UIC { get; set; }
              
        public string Barcode { get; set; }
                
        public string TPEno { get; set; }
                
        public string EngineSize { get; set; }
               
        public string FuelSticker { get; set; }
               
        public string FuelCapacity { get; set; }
                
        public string KeyTag { get; set; }

        public string VehicleTag { get; set; }
               
        public string TransmissionCode { get; set; }
               
        public string Accessories { get; set; }
              
        public string GVWR { get; set; }
              
        public string Others { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? WSD { get; set; }

        public int? WTermInMonths { get; set; }

        public byte? Active { get; set; }

        public byte? ExcludeInspect { get; set; }

        public byte? IsArchive { get; set; }

        public byte? TempClose { get; set; }
               
        public string ActLocation { get; set; }
               
        public string UdfLbl1 { get; set; }
                
        public string UdfLbl2 { get; set; }
               
        public string UdfLbl3 { get; set; }
              
        public string UdfLbl4 { get; set; }
              
        public string UdfLbl5 { get; set; }
               
        public string UdfLbl6 { get; set; }
                
        public string UdfLbl7 { get; set; }
              
        public string UdfLbl8 { get; set; }
                
        public string UdfLbl9 { get; set; }
               
        public string UdfLbl10 { get; set; }
                
        public string Udf1 { get; set; }
               
        public string Udf2 { get; set; }
               
        public string Udf3 { get; set; }
               
        public string Udf4 { get; set; }
                
        public string Udf5 { get; set; }
              
        public string Udf6 { get; set; }
                
        public string Udf7 { get; set; }
              
        public string Udf8 { get; set; }
              
        public string Udf9 { get; set; }
               
        public string Udf10 { get; set; }

        public byte? FlagID { get; set; }

        public byte? Flagged { get; set; }

        public string FlagReason { get; set; }

        public byte? FlaggedUtil { get; set; }

        public string FlagUtilReason { get; set; }

        public byte? Verified { get; set; }
                
        public string CurrentWONO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CurrentWODate { get; set; }
               
        public string OLDNLID { get; set; }
               
        public string OldSiteCode { get; set; }
              
        public string SiteCode { get; set; }
               
        public string CreatedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateCreated { get; set; }
             
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateModified { get; set; }

        [NotMapped]
        public virtual List<FleetEngineHistory> FleetEngineHistory { get; set; }

        [NotMapped]
        public virtual List<FleetFuelMonitoring> FleetFuelMonitoring { get; set; }

        [NotMapped]
        public virtual List<FleetOdometerHistory> FleetOdometerHistory { get; set; }

    }


    /// <summary>
    /// Equipment Engine History
    /// </summary>
    [Table("fleet_enghistory")]
    public class FleetEngineHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long erid { get; set; }

        public string NLID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Notes { get; set; }

        [Key]
        [Column(Order = 1)]
        public string SiteCode { get; set; }
    }

    /// <summary>
    /// Equipment Fuel Monitoring
    /// </summary>
    [Table("fleet_fuelmonitoring")]
    public class FleetFuelMonitoring
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long FuelID { get; set; }

        public string NLID { get; set; }

        public decimal? TotalMiles { get; set; }

        public decimal? LastFuel { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RefuelDate { get; set; }

        public decimal? TotalFuel { get; set; }

        public decimal? AverageKM { get; set; }

        [Key]
        [Column(Order = 1)]
        public string SiteCode { get; set; }
    }

    /// <summary>
    /// Equipment Odometer History
    /// </summary>
    [Table("fleet_odomhistory")]
    public  class FleetOdometerHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long OHID { get; set; }

        public string NLID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Notes { get; set; }

        [Key]
        [Column(Order = 1)]
        public string SiteCode { get; set; }
    }
}
