namespace BlazeAstro.Services.Models.MarsPhotos
{
    using System;
    using System.Text.Json.Serialization;

    public class MarsPhotosRequestModel
    {
        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; }

        [JsonPropertyName("earth_date")]
        public DateTime EarthDate { get; set; }

        [JsonPropertyName("sol")]
        public int Sol { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        public RoverName RoverName { get; set; }
    }
}