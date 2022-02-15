namespace BlazeAstro.Web.Shared.Attributes.Mars
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BlazeAstro.Web.Shared.Models.Mars;
    using BlazeAstro.Web.Shared.Validations.Contracts;

    [AttributeUsage(AttributeTargets.Class)]
    public class MarsInputAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var inputModel = value as MarsInputModel;

            if (inputModel != null)
            {
                var requestValidation = validationContext.GetService(typeof(IRequestValidation<MarsInputModel>)) as IRequestValidation<MarsInputModel>;
                var result = requestValidation.Validate(inputModel);

                if (!result.IsSuccess)
                {
                    return new ValidationResult(result.ErrorMessage);
                }

                return ValidationResult.Success;
            }

            return base.IsValid(value, validationContext);
        }
    }
}