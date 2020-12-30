using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = A();

            var b = 2;

            Thread.Sleep(10000);

            var wc = new WebClient();

            var task = wc.DownloadStringTaskAsync("https://github.com/");
        }

        private async Task<int> A()
        {
            var b = await B();

            return b + 1;
        }

        private async Task<int> B()
        {
            var b = await Task.Run(() =>
            {
                var wc = new WebClient();

                var task = wc.DownloadStringTaskAsync("https://github.com/");

                return task.Result.Length;
            });

            return b + 1;
        }
    }
}
