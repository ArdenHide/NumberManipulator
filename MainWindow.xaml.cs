using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NumberManipulator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Exit(object sender, RoutedEventArgs e)
    {
        Core.Exit();
    }

    private void Clear(object sender, RoutedEventArgs e)
    {
        Core.Clear(display);
    }

    private void Remove(object sender, RoutedEventArgs e)
    {
        Core.RemoveLast(display);
    }

    private void PrintButtonText(object sender, RoutedEventArgs e)
    {
        Core.PrintButtonText(display, (Button)sender);
    }

    private void Calculate(object sender, RoutedEventArgs e)
    {
        Core.Calculate(display, (Button)sender);
    }
}
