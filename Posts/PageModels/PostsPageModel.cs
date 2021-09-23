using System.ComponentModel;
using Posts.Models;
using Posts.Interfaces;
using Posts.DataServices;
using System.Collections.Generic;
using FreshMvvm;
using System.Collections.ObjectModel;

namespace Posts.PageModels
{
    public class PostsPageModel: FreshBasePageModel
    {
        public ObservableCollection<Post> Posts { get; set; }
        private readonly IDataInterface DataInterface;

        public PostsPageModel()
        {
            Posts = new ObservableCollection<Post>();
            DataInterface = new PostsWebService();
        }

        public override void Init(object initData)
        {
            LoadPosts();
        }

        async void LoadPosts()
        {
            Posts = await DataInterface.LoadPosts();
        }
    }
}
