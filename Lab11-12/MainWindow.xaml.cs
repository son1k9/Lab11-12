using Lab11_12.View;
using System.Windows;

namespace Lab11_12;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Countries_Click(object sender, RoutedEventArgs e)
    {
        Window window = new CountryView() { Owner = this };
        window.Show();
    }

    private void Roles_Click(object sender, RoutedEventArgs e)
    {
        Window window = new CityView() { Owner = this };
        window.Show();
    }
}