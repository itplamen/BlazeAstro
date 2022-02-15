namespace BlazeAstro.Web.Shared.Models.Mars
{
    using AutoMapper;
    
    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.MarsPhotos;
    using BlazeAstro.Web.Shared.Constants;

    public class PhotoOutputModel : IMapFrom<PhotoResponseModel>, ICustomMapping
    {
        public int Id { get; set; }

        public int Sol { get; set; }

        public string ImgUrl { get; set; }

        public string EarthDate { get; set; }

        public CameraOutputModel Camera { get; set; }

        public RoverOutputModel Rover { get; set; }

        public void CreateMappings(Profile mapper)
        {
            mapper.CreateMap<PhotoResponseModel, PhotoOutputModel>()
                .ForMember(dest => dest.EarthDate, opt => opt.MapFrom(src => src.EarthDate.ToString(MarsConstants.DateFormat)));
        }
    }
}