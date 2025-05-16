using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assests.Images.plane.png", assembly);
        }

        private async Task LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);  
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);
            if (isEmailEmpty || isPasswordEmpty)
            {
              
            }
            else
            {
                bool result =await Auth.LoginUser(emailEntry.Text, passwordEntry.Text);
                await Navigation.PushAsync(new HomePage());
            }
        }
    }
}
