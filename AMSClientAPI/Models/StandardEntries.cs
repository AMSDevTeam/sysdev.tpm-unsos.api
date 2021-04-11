using System;
namespace AMSClientAPI.Models
{
    /// <summary>
    /// Assigned Unit
    /// </summary>
    public class PicklistAssignedUnit
    {
        public int UnitID { get; set; }

        public string UnitName { get; set; }
    }
    /// <summary>
    /// Colors
    /// </summary>
    public  class PicklistColors
    {
        public int ColorID { get; set; }

        public string Color { get; set; }
    }

    /// <summary>
    /// Employee Operation / Mechanic
    /// </summary>
    public  class EmployeeOperation
    {
        public string EmpCode { get; set; }

        public string LName { get; set; }

        public string FName { get; set; }

        public string MName { get; set; }

        public string DisplayName { get; set; }

        public string Department { get; set; }

        public string Position { get; set; }

        public string SkillLevel { get; set; }

        public string Status { get; set; }

        public string ContactNo { get; set; }

        public string SiteCode { get; set; }

        public string employerName { get; set; }

        public byte? isLocal { get; set; }
    }

    /// <summary>
    /// Employee Managers
    /// </summary>
    public  class EmployeeManagers
    {
        public string EmpCode { get; set; }

        public string LName { get; set; }

        public string FName { get; set; }

        public string MName { get; set; }

        public string DisplayName { get; set; }

        public string Category { get; set; }

        public string Department { get; set; }

        public string Position { get; set; }

        public string Status { get; set; }

        public string ContactNo { get; set; }

        public string SiteCode { get; set; }

        public string employerName { get; set; }

        public byte? isLocal { get; set; }
    }

    /// <summary>
    /// FAStrax Standard Site List
    /// </summary>
    public class FASTraxSitesList
    {
        public long SiteId { get; set; }
       
        public string SiteCode { get; set; }

        public string CostCenter { get; set; }

        public string Division { get; set; }

        public string Location { get; set; }

        public long? AccountCode { get; set; }

        public byte? Active { get; set; }

        public DateTime? LastUpdate { get; set; }
    }

    /// <summary>
    /// Makes Picklist
    /// </summary>
    public  class PicklistMakes
    {
        public int MakeID { get; set; }

        public string Make { get; set; }
    }


    /// <summary>
    /// Models Picklist
    /// </summary>
    public class PicklistModels
    {
        public int ModelID { get; set; }

        public int? MakeID { get; set; }

        public string Model { get; set; }

        public byte? ForAid { get; set; }

        public string VehicleCode { get; set; }
    }

    /// <summary>
    /// Non-Vehicle Type Picklist
    /// </summary>
    public  class PicklistNonVehicleType
    {
        public int NonVehTypeID { get; set; }

        public int? VehClassID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

    }

    /// <summary>
    /// Non-VehicleType Make and Model Picklist
    /// </summary>
    public  class PicklistNonVehicleTypeMake
    {
        public long NVTModelID { get; set; }

        public int? NonVehTypeID { get; set; }

        public int? ModelID { get; set; }

        public byte? Status { get; set; }
    }

    /// <summary>
    /// Parts Category Picklist
    /// </summary>
    public  class PicklistPartsCategory
    {
        public long PCatID { get; set; }

        public string PCatName { get; set; }

        public string PGrpCode { get; set; }
    }

    /// <summary>
    /// Parts Department Picklist
    /// </summary>
    public  class PicklistPartsDepartment
    {
        public int PartsDeptID { get; set; }

        public string Department { get; set; }

        public byte? Chargeable { get; set; }

        public long? SiteId { get; set; }
    }

    /// <summary>
    /// Regions Picklist
    /// </summary>
    public  class PicklistRegions
    {
        public int RegID { get; set; }

        public string Type { get; set; }
    }

    /// <summary>
    /// SC Account Group Picklist
    /// </summary>
    public class PicklistSCAccountGroup
    {
        public string AccGrpID { get; set; }

        public string AccID { get; set; }

        public string AccGrpName { get; set; }

        public long? AccountId { get; set; }
    }

    /// <summary>
    /// Series Picklist
    /// </summary>
    public class PicklistSeries
    {
        public int SeriesID { get; set; }

        public string SeriesNo { get; set; }

        public int? ModelID { get; set; }
    }

    /// <summary>
    /// Equipment Category Picklist
    /// </summary>
    public  class PicklistEquipmentCategory
    {
        public int VehClassID { get; set; }

        public string Class { get; set; }

        public byte? Type { get; set; }
    }

    /// <summary>
    /// Equipment Type Picklist
    /// </summary>
    public  class PicklistEquipmentType
    {
        public int VehTypeID { get; set; }

        public int? VehClassID { get; set; }

        public string Description { get; set; }

        public int? ssKM { get; set; }

        public int? ssWeek { get; set; }

        public string Class { get; set; }

        public int? LicenseCat { get; set; }

        public int? ssKMUNIT { get; set; }

        public int? ssWeekUNIT { get; set; }
    }

    /// <summary>
    /// Equipment Type Make Picklist
    /// </summary>
    public class PicklistEquipmentTypeMake
    {
        public long VTModelID { get; set; }

        public int? VehTypeID { get; set; }

        public int? ModelID { get; set; }
    }

    /// <summary>
    /// Department and Location Picklist
    /// </summary>
    public class PicklistDepartmentLocation
    {
        public long NodeID { get; set; }

        public long? Parent { get; set; }

        public string Caption { get; set; }

        public string SiteCode { get; set; }
    }

    /// <summary>
    /// Customers Picklist
    /// </summary>
    public  class Customers
    {
        public string CusRefCode { get; set; }

        public string CustomerNo { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PostalCode { get; set; }

        public string Province { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string TRNNo { get; set; }

        public string OPCName { get; set; }

        public string OPCEmail { get; set; }

        public string OPCPhone { get; set; }

        public string OPCFax { get; set; }

        public string FPCName { get; set; }

        public string FPCEmail { get; set; }

        public string FPCPhone { get; set; }

        public string FPCFax { get; set; }

        public string Person1 { get; set; }

        public string Person2 { get; set; }

        public string Person3 { get; set; }

        public string Person4 { get; set; }

        public string DeliveryAddress { get; set; }

        public string CurrencyCode { get; set; }

        public decimal? Rate { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public string Privilege { get; set; }

        public int? TierID { get; set; }

        public int? ConTypeID { get; set; }

        public string CGrpID { get; set; }

        public int? CusTypeID { get; set; }

        public int? CreditTermID { get; set; }

        public decimal? CreditLimit { get; set; }

        public DateTime? DateApproved { get; set; }

        public byte? Blocked { get; set; }

        public int? InterestID { get; set; }

        public DateTime? DateBlocked { get; set; }

        public string Reasons { get; set; }

        public string lblUDF1 { get; set; }

        public string lblUDF2 { get; set; }

        public string lblUDF3 { get; set; }

        public string lblUDF4 { get; set; }

        public string lblUDF5 { get; set; }

        public string Udf1 { get; set; }

        public string Udf2 { get; set; }

        public string Udf3 { get; set; }

        public string Udf4 { get; set; }

        public string Udf5 { get; set; }

        public string Notes { get; set; }

        public byte? Internal { get; set; }

        public string PaymentTerm { get; set; }

        public string GeneralTerm { get; set; }

        public long? AccountID { get; set; }

        public long? ModifiedByID { get; set; }

        public DateTime DateModified { get; set; }

        public long? CreatedByID { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
