namespace BlazeAstro.Web.Shared.Constants
{
    using System;
    using System.Collections.Generic;

    using BlazeAstro.Web.Shared.Models.Mars;

    public static class MarsConstants
    {
        public const string DateFormat = "yyyy-MM-dd";

        public static IDictionary<RoverName, (DateTime LandingDate, DateTime LastDate)> Rovers = 
            new Dictionary<RoverName, (DateTime LandingDate, DateTime LastDate)>()
        {
            { RoverName.Spirit, (new DateTime(2004, 1, 5), new DateTime(2010, 3, 21))},
            { RoverName.Opportunity, (new DateTime(2004, 1, 26), new DateTime(2018, 6, 9))},
            { RoverName.Curiosity, (new DateTime(2012, 8, 6), DateTime.Now)}
        };
    }
}   