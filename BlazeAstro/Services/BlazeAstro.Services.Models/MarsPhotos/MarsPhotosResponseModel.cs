namespace BlazeAstro.Services.Models.MarsPhotos
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class MarsPhotosResponseModel
    {
        [JsonProperty("photos")]
        public IEnumerable<PhotoResponseModel> Photos { get; set; }
    }
}