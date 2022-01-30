namespace BlazeAstro.Services.Models.Apod
{
    using System.Text.Json.Serialization;

    public class ApodRequestModel
    {
        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public string EndDate { get; set; }

        [JsonPropertyName("thumbs")]
        public bool Thumbs { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}