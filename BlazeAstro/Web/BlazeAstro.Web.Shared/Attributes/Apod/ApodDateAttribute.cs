namespace BlazeAstro.Web.Shared.Attributes.Apod
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    public class ApodDateAttribute : RangeAttribute
    {
        private const string MIN_RANGE = "1995-06-16";

        public ApodDateAttribute()
            : base(typeof(DateTime), MIN_RANGE, DateTime.Now.ToString("yyyy-MM-dd"))
        {
        }

        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;

            return date == default(DateTime) ||
                (date >= new DateTime(1995, 6, 16) && date <= DateTime.Now.Date);
        }
    }
}