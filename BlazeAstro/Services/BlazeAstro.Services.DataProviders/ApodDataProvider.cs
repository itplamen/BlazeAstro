namespace BlazeAstro.Services.DataProviders
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.WebUtilities;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.DataProviders.Utilities;
    using BlazeAstro.Services.Models.Apod;

    public class ApodDataProvider : IDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>>
    {
        private readonly HttpClient httpClient;

        public ApodDataProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ApodResponseModel>> GetData(ApodRequestModel request)
        {
            var queryString = QueryStringBuilder.Build(request);
            string url = QueryHelpers.AddQueryString(request.Url, queryString);

            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var token = JToken.Parse(content);

            if (token is JArray)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ApodResponseModel>>(content);
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ApodResponseModel>(content);

                return new List<ApodResponseModel>() { result };
            }
        }
    }
}