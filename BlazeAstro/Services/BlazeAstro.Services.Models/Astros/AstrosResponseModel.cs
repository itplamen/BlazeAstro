namespace BlazeAstro.Services.Models.Astros
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class AstrosResponseModel
    {
        [JsonPropertyName("people")]
        public IEnumerable<AstronautResponseModel> Astronauts { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }
    }
}