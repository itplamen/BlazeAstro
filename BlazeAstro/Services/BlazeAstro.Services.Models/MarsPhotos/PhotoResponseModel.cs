namespace BlazeAstro.Services.Models.MarsPhotos
{
    using System;
    using System.Text.Json.Serialization;

    public class PhotoResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sol")]
        public int Sol { get; set; }

        [JsonPropertyName("img_src")]
        public string ImgUrl { get; set; }

        [JsonPropertyName("earth_date")]
        public DateTime EarthDate { get; set; }
    }
}