using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Position = Xamarin.Forms.Maps.Position;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		IGeolocator locator= CrossGeolocator.Current;
		public MapPage ()
		{
			InitializeComponent ();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			GetLocation();
			GetPosts();
		}
        protected void GetPosts()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Post>();
                var posts = connection.Table<Post>().ToList();
                DisplayOnMap(posts);
            }
        }

        private void DisplayOnMap(List<Post> posts)
        {
			foreach (var post in posts)
			{
				try
				{
					var position = new Position(post.Latitude, post.Logitude);
					var pin = new Pin
					{
						Position = position,
						Label = post.VenueName,
						Address = post.Address,
						Type = PinType.SavedPin
					};
					locationsMap.Pins.Add(pin);

				}
				catch (Exception ex)
				{

				}
			}
         }

        protected override void OnDisappearing()
		{
			base.OnDisappearing();
			locator.StopListeningAsync();
		}


		private async void GetLocation()
		{ 
			var staus= await CheckAndRequestLocationPermission();
			if (staus == PermissionStatus.Granted)
			{
				var location = await Geolocation.GetLocationAsync();
				var locator = CrossGeolocator.Current;
				locator.PositionChanged += Locator_PositionChanged;
				await locator.StartListeningAsync(TimeSpan.FromSeconds(10), 100);
				CenterMap(location.Latitude,location.Longitude);
				locationsMap.IsShowingUser = true;
			}
		}

		private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
		{
			CenterMap(e.Position.Latitude, e.Position.Longitude);
		}

		private void CenterMap(double latitude, double longitude)
		{
			var center = new Position(latitude, longitude);
			MapSpan span = new MapSpan(center, 1, 1);
			locationsMap.MoveToRegion(span);
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