namespace BlazeAstro.Services.Models.Apod
{
    using System;
    using System.Text.Json.Serialization;

    public class ApodResponseModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("explanation")]
        public string Explanation { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}