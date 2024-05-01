using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using VisualPartSAOD.ViewModel.Lab2;

namespace VisualPartSAOD
{
    public partial class UserControlLab5 : UserControl
    {
        public UserControlLab5()
        {
            InitializeComponent();

            if (cartesianChart.DataContext is SummaryInfoLab5 viewModel)
            {
                cartesianChart.VisualElements = viewModel.VisualElements;
                cartesianChart.Background = Brushes.White;
                cartesianChart2.VisualElements = viewModel.VisualElements;
                cartesianChart2.Background = Brushes.White;
            }
            
        }
    }
}
