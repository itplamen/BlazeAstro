namespace BlazeAstro.Web.Shared.Attributes.Apod
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BlazeAstro.Web.Shared.Constants;

    [AttributeUsage(AttributeTargets.Property)]
    public class ApodDateAttribute : RangeAttribute
    {
        public ApodDateAttribute()
            : base(typeof(DateTime), ApodConstants.MinRange, DateTime.Now.ToString(ApodConstants.DateFormat))
        {
        }

        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;

            return date == default(DateTime) ||
                (date >= ApodConstants.MinDate && date <= DateTime.Now.Date);
        }
    }
}