using System.ComponentModel;
using System.Windows;

namespace WpfValidationRule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;
        public string BindingName
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(BindingName));
            }
        }
    }
}
