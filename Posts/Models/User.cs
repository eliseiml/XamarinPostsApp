using System;
namespace Posts.Models
{
    public class User
    {
        public int Id { get; }
        public string Name { get; }
        public string Username { get; }
        public string Email { get; }

        public User(
            int id,
            string name,
            string username,
            string email
            )
        {
            this.Id = id;
            this.Name = name;
            this.Username = username;
            this.Email = email;
        }
    }
}
