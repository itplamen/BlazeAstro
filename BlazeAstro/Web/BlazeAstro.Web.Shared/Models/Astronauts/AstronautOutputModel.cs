namespace BlazeAstro.Web.Shared.Models.Astronauts
{
    using System;

    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.Astronauts;

    public class AstronautOutputModel : IMapFrom<AstronautResponseModel>
    {
        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int ImgWidth { get; set; }

        public int ImgHeight { get; set; }

        public string Country { get; set; }

        public string CountryFlagUrl { get; set; }

        public DateTime LaunchDate { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Biography { get; set; }

        public string Wikipedia { get; set; }

        public string Twitter { get; set; }
    }
}