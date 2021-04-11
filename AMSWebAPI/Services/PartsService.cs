using AMSWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AMSWebAPI.Services
{
    public class PartsService : IDisposable
    {
        private readonly FSXAPIDBContext _context;

        public PartsService(FSXAPIDBContext dbcontext)
        {
            _context = dbcontext;
            dbcontext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Insert Update Parts Inventory
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>
        public async Task<bool> PartsInventoryUpdateAsync(Parts parts)
        {
            bool result = true;

            using (_context)
            {
                try
                {
                    var model = await _context.Parts.FirstOrDefaultAsync(p => p.PartID == parts.PartID && p.SiteCode == parts.SiteCode);
                    if (model == null)
                    {
                        _context.Parts.Add(parts);                       

                    }
                    else
                    {
                        _context.Parts.Update(parts);   
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
