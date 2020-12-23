using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataGridRowGragDrop
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public MainWindowViewModel()
        {
            InitEmployeeList();
        }

        private void InitEmployeeList()
        {
            Employees = new ObservableCollection<Employee>();
            Employees.Add(new Employee("000001", "上证指数01"));
            Employees.Add(new Employee("000002", "上证指数02"));
            Employees.Add(new Employee("000003", "上证指数03"));
            Employees.Add(new Employee("000004", "上证指数04"));
            Employees.Add(new Employee("000005", "上证指数05"));
            Employees.Add(new Employee("000006", "上证指数06"));
            RaisePropertyChange("Employees");

        }
    }
}
