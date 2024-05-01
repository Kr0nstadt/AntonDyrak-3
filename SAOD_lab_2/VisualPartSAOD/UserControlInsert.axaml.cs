using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using LiveChartsCore.Kernel.Events;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView.Drawing;
using VisualPartSAOD.ViewModel.Lab2;
namespace VisualPartSAOD;

public partial class UserControlInsert : UserControl
{
    public UserControlInsert()
    {
        InitializeComponent();
        if (cartesianChart.DataContext is InfoInsertSort viewModel)
        {
            cartesianChart.VisualElements = viewModel.VisualElements;
            cartesianChart.Background = Brushes.White;
        }
    }
}