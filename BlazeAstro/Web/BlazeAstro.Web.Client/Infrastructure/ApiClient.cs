namespace BlazeAstro.Web.Client.Infrastructure
{
    using System.Net.Http.Json;

    using Microsoft.JSInterop;

    public class ApiClient : IApiClient
    {
        private readonly IJSRuntime jsRuntime;
        private readonly HttpClient httpClient;

        public ApiClient(IJSRuntime jsRuntime, HttpClient httpClient)
        {
            this.jsRuntime = jsRuntime;
            this.httpClient = httpClient;
        }

        public async Task<TResponse>Get<TResponse>(string url)
            where TResponse : class

        {
            await jsRuntime.InvokeVoidAsync("showLoader");

            var response = await httpClient.GetFromJsonAsync<TResponse>(url);

            await jsRuntime.InvokeVoidAsync("hideLoader");

            return response;
        }
    }
}