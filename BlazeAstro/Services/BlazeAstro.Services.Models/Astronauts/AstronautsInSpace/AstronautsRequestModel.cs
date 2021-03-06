namespace BlazeAstro.Services.Models.Astronauts.AstronautsInSpace
{
    using BlazeAstro.Services.Models.Contracts;

    public class AstronautsRequestModel : IRequest
    {
        public string Url { get; set; }

        public string CacheKey => Url.GetHashCode().ToString();
    }
}