namespace BlazeAstro.Services.Models.Astronauts
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class AstronautsResponseModel
    {
        [JsonPropertyName("people")]
        public IEnumerable<AstronautResponseModel> Astronauts { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }
    }
}