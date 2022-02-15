namespace BlazeAstro.Web.Api.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.MarsPhotos;
    using BlazeAstro.Web.Shared.Models.Mars;
    
    [ApiController]
    [Route("api/[controller]")]
    public class MarsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IDataProvider<MarsPhotosRequestModel, MarsPhotosResponseModel> dataProvider;

        public MarsController(IMapper mapper, IConfiguration configuration, IDataProvider<MarsPhotosRequestModel, MarsPhotosResponseModel> dataProvider)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.dataProvider = dataProvider;
        }

        [HttpGet]
        public async Task<ActionResult<MarsOutputModel>> Get([FromQuery] MarsInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var request = mapper.Map<MarsPhotosRequestModel>(input);
            request.ApiKey = configuration["API:NASA:Key"];
            request.Url = configuration["API:NASA:MarsPhotosUrl"];

            var response = await dataProvider.GetData(request);
            var output = mapper.Map<MarsOutputModel>(response);

            return Ok(output);
        }
    }
}
