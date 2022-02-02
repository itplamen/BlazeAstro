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
        private readonly IDataProvider<AstronautsRequestModel, AstronautsResponseModel> dataProvider;

        public AstronautsController(IMapper mapper, IDataProvider<AstronautsRequestModel, AstronautsResponseModel> dataProvider)
        {
            this.mapper = mapper;
            this.dataProvider = dataProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AstronautsOutputModel>>> Get()
        {
            var response = await dataProvider.GetData(new AstronautsRequestModel());
            var output = mapper.Map<AstronautsOutputModel>(response);

            return Ok(output);
        }
    }
}