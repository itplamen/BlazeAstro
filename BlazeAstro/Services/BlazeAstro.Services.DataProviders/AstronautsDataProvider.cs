namespace BlazeAstro.Services.DataProviders
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Astronauts;

    public class AstronautsDataProvider : IDataProvider<AstronautsRequestModel, AstronautsResponseModel>
    {
        private readonly HttpClient httpClient;

        public AstronautsDataProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<AstronautsResponseModel> GetData(AstronautsRequestModel request)
        {
            var response = await httpClient.GetAsync(request.Url);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AstronautsResponseModel>(content);

            return result;
        }
    }
}