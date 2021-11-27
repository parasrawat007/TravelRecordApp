using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using TravelRecordApp.Helpers;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(TravelRecordApp.iOS.Dependencies.Auth))]
namespace TravelRecordApp.iOS.Dependencies
{
    public class Auth : IAuth
    {
        public string GetCurrentUserId()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid;
        }

        public bool IsAuthenticated()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser != null;
        }

        public async Task<bool> LoginUser(string Email, string Password)
        {
            try
            {
                await Firebase.Auth.Auth.DefaultInstance.SignInWithPasswordAsync(Email, Password);
                return true;
            }
            catch (NSErrorException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an Unkown Error");
            }
        }

        public async Task<bool> RegisterUser(string Email, string Password)
        {
            try
            {
                await Firebase.Auth.Auth.DefaultInstance.CreateUserAsync(Email, Password);
                return true;
            }
            catch (NSErrorException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an Unkown Error");
            }
        }
    }
}