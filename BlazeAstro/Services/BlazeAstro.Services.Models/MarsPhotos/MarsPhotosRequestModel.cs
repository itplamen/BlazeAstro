namespace BlazeAstro.Services.Models.MarsPhotos
{
    using System;

    using Newtonsoft.Json;

    using BlazeAstro.Services.Models.Contracts;

    public class MarsPhotosRequestModel : IRequest
    {
        public string Url { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("earth_date")]
        public DateTime EarthDate { get; set; }

        [JsonProperty("sol")]
        public int Sol { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        public RoverName RoverName { get; set; }
    }
}