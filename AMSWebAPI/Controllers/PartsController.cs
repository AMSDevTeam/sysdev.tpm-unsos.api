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
    public class PartsController : ControllerBase
    {
        private readonly PartsService _service;
        public PartsController(FSXAPIDBContext context)
        {       
            _service = new PartsService(context);
        }

        // POST: api/Parts       
        [HttpPost]
        [Route(Constant.parts_inventory)]
        public async Task<object> PostFleet([FromBody]SimpleModel list)
        {
            Parts model = Newtonsoft.Json.JsonConvert.DeserializeObject<Parts>(list.Name);
            var response = this.StatusCode((int)(HttpStatusCode.OK), await _service.PartsInventoryUpdateAsync(model));
            _service.Dispose();
            return response;
        }

    }
}
