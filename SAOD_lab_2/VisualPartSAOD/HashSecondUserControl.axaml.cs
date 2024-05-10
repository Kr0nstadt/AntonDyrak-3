using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Text.RegularExpressions;
using System;
using Hash;
using VisualPartSAOD.ViewModel.Lab2;

namespace VisualPartSAOD;

public partial class HashSecondUserControl : UserControl
{
    public HashSecondUserControl()
    {
        InitializeComponent();
    }
    RandomIntArray array = new RandomIntArray(100);
    string txt = "";
    string txt2 = "";
    public void ButtonClicked1(object source, RoutedEventArgs args)
    {
        int key = Int32.Parse(Box1.Text);
        HashTwoIntArray hash = new HashTwoIntArray(array,50,1,key);
        txt += "Результат поиска : " + hash.SearchRes +"\n";
        txt += hash.ToString();
        SearchRes1.Text = txt;
        txt = "";
    }

    public void ButtonClicked2(object source, RoutedEventArgs args)
    {
        int key = Int32.Parse(Box2.Text);
        HashTwoIntArray hash = new HashTwoIntArray(array, 50, 2, key);
        txt2 += "Результат поиска : " + hash.SearchRes + "\n";
        txt2 += hash.ToString();
        SearchRes2.Text = txt2;
        txt2 = "";
    }
}