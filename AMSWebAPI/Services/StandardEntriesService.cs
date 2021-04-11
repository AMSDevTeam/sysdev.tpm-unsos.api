using AMSWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AMSWebAPI.Services
{
    public class StandardEntriesService : IDisposable
    {
        private readonly FSXAPIDBContext _context;
    
        public StandardEntriesService(FSXAPIDBContext dbcontext)
        {
            _context = dbcontext;
            dbcontext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }      

        /// <summary>
        /// Insert/Update Assigned Unit Picklist 
        /// </summary>
        /// <param name="db">DB Context</param>
        /// <param name="se">Picklist Assigned Unit Model</param>
        /// <returns></returns>
        public async Task<bool> AssignedUnitUpdateAsync(PicklistAssignedUnit se)
        {
            bool result = true;

            using (_context)
            {
                try
                {
                    var model = await _context.PicklistAssignedUnit.FirstOrDefaultAsync(p => p.UnitID == se.UnitID);                   

                    if (model == null)
                    {
                        _context.PicklistAssignedUnit.Add(se);                       
                    }
                    else
                    {               
                        _context.PicklistAssignedUnit.Update(se);                       
                    }

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
        /// Insert/ Update Colors Picklist
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> ColorsUpdateAsync(PicklistColors se)
        {
            bool result = true;

            using (_context)
            {
                try
                {
                    var model = await _context.PicklistColors.FirstOrDefaultAsync(p => p.ColorID == se.ColorID);
                    if (model == null)
                    {
                        _context.PicklistColors.Add(se);
                    }
                    else
                    {                
                        _context.PicklistColors.Update(se);
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
        /// Insert/Update Department and Location Picklist
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> DepartmentLocationUpdateAsync(PicklistDepartmentLocation se)
        {
            bool result = true;

            using (_context)
            {
                try
                {
                    var model = await _context.PicklistDepartmentLocation.FirstOrDefaultAsync(p => p.NodeID == se.NodeID && p.SiteCode == se.SiteCode);
                    if (model == null)
                    {
                        _context.PicklistDepartmentLocation.Add(se);
                    }
                    else
                    {
                        _context.PicklistDepartmentLocation.Update(se);
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
        /// Insert/Update Equipment Category Picklist 
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> EquipmentCategoryUpdateAsync(PicklistEquipmentCategory se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.PicklistEquipmentCategory.FirstOrDefaultAsync(p => p.VehClassID == se.VehClassID);
                    if (model == null)
                    {
                        _context.PicklistEquipmentCategory.Add(se);
                    }
                    else
                    {
                        _context.PicklistEquipmentCategory.Update(se);
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
        /// Insert/Update Equipment Type Picklist
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> EquipmentTypeUpdateAsync( PicklistEquipmentType se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.PicklistEquipmentType.FirstOrDefaultAsync(p => p.VehTypeID == se.VehTypeID);
                    if (model == null)
                    {
                        _context.PicklistEquipmentType.Add(se);
                    }
                    else
                    {
                        _context.PicklistEquipmentType.Update(se);
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
        /// Insert/Update Equipment Type Make Picklist
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> EquipmentTypeMakeUpdateAsync( PicklistEquipmentTypeMake se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.PicklistEquipmentTypeMake.FirstOrDefaultAsync(p => p.VTModelID == se.VTModelID);
                    if (model == null)
                    {
                        _context.PicklistEquipmentTypeMake.Add(se);
                    }
                    else
                    {
                        _context.PicklistEquipmentTypeMake.Update(se);
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
        /// Insert/Update Non Vehicle Type Picklist
        /// </summary>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> NonVehicleTypeUpdateAsync(PicklistNonVehicleType se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.PicklistNonVehicleType.FirstOrDefaultAsync(p => p.NonVehTypeID == se.NonVehTypeID);
                    if (model == null)
                    {
                        _context.PicklistNonVehicleType.Add(se);
                    }
                    else
                    {
                        _context.PicklistNonVehicleType.Update(se);
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
        /// Insert/Update Non Vehicle Type Make Picklist
        /// </summary>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> NonVehicleTypeMakeUpdateAsync(PicklistNonVehicleTypeMake se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.PicklistNonVehicleTypeMake.FirstOrDefaultAsync(p => p.NVTModelID == se.NVTModelID);
                    if (model == null)
                    {
                        _context.PicklistNonVehicleTypeMake.Add(se);
                    }
                    else
                    {
                        _context.PicklistNonVehicleTypeMake.Update(se);
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
        /// Insert/Update Regiosn Picklist 
        /// </summary>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> RegionsUpdateAsync(PicklistRegions se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.PicklistRegions.FirstOrDefaultAsync(p => p.RegID == se.RegID);
                    if (model == null)
                    {
                        _context.PicklistRegions.Add(se);
                    }
                    else
                    {
                        _context.PicklistRegions.Update(se);
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
        /// Insert/Update Parts Department Picklist
        /// </summary>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> PartsDepartmentUpdateAsync(PicklistPartsDepartment se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.PicklistPartsDepartment.FirstOrDefaultAsync(p => p.PartsDeptID == se.PartsDeptID);
                    if (model == null)
                    {
                        _context.PicklistPartsDepartment.Add(se);
                    }
                    else
                    {
                        _context.PicklistPartsDepartment.Update(se);
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
        /// Insert/Update Parts Category Picklist
        /// </summary>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> PartsCategoryUpdateAsync(PicklistPartsCategory se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.PicklistPartsCategory.FirstOrDefaultAsync(p => p.PCatID == se.PCatID);
                    if (model == null)
                    {
                        _context.PicklistPartsCategory.Add(se);
                    }
                    else
                    {
                        _context.PicklistPartsCategory.Update(se);
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
        /// Insert/Update Makes Picklist
        /// </summary>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> MakesUpdateAsync(PicklistMakes se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.PicklistMakes.FirstOrDefaultAsync(p => p.MakeID == se.MakeID);
                    if (model == null)
                    {
                        _context.PicklistMakes.Add(se);
                    }
                    else
                    {
                        _context.PicklistMakes.Update(se);
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
        /// Insert/Update Models Picklist
        /// </summary>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> ModelsUpdateAsync(PicklistModels se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.PicklistModels.FirstOrDefaultAsync(p => p.ModelID == se.ModelID);
                    if (model == null)
                    {
                        _context.PicklistModels.Add(se);
                    }
                    else
                    {
                        _context.PicklistModels.Update(se);
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
        /// Insert/Update Series Picklist
        /// </summary>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> SeriesUpdateAsync(PicklistSeries se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.PicklistSeries.FirstOrDefaultAsync(p => p.SeriesID == se.SeriesID);
                    if (model == null)
                    {
                        _context.PicklistSeries.Add(se);
                    }
                    else
                    {
                        _context.PicklistSeries.Update(se);
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
        /// Insert/Update Customer Information
        /// </summary>
        /// <param name="se"></param>
        /// <returns></returns>
        public async Task<bool> CustomersUpdateAsync(Customers se)
        {
            bool result = true;
            using (_context)
            {
                try
                {
                    var model = await _context.Customers.FirstOrDefaultAsync(p => p.CusRefCode == se.CusRefCode);
                    if (model == null)
                    {
                        _context.Customers.Add(se);
                    }
                    else
                    {
                        _context.Customers.Update(se);
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
