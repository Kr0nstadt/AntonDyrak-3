using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using VisualPartSAOD.ViewModel.Lab2;

namespace VisualPartSAOD;

public partial class UserControlQuickSort : UserControl
{
    public UserControlQuickSort()
    {
        InitializeComponent();
        if (cartesianChart2.DataContext is QuickSortInfo viewModel)
        {

            cartesianChart2.VisualElements = viewModel.VisualElements;
            cartesianChart2.Background = Brushes.White;
        }
    }
}