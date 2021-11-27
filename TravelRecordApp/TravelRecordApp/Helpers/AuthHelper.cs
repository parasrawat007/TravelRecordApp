using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordApp.Helpers
{
    public interface IAuth
    {
        Task<bool> RegisterUser(string Email, string Password);
        Task<bool> LoginUser(string Email, string Password);
        bool IsAuthenticated();
        string GetCurrentUserId(); 
    }
    public class Auth
    {
        private static IAuth auth = DependencyService.Get<IAuth>();
        public Auth()
        {

        }
        public async static Task<bool> RegisterUser(string Email, string Password)
        {
            try
            {
                return await auth.RegisterUser(Email, Password);
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                "The password must be 6 characters long"
                return false;
            }
        }
        public async static Task<bool> LoginUser(string Email, string Password)
        {
            try
            {
                return await auth.LoginUser(Email, Password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                var registerMessage = "There is no user record corresponding to this identifier.";
                if (ex.Message.Contains(registerMessage))
                {
                    return await RegisterUser(Email, Password);
                }
                return false;
            }
        }
        public static bool IsAuthenticated()
        {
            return auth.IsAuthenticated();
        }
        public static string GetCurrentUserId()
        {
            return auth.GetCurrentUserId();
        }
    }
}
