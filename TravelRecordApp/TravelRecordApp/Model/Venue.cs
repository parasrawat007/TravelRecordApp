using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    public class Venue
    {

        public static string GenerateUrl(double latitude,double longitude)
        {
            return string.Format(Constants.VenueSearch, latitude, longitude, Constants.ClientId, Constants.ClientSecret,DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
