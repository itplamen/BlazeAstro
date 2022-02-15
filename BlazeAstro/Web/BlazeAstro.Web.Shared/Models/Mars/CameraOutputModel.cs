namespace BlazeAstro.Web.Shared.Models.Mars
{
    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.MarsPhotos;

    public class CameraOutputModel : IMapFrom<CameraResponseModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }
    }
}