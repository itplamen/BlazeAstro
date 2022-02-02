namespace BlazeAstro.Services.Models.Apod
{
    using System.Runtime.Serialization;

    public enum MediaType
    {
        [EnumMember(Value = "image")]
        Image,

        [EnumMember(Value = "video")]
        Video
    }
}