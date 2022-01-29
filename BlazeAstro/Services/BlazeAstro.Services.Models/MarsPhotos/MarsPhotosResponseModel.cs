namespace BlazeAstro.Services.Models.MarsPhotos
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class MarsPhotosResponseModel
    {
        [JsonPropertyName("photos")]
        public IEnumerable<PhotoResponseModel> Photos { get; set; }
    }
}