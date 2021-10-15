using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		private void ToolbarItemSave_Clicked(object sender, EventArgs e)
		{
			var post = new Post()
			{
				Experience = EntryExperience.Text
			};

			SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation);
			con.CreateTable<Post>();
			int rows=con.Insert(post);
			con.Close();
			if (rows > 0)
				DisplayAlert("Success", "Experience successfully inserted", "Ok");
			else
				DisplayAlert("Failure", "Experience Not inserted", "Ok");
		}
	}
}