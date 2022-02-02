namespace BlazeAstro.Services.Models.Apod
{
    using Newtonsoft.Json;

    using BlazeAstro.Services.Models.Contracts;

    public class ApodRequestModel : IRequest
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("thumbs")]
        public bool Thumbs { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        public string Url { get; set; }

        public string CacheKey => (ApiKey.GetHashCode() ^ Url.GetHashCode() ^ Date?.GetHashCode() ?? 0 ^
            StartDate?.GetHashCode() ?? 0 ^ EndDate?.GetHashCode() ?? 0 ^
            Thumbs.GetHashCode() ^ Count.GetHashCode() * 47).ToString();
    }
}