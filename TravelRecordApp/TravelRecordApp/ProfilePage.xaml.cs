using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //using (var con = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    var PostTable = con.Table<Post>().ToList();
            //    var Categories = PostTable.OrderBy(p => p.Id).Select(p => p.CategoryName).Distinct().ToList();

            //    Dictionary<string, int> CategoriesCount = new Dictionary<string, int>();
            //    foreach (var Category in Categories)
            //    {
            //        var count = PostTable.Where(p => p.CategoryName == Category).Count();
            //        CategoriesCount.Add(Category, count);
            //    }
            //    ListViewCategoris.ItemsSource = CategoriesCount;

            //    LabelPostCount.Text = PostTable.Count.ToString();
            //}

                var PostTable = await Firestore.Read();
                var Categories = PostTable.OrderBy(p => p.Id).Select(p => p.CategoryName).Distinct().ToList();

                Dictionary<string, int> CategoriesCount = new Dictionary<string, int>();
                foreach (var Category in Categories)
                {
                    var count = PostTable.Where(p => p.CategoryName == Category).Count();
                    CategoriesCount.Add(Category, count);
                }
                ListViewCategoris.ItemsSource = CategoriesCount;

                LabelPostCount.Text = PostTable.Count.ToString();
            
        }
    }
}