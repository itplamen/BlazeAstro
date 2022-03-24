namespace BlazeAstro.Web.Client.Infrastructure
{
    using System.Net.Http.Json;

    using Microsoft.JSInterop;

    using BlazeAstro.Web.Shared.Models.Api;

    public class ApiClient : IApiClient
    {
        private readonly IJSRuntime jsRuntime;
        private readonly HttpClient httpClient;

        public ApiClient(IJSRuntime jsRuntime, HttpClient httpClient)
        {
            this.jsRuntime = jsRuntime;
            this.httpClient = httpClient;
        }

        public async Task<ApiResponse<TOutput>>Get<TOutput>(string url)
            where TOutput : class
        {
            try
            {
                await jsRuntime.InvokeVoidAsync("showLoader");

                var output = await httpClient.GetFromJsonAsync<TOutput>(url);
                var response = new ApiResponse<TOutput>() { Data = output };

                await jsRuntime.InvokeVoidAsync("hideLoader");

                return response;
            }
            catch (Exception ex)
            {
                await jsRuntime.InvokeVoidAsync("hideLoader");

                return new ApiResponse<TOutput>() { ErrorMessage = "Could not retrieve data. Please try again" };
            }
        }
    }
}