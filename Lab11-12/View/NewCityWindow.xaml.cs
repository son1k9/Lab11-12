using System.Windows;

namespace Lab11_12.View
{
    /// <summary>
    /// Interaction logic for NewCityWindow.xaml
    /// </summary>
    public partial class NewCityWindow : Window
    {
        public NewCityWindow()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
