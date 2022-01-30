namespace BlazeAstro.Web.Shared.Models.Astronauts
{
    using System.Collections.Generic;

    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.Astronauts;

    public class AstronautsOutputModel : IMapFrom<AstronautsResponseModel>
    {
        public IEnumerable<AstronautOutputModel> Astronauts { get; set; }

        public int Number { get; set; }
    }
}