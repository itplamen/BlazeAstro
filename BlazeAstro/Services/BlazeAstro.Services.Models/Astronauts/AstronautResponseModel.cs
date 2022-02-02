namespace BlazeAstro.Services.Models.Astronauts
{
    using System;

    using Newtonsoft.Json;

    public class AstronautResponseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("biophoto")]
        public string ImgUrl { get; set; }

        [JsonProperty("biophotowidth")]
        public int ImgWidth { get; set; }

        [JsonProperty("biophotoheight")]
        public int ImgHeight { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryflag")]
        public string CountryFlagUrl { get; set; }

        [JsonProperty("launchdate")]
        public DateTime LaunchDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("bio")]
        public string Biography { get; set; }

        [JsonProperty("biolink")]
        public string Wikipedia { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }
    }
}