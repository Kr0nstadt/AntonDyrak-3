using Avalonia.Controls;
using Avalonia.Media;
using VisualPartSAOD.ViewModel.Lab2;

namespace VisualPartSAOD
{
    public partial class DigitSortUserControl : UserControl
    {
        public DigitSortUserControl()
        {
            InitializeComponent();
            if (cartesianChart2.DataContext is DigitalSortInfo viewModel)
            {

                cartesianChart2.VisualElements = viewModel.VisualElements;
                cartesianChart2.Background = Brushes.White;
            }
        }
    }
}
