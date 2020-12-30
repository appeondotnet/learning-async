using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var tokenSource = new CancellationTokenSource();
                var tokenSource2 = new CancellationTokenSource();
                var tokenSource3 = CancellationTokenSource.CreateLinkedTokenSource(tokenSource.Token, tokenSource2.Token);

                tokenSource.Token.Register(() =>
                {
                    Console.WriteLine("Task Cancelled.");
                });

                tokenSource2.Token.Register(() =>
                {
                    Console.WriteLine("Task2 Cancelled.");
                });

                tokenSource2.CancelAfter(1000);

                tokenSource3.Token.Register(() =>
                {
                    Console.WriteLine("Task3 Cancelled.");
                });

                GetToday(tokenSource.Token);

                tokenSource.Cancel();

                Thread.Sleep(2000);

                Console.ReadLine();
            }
            catch (Exception)
            {
                // 对于 async void 方法，没有 Task 对象，因此 async void 方法引发的任何异常都会直接在 SynchronizationContext（在 async void 方法启动时处于活动状态）上引发。
            }
        }

        private static async Task GetToday(CancellationToken cancellationToken)
        {
            try
            {
                var client = new HttpClient();

                var res = await client.GetAsync("http://www.weather.com.cn/data/sk/101110101.html", cancellationToken);

                Console.WriteLine(res);
            }
            catch (OperationCanceledException ex)
            {
                // 当 async Task 或 async Task<T> 方法引发异常时，会捕获该异常并将其置于 Task 对象上。
                Console.WriteLine(ex.Message);

                throw ex;
            }
        }
    }
}
