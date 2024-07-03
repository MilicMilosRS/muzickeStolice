using System.Collections.Generic;
using System.Linq;
using System.Windows;
using muzickeStolice.Model;
using Microsoft.EntityFrameworkCore;
using muzickeStolice.Controller;

namespace muzickeStolice.View
{
    public partial class IzvodjaciWindow : Window
    {
        public List<Izvodjac> SelectedIzvodjaci { get; private set; }

        public IzvodjaciWindow(List<Izvodjac> selectedIzvodjaci)
        {
            InitializeComponent();
            SelectedIzvodjaci = selectedIzvodjaci ?? new List<Izvodjac>();
            LoadIzvodjaci();
        }

        private void LoadIzvodjaci()
        {
            // Load Osoba and Bend separately
            var osobe = DatabaseController.database.Osobe.Include(o => o.Izvodjac).ToList();
            var bendovi = DatabaseController.database.Bendovi.Include(b => b.Izvodjac).ToList();

            // Combine the results into a unified view model
            var izvodjaciView = new List<dynamic>();

            izvodjaciView.AddRange(osobe.Select(o => new
            {
                ID = o.Izvodjac.ID,
                Type = "Osoba",
                Name = $"{o.Ime} {o.Prezime}",
                Description = o.Biografija
            }));

            izvodjaciView.AddRange(bendovi.Select(b => new
            {
                ID = b.Izvodjac.ID,
                Type = "Bend",
                Name = b.Naziv,
                Description = b.Opis
            }));

            IzvodjaciDataGrid.ItemsSource = izvodjaciView;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = IzvodjaciDataGrid.SelectedItems;

            foreach (var item in selectedItems)
            {
                int id = (int)item.GetType().GetProperty("ID").GetValue(item, null);
                var izvodjac = DatabaseController.database.Izvodjaci.FirstOrDefault(i => i.ID == id);
                if (izvodjac != null && !SelectedIzvodjaci.Contains(izvodjac))
                {
                    SelectedIzvodjaci.Add(izvodjac);
                }
            }

            DialogResult = true;
            Close();
        }
    }
}
