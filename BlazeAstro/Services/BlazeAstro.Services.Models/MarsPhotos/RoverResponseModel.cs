namespace BlazeAstro.Services.Models.MarsPhotos
{
    using System;

    using Newtonsoft.Json;

    public class RoverResponseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public RoverName Name { get; set; }

        [JsonProperty("launch_date")]
        public DateTime LaunchDate { get; set; }

        [JsonProperty("landing_date")]
        public DateTime LandingDate { get; set; }
    }
}