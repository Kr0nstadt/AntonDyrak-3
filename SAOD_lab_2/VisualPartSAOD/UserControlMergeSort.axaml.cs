using Avalonia.Controls;
using Avalonia.Media;
using VisualPartSAOD.ViewModel.Lab2;

namespace VisualPartSAOD
{
    public partial class UserControlMergeSort : UserControl
    {
        public UserControlMergeSort()
        {
            InitializeComponent();
            if (cartesianChart2.DataContext is MergeSortInfo viewModel)
            {

                cartesianChart2.VisualElements = viewModel.VisualElements;
                cartesianChart2.Background = Brushes.White;
            }
        }
    }
}
