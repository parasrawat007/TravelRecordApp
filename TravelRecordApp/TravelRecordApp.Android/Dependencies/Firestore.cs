using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Java.Interop;
using Java.Util;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using Xamarin.Forms;

[assembly:Dependency(typeof(TravelRecordApp.Droid.Dependencies.Firestore))]
namespace TravelRecordApp.Droid.Dependencies
{
    public class Firestore : Java.Lang.Object,IFirestore,IOnCompleteListener
    {
        List<Post> posts;
        bool HasReadPost = false;
        
        public Firestore()
        {
            posts = new List<Post>();
        }

        public async Task<bool> Delete(Post post)
        {

            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("posts");
                collection.Document(post.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }       
        
        public bool Insert(Post post)
        {
            try
            {
                var PostDocument = new Dictionary<string, Java.Lang.Object>()
                {
                    {"experience",post.Experience },
                    {"venueName",post.VenueName },
                    {"categoryId",post.CategoryId },
                    {"categoryName",post.CategoryName },
                    {"address",post.Address },
                    {"latitude",post.Latitude },
                    {"longitude",post.Longitude },
                    {"distance",post.Distance },
                    {"distance",post.Distance },
                    {"userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid}
                };
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("posts");
                collection.Add(new HashMap(PostDocument));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if(task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;
                posts.Clear();
                foreach(var doc in documents.Documents)
                {
                    Post post = new Post() {
                        Experience = doc.Get("experience").ToString(),
                        VenueName=doc.Get("venueName").ToString(),
                        CategoryId = doc.Get("categoryId").ToString(),
                        CategoryName = doc.Get("categoryName").ToString(),
                        Address = doc.Get("address").ToString(),
                        Latitude = (double)doc.Get("latitude"),
                        Longitude = (double)doc.Get("longitude"),
                        Distance = (int)doc.Get("distance"),
                        Id=doc.Id,
                    };
                    posts.Add(post);
                }
            }
            else
            {
                posts.Clear();
            }
            HasReadPost = true;
        }

        public async Task<List<Post>> Read()
        {
            try
            {
                HasReadPost = false;
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("posts");
                var query = collection.WhereEqualTo("userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
                query.Get().AddOnCompleteListener(this);
                for (int i = 0; i < 50; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (HasReadPost)
                    {
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                return posts;
            }
            return posts;
        }            

        public async Task<bool> Update(Post post)
        {
            try
            {
                var PostDocument = new Dictionary<string, Java.Lang.Object>()
                {
                    {"experience",post.Experience },
                    {"venueName",post.VenueName },
                    {"categoryId",post.CategoryId },
                    {"categoryName",post.CategoryName },
                    {"address",post.Address },
                    {"latitude",post.Latitude },
                    {"longitude",post.Longitude },
                    {"distance",post.Distance },
                    {"distance",post.Distance },
                    {"userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid}
                };
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("posts");
                collection.Document(post.Id).Update(PostDocument);          

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}