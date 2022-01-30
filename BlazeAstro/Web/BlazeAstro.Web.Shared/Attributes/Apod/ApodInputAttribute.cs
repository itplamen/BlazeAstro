namespace BlazeAstro.Web.Shared.Attributes.Apod
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BlazeAstro.Web.Shared.Models.Apod;
    using BlazeAstro.Web.Shared.Validations.Apod;
    
    [AttributeUsage(AttributeTargets.Class)]
    public class ApodInputAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var inputModel = value as ApodInputModel;

            if (inputModel != null)
            {
                var requestValidations = validationContext.GetService(typeof(IEnumerable<IApodRequestValidation>)) as IEnumerable<IApodRequestValidation>;
                foreach (var validation in requestValidations)
                {
                    var result = validation.Validate(inputModel);

                    if (!result.IsSuccess)
                    {
                        return new ValidationResult(result.ErrorMessage);
                    }
                }

                return ValidationResult.Success;
            }

            return base.IsValid(value, validationContext);
        }
    }
}