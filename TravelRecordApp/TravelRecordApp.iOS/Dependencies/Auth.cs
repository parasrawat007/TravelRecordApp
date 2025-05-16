using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string GetCurrentUserId()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid;
        }

        public bool IsAuthenticated()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser!=null;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {

                await Firebase.Auth.Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
            }
            catch (NSErrorException error)
            {

                throw new Exception(error.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("There was an Unknown error");
            }
            return true;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            try
            {

                await Firebase.Auth.Auth.DefaultInstance.Regis(email, password);
            }
            catch (NSErrorException error)
            {

                throw new Exception(error.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an Unknown error");
            }
            return true;
        }
    }
}