using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using Xamarin.Forms;

[assembly:Dependency(typeof(TravelRecordApp.Droid.Dependencies.Firestore))]
namespace TravelRecordApp.Droid.Dependencies
{
    class Firestore : IFirestore
    {
        public async Task<bool> Delete(Post post)
        {
            // var collection =Firebase.CloudFirestore
            //Firebase.Clo
            throw new NotImplementedException();
        }

        public bool Insert(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}