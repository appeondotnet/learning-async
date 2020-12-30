using System;
using System.Threading;

namespace WaitHandle_AutoResetEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.AutoResetEvent调用一次Set()只能继续一个阻塞线程
            // 2.AutoResetEvent调用Set()后自动Reset()
            var autoReset = new AutoResetEvent(false);

            for (int i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    autoReset.WaitOne();
                    Console.WriteLine(i);
                });

                thread.Start();
            }

            Thread.Sleep(3000);

            autoReset.Set();
            autoReset.Set();
            autoReset.Set();

            for (int i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    autoReset.WaitOne();
                    Console.WriteLine(i);
                });

                thread.Start();
            }

            Thread.Sleep(3000);

            autoReset.Set();
            autoReset.Set();
            autoReset.Set();

            Console.ReadLine();
        }
    }
}
