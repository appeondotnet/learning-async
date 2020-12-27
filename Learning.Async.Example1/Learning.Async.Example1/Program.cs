using System;
using System.Threading.Tasks;

namespace Learning.Async.Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private async void DoSomeThing()
        {
            var task = Task.Delay(3000);
        }
    }
}
