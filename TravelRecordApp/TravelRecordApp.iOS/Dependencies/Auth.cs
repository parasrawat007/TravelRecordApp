using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using TravelRecordApp.Helpers;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(TravelRecordApp.iOS.Dependencies.Auth))]
namespace TravelRecordApp.iOS.Dependencies
{
    public class Auth : IAuth
    {
        public Auth()
        {
        }
        public string GetCurrentUserId(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool LoginUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool RegisterUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}