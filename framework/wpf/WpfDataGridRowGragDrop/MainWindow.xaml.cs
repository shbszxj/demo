using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDataGridRowGragDrop
{
    public delegate Point GetDragDropPosition(IInputElement theElement);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int prevRowIndex = -1;

        public MainWindow()
        {
            InitializeComponent();

            MainWindowViewModel ViewModel = new MainWindowViewModel();
            this.grid.DataContext = ViewModel;
        }

        private void DataGrid_Drop(object sender, DragEventArgs e)
        {

        }

        private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            prevRowIndex = GetDataGridItemCurrentRowIndex(e.GetPosition);

            if (prevRowIndex < 0)
                return;
            dgEmployee.SelectedIndex = prevRowIndex;

            Employee selectedEmp = dgEmployee.Items[prevRowIndex] as Employee;

            if (selectedEmp == null)
                return;

            //Now Create a Drag Rectangle with Mouse Drag-Effect
            //Here you can select the Effect as per your choice

            DragDropEffects dragdropeffects = DragDropEffects.Move;

            if (DragDrop.DoDragDrop(dgEmployee, selectedEmp, dragdropeffects)
                                != DragDropEffects.None)
            {
                //Now This Item will be dropped at new location and so the new Selected Item
                dgEmployee.SelectedItem = selectedEmp;
            }
        }

        private int GetDataGridItemCurrentRowIndex(GetDragDropPosition pos)
        {
            int curIndex = -1;
            for (int i = 0; i < dgEmployee.Items.Count; i++)
            {
                DataGridRow itm = GetDataGridRowItem(i);
                if (IsTheMouseOnTargetRow(itm, pos))
                {
                    curIndex = i;
                    break;
                }
            }
            return curIndex;
        }

        private DataGridRow GetDataGridRowItem(int index)
        {
            if (dgEmployee.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
                return null;

            return dgEmployee.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
        }

        private bool IsTheMouseOnTargetRow(Visual theTarget, GetDragDropPosition pos)
        {
            Rect posBounds = VisualTreeHelper.GetDescendantBounds(theTarget);
            Point theMousePos = pos((IInputElement)theTarget);
            return posBounds.Contains(theMousePos);
        }
    }
}
