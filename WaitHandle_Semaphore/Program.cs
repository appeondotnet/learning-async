using System;
using System.Threading;

namespace WaitHandle_Semaphore
{
    class Program
    {
        static void Main(string[] args)
        {
            var semaphore = new Semaphore(1, 1);

            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread((str) =>
                {
                    semaphore.WaitOne();

                    Console.WriteLine(str + "进洗手间：" + DateTime.Now.ToString());

                    Thread.Sleep(1000);

                    Console.WriteLine(str + "出洗手间：" + DateTime.Now.ToString());

                    semaphore.Release();
                });

                thread.Name = string.Format("编号{0}", i.ToString());

                thread.Start(thread.Name);
            }

            Console.ReadKey();
        }
    }
}
