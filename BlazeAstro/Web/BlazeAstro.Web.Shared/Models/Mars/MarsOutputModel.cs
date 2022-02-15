namespace BlazeAstro.Web.Shared.Models.Mars
{
    using System.Collections.Generic;

    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.MarsPhotos;

    public class MarsOutputModel : IMapFrom<MarsPhotosResponseModel>
    {
        public IEnumerable<PhotoOutputModel> Photos { get; set; }
    }
}