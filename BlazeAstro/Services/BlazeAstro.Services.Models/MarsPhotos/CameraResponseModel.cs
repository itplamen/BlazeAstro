namespace BlazeAstro.Services.Models.MarsPhotos
{
    using Newtonsoft.Json;

    public class CameraResponseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }
    }
}