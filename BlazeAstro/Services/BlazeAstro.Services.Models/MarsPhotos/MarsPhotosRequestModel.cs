namespace BlazeAstro.Services.Models.MarsPhotos
{
    using Newtonsoft.Json;

    using BlazeAstro.Services.Models.Contracts;

    public class MarsPhotosRequestModel : IRequest
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("earth_date")]
        public string EarthDate { get; set; }

        [JsonProperty("sol")]
        public int Sol { get; set; }

        public RoverName RoverName { get; set; }

        public string Url { get; set; }

        public string CacheKey => (15 * ApiKey.GetHashCode() ^ Url.GetHashCode() ^ EarthDate?.GetHashCode() ?? 0 
            ^ Sol.GetHashCode() ^ RoverName.ToString().GetHashCode()).ToString();
    }
}