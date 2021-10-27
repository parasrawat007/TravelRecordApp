using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
		public NewTravelPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);
            ListViewVenue.ItemsSource = venues;
        }
        private void ToolbarItemSave_Clicked(object sender, EventArgs e)
		{
            try
            {
                var SelectedVenue = ListViewVenue.SelectedItem as Venue;
                var FirstCategory = SelectedVenue.Categories.FirstOrDefault();
                var post = new Post()
                {
                    Experience = EntryExperience.Text,
                    CategoryId = FirstCategory.Id,
                    CategoryName = FirstCategory.Name,
                    Address = SelectedVenue.Location.Address,
                    Distance = SelectedVenue.Location.Distance,
                    Latitude = SelectedVenue.Location.Lat,
                    Longitude = SelectedVenue.Location.Lng,
                    VenueName = SelectedVenue.Name
                };
                using (var con = new SQLiteConnection(App.DatabaseLocation))
                {
                    con.CreateTable<Post>();
                    int rows = con.Insert(post);
                    if (rows > 0)
                        DisplayAlert("Success", "Experience successfully inserted", "Ok");
                    else
                        DisplayAlert("Failure", "Experience Not inserted", "Ok");
                }
            }           
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message,"Ok");
            }

			
		}
	}
}