using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Posts.Interfaces;
using Posts.Models;
using System.Collections.ObjectModel;


namespace Posts.DataServices
{
    public class PostsWebService : IDataInterface
    {
        HttpClient http;
        public PostsWebService()
        {
            http = new HttpClient();
        }

        public async Task<ObservableCollection<Post>> LoadPosts()
        {
            List<Post> data = new List<Post>();

            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.Method = HttpMethod.Get;
            requestMessage.RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
            requestMessage.Headers.Add("Accept", "application/json");

            HttpResponseMessage response = await http.SendAsync(requestMessage);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                try
                {
                    data = JsonConvert.DeserializeObject<List<Post>>(jsonStr);
                } catch (Exception e) {
                    Console.WriteLine("Error while deserializing json: " + e.ToString());
                }
            }
            ObservableCollection<Post> ff = new ObservableCollection<Post>(data);
            return ff;

        }
    }
}