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
    public class SalesController : ControllerBase
    {
        private readonly SalesService _service;
        public SalesController(FSXAPIDBContext context)
        {
            _service = new SalesService (context);
        }

        // POST: api/Sales       
        [HttpPost]
        [Route(Constant.quotation)]
        public async Task<ActionResult<Quotation>> PostQuotation([FromBody]SimpleModel list)
        {
            Quotation model = Newtonsoft.Json.JsonConvert.DeserializeObject<Quotation>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.QuotationUpdateAsync(model));
            _service.Dispose();
            return response;
        }

        // POST: api/Sales       
        [HttpPost]
        [Route(Constant.workorder)]
        public async Task<ActionResult<WorkOrder>> PostWorkOrder([FromBody]SimpleModel list)
        {
            WorkOrder model = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkOrder>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.WorkOrderUpdateAsync(model));
            _service.Dispose();
            return response;
        }


        // POST: api/Sales       
        [HttpPost]
        [Route(Constant.sales_invoice)]
        public async Task<ActionResult<SalesInvoice>> PostSalesInvoice([FromBody]SimpleModel list)
        {
            SalesInvoice model = Newtonsoft.Json.JsonConvert.DeserializeObject<SalesInvoice>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.SalesInvoiceUpdateAsync(model));
            _service.Dispose();
            return response;
        }
    }
}
