using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BlazeAstro.Services.Models.Apod
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MediaType
    {
        [EnumMember(Value = "image")]
        Image,

        [EnumMember(Value = "video")]
        Video
    }
}