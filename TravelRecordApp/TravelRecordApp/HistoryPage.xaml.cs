﻿using SQLite;
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
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
			{
				connection.CreateTable<Post>();
				var posts = connection.Table<Post>().ToList();
			}
		}
	}
}