namespace BlazeAstro.Web.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Apod;
    using BlazeAstro.Web.Shared.Models.Apod;

    public class ApodFunction
    {
        private readonly IMapper mapper;
        private readonly IDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>> dataProvider;

        public ApodFunction(IMapper mapper, IDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>> dataProvider)
        {
            this.mapper = mapper;
            this.dataProvider = dataProvider;
        }

        [FunctionName("ApodFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "apod")] HttpRequest req)
        {
            var input = new ApodInputModel();
            input.Count = req.Query.ContainsKey(nameof(input.Count)) ? int.Parse(req.Query[nameof(input.Count)]) : 0;
            input.Date = req.Query.ContainsKey(nameof(input.Date)) ? DateTime.Parse(req.Query[nameof(input.Date)]) : default(DateTime);
            input.StartDate = req.Query.ContainsKey(nameof(input.StartDate)) ? DateTime.Parse(req.Query[nameof(input.StartDate)]) : default(DateTime);
            input.EndDate = req.Query.ContainsKey(nameof(input.EndDate)) ? DateTime.Parse(req.Query[nameof(input.EndDate)]) : default(DateTime);
            input.Thumbs = req.Query.ContainsKey(nameof(input.Thumbs)) ? bool.Parse(req.Query[nameof(input.Thumbs)]) : false;

            var request = mapper.Map<ApodRequestModel>(input);
            request.ApiKey = Environment.GetEnvironmentVariable("NASA_API_KEY", EnvironmentVariableTarget.Process);
            request.Url = Environment.GetEnvironmentVariable("APOD_URL", EnvironmentVariableTarget.Process);

            var response = await dataProvider.GetData(request);
            var output = mapper.Map<IEnumerable<ApodOutputModel>>(response);

            return new OkObjectResult(output);
        }
    }
}