using System;
using System.Collections.Generic;

namespace BlogPostsWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            Console.WriteLine("start");
            //

            List<int> list = new List<int>();

            for(int i = 0; i < 10; i++)
            {
                list.Add(i + 4);
            }

            AskBlogPostWork.StartWorkPost(list.ToArray());

            //
            Console.WriteLine("end");
            //
            Console.ReadLine();
        }



    }
}
