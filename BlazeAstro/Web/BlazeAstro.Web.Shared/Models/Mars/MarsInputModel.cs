namespace BlazeAstro.Web.Shared.Models.Mars
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    
    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.MarsPhotos;
    using BlazeAstro.Web.Shared.Attributes.Mars;
    using BlazeAstro.Web.Shared.Constants;

    [MarsInput]
    public class MarsInputModel : IMapTo<MarsPhotosRequestModel>, ICustomMapping
    {
        public DateTime EarthDate { get; set; }

        [Range(0, int.MaxValue)]
        public int Sol { get; set; }

        [Required]
        public RoverName RoverName { get; set; }

        public void CreateMappings(Profile mapper)
        {
            mapper.CreateMap<MarsInputModel, MarsPhotosRequestModel>()
                .ForMember(dest => dest.EarthDate, opt =>
                {
                    opt.PreCondition(src => src.EarthDate != default(DateTime));
                    opt.MapFrom(src => src.EarthDate.ToString(MarsConstants.DateFormat));
                }); ;
        }
    }
}
