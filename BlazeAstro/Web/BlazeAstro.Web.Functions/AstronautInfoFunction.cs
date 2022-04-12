namespace BlazeAstro.Web.Functions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Astronauts.AstronautInfo;
    using BlazeAstro.Web.Shared.Models.Astronauts;

    public class AstronautInfoFunction
    {
        private readonly IMapper mapper;
        private readonly IDataProvider<AstronautInfoRequestModel, AstronautInfoResponseModel> astronautInfoDataProvider;

        public AstronautInfoFunction(IMapper mapper, IDataProvider<AstronautInfoRequestModel, AstronautInfoResponseModel> astronautInfoDataProvider)
        {
            this.mapper = mapper;
            this.astronautInfoDataProvider = astronautInfoDataProvider;
        }

        [FunctionName("AstronautInfoFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "astronauts/{name}")] HttpRequest req)
        {
            if (req.Path.HasValue)
            {
                string name = req.Path.Value.Split("/").Last();
                var request = new AstronautInfoRequestModel() { Url = $"{Environment.GetEnvironmentVariable("ASTRONAUTS_INFO", EnvironmentVariableTarget.Process)}/{name}" };

                var response = await astronautInfoDataProvider.GetData(request);
                var output = mapper.Map<AstronautInfoOutputModel>(response);

                return new OkObjectResult(output);
            }
            
            return new BadRequestResult();
        }
    }
}