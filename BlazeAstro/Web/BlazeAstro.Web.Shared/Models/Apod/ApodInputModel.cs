namespace BlazeAstro.Web.Shared.Models.Apod
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.Apod;
    using BlazeAstro.Web.Shared.Attributes.Apod;

    [ApodInput]
    public class ApodInputModel : IMapTo<ApodRequestModel>, ICustomMapping
    { 
        [ApodDate]
        public DateTime Date { get; set; }

        [ApodDate]
        public DateTime StartDate { get; set; }

        [ApodDate]
        public DateTime EndDate { get; set; }

        [Range(0, 100)]
        public int Count { get; set; }

        public bool Thumbs { get; set; }

        public void CreateMappings(Profile mapper)
        {
            mapper.CreateMap<ApodInputModel, ApodRequestModel>()
                .ForMember(dest => dest.Date, opt =>
                {
                    opt.PreCondition(src => src.Date != default(DateTime));
                    opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd"));
                })
                .ForMember(dest => dest.StartDate, opt =>
                {
                    opt.PreCondition(src => src.StartDate != default(DateTime));
                    opt.MapFrom(src => src.StartDate.ToString("yyyy-MM-dd"));
                })
                .ForMember(dest => dest.EndDate, opt =>
                {
                    opt.PreCondition(src => src.EndDate != default(DateTime));
                    opt.MapFrom(src => src.EndDate.ToString("yyyy-MM-dd"));
                });
        }
    }
}