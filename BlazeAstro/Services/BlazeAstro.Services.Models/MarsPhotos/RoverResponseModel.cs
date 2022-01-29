namespace BlazeAstro.Services.Models.MarsPhotos
{
    using System;
    using System.Text.Json.Serialization;

    public class RoverResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public RoverName Name { get; set; }

        [JsonPropertyName("launch_date")]
        public DateTime LaunchDate { get; set; }

        [JsonPropertyName("landing_date")]
        public DateTime LandingDate { get; set; }
    }
}