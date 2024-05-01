using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using Implementation;
namespace LAB_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object source, RoutedEventArgs args)
        {
            Regex regexSet = new Regex("^[a-z]*$");

            bool at = regexSet.IsMatch(Box.Text);


            if (at == false)
            {
                Exp.Text = "Можно вводить только маленькие латинские буквы :(";
                Res.Text = "";
            }
            else
            {
                Variety variety = new Variety(Box.Text);
                List<char[]> list = new List<char[]>();
                Rearrangement rar = new Rearrangement(variety);
                list = rar.result;
                string txt = "";
                int namber = 1;
                
                foreach (char[] c in list)
                {
                    txt += namber + " ";
                    foreach (char c2 in c)
                    {
                        txt += c2;
                        txt += " ";
                    }
                    namber++;
                    txt += "\n";
                }
                Res.Text = txt;


            }
        }
    }
}