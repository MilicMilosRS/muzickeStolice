using muzickeStolice.Controller;
using muzickeStolice.Model;
using System;
using System.Windows;

namespace muzickeStolice.View
{
    public partial class CreateOsobaWindow : Window
    {
        public CreateOsobaWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string ime = ImeTextBox.Text;
            string prezime = PrezimeTextBox.Text;
            string biografija = BiografijaTextBox.Text;
            DateOnly datumRodjenja = DateOnly.FromDateTime(DatumRodjenjaPicker.SelectedDate.Value);
            string slikaUrl = SlikaUrlTextBox.Text;

            if (string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime) || datumRodjenja == null)
            {
                MessageBox.Show("Popunite potrebna mesta");
                return;
            }

            Osoba o = OsobaController.Create(ime, prezime, biografija, datumRodjenja, slikaUrl);
            o.SlikaUrl = slikaUrl;
            DatabaseController.database.SaveChanges();

            MessageBox.Show("Osoba je uspesno napravljena");
            this.Close();
        }
    }
}
