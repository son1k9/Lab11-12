using System.Windows;

namespace Lab11_12.View
{
    /// <summary>
    /// Interaction logic for NewCityWindow.xaml
    /// </summary>
    public partial class NewCountryWindow : Window
    {
        public NewCountryWindow()
        {
            InitializeComponent();
        }

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
