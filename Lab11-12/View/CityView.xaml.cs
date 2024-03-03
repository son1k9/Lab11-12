using Lab11_12.ViewModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Lab11_12.View;

/// <summary>
/// Interaction logic for CityView.xaml
/// </summary>
public partial class CityView : Window
{
    CityViewModel _cityViewModel = new CityViewModel();

    public CityView()
    {
        InitializeComponent();
        DataContext = _cityViewModel;
        _cityViewModel.PropertyChanged += AutoSizeGridView;
    }

    private void AutoSizeGridView(object? sender, EventArgs e)
    {
        GridView? gridView = lvCity.View as GridView;
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

    private void Window_Closing(object sender, CancelEventArgs e)
    {
        if (Owner is MainWindow window)
        {
            window.EnableButtons();
        }
    }
}
