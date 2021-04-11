using AMSWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AMSWebAPI.Services
{
    public class SalesService : IDisposable
    {
        private readonly FSXAPIDBContext _context;

        public SalesService(FSXAPIDBContext dbcontext)
        {
            _context = dbcontext;
            dbcontext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Insert/Update Quotation Records
        /// </summary>
        /// <param name="quotation">Quotation model</param>
        /// <returns></returns>
        public async Task<bool> QuotationUpdateAsync(Quotation quotation)
        {
            bool result = true;

            using (_context)
            {
                try
                {
                    var model = await _context.Quotation.FirstOrDefaultAsync(p => p.QuotationNo == quotation.QuotationNo);
                    if (model == null)
                    {
                        _context.Quotation.Add(quotation);
                        _context.QuotationParts.AddRange(quotation.QuotationParts);
                        _context.QuotationServices.AddRange(quotation.QuotationServices);

                    }
                    else
                    {
                        _context.Quotation.Update(quotation);
                        var _partid = string.Join(",", quotation.QuotationParts.Select(c => c.QTPartID).ToArray());
                        var _serveid = string.Join(",", quotation.QuotationServices.Select(c => c.QTServiceID).ToArray());

                        string _script = "delete from quotationparts where " + (quotation.QuotationParts.Count() > 0 ? "QTPartID not in (" + _partid + ") and " : "") + "QuotationNo = '" + quotation.QuotationNo + "' AND SiteCode = '" + quotation.SiteCode + "';";
                        _script += "delete from quotationservices where " + (quotation.QuotationServices.Count() > 0 ? "QTServiceID not in (" + _serveid + ") and " : "") + "QuotationNo = '" + quotation.QuotationNo + "' AND SiteCode = '" + quotation.SiteCode + "';";

                        await _context.Database.ExecuteSqlRawAsync(_script);
                        await _context.QuotationParts.UpsertRange(quotation.QuotationParts).On(a => new { a.QuotationNo, a.QTPartID }).RunAsync();
                        await _context.QuotationServices.UpsertRange(quotation.QuotationServices).On(a => new { a.QuotationNo, a.QTServiceID }).RunAsync();

                    }

                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Insert/Update Work Order Records
        /// </summary>
        /// <param name="wo">Work Order model</param>
        /// <returns></returns>
        public async Task<bool> WorkOrderUpdateAsync(WorkOrder wo)
        {
            bool result = true;

            using (_context)
            {
                try
                {
                    var model = await _context.WorkOrder.FirstOrDefaultAsync(p => p.WONo == wo.WONo);
                    if (model == null)
                    {
                        _context.WorkOrder.Add(wo);
                        _context.WorkOrderParts.AddRange(wo.WorkOrderParts);
                        _context.WorkOrderServices.AddRange(wo.WorkOrderServices);
                        _context.WorkOrderLaborers.AddRange(wo.WorkOrderLaborers);
                        _context.WorkOrderDamagedInfo.AddRange(wo.WorkOrderDamagedInfo);
                        _context.WorkOrderRepairInfo.AddRange(wo.WorkOrderRepairInfo);
                        _context.WorkOrderDamagedParts.AddRange(wo.WorkOrderDamagedParts);
                    }
                    else
                    {
                        _context.WorkOrder.Update(wo);
                        var _partid = string.Join(",", wo.WorkOrderParts.Select(c => c.WOPartID).ToArray());
                        var _serveid = string.Join(",", wo.WorkOrderServices.Select(c => c.WOServiceID).ToArray());
                        var _laborid = string.Join(",", wo.WorkOrderLaborers.Select(c => c.LaborID).ToArray());
                        var _damInfoID = string.Join(",", wo.WorkOrderDamagedInfo.Select(c => c.DamRepID).ToArray());
                        var _damrefID = string.Join(",", wo.WorkOrderRepairInfo.Select(c => c.DamRepID).ToArray());
                        var _dampartsID = string.Join(",", wo.WorkOrderDamagedParts.Select(c => c.PartsHistID).ToArray());

                        string _script = "delete from workorderparts where " + (wo.WorkOrderParts.Count() > 0 ? "WOPartID not in (" + _partid + ") and " : "") + "WONo = '" + wo.WONo + "' AND SiteCode = '" + wo.SiteCode + "';";
                        _script += "delete from workorderservices where " + (wo.WorkOrderServices.Count() > 0 ? "WOServiceID not in (" + _serveid + ") and " : "") + "WONo = '" + wo.WONo + "' AND SiteCode = '" + wo.SiteCode + "';";
                        _script += "delete from workorder_laborer where " + (wo.WorkOrderLaborers.Count() > 0 ? "LaborID not in (" + _laborid + ") and " : "") + "WONo = '" + wo.WONo + "' AND SiteCode = '" + wo.SiteCode + "';";
                        _script += "delete from workorder_damage_info where " + (wo.WorkOrderDamagedInfo.Count() > 0 ? "DamRepID not in (" + _damInfoID + ") and " : "") + "WONo = '" + wo.WONo + "' AND SiteCode = '" + wo.SiteCode + "';";
                        _script += "delete from workorder_repair_info where " + (wo.WorkOrderRepairInfo.Count() > 0 ? "DamRepID not in (" + _damrefID + ") and " : "") + "WONo = '" + wo.WONo + "' AND SiteCode = '" + wo.SiteCode + "';";
                        _script += "delete from workorder_damparts where " + (wo.WorkOrderDamagedParts.Count() > 0 ? "PartsHistID not in (" + _dampartsID + ") and " : "") + "WONo = '" + wo.WONo + "' AND SiteCode = '" + wo.SiteCode + "';";

                        await _context.Database.ExecuteSqlRawAsync(_script);
                        await _context.WorkOrderParts.UpsertRange(wo.WorkOrderParts).On(a => new { a.WONo, a.WOPartID }).RunAsync();
                        await _context.WorkOrderServices.UpsertRange(wo.WorkOrderServices).On(a => new { a.WONo, a.WOServiceID}).RunAsync();
                        await _context.WorkOrderLaborers.UpsertRange(wo.WorkOrderLaborers).On(a => new { a.WONo, a.LaborID}).RunAsync();
                        await _context.WorkOrderDamagedInfo.UpsertRange(wo.WorkOrderDamagedInfo).On(a => new { a.WONo, a.DamRepID}).RunAsync();
                        await _context.WorkOrderRepairInfo.UpsertRange(wo.WorkOrderRepairInfo).On(a => new { a.WONo, a.DamRepID}).RunAsync();
                        await _context.WorkOrderDamagedParts.UpsertRange(wo.WorkOrderDamagedParts).On(a => new { a.WONo, a.PartsHistID}).RunAsync();

                    }

                    //** Insert/Update Department Location
                    try
                    {
                        var deploc = await _context.PicklistDepartmentLocation.FirstOrDefaultAsync(p => p.NodeID == wo.LocID);
                        if (deploc != null)
                        {
                            _context.PicklistDepartmentLocation.Add(wo.PicklistDepartmentLocation);
                        }
                        else
                        {
                            _context.PicklistDepartmentLocation.Update(wo.PicklistDepartmentLocation);
                        }
                    }
                    catch (Exception) { }
                    //** End Here
                    
                    await _context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Insert/Update Work Order Sales Invoice Records
        /// </summary>
        /// <param name="sinvoice">Sales Invoice model</param>
        /// <returns></returns>
        public async Task<bool> SalesInvoiceUpdateAsync(SalesInvoice sinvoice)
        {
            bool result = true;

            using (_context)
            {
                try
                {
                    var model = await _context.SalesInvoice.FirstOrDefaultAsync(p => p.WONo == sinvoice.WONo);
                    if (model == null)
                    {
                        _context.SalesInvoice.Add(sinvoice);
                        _context.SalesInvoiceParts.AddRange(sinvoice.SalesInvoiceParts);
                        _context.SalesInvoiceServices.AddRange(sinvoice.SalesInvoiceServices);
                       
                    }
                    else
                    {
                        _context.SalesInvoice.Update(sinvoice);
                        var _partid = string.Join(",", sinvoice.SalesInvoiceParts.Select(c => c.SDetailID).ToArray());
                        var _serveid = string.Join(",", sinvoice.SalesInvoiceServices.Select(c => c.SDetailID).ToArray());
                       
                        string _script = "delete from salesinvoice_part where " + (sinvoice.SalesInvoiceParts.Count() > 0 ? "SDetailID not in (" + _partid + ") and " : "") + "WONo = '" + sinvoice.WONo + "' AND SiteCode = '" + sinvoice.SiteCode + "';";
                        _script += "delete from salesinvoice_services where " + (sinvoice.SalesInvoiceServices.Count() > 0 ? "SDetailID not in (" + _serveid + ") and " : "") + "WONo = '" + sinvoice.WONo + "' AND SiteCode = '" + sinvoice.SiteCode + "';";
                       
                        await _context.Database.ExecuteSqlRawAsync(_script);
                        await _context.SalesInvoiceParts.UpsertRange(sinvoice.SalesInvoiceParts).On(a => new { a.WONo, a.SDetailID }).RunAsync();
                        await _context.SalesInvoiceServices.UpsertRange(sinvoice.SalesInvoiceServices).On(a => new { a.WONo, a.SDetailID }).RunAsync();
                        
                    }

                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Dispose 
        /// </summary>
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
