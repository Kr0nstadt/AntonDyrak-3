using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using Implementation;

namespace LAB4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonClicked(object source, RoutedEventArgs args)
        {
            Regex regexSet = new Regex("^[0-9]*$");
            bool at = false;
            if (N.Text == null || N.Text == "" || N.Text == " ")
            {
                Exp.Text = "Пустое множество";
                Res.Text = "";
                at = false;
            }
            else
            {
                at = regexSet.IsMatch(N.Text);
            }

            if (at == false)
            {
                Exp.Text = "Можно только цифорки вводить";
                Res.Text = "";
            }
            else
            {
                int n = int.Parse(N.Text);
                List<string> list = CodeGray.generateGray(n);
                string result = "";
                int i = 1;
                foreach (var item in list)
                {
                    result += i +" "+ item + "\n";
                    i++;
                }
                Res.Text = result;
                Exp.Text = null;

            }
        }
    }
}