namespace BlazeAstro.Services.Models.Apod
{
    using System;

    using Newtonsoft.Json;

    public class ApodResponseModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("explanation")]
        public string Explanation { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("media_type")]
        public MediaType MediaType { get; set; }
    }
}