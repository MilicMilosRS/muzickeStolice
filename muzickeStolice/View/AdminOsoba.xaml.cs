using muzickeStolice.Controller;
using muzickeStolice.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace muzickeStolice.View
{
    /// <summary>
    /// Interaction logic for AdminOsoba.xaml
    /// </summary>
    public partial class AdminOsoba : Window
    {
        public AdminOsoba()
        {
            InitializeComponent();
            LoadOsobe();
        }

        private void LoadOsobe()
        {
            var osobe = DatabaseController.database.Osobe.ToList();
            OsobeDataGrid.ItemsSource = osobe;
        }

        private void CreateOsobaButton_Click(object sender, RoutedEventArgs e)
        {
            CreateOsobaWindow createWindow = new CreateOsobaWindow();
            createWindow.ShowDialog();
            LoadOsobe();
        }

        private void EditOsobaButton_Click(object sender, RoutedEventArgs e)
        {
            if (OsobeDataGrid.SelectedItem is Osoba selectedOsoba)
            {
                EditOsobaWindow editWindow = new EditOsobaWindow(selectedOsoba);
                editWindow.ShowDialog();
                LoadOsobe();
            }
        }
    }
}
