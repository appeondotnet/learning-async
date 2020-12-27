using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Learning.Async.Example2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Example1  直接跳出 不会卡UI
            this.DoSomeThingAsync1();

            //Example2  无法进行下去，UI卡死
            var task = DoSomeThingAsync2();
            Task.WaitAll(task);
        }

        private async void DoSomeThingAsync1()
        {
            await this.DoSomeThingAsync2();
        }

        private async Task DoSomeThingAsync2()
        {
            var task = Task.Delay(3000);

            await task;
        }
    }
}
