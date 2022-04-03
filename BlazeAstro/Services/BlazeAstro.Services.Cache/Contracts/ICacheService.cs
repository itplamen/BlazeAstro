namespace BlazeAstro.Services.Cache.Contracts
{
    using System.Threading.Tasks;

    public interface ICacheService<TValue>
        where TValue : class
    {
        Task Set(string key, TValue value);

        Task<TValue> Get(string key);
    }
}