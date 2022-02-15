namespace BlazeAstro.Web.Shared.Models.Mars
{
    using System;

    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.MarsPhotos;

    public class RoverOutputModel : IMapFrom<RoverResponseModel>
    {
        public int Id { get; set; }

        public RoverName Name { get; set; }

        public DateTime LaunchDate { get; set; }

        public DateTime LandingDate { get; set; }
    }
}