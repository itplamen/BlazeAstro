namespace BlazeAstro.Web.Api.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Apod;
    using BlazeAstro.Web.Shared.Models.Apod;

    [ApiController]
    [Route("api/[controller]")]
    public class ApodController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>> dataProvider;

        public ApodController(IMapper mapper, IDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>> dataProvider)
        {
            this.mapper = mapper;
            this.dataProvider = dataProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApodOutputModel>>> Get([FromQuery] ApodInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var request = mapper.Map<ApodRequestModel>(input);
            

            var response = await dataProvider.GetData(request);

            var output = mapper.Map<IEnumerable<ApodOutputModel>>(response);

            return Ok(output);
        }
    }
}
