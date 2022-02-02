namespace BlazeAstro.Services.Models.MarsPhotos
{
    using System;

    using Newtonsoft.Json;

    public class PhotoResponseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("sol")]
        public int Sol { get; set; }

        [JsonProperty("img_src")]
        public string ImgUrl { get; set; }

        [JsonProperty("earth_date")]
        public DateTime EarthDate { get; set; }
    }
}