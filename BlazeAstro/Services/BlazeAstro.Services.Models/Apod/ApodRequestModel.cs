namespace BlazeAstro.Services.Models.Apod
{
    using System;
    using System.Text.Json.Serialization;

    public class ApodRequestModel
    {
        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("thumbs")]
        public bool Thumbs { get; set; }
    }
}