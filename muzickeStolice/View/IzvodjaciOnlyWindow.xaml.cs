using Microsoft.EntityFrameworkCore;
using muzickeStolice.Controller;
using muzickeStolice.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace muzickeStolice.View
{
    public partial class IzvodjaciOnlyWindow : Window
    {
        public List<Osoba> SelectedOsobe { get; private set; }

        public IzvodjaciOnlyWindow(List<Osoba> selectedOsobe)
        {
            InitializeComponent();
            SelectedOsobe = selectedOsobe ?? new List<Osoba>();
            LoadIzvodjaci();
        }

        private void LoadIzvodjaci()
        {
            var osobe = DatabaseController.database.Osobe.Include(o => o.Izvodjac).ToList();
            var izvodjaciView = osobe.Select(o => new
            {
                ID = o.Izvodjac.ID,
                Name = $"{o.Ime} {o.Prezime}",
                Description = o.Biografija
            }).ToList();

            IzvodjaciDataGrid.ItemsSource = izvodjaciView;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = IzvodjaciDataGrid.SelectedItems;

            foreach (var item in selectedItems)
            {
                int id = (int)item.GetType().GetProperty("ID").GetValue(item, null);
                var osoba = DatabaseController.database.Osobe.Include(o => o.Izvodjac).FirstOrDefault(o => o.Izvodjac.ID == id);
                if (osoba != null && !SelectedOsobe.Contains(osoba))
                {
                    SelectedOsobe.Add(osoba);
                }
            }

            DialogResult = true;
            Close();
        }
    }
}
