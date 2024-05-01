using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Perchev_Kyrsach.Fields;

namespace VisialPart
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CellPressedRightButtonClick(object sender, PointerPressedEventArgs pointerEventArgs)
        {
            if(sender is Button button)
            {
                PointerPoint p = pointerEventArgs.GetCurrentPoint(button);
                if (p.Properties.IsRightButtonPressed && 
                    button.DataContext is AbstractField cell &&
                    this.DataContext is MainWindowViewModel vm)
                {
                    vm.SetFlag(cell);
                }
            }
            
        }
    }
}