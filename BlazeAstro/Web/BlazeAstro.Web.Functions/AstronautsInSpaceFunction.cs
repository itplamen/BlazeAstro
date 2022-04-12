namespace BlazeAstro.Web.Functions
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Astronauts.AstronautsInSpace;
    using BlazeAstro.Web.Shared.Models.Astronauts;

    public class AstronautsInSpaceFunction
    {
        private readonly IMapper mapper;
        private readonly IDataProvider<AstronautsRequestModel, AstronautsResponseModel> astronautsDataProvider;

        public AstronautsInSpaceFunction(IMapper mapper, IDataProvider<AstronautsRequestModel, AstronautsResponseModel> astronautsDataProvider)
        {
            this.mapper = mapper;
            this.astronautsDataProvider = astronautsDataProvider;
        }

        [FunctionName("AstronautsInSpaceFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "astronauts")] HttpRequest req)
        {
            var request = new AstronautsRequestModel() { Url = Environment.GetEnvironmentVariable("ASTRONAUTS_IN_SPACE", EnvironmentVariableTarget.Process) };

            var response = await astronautsDataProvider.GetData(request);
            var output = mapper.Map<AstronautsOutputModel>(response);

            return new OkObjectResult(output);
        }
    }
}