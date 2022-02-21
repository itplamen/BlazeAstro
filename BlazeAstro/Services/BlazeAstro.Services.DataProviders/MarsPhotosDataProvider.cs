namespace BlazeAstro.Services.DataProviders
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.WebUtilities;

    using Newtonsoft.Json;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.MarsPhotos;
    using BlazeAstro.Services.DataProviders.Utilities;

    public class MarsPhotosDataProvider : IDataProvider<MarsPhotosRequestModel, MarsPhotosResponseModel>
    {
        private readonly HttpClient httpClient;

        public MarsPhotosDataProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<MarsPhotosResponseModel> GetData(MarsPhotosRequestModel request)
        {
            var queryString = QueryStringBuilder.Build(request);
            string url = QueryHelpers.AddQueryString($"{request.Url}/{request.RoverName}/photos", queryString);

            var response = await httpClient.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MarsPhotosResponseModel>(content);

            return result;
        }
    }
}