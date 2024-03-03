using Lab11_12.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Lab11_12.View;

/// <summary>
/// Interaction logic for CountryView.xaml
/// </summary>
public partial class CountryView : Window
{
    CountryViewModel _countryViewModel = new CountryViewModel();

    public CountryView()
    {
        InitializeComponent();
        DataContext = _countryViewModel;
        _countryViewModel.PropertyChanged += AutoSizeGridView;
    }

    private void AutoSizeGridView(object? sender, EventArgs e)
    {
        GridView? gridView = lvCountry.View as GridView;
        if (gridView != null)
        {
            foreach (var column in gridView.Columns)
            {
                if (double.IsNaN(column.Width))
                    column.Width = column.ActualWidth;
                column.Width = double.NaN;
            }
        }
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (Owner is MainWindow window)
        {
            window.EnableButtons();
        }
    }
}
    