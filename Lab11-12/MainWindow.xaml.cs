using Lab11_12.View;
using System.Windows;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using PdfSharp.Fonts;
using Lab11_12.ViewModel;
using PdfSharp.Drawing.Layout;

namespace Lab11_12;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        GlobalFontSettings.FontResolver = new FileFontResolver();
    }

    private void Countries_Click(object sender, RoutedEventArgs e)
    {
        Window window = new CountryView() { Owner = this };
        window.Show();
        DisableButtons();
    }

    private void Roles_Click(object sender, RoutedEventArgs e)
    {
        Window window = new CityView() { Owner = this };
        window.Show();
        DisableButtons();
    }

    private void DisableButtons()
    {
        Countries.IsEnabled = false;
        Roles.IsEnabled = false;
    }

    public void EnableButtons()
    {
        Countries.IsEnabled = true;
        Roles.IsEnabled = true;
    }

    private void PDF_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Страны и города.";

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XTextFormatter tf = new XTextFormatter(gfx);

            XFont font = new XFont("Verdana", 20);
            XFont font1 = new XFont("Verdana", 16);

            int lastPosition = 0;

            gfx.DrawString("Список стран", font, XBrushes.Black,
                new XRect(0, lastPosition, page.Width, 20),
                XStringFormat.TopLeft);
            foreach(var country in CountryViewModel.Countries) 
            {
                lastPosition += 21;
                gfx.DrawString($"    {country.CountryId} {country.Name} {country.Code}", font1, XBrushes.Black,
                new XRect(0, lastPosition, page.Width, 21),
                XStringFormat.TopLeft);
            }



            lastPosition += 20;

            gfx.DrawString("Список городов", font, XBrushes.Black,
                new XRect(0, lastPosition, page.Width, 20),
                XStringFormat.TopLeft);
            CityViewModel vmCity = new CityViewModel();
            foreach (var cityCountry in vmCity.CitiesWithCountries)
            {
                lastPosition += 21;
                gfx.DrawString($"    {cityCountry.Id} {cityCountry.Name} {cityCountry.Country}", font1, XBrushes.Black,
                new XRect(0, lastPosition, page.Width, 21),
                XStringFormat.TopLeft);
            }

            DateTime dt = DateTime.Now;
            string file = $"..\\..\\..\\Export\\Output-{dt:dd-M-y-H-m-s}.pdf";
            document.Save(file);
            MessageBox.Show("Успех");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}