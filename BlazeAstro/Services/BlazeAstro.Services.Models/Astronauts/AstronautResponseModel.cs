namespace BlazeAstro.Services.Models.Astronauts
{
    using System;
    using System.Text.Json.Serialization;

    public class AstronautResponseModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("biophoto")]
        public string ImgUrl { get; set; }

        [JsonPropertyName("biophotowidth")]
        public int ImgWidth { get; set; }

        [JsonPropertyName("biophotoheight")]
        public int ImgHeight { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("countryflag")]
        public string CountryFlagUrl { get; set; }

        [JsonPropertyName("launchdate")]
        public DateTime LaunchDate { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("bio")]
        public string Biography { get; set; }

        [JsonPropertyName("biolink")]
        public string Wikipedia { get; set; }

        [JsonPropertyName("twitter")]
        public string Twitter { get; set; }
    }
}