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
			var location = CrossGeolocator.Current;
			var position =await location.GetPositionAsync();

			var venues = VenueLogic.GetVenues(position.Latitude, position.Longitude);
		}
		private void Save_Clicked(object sender, EventArgs e)
		{
			Post post = new Post()
			{
				Experience = experienceEntry.Text
			};
			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			{
				conn.CreateTable<Post>();
				int rows = conn.Insert(post);
				conn.Close();
				if (rows > 0)
				{
					DisplayAlert("Success", "Experience successfully inserted", "Ok");
				}
				else
				{
					DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
				}
			}
		}
	}
}