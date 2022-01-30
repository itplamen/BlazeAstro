namespace BlazeAstro.Services.DataProviders
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Astronauts;

    public class AstronautsDataProvider : IDataProvider<AstronautsResponseModel>
    {
        private const string BASE_URL = "https://www.howmanypeopleareinspacerightnow.com/peopleinspace.json";

        private readonly HttpClient httpClient;

        public AstronautsDataProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<AstronautsResponseModel> GetData()
        {
            var response = await httpClient.GetFromJsonAsync<AstronautsResponseModel>(BASE_URL);

            return response;
        }
    }
}