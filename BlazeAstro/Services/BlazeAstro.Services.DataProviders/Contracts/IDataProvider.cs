namespace BlazeAstro.Services.DataProviders.Contracts
{
    using System.Threading.Tasks;

    using BlazeAstro.Services.Models.Contracts;

    public interface IDataProvider<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : class
    {
        Task<TResponse> GetData(TRequest request);
    }
}