namespace BlazeAstro.Web.Shared.Models.Apod
{
    using System;

    using BlazeAstro.Infrastructure.Mapping;
    using BlazeAstro.Services.Models.Apod;
    
    public class ApodOutputModel : IMapFrom<ApodResponseModel>
    {
        public string Title { get; set; }

        public string Explanation { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }

        public string Copyright { get; set; }

        public DateTime Date { get; set; }

        public string MediaType { get; set; }
    }
}