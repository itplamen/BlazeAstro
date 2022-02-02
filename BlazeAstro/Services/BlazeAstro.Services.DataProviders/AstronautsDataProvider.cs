namespace BlazeAstro.Services.DataProviders
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

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
            var response = await httpClient.GetFromJsonAsync<AstronautsResponseModel>(request.Url);

            return response; ;
        }
    }
}