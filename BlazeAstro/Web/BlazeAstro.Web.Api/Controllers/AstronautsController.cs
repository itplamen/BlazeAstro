namespace BlazeAstro.Web.Api.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Astronauts;
    using BlazeAstro.Web.Shared.Models.Astronauts;

    [ApiController]
    [Route("api/[controller]")]
    public class AstronautsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IDataProvider<AstronautsRequestModel, AstronautsResponseModel> dataProvider;

        public AstronautsController(IMapper mapper, IConfiguration configuration, IDataProvider<AstronautsRequestModel, AstronautsResponseModel> dataProvider)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.dataProvider = dataProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AstronautsOutputModel>>> Get()
        {
            var request = new AstronautsRequestModel() { Url = configuration["API:AstronautsInSpace:Url"] };
            
            var response = await dataProvider.GetData(request);
            var output = mapper.Map<AstronautsOutputModel>(response);

            return Ok(output);
        }
    }
}