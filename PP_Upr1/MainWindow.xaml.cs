using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace PP_Upr1
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

        private async Task SlowWork()
        {
            DateTime start = DateTime.Now;
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                if (i % 20 == 0 && i > 0)
                {
                    PrintedLabel.Content += Environment.NewLine;
                }

                int randomNumber = rnd.Next(1, 5000);
                PrintedLabel.Content += randomNumber + "  ";

                int randomSleepTime = rnd.Next(100, 200);
                await Task.Delay(randomSleepTime);
            }

            DateTime endTime = DateTime.Now;

            PrintedLabel.Content += $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}Start: {start}{Environment.NewLine}End: {endTime}";
        }

        private async void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            SlowWorkButton.IsEnabled = false;
            //_ = SlowWork();
            await SlowWork();
            SlowWorkButton.IsEnabled = true;
        }


    }
}
