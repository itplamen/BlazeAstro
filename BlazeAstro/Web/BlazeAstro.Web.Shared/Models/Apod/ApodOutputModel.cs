namespace BlazeAstro.Web.Shared.Models.Apod
{
    using AutoMapper;

    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.Apod;
    using BlazeAstro.Web.Shared.Constants;

    public class ApodOutputModel : IMapFrom<ApodResponseModel>, ICustomMapping
    {
        public string Title { get; set; }

        public string Explanation { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }

        public string Copyright { get; set; }

        public string Date { get; set; }

        public string MediaType { get; set; }

        public void CreateMappings(Profile mapper)
        {
            mapper.CreateMap<ApodResponseModel, ApodOutputModel>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString(ApodConstants.DateFormat)));
        }
    }
}