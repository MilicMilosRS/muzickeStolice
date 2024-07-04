using muzickeStolice.Controller;
using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace muzickeStolice.View
{
    public partial class EditBendWindow : Window
    {
        private Bend _bend;
        private List<Osoba> selectedClanovi = new List<Osoba>();

        public EditBendWindow(Bend bend)
        {
            InitializeComponent();
            _bend = bend;
            LoadBendDetails();
        }

        private void LoadBendDetails()
        {
            NazivTextBox.Text = _bend.Naziv;
            OpisTextBox.Text = _bend.Opis;
            DatumOsnivanjaPicker.SelectedDate = _bend.DatumOsnivanja.ToDateTime(TimeOnly.MinValue);
            SlikeLinkoviTextBox.Text = string.Join(",", _bend.slikeLinkovi);
            selectedClanovi = _bend.clanovi.ToList();
        }

        private void SelectClanoviButton_Click(object sender, RoutedEventArgs e)
        {
            IzvodjaciOnlyWindow izvodjaciWindow = new IzvodjaciOnlyWindow(selectedClanovi);
            if (izvodjaciWindow.ShowDialog() == true)
            {
                selectedClanovi = izvodjaciWindow.SelectedOsobe;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _bend.Naziv = NazivTextBox.Text;
            _bend.Opis = OpisTextBox.Text;
            _bend.DatumOsnivanja = DateOnly.FromDateTime(DatumOsnivanjaPicker.SelectedDate.Value);
            _bend.slikeLinkovi = SlikeLinkoviTextBox.Text.Split(',').ToList();
            _bend.clanovi = selectedClanovi;

            DatabaseController.database.SaveChanges();
            MessageBox.Show("Bend updated successfully!");
            this.Close();
        }
    }
}
