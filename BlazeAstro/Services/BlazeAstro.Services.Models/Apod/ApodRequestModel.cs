namespace BlazeAstro.Services.Models.Apod
{
    using Newtonsoft.Json;

    using BlazeAstro.Services.Models.Contracts;

    public class ApodRequestModel : IRequest
    {
        public string Url { get; set; }

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
    }
}