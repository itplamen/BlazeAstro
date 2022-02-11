namespace BlazeAstro.Web.Api.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Astronauts.AstronautInfo;
    using BlazeAstro.Services.Models.Astronauts.AstronautsInSpace;
    using BlazeAstro.Web.Shared.Models.Astronauts;

    [ApiController]
    [Route("api/[controller]")]
    public class AstronautsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IDataProvider<AstronautsRequestModel, AstronautsResponseModel> astronautsDataProvider;
        private readonly IDataProvider<AstronautInfoRequestModel, AstronautInfoResponseModel> astronautInfoDataProvider;

        public AstronautsController(
            IMapper mapper, 
            IConfiguration configuration, 
            IDataProvider<AstronautsRequestModel, AstronautsResponseModel> astronautsDataProvider, 
            IDataProvider<AstronautInfoRequestModel, AstronautInfoResponseModel> astronautInfoDataProvider)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.astronautsDataProvider = astronautsDataProvider;
            this.astronautInfoDataProvider = astronautInfoDataProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AstronautsOutputModel>>> Get()
        {
            var request = new AstronautsRequestModel() { Url = configuration["API:Astronauts:InSpace:Url"] };
            
            var response = await astronautsDataProvider.GetData(request);
            var output = mapper.Map<AstronautsOutputModel>(response);

            return Ok(output);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<AstronautInfoOutputModel>> Get(string name)
        {
            var request = new AstronautInfoRequestModel() { Url = $"{configuration["API:Astronauts:Info:Url"]}/{name}" };

            var response = await astronautInfoDataProvider.GetData(request);
            var output = mapper.Map<AstronautInfoOutputModel>(response);

            return Ok(output);
        }
    }
}