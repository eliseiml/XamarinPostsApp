using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Posts.Models;

namespace Posts.Interfaces
{
    public interface IDataInterface
    {
        Task<ObservableCollection<Post>> LoadPosts();
        Task<ObservableCollection<Comment>> LoadComments(int postId);
    }
}
