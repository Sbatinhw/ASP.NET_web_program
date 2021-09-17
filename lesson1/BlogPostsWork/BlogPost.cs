using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostsWork
{
    class BlogPost
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        

        public string Print()
        {
            return $"\n{userId}\n{id}\n{title}\n{body}";
        }
    }
}
