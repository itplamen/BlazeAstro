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
        private readonly IConfiguration configuration;
        private readonly IDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>> dataProvider;

        public ApodController(IMapper mapper, IConfiguration configuration, IDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>> dataProvider)
        {
            this.mapper = mapper;
            this.configuration = configuration;
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
            request.ApiKey = configuration["API:NASA:Key"];
            request.Url = configuration["API:NASA:ApodUrl"];

            var response = await dataProvider.GetData(request);
            var output = mapper.Map<IEnumerable<ApodOutputModel>>(response);

            return Ok(output);
        }
    }
}