namespace BlazeAstro.Services.Models.MarsPhotos
{
    using System.Text.Json.Serialization;

    public class CameraResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
    }
}