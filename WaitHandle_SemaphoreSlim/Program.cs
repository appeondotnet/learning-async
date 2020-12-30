using System;
using System.Threading;
using System.Threading.Tasks;

namespace WaitHandle_SemaphoreSlim
{
    internal class Program
    {
        private static SemaphoreSlim _semaphoreSlim;

        private static void Main(string[] args)
        {
            _semaphoreSlim = new SemaphoreSlim(1, 1);

            //GetToday(1, default);

            //GetToday(2, default);

            //GetTodayWithSemaphoreSlim(1, default);

            //GetTodayWithSemaphoreSlim(2, default);

            GetTodayWithSemaphoreSlim2(1, default);

            GetTodayWithSemaphoreSlim2(2, default);

            Console.WriteLine("Complete.");
            Console.ReadLine();
        }

        private static async Task GetToday(int id, CancellationToken cancellationToken)
        {
            var random = new Random(100);

            await Task.Run(() =>
            {
                Task.Delay(random.Next());

                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Number:{id},{i}");
                }
            });
        }

        private static async Task GetTodayWithSemaphoreSlim(int id, CancellationToken cancellationToken)
        {
            var random = new Random(100);

            await _semaphoreSlim.WaitAsync();

            await Task.Run(() =>
            {
                Task.Delay(random.Next());

                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Number:{id},{i}");
                }
            });

            _semaphoreSlim.Release();
        }

        private static async Task GetTodayWithSemaphoreSlim2(int id, CancellationToken cancellationToken)
        {
            var random = new Random(100);

            _semaphoreSlim.Wait();

            await Task.Run(() =>
            {
                Task.Delay(random.Next());

                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Number:{id},{i}");
                }
            });

            _semaphoreSlim.Release();
        }
    }
}
