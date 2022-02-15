namespace BlazeAstro.Web.Shared.Validations.Mars
{
    using System;

    using BlazeAstro.Web.Shared.Constants;
    using BlazeAstro.Web.Shared.Models.Mars;
    using BlazeAstro.Web.Shared.Validations.Contracts;

    public class MarsRequestValidation : IRequestValidation<MarsInputModel>
    {
        public (bool IsSuccess, string ErrorMessage) Validate(MarsInputModel inputModel)
        {
            if (inputModel.EarthDate != default(DateTime) && inputModel.Sol > 0)
            {
                string error = $@"'{nameof(inputModel.EarthDate)}' cannot be used in conjunction with '{nameof(inputModel.Sol)}'";

                return (false, error);
            }

            if (inputModel.EarthDate != default(DateTime) && 
                (inputModel.EarthDate < MarsConstants.Rovers[inputModel.RoverName].LandingDate ||
                inputModel.EarthDate > MarsConstants.Rovers[inputModel.RoverName].LastDate))
            {
                string error = $@"'{nameof(inputModel.EarthDate)}' is out of date range for rover '{inputModel.RoverName.ToString()}'";

                return (false, error);
            }

            return (true, null);
        }
    }
}