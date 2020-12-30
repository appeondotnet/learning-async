using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Yield
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = FindSeriesSumAsync(100000, default);

            CountBig(10000);

            CountBig(10001);

            CountBig(10002);

            Console.WriteLine("Length =" + task.Result);

            Console.Read();
        }

        static async Task<int> FindSeriesSumAsync(int number, CancellationToken cancellationToken)
        {
            for (int i = 0; i < number; i++)
            {
                if (i % 20000 == 0)
                {
                    await Task.Yield();

                    Console.WriteLine("i % 20000 :i=" + i);
                }
            }

            var wc = new WebClient();

            Console.WriteLine("开始下载任务");

            string str = await wc.DownloadStringTaskAsync("https://github.com/");

            return str.Length;
        }

        static void CountBig(int p)
        {
            for (int i = 0; i < p; i++)
            {
                if (i == p - 1)
                {
                    Console.WriteLine("p =" + p);
                }
            }
        }
    }
}
