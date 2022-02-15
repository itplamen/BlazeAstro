namespace BlazeAstro.Services.DataProviders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.WebUtilities;

    using Newtonsoft.Json;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.MarsPhotos;

    public class MarsPhotosDataProvider : IDataProvider<MarsPhotosRequestModel, MarsPhotosResponseModel>
    {
        private readonly HttpClient httpClient;

        public MarsPhotosDataProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<MarsPhotosResponseModel> GetData(MarsPhotosRequestModel request)
        {
            var queryString = new Dictionary<string, string>();
            var properties = request.GetType().GetProperties();

            foreach (var prop in properties)
            {
                if (prop.CustomAttributes.Any())
                {
                    string name = prop.CustomAttributes.First().ConstructorArguments.First().Value?.ToString();
                    string value = prop.GetValue(request)?.ToString();

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                    {
                        if (prop.PropertyType != typeof(int) ||
                            (int.TryParse(value, out int parsed) &&
                            parsed != 0))
                        {
                            queryString.Add(name, value);
                        }
                    }
                }
            }

            string url = QueryHelpers.AddQueryString($"{request.Url}/{request.RoverName}/photos", queryString);
            var response = await httpClient.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MarsPhotosResponseModel>(content);

            return result;
        }
    }
}