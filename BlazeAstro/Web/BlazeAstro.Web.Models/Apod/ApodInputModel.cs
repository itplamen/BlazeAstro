namespace BlazeAstro.Web.Models.Apod
{
    using System;

    public class ApodInputModel
    {
        public DateTime Date { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public bool Thumbs { get; set; }

        public int Count { get; set; }
    }
}