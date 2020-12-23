using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Wpf.ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly char[] characters = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private const int LENGTH_OF_NAME = 5;

        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Item> _items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _items.Add(new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Name = CreateRandomName()
            });
        }

        private string CreateRandomName()
        {
            Random random = new Random();
            var str = new char[LENGTH_OF_NAME];
            for (int i = 0; i < LENGTH_OF_NAME; i++)
            {
                str[i] = characters[random.Next(characters.Length - 1)];
            }
            return new string(str);
        }
    }
}
