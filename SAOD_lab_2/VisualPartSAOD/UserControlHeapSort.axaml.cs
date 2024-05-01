using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using VisualPartSAOD.ViewModel.Lab2;

namespace VisualPartSAOD
{
    public partial class UserControlHeapSort : UserControl
    {
        public UserControlHeapSort()
        {
            InitializeComponent();
            if (cartesianChart2.DataContext is HearSortInfo viewModel)
            {
                
                cartesianChart2.VisualElements = viewModel.VisualElements;
                cartesianChart2.Background = Brushes.White;
            }
        }
         
}
}
