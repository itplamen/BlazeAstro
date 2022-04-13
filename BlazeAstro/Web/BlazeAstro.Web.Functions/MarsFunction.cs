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
    using BlazeAstro.Services.Models.MarsPhotos;
    using BlazeAstro.Web.Shared.Models.Mars;
    using Rover = BlazeAstro.Web.Shared.Models.Mars;

    public class MarsFunction
    {
        private readonly IMapper mapper;
        private readonly IDataProvider<MarsPhotosRequestModel, MarsPhotosResponseModel> dataProvider;

        public MarsFunction(IMapper mapper, IDataProvider<MarsPhotosRequestModel, MarsPhotosResponseModel> dataProvider)
        {
            this.mapper = mapper;
            this.dataProvider = dataProvider;
        }

        [FunctionName("MarsFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "mars")] HttpRequest req)
        {
            var input = new MarsInputModel();
            input.EarthDate = req.Query.ContainsKey(nameof(input.EarthDate)) ? DateTime.Parse(req.Query[nameof(input.EarthDate)]) : default(DateTime);
            input.Sol = req.Query.ContainsKey(nameof(input.Sol)) ? int.Parse(req.Query[nameof(input.Sol)]) : 0;
            input.RoverName = req.Query.ContainsKey(nameof(input.RoverName)) ? (Rover.RoverName)Enum.Parse(typeof(Rover.RoverName), req.Query["RoverName"]) : Rover.RoverName.Perseverance;

            var request = mapper.Map<MarsPhotosRequestModel>(input);
            request.ApiKey = Environment.GetEnvironmentVariable("NASA_API_KEY", EnvironmentVariableTarget.Process);
            request.Url = Environment.GetEnvironmentVariable("MARS_URL", EnvironmentVariableTarget.Process);

            var response = await dataProvider.GetData(request);
            var output = mapper.Map<MarsOutputModel>(response);

            return new OkObjectResult(output);
        }
    }
}