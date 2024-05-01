using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using VisualPartSAOD.ViewModel.Lab2;

namespace VisualPartSAOD;

public partial class UserControlLab4 : UserControl
{
    public UserControlLab4()
    {
        InitializeComponent();

        if (cartesianChart.DataContext is SummaryInfoLab4 viewModel)
        {
            cartesianChart.VisualElements = viewModel.VisualElements;
            cartesianChart.Background = Brushes.White;
        }
    }
}