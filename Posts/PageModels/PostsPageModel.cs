using System.ComponentModel;
using Posts.Models;
using Posts.Interfaces;
using Posts.DataServices;
using System.Collections.Generic;
using FreshMvvm;
using System.Collections.ObjectModel;
using Posts.Dependencies;
using System;

namespace Posts.PageModels
{
    public class PostsPageModel : FreshBasePageModel
    {
        public ObservableCollection<Post> Posts { get; set; }
        private readonly IDataInterface DataInterface;

        public PostsPageModel()
        {
            Posts = new ObservableCollection<Post>();
            DataInterface = ServiceLocator.GetIDataInterface();
        }

        public override void Init(object initData)
        {
            LoadPosts();
        }

        async void LoadPosts()
        {
            Posts = await DataInterface.LoadPosts();
        }

        public Post SelectedPost
        {
            get { return null; }

            set

            {
                CoreMethods.PushPageModel<PostDetailsPageModel>(value);

                RaisePropertyChanged();
            }
        }
    }
}
