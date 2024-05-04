using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Text.RegularExpressions;
using System;
using Hash;
using VisualPartSAOD.ViewModel.Lab2;

namespace VisualPartSAOD;

public partial class UserControlHash : UserControl
{
    public UserControlHash()
    {
        InitializeComponent();
    }
    RandomIntArray array = new RandomIntArray(100);
    public void ButtonClicked(object source, RoutedEventArgs args)
    {
        int key = Int32.Parse(Box.Text);
        
        SearchRes.Text = new HashTableSearchViewModel(array,19,key).ToString();
    }
}