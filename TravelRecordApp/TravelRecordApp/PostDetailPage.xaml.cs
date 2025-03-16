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
	public partial class PostDetailPage : ContentPage
	{
		Post selectedPost;
		public PostDetailPage (Post post)
		{
			InitializeComponent ();
			selectedPost=post;
			experienceEntry.Text = selectedPost.Experience;
		}

		private void UpdateButton_Clicked(object sender, EventArgs e)
		{
			
		}

		private void SaveButton_Clicked(object sender, EventArgs e)
		{
			selectedPost.Experience = experienceEntry.Text;
			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			{
				int rows=conn.Update(selectedPost);
				if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully updated", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be updated", "Ok");
                }
            }
		}
		private void DeleteButton_Clicked(object sender, EventArgs e)
		{
			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			{
				int rows = conn.Delete(selectedPost);
                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully deleted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
                }
            }
		}
	}
}