using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            Duration = new TimerDuration(DateTime.Now);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private TimerDuration _duration;
        public TimerDuration Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                RaisePropertyChanged(nameof(Duration));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Duration.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Duration.Pause();
        }
    }
}
