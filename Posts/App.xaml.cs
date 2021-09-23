using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Posts.Pages;
using Posts.PageModels;
using FreshMvvm;

namespace Posts
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var postsPage = FreshPageModelResolver.ResolvePageModel<PostsPageModel>();
            var postsContainer = new FreshNavigationContainer(postsPage, "Container");
            MainPage = postsContainer;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
