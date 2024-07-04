using muzickeStolice.Controller;
using muzickeStolice.Model;
using System;
using System.Windows;

namespace muzickeStolice.View
{
    /// <summary>
    /// Interaction logic for EditOsobaWindow.xaml
    /// </summary>
    public partial class EditOsobaWindow : Window
    {
        private Osoba _osoba;

        public EditOsobaWindow(Osoba osoba)
        {
            InitializeComponent();
            _osoba = osoba;
            LoadOsobaDetails();
        }

        private void LoadOsobaDetails()
        {
            ImeTextBox.Text = _osoba.Ime;
            PrezimeTextBox.Text = _osoba.Prezime;
            BiografijaTextBox.Text = _osoba.Biografija;
            DatumRodjenjaPicker.SelectedDate = _osoba.DatumRodjenja.ToDateTime(TimeOnly.MinValue);
            SlikaUrlTextBox.Text = _osoba.SlikaUrl;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _osoba.Ime = ImeTextBox.Text;
            _osoba.Prezime = PrezimeTextBox.Text;
            _osoba.Biografija = BiografijaTextBox.Text;
            _osoba.DatumRodjenja = DateOnly.FromDateTime(DatumRodjenjaPicker.SelectedDate.Value);
            _osoba.SlikaUrl = SlikaUrlTextBox.Text;

            DatabaseController.database.SaveChanges();
            this.Close();
        }
    }
}
