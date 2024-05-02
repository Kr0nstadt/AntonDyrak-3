using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Perchev_Kyrsach.Fields;

namespace VisialPart;

public partial class MinesweeperView : UserControl
{
    public MinesweeperView()
    {
        InitializeComponent();
    }

    public void CellPressedRightButtonClick(object sender, PointerPressedEventArgs pointerEventArgs)
    {
        if (sender is Button button)
        {
            PointerPoint p = pointerEventArgs.GetCurrentPoint(button);
            if (p.Properties.IsRightButtonPressed &&
                button.DataContext is AbstractField cell &&
                this.DataContext is MinesweeperViewModel vm)
            {
                vm.SetFlag(cell);
            }
        }

    }
}