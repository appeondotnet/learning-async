using System;
using System.Threading;

namespace WaitHandle_ManualResetEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.ManualResetEvent调用一次Set()允许继续全部阻塞线程，这是和AutoResetEvent的区别
            // 2.ManualResetEvent调用Set()后需要手动Reset(),将信号设置为非终止状态，只有非终止状态线程中调用WaitOne()才能导所在的致线程阻止。

            var manualReset = new ManualResetEvent(false);

            for (int i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    manualReset.WaitOne();
                    Console.WriteLine(i);
                });

                thread.Start();
            }

            Thread.Sleep(3000);

            manualReset.Set();
            manualReset.Reset();

            for (int i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    manualReset.WaitOne();
                    Console.WriteLine(i);
                });

                thread.Start();
            }

            Thread.Sleep(3000);

            manualReset.Set();

            Console.ReadLine();
        }
    }
}
