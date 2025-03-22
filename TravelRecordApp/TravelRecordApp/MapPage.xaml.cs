using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
			GetLocation();
        }

        private async void GetLocation()
		{ 
			var staus= await CheckAndRequestLocationPermission();
			if (staus == PermissionStatus.Granted)
			{
                var location = await Geolocation.GetLastKnownLocationAsync();
                locationsMap.IsShowingUser = true;
			}
        }

        private async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
			var status=await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
			if (status == PermissionStatus.Granted)
				return status;
			else if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
				await DisplayAlert("Need permission",  "We will have to access your location so please allow access from settings",  "Ok",  "Cancel");

            status= await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
			return status;
        }
    }
}