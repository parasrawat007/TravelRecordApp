using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TravelRecordApp.Helpers
{
    public interface IAuth
    {
        bool RegisterUser(string Email, string Password);
        bool LoginUser(string Email, string Password);
        bool IsAuthenticated(string Email, string Password);
        string GetCurrentUserId(string Email, string Password); 
    }
    public class Auth
    {
        private static IAuth auth = DependencyService.Get<IAuth>();
        public Auth()
        {

        }
        public static bool RegisterUser(string Email, string Password)
        {
            return auth.RegisterUser(Email,Password);
        }
        public static bool LoginUser(string Email, string Password)
        {
            return auth.LoginUser(Email, Password);
        }
        public static bool IsAuthenticated(string Email, string Password)
        {
            return auth.IsAuthenticated(Email, Password);
        }
        public static string GetCurrentUserId(string Email, string Password)
        {
            return auth.GetCurrentUserId(Email, Password);
        }
    }
}
