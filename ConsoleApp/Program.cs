using System;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var task = Test();

            for (int i = 1; i < 100001; i++)
            {
                if (i % 10000 == 0)
                {
                    Console.WriteLine("aa");
                }
            }

            Console.WriteLine("Done");

            Console.ReadKey();
        }

        static async Task Test()
        {
            var wc = new WebClient();

            var t = await wc.DownloadStringTaskAsync("https://github.com/");

            Console.WriteLine(t.Length);
        }
    }
}
