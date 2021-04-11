using AMSWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AMSWebAPI.Services
{
    public class FleetService : IDisposable
    {
        private readonly FSXAPIDBContext _context;

        public FleetService(FSXAPIDBContext dbcontext)
        {
            _context = dbcontext;
            dbcontext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }       

        /// <summary>
        /// Insert Update Fleet Information
        /// </summary>
        /// <param name="fleet"></param>
        /// <returns></returns>
        public async Task<bool> FleetUpdateAsync(Fleet fleet)
        {
            bool result = true;

            using (_context)
            {
                try
                {
                    var model = await _context.Fleet.FirstOrDefaultAsync(p => p.NLID == fleet.NLID);                   
                    if (model == null)
                    {
                        _context.Fleet.Add(fleet);
                        _context.FleetEngineHistory.AddRange(fleet.FleetEngineHistory);                      
                    }
                    else
                    {
                        _context.Fleet.Update(fleet);
                        var _ferids = string.Join(",", fleet.FleetEngineHistory.Select(c => c.erid).ToArray());                 

                        string _script = "delete from [dbo].[fleet_enghistory] where " + (fleet.FleetEngineHistory.Count() > 0 ? "erid not in (" + _ferids + ") and " : "") + "SiteCode = '" + fleet.SiteCode + "';";

                        await _context.Database.ExecuteSqlRawAsync(_script);
                        await _context.FleetEngineHistory.UpsertRange(fleet.FleetEngineHistory).On(a => new { a.erid, a.SiteCode }).RunAsync();
             
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
