namespace BlazeAstro.Services.Models.Astros
{
    using System.Text.Json.Serialization;

    public class AstronautResponseModel
    {
        [JsonPropertyName("craft")]
        public string Craft { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}