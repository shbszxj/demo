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

namespace WpfRoutingEventDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.button1.AddHandler(Button.ClickEvent, new RoutedEventHandler(RoutedEvent));
            this.MEvent += new RoutedEventHandler(MainWindow_MEvent);
        }


        void MainWindow_MEvent(object sender, RoutedEventArgs e)
        {
            this.textBox1.Text = DateTime.Now.ToString();
        }

        private static readonly RoutedEvent MyEvent =
            EventManager.RegisterRoutedEvent("Event", RoutingStrategy.Bubble, typeof(RoutedEvent), typeof(RoutedEventArgs));


        public event RoutedEventHandler MEvent
        {
            add
            {
                AddHandler(MyEvent, value);
            }
            remove
            {
                RemoveHandler(MyEvent, value);
            }
        }

        void RoutedEvent(object o, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(MyEvent);
            this.RaiseEvent(args);
        }

    }
}
