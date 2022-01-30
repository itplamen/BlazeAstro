namespace BlazeAstro.Services.Models.Apod
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MediaType
    {
        [EnumMember(Value = "image")]
        Image,

        [EnumMember(Value = "video")]
        Video
    }
}