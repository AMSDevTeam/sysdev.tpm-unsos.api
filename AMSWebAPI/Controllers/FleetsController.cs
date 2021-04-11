using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AMSWebAPI.Models;
using AMSWebAPI.Shared;
using System.Net;
using AMSWebAPI.Services;

namespace AMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetsController : ControllerBase
    {
        private readonly FleetService _service;
        public FleetsController(FSXAPIDBContext context)
        {
            _service = new FleetService(context);
        }


        // POST: api/Fleets
        [HttpPost]
        [Route(Constant.fleet)]
        public async Task<object> PostFleet([FromBody]SimpleModel list)
        {
            Fleet model = Newtonsoft.Json.JsonConvert.DeserializeObject<Fleet>(list.Name);
            var response = this.StatusCode((int)(HttpStatusCode.OK), await _service.FleetUpdateAsync(model));
            _service.Dispose();
            return response;
        }

    }
}
