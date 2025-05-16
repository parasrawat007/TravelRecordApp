using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordApp.Helpers
{
    public interface IAuth
    {
        Task<bool> RegisterUser(string email, string password);
        Task<bool> LoginUser(string email, string password);
        bool IsAuthenticated();
        string GetCurrentUserId();
    }
    class Auth
    {
        private static IAuth auth=DependencyService.Get<IAuth>();
        public Auth()
        {
            
        }
        public async static Task<bool> RegisterUser(string email,string password) 
        {
            try
            {

                return await auth.RegisterUser(email, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return false;
            }
        }
        public async static Task<bool> LoginUser(string email, string password)
        {
            try
            {

                return await auth.LoginUser(email, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                if (ex.Message.Contains("There is no user record corresponding to this identifier. The user may have been deleted."))
                { 
                    return await RegisterUser(email, password);
                }
                return false;
            }
        }
        public static bool IsAuthenticated()
        {
            return  auth.IsAuthenticated();
        }
        public  static string GetCurrentUserId(string email, string password)
        {
            return auth.GetCurrentUserId();
        }
    }
}
