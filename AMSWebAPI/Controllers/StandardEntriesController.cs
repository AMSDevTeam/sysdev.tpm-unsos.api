using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AMSWebAPI.Models;
using AMSWebAPI.Services;
using AMSWebAPI.Shared;
using System.Net;

namespace AMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardEntriesController : ControllerBase
    {
        private readonly StandardEntriesService _service;

        public StandardEntriesController(FSXAPIDBContext context)
        {
            _service = new StandardEntriesService(context);
        }              

        // POST: api/StandardEntries       
        [HttpPost]
        [Route(Constant.picklist_assigned_unit)]
        public async Task<ActionResult<PicklistAssignedUnit>> PostAssignedUnit([FromBody]SimpleModel list)
        {
            PicklistAssignedUnit model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistAssignedUnit>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.AssignedUnitUpdateAsync(model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_colors)]
        public async Task<ActionResult<PicklistColors>> PostColors([FromBody]SimpleModel list)
        {
            PicklistColors model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistColors>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.ColorsUpdateAsync( model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_department_location)]
        public async Task<ActionResult<PicklistDepartmentLocation>> PostDepartmentLocation([FromBody]SimpleModel list)
        {
            PicklistDepartmentLocation model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistDepartmentLocation>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.DepartmentLocationUpdateAsync( model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_equipment_category)]
        public async Task<ActionResult<PicklistEquipmentCategory>> PostEquipmentCategory([FromBody]SimpleModel list)
        {
            PicklistEquipmentCategory model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistEquipmentCategory>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.EquipmentCategoryUpdateAsync( model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_equipment_type)]
        public async Task<ActionResult<PicklistEquipmentType>> PostEquipmentType([FromBody]SimpleModel list)
        {
            PicklistEquipmentType model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistEquipmentType>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.EquipmentTypeUpdateAsync( model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_equipment_type_make)]
        public async Task<ActionResult<PicklistEquipmentTypeMake>> PostEquipmentTypeMake([FromBody]SimpleModel list)
        {
            PicklistEquipmentTypeMake model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistEquipmentTypeMake>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.EquipmentTypeMakeUpdateAsync( model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_nonvehicle_type)]
        public async Task<ActionResult<PicklistNonVehicleType>> PostNonVehicleType([FromBody]SimpleModel list)
        {
            PicklistNonVehicleType model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistNonVehicleType>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.NonVehicleTypeUpdateAsync(model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_nonvehicle_type_make)]
        public async Task<ActionResult<PicklistNonVehicleTypeMake>> PostNonVehicleTypeMake([FromBody]SimpleModel list)
        {
            PicklistNonVehicleTypeMake model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistNonVehicleTypeMake>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.NonVehicleTypeMakeUpdateAsync(model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_regions)]
        public async Task<ActionResult<PicklistRegions>> PostRegions([FromBody]SimpleModel list)
        {
            PicklistRegions model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistRegions>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.RegionsUpdateAsync(model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_parts_department)]
        public async Task<ActionResult<PicklistPartsDepartment>> PostPartsDepartment([FromBody]SimpleModel list)
        {
            PicklistPartsDepartment model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistPartsDepartment>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.PartsDepartmentUpdateAsync(model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_parts_category)]
        public async Task<ActionResult<PicklistPartsCategory>> PostPartsCategory([FromBody]SimpleModel list)
        {
            PicklistPartsCategory model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistPartsCategory>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.PartsCategoryUpdateAsync(model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_makes)]
        public async Task<ActionResult<PicklistMakes>> PostMakes([FromBody]SimpleModel list)
        {
            PicklistMakes model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistMakes>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.MakesUpdateAsync(model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_models)]
        public async Task<ActionResult<PicklistModels>> PostModels([FromBody]SimpleModel list)
        {
            PicklistModels model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistModels>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.ModelsUpdateAsync(model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_series)]
        public async Task<ActionResult<PicklistSeries>> PostSeries([FromBody]SimpleModel list)
        {
            PicklistSeries model = Newtonsoft.Json.JsonConvert.DeserializeObject<PicklistSeries>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.SeriesUpdateAsync(model));
            _service.Dispose();
            return response;
        }

        // POST: api/StandardEntries      
        [HttpPost]
        [Route(Constant.picklist_series)]
        public async Task<ActionResult<Customers>> PostCustomers([FromBody]SimpleModel list)
        {
            Customers model = Newtonsoft.Json.JsonConvert.DeserializeObject<Customers>(list.Name);
            var response = this.StatusCode((int)HttpStatusCode.OK, await _service.CustomersUpdateAsync(model));
            _service.Dispose();
            return response;
        }

    }
}
