using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;
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
        IGeolocator locator = CrossGeolocator.Current;
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

        private async void GetPosts()
        {
            //using (var con = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    con.CreateTable<Post>();
            //    var posts = con.Table<Post>().ToList();
            //    DisplayOnMap(posts);
            //}
            var posts =await Firestore.Read();
            DisplayOnMap(posts);
        }

        private void DisplayOnMap(List<Post> posts)
        {
            foreach (var post in posts)
            {
                try
                {
                    var position = new Position(post.Latitude, post.Longitude);
                    var pin = new Pin()
                    {
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address,
                        Type = PinType.SavedPin
                    };
                    MapLocation.Pins.Add(pin);
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error",ex.Message, "Ok");
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
           var status = await CheckAndRequestPermission();
            if (status == PermissionStatus.Granted)
            {
                var location = await Geolocation.GetLocationAsync();
              
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(new TimeSpan(0, 1, 0),100);
                MapLocation.IsShowingUser = true;
                CenterMap(location.Latitude, location.Longitude);
            }
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            CenterMap(e.Position.Latitude, e.Position.Longitude);
        }

        private void CenterMap(double latitude, double longitude)
        {
            var position = new Position(latitude, longitude);
            var mapspan = new MapSpan(position,0.0005,0.0005);
            MapLocation.MoveToRegion(mapspan);
        }

        private async Task<PermissionStatus> CheckAndRequestPermission()
        {
            var status =await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Granted)
            {
                MapLocation.IsShowingUser = true;
                return status;
            }
            else if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                //propm the user to turn on the permission in settings
                return status;
            }
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status;
        }
    }
}