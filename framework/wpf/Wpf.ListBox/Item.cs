using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.ListBox
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }
    }
}
