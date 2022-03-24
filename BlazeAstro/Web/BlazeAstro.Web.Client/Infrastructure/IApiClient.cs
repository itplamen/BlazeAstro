namespace BlazeAstro.Web.Client.Infrastructure
{
    using BlazeAstro.Web.Shared.Models.Api;

    public interface IApiClient
    {
        Task<ApiResponse<TOutput>> Get<TOutput>(string url)
            where TOutput : class;
    }
}