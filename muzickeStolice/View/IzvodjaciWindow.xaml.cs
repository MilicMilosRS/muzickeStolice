using muzickeStolice.Controller;
using muzickeStolice.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace muzickeStolice
{
    public partial class IzvodjaciWindow : Window
    {
        public List<Izvodjac> SelectedIzvodjaci { get; private set; } = new List<Izvodjac>();

        public IzvodjaciWindow(List<Izvodjac> selectedIzvodjaci)
        {
            InitializeComponent();
            LoadIzvodjaci();
            SelectedIzvodjaci = selectedIzvodjaci;
        }

        private void LoadIzvodjaci()
        {
            var izvodjaci = DatabaseController.database.Izvodjaci.ToList();
            IzvodjaciDataGrid.ItemsSource = izvodjaci;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedIzvodjaci = IzvodjaciDataGrid.SelectedItems.Cast<Izvodjac>().ToList();
            this.DialogResult = true;
            this.Close();
        }
    }
}
