using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace Contra
{
    //JsonConvert.SerializeObject(" ");
    public class Comment
    {
        public int PostId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }

    public class CountComment
    {
        public int Count { get; set; }
        public int Id { get; set; }
    }

    class Program
    {
        public static Queue<CountComment> Numbers = new Queue<CountComment>();

        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string address = "https://jsonplaceholder.typicode.com/comments?postId=1";
            string comments = client.DownloadString(address);

            JavaScriptSerializer json = new JavaScriptSerializer();
            var res = json.Deserialize(comments, typeof(List<Comment>));

            //foreach (var item in (IList)res)
            //    Console.WriteLine(((Comment)item).Email);

            Parallel.ForEach(res as List<Comment>,AddCount);

            foreach (var item in Numbers)
            {
                Console.WriteLine(item.Count);
            }
            Console.Read();
        }

        public static void AddCount(Comment comment)
        {
            if (comment.Id % 2 != 0) return; 
                int a = 0;
            for (int i = 0; i < comment.Body.Length; i++)
                if (char.IsLetter(comment.Body[i]))
                    a++;
            Numbers.Enqueue(new CountComment {
                Count = a,
                Id = comment.Id
            });
        }
    }
}
