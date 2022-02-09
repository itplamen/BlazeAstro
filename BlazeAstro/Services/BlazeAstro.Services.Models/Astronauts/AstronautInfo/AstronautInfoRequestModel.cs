namespace BlazeAstro.Services.Models.Astronauts.AstronautInfo
{
    using BlazeAstro.Services.Models.Contracts;

    public class AstronautInfoRequestModel : IRequest
    {
        public string Url { get; set; }

        public string CacheKey => (Url.GetHashCode() * 13).ToString();
    }
}