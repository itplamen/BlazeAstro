namespace BlazeAstro.Services.Models.MarsPhotos
{
    using System.Runtime.Serialization;

    public enum RoverName
    {
        [EnumMember(Value = "Spirit")]
        Spirit,

        [EnumMember(Value = "Curiosity")]
        Curiosity,

        [EnumMember(Value = "Opportunity")]
        Opportunity
    }
}