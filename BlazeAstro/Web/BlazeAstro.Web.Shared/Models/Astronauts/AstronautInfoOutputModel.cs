namespace BlazeAstro.Web.Shared.Models.Astronauts
{
    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.Astronauts.AstronautInfo;

    public class AstronautInfoOutputModel : IMapFrom<AstronautInfoResponseModel>
    {
        public string ImgUrl { get; set; }

        public string DateOfBirth { get; set; }

        public string AstronautInfo { get; set; }

        public string SpaceAgencyName { get; set; }

        public string SpaceAgencyInfo { get; set; }
    }
}