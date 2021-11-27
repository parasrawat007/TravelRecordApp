using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using TravelRecordApp.Helpers;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(TravelRecordApp.iOS.Dependencies.Auth))]
namespace TravelRecordApp.iOS.Dependencies
{
    public class Auth : IAuth
    {
        public string GetCurrentUserId(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public bool LoginUser(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public bool RegisterUser(string Email, string Password)
        {
            throw new NotImplementedException();
        }
    }
}