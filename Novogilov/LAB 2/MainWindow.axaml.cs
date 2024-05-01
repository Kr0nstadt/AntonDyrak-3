using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;
using Avalonia.Rendering.Composition;

namespace LAB_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ButtonClicked(object source, RoutedEventArgs args)
        {
            Regex regexSet = new Regex("^[a-z]*$");
            Regex regex = new Regex("^([a-z]{2},)*([a-z]{2})$|^([a-z]{2})$");
            bool at = regexSet.IsMatch(AString.Text);
            bool bt = regex.IsMatch(RString.Text);
            
            if (at == false || bt == false)
            {
                Exeption.Text = "Можно вводить только маленькие латинские буквы :(";
                InfoR.Text = "";
            }
            else
            {
                try
                {
                    AttitubeInfo V = new AttitubeInfo(RString.Text, AString.Text);
                    Exeption.Text = "";
                    InfoR.Text = V.Info;
                }
                catch(ArgumentException a)
                {
                    Exeption.Text = "В отношении должны присутствовать только элементы множества :'(";
                    InfoR.Text = "";
                }

                
                
            }
        }
    }
}