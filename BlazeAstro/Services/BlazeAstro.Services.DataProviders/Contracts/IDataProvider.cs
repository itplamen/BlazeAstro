namespace BlazeAstro.Services.DataProviders.Contracts
{
    using System.Threading.Tasks;

    public interface IDataProvider<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        Task<TResponse> GetData(TRequest request);
    }

    public interface IDataProvider<TResponse>
        where TResponse : class
    {
        Task<TResponse> GetData();
    }
}