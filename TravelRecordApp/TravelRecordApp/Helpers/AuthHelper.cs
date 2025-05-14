using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TravelRecordApp.Helpers
{
    public interface IAuth
    {
        bool RegisterUser(string email, string password);
        bool LoginUser(string email, string password);
        bool IsAuthenticated(string email, string password);
        string GetCurrentUserId(string email, string password);
    }
    class Auth
    {
        private static IAuth auth=DependencyService.Get<IAuth>();
        public Auth()
        {
            
        }
        public static bool RegisterUser(string email,string password) 
        {
            return auth.RegisterUser(email,password);
        }
        public static bool LoginUser(string email, string password)
        {
            return auth.LoginUser(email,password);
        }
        public static bool IsAuthenticated(string email, string password)
        {
            return auth.IsAuthenticated(email,password);
        }
        public static string GetCurrentUserId(string email, string password)
        {
            return auth.GetCurrentUserId(email,password);
        }
    }
}
