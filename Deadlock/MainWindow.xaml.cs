using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Deadlock
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
            using var wc = new WebClient();

            var task = wc.DownloadStringTaskAsync("https://github.com/");

            textbox.Text = task.Result.Length.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // WebClient使用ConfigureAwait后仍然死锁，而HttpClient不会

            using var wc = new WebClient();

            var task = wc.DownloadStringTaskAsync("https://github.com/").ConfigureAwait(false);

            textbox.Text = task.GetAwaiter().GetResult().Length.ToString();
        }

        private async Task<string> ConfigureAwaitDeadlock()
        {
            using var wc = new WebClient();

            var t = await wc.DownloadStringTaskAsync("https://github.com/").ConfigureAwait(false);

            return t;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var task = ConfigureAwaitDeadlock();

            textbox.Text = task.Result.Length.ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using var wc = new WebClient();

            var task = wc.DownloadStringTaskAsync("https://github.com/");

            task.Wait();

            textbox.Text = task.Result.ToString();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // 由Task.Run新启动的线程来调用的，而Task.Run新启动的线程是线程池线程，该线程没有SynchronizationContext,不会和top-level method的线程阻塞造成死锁。

            var task = Task.Run(async () =>
            {
                using var wc = new WebClient();

                var t = await wc.DownloadStringTaskAsync("https://github.com/");

                return t;
            });

            textbox.Text = task.Result.Length.ToString();
        }

        private async Task<string> ConfigureAwait()
        {
            using var wc = new HttpClient();

            var t = await wc.GetStringAsync("https://github.com/").ConfigureAwait(false);

            return t;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var task = ConfigureAwait();

            textbox.Text = task.Result.Length.ToString();
        }

        private async void Button_Click_6(object sender, RoutedEventArgs e)
        {
            using var wc = new WebClient();

            var task = await wc.DownloadStringTaskAsync("https://github.com/");

            textbox.Text = task.Length.ToString();
        }
    }
}
