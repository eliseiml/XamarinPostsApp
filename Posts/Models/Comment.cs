using System;
namespace Posts.Models
{
    public class Comment
    {

        public int PostId { get; }
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Body { get; }

        public Comment(
            int postId,
            int id,
            string name,
            string email,
            string body
        )
        {
            this.PostId = postId;
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Body = body;
        }

    }
}
