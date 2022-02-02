namespace BlazeAstro.Services.Models.Astronauts
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class AstronautsResponseModel
    {
        [JsonProperty("people")]
        public IEnumerable<AstronautResponseModel> Astronauts { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }
    }
}