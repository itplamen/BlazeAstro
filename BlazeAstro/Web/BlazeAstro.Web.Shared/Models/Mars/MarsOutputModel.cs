namespace BlazeAstro.Web.Shared.Models.Mars
{
    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.MarsPhotos;

    public class MarsOutputModel : IMapFrom<MarsPhotosResponseModel>
    {
        public PhotoOutputModel[] Photos { get; set; }
    }
}