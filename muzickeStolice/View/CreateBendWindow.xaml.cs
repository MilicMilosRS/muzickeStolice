using muzickeStolice.Controller;
using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace muzickeStolice.View
{
    public partial class CreateBendWindow : Window
    {
        private List<Osoba> selectedClanovi = new List<Osoba>();

        public CreateBendWindow()
        {
            InitializeComponent();
        }

        private void SelectClanoviButton_Click(object sender, RoutedEventArgs e)
        {
            IzvodjaciOnlyWindow izvodjaciWindow = new IzvodjaciOnlyWindow(selectedClanovi);
            if (izvodjaciWindow.ShowDialog() == true)
            {
                selectedClanovi = izvodjaciWindow.SelectedOsobe;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string naziv = NazivTextBox.Text;
            string opis = OpisTextBox.Text;
            DateOnly datumOsnivanja = DateOnly.FromDateTime(DatumOsnivanjaPicker.SelectedDate.Value);
            string slikeLinkoviText = SlikeLinkoviTextBox.Text;

            var slikeLinkovi = slikeLinkoviText.Split(',').ToList();

            Bend newBend = BendController.Create(naziv, opis, datumOsnivanja, selectedClanovi);
            newBend.slikeLinkovi = slikeLinkovi;

            MessageBox.Show("Bend created successfully!");
            this.Close();
        }
    }
}
