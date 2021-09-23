using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using Posts.Interfaces;
using Posts.Models;
using Posts.Dependencies;

namespace Posts.PageModels
{
    public class PostDetailsPageModel: FreshBasePageModel
    {
        public ObservableCollection<Comment> Comments;
        private readonly IDataInterface DataInterface;

        public PostDetailsPageModel()
        {
            Comments = new ObservableCollection<Comment>();
            DataInterface = ServiceLocator.GetIDataInterface();
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            LoadComments();
        }

        async void LoadComments()
        {

        }
    }
}
