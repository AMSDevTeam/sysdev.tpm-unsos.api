using AMSWebAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace AMSWebAPI
{
    public class FSXAPIDBContext : DbContext
    {
        public FSXAPIDBContext(DbContextOptions<FSXAPIDBContext> options)
            : base(options) { }

        //** Fleet
        public virtual DbSet<Fleet> Fleet { get; set; }
        public virtual DbSet<FleetEngineHistory> FleetEngineHistory { get; set; }
        public virtual DbSet<FleetFuelMonitoring> FleetFuelMonitoring { get; set; }
        public virtual DbSet<FleetOdometerHistory> FleetOdometerHistory { get; set; }

        //** Parts
        public virtual DbSet<Parts> Parts { get; set; }

        //** Quotation
        public virtual DbSet<Quotation> Quotation { get; set; }
        public virtual DbSet<QuotationParts> QuotationParts { get; set; }
        public virtual DbSet<QuotationServices> QuotationServices { get; set; }

        //** Work Order
        public virtual DbSet<WorkOrder> WorkOrder { get; set; }
        public virtual DbSet<WorkOrderParts> WorkOrderParts { get; set; }
        public virtual DbSet<WorkOrderServices> WorkOrderServices { get; set; }
        public virtual DbSet<WorkOrderLaborers> WorkOrderLaborers { get; set; }
        public virtual DbSet<WorkOrderDamagedInfo> WorkOrderDamagedInfo { get; set; }
        public virtual DbSet<WorkOrderDamagedParts> WorkOrderDamagedParts { get; set; }
        public virtual DbSet<WorkOrderRepairInfo> WorkOrderRepairInfo { get; set; }

        //** Sales Invoice
        public virtual DbSet<SalesInvoice> SalesInvoice { get; set; }
        public virtual DbSet<SalesInvoiceParts> SalesInvoiceParts { get; set; }
        public virtual DbSet<SalesInvoiceServices> SalesInvoiceServices { get; set; }


        //** Standard Entries/ Picklist
        public virtual DbSet<PicklistAssignedUnit> PicklistAssignedUnit { get; set; }     
        public virtual DbSet<PicklistColors> PicklistColors { get; set; }
        public virtual DbSet<EmployeeManagers> EmployeeManagers { get; set; }
        public virtual DbSet<EmployeeOperation> EmployeeOperation { get; set; }
        public virtual DbSet<FASTraxSitesList> FASTraxSitesList { get; set; }
        public virtual DbSet<PicklistMakes> PicklistMakes { get; set; }
        public virtual DbSet<PicklistModels> PicklistModels { get; set; }
        public virtual DbSet<PicklistNonVehicleType> PicklistNonVehicleType { get; set; }
        public virtual DbSet<PicklistNonVehicleTypeMake> PicklistNonVehicleTypeMake { get; set; }
        public virtual DbSet<PicklistPartsCategory> PicklistPartsCategory { get; set; }
        public virtual DbSet<PicklistPartsDepartment> PicklistPartsDepartment { get; set; }
        public virtual DbSet<PicklistRegions> PicklistRegions { get; set; }
        public virtual DbSet<PicklistSCAccountGroup> PicklistSCAccountGroup { get; set; }
        public virtual DbSet<PicklistSeries> PicklistSeries { get; set; }
        public virtual DbSet<PicklistEquipmentCategory> PicklistEquipmentCategory { get; set; }
        public virtual DbSet<PicklistEquipmentType> PicklistEquipmentType { get; set; }
        public virtual DbSet<PicklistEquipmentTypeMake> PicklistEquipmentTypeMake { get; set; }
        public virtual DbSet<PicklistDepartmentLocation> PicklistDepartmentLocation { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string _Model = modelBuilder.GetType().Name;
            //** Parts
            modelBuilder.Entity<Parts>().Property(x => x.Qty).HasColumnType("decimal(20,4)");
            modelBuilder.Entity<Parts>().Property(x => x.BaseUnitCost).HasColumnType("decimal(20,6)");
            modelBuilder.Entity<Parts>().Property(x => x.UnitCost).HasColumnType("decimal(20,6)");
            modelBuilder.Entity<Parts>().Property(x => x.BaseSalesPrice).HasColumnType("decimal(20,4)");
            modelBuilder.Entity<Parts>().Property(x => x.SalesPrice).HasColumnType("decimal(20,4)");
            modelBuilder.Entity<Parts>().Property(x => x.ProfitPercentage).HasColumnType("decimal(20,4)");
            //** End Parts Here

            //** Quotations        
            modelBuilder.Entity<Quotation>().Property(x => x.Gross).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<Quotation>().Property(x => x.GrossUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<Quotation>().Property(x => x.Discount).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<Quotation>().Property(x => x.DiscountUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<Quotation>().Property(x => x.Net).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<Quotation>().Property(x => x.NetUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<Quotation>().Property(x => x.LaborCost).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<Quotation>().Property(x => x.LaborCostUSD).HasColumnType("decimal(38,4)");

            modelBuilder.Entity<QuotationParts>().Property(x => x.CostPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<QuotationParts>().Property(x => x.SalesPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<QuotationParts>().Property(x => x.CostPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<QuotationParts>().Property(x => x.SalesPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<QuotationParts>().Property(x => x.ProfitPercentage).HasColumnType("decimal(10,4)");

            modelBuilder.Entity<QuotationServices>().Property(x => x.Hours).HasColumnType("decimal(10,4)");
            modelBuilder.Entity<QuotationServices>().Property(x => x.CostPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<QuotationServices>().Property(x => x.SalesPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<QuotationServices>().Property(x => x.CostPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<QuotationServices>().Property(x => x.SalesPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<QuotationServices>().Property(x => x.ProfitPercentage).HasColumnType("decimal(10,4)");
            //** End Quotation Here

            //** Work Order
            modelBuilder.Entity<WorkOrder>().Property(x => x.Rate).HasColumnType("decimal(10,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.Gross).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.GrossUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.Discount).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.DiscountUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.Net).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.NetUSD).HasColumnType("decimal(38,4)");

            modelBuilder.Entity<WorkOrder>().Property(x => x.PartsCost).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.PartsCostUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.Total).HasColumnType("decimal(20,4)");

            modelBuilder.Entity<WorkOrder>().Property(x => x.LaborCost).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.LaborCostUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.LaborProfPerc).HasColumnType("decimal(18,4)");

            modelBuilder.Entity<WorkOrder>().Property(x => x.WOGross).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.WOGrossUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.WODiscount).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.WODiscountUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.WONet).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.WONetUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<WorkOrder>().Property(x => x.DiscPerc).HasColumnType("decimal(38,4)");

            modelBuilder.Entity<WorkOrderDamagedParts>().Property(x => x.UnitCost).HasColumnType("decimal(20,2)");

            modelBuilder.Entity<WorkOrderParts>().Property(x => x.CostPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<WorkOrderParts>().Property(x => x.CostPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<WorkOrderParts>().Property(x => x.SalesPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<WorkOrderParts>().Property(x => x.SalesPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<WorkOrderParts>().Property(x => x.ProfitPercentage).HasColumnType("decimal(10,4)");

            modelBuilder.Entity<WorkOrderServices>().Property(x => x.Hours).HasColumnType("decimal(10,4)");
            modelBuilder.Entity<WorkOrderServices>().Property(x => x.CostPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<WorkOrderServices>().Property(x => x.CostPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<WorkOrderServices>().Property(x => x.SalesPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<WorkOrderServices>().Property(x => x.SalesPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<WorkOrderServices>().Property(x => x.ProfitPercentage).HasColumnType("decimal(10,4)");
            //** End Work Order Here

            //** Sales Invoice
            modelBuilder.Entity<SalesInvoice>().Property(x => x.INVRate).HasColumnType("decimal(10,4)");
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalPartsPrice).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalPartsPriceUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalLaborPrice).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalLaborPriceUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalGross).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalGrossUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalDiscount).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalDiscountUSD).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalVAT).HasColumnType("decimal(20,4)");
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalVATUSD).HasColumnType("decimal(20,4)");        
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalNet).HasColumnType("decimal(38,4)");
            modelBuilder.Entity<SalesInvoice>().Property(x => x.TotalNetUSD).HasColumnType("decimal(38,4)");

            modelBuilder.Entity<SalesInvoiceParts>().Property(x => x.CostPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<SalesInvoiceParts>().Property(x => x.CostPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<SalesInvoiceParts>().Property(x => x.SalesPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<SalesInvoiceParts>().Property(x => x.SalesPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<SalesInvoiceParts>().Property(x => x.ProfitPercentage).HasColumnType("decimal(10,4)");

            modelBuilder.Entity<SalesInvoiceServices>().Property(x => x.Hours).HasColumnType("decimal(10,4)");
            modelBuilder.Entity<SalesInvoiceServices>().Property(x => x.CostPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<SalesInvoiceServices>().Property(x => x.CostPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<SalesInvoiceServices>().Property(x => x.SalesPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<SalesInvoiceServices>().Property(x => x.SalesPriceUSD).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<SalesInvoiceServices>().Property(x => x.ProfitPercentage).HasColumnType("decimal(10,4)");
            //** End Sales Invoice Here 

            //** Fleet
            modelBuilder.Entity<Fleet>()
            .HasKey(f => new { f.FleetID,f.NLID });

            modelBuilder.Entity<FleetEngineHistory>()
           .HasKey(f => new { f.erid, f.SiteCode });

            modelBuilder.Entity<FleetFuelMonitoring>()
           .HasKey(f => new { f.FuelID, f.SiteCode });

            modelBuilder.Entity<FleetOdometerHistory>()
           .HasKey(f => new { f.OHID, f.SiteCode });
            //** End Fleet Here

            //**Parts Inventory
            modelBuilder.Entity<Parts>()
           .HasKey(f => new { f.PartID, f.SiteCode });
            //** End Parts Here

            //** Quotations
            modelBuilder.Entity<QuotationParts>()
           .HasKey(f => new { f.QTPartID, f.QuotationNo });

            modelBuilder.Entity<QuotationServices>()
           .HasKey(f => new { f.QTServiceID, f.QuotationNo });
            //** End Quotations Here

            //** Work Order
            modelBuilder.Entity<WorkOrderParts>()
           .HasKey(f => new { f.WOPartID, f.WONo });

            modelBuilder.Entity<WorkOrderServices>()
           .HasKey(f => new { f.WOServiceID, f.WONo });

            modelBuilder.Entity<WorkOrderLaborers>()
           .HasKey(f => new { f.LaborID, f.WONo });

            modelBuilder.Entity<WorkOrderDamagedInfo>()
           .HasKey(f => new { f.DamRepID, f.WONo });

            modelBuilder.Entity<WorkOrderDamagedParts>()
           .HasKey(f => new { f.PartsHistID, f.WONo });

            modelBuilder.Entity<WorkOrderRepairInfo>()
           .HasKey(f => new { f.DamRepID, f.WONo });
            //** End Work Order Here

            //** Sales Invoice 
            modelBuilder.Entity<SalesInvoice>()
           .HasKey(f => new { f.WOInvID, f.WONo });

            modelBuilder.Entity<SalesInvoiceParts>()
           .HasKey(f => new { f.SDetailID, f.WONo });

            modelBuilder.Entity<SalesInvoiceServices>()
           .HasKey(f => new { f.SDetailID, f.WONo });

        }
    }
}
