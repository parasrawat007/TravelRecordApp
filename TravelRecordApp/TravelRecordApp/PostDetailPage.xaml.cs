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
        Post post = new Post();
		public PostDetailPage (Post post)
		{
            this.post = post;       
			InitializeComponent();
            EntryExperience.Text = post.Experience;
        }      

        private void ButtonUpdate_Clicked(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Post>();
                post.Experience = EntryExperience.Text;
                int rows=con.Update(post);
                if (rows > 0)
                    DisplayAlert("Success", "Updated Successfully","Ok");
                else
                    DisplayAlert("Failure", "Updates Failed", "Ok");
            }
        }
        private void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Post>();
                post.Experience = EntryExperience.Text;
                int rows = con.Delete(post);
                if (rows > 0)
                    DisplayAlert("Success", "Deleted Successfully", "Ok");
                else
                    DisplayAlert("Failure", "Deletion Failed", "Ok");
            }
        }
    }
}