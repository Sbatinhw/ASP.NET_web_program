using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.IO;
using System.Threading;

namespace BlogPostsWork
{
    class AskBlogPostWork
    {
        private static HttpClient client = new HttpClient();
        private static string connectionString = "https://jsonplaceholder.typicode.com/posts/";

        private static string directoryWay = $"{Directory.GetCurrentDirectory()}";
        private static string resultFileName = "output.txt";

        private static int errorWriteCount = 10;

        private static CancellationTokenSource cts = new CancellationTokenSource();

        public static void StartWorkPost(int[] postsId)
        {
            //ожидаем выполнение всех асинхронных методов
            WorkPost(postsId).Wait();
        }
        private static async Task WorkPost(int[] postsid)
        {
            //список задач на запрос и запись
            var tasks = new List<Task>();
            foreach(var n in postsid)
            {
                tasks.Add(AskAndWrite(n));
            }
            await Task.WhenAll(tasks);
        }

        private static async Task AskAndWrite(int postId)
        {
            var post = await GetPost(postId);
            await WritePost(post);
        }

        private static async Task<BlogPost> GetPost(int postId)
        {
            return await Task.Run(() =>
            {
                return AskPost(postId);
            });
        }

        /// <summary>Запись одного поста </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        private static async Task WritePost(BlogPost post)
        {
            string writePath = $"{directoryWay}\\{resultFileName}";

            //попытки записать пост
            for(int i = 0; i < errorWriteCount; i++)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        await sw.WriteLineAsync($"{post.Print()}\n");
                    }
                    Console.WriteLine($"Excelent write post {post.id}. try {i}");
                    break;
                }
                catch
                {
                    Console.WriteLine($"Error write post {post.id}");
                }
            }
        }

        private static async Task WritePost(BlogPost[] posts)
        {
            string writePath = $"{directoryWay}\\{resultFileName}";

            foreach (var post in posts)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath, true))
                    {
                        await sw.WriteLineAsync($"{post.Print()}");
                    }
                }
                catch
                {
                    Console.WriteLine($"Error post write {post.id}");
                }
            }
        }
            

        private static async Task<BlogPost> AskPost(int id)
        {
            {
                //токен отмены
                cts.CancelAfter(10000);
                try
                {
                    HttpResponseMessage response = await client.GetAsync ($"{connectionString}{id}", cts.Token);

                    using var responseStream = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<BlogPost>(responseStream);
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}
