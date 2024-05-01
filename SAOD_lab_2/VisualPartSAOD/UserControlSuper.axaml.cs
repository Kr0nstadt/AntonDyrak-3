using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using VisualPartSAOD.ViewModel.Lab2;

namespace VisualPartSAOD;

public partial class UserControlSuper : UserControl
{
    public UserControlSuper()
    {
        InitializeComponent();
        if (cartesianChart.DataContext is SummaryInfoSuper viewModel)
        {
            cartesianChart.VisualElements = viewModel.VisualElements;
            cartesianChart.Background = Brushes.White;
        }
    }
}