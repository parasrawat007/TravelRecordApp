using System;
using System.Collections.Generic;
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
            ImageIcon.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png",assembly);
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool IsEmailEmpty = string.IsNullOrEmpty(EntryEmail.Text);
            bool IsPasswordEmpty = string.IsNullOrEmpty(EntryPassword.Text);
            if (IsEmailEmpty || IsPasswordEmpty)
            {

            }
            else
            {
                var result = await Auth.LoginUser(EntryEmail.Text, EntryPassword.Text);
                if (result)
                {
                    await Navigation.PushAsync(new HomePage());
                }
            }
        }
    }
}
