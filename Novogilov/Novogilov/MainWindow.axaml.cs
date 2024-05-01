using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;

namespace Novogilov
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();         
        }
        
        public void ButtonClicked(object source, RoutedEventArgs args)
        {
            Regex regex = new Regex("^[a-z A-Z]*$");
            if(regex.IsMatch(AString.Text) == false || regex.IsMatch(BString.Text) == false)
            {
                Exeption.Text = "Можно вводить только латинские буквы :(";
            }
            else
            {
                VarietyInfo V = new VarietyInfo(AString.Text, BString.Text);
                Exeption.Text = "";
                unionTextBlock.Text = V.UnionInfo;
                intersectionTextBlock.Text = V.IntersectionInfo;
                differenceTextBlock.Text = V.DifferenceInfo;
                subsetTextBlock.Text = V.SubsetInfo;
            }
        }
        
    }
}