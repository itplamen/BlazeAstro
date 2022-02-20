namespace BlazeAstro.Web.Client.Infrastructure
{
    public interface IApiClient
    {
        Task<TResponse> Get<TResponse>(string url)
            where TResponse : class;
    }
}
