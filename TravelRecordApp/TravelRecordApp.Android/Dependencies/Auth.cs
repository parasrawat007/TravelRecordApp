using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TravelRecordApp.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(TravelRecordApp.Droid.Dependencies.Auth))]
namespace TravelRecordApp.Droid.Dependencies
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