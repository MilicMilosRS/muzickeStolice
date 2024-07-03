using muzickeStolice.Controller;
using muzickeStolice.Model;
using muzickeStolice.View;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace muzickeStolice
{
    public partial class CreateMuzickoDeloWindow : Window
    {
        private List<Izvodjac> selectedIzvodjaci = new List<Izvodjac>();

        public CreateMuzickoDeloWindow()
        {
            InitializeComponent();
            LoadZanrovi();
        }

        private void LoadZanrovi()
        {
            var zanrovi = DatabaseController.database.Zanrovi.ToList();
            ZanrComboBox.ItemsSource = zanrovi;
            ZanrComboBox.DisplayMemberPath = "Naziv";
        }

        private void SelectIzvodjaciButton_Click(object sender, RoutedEventArgs e)
        {
            IzvodjaciWindow izvodjaciWindow = new IzvodjaciWindow(selectedIzvodjaci);
            if (izvodjaciWindow.ShowDialog() == true)
            {
                selectedIzvodjaci = izvodjaciWindow.SelectedIzvodjaci;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string naziv = NazivTextBox.Text;
            Zanr selectedZanr = ZanrComboBox.SelectedItem as Zanr;
            string opis = OpisTextBox.Text;
            TipDela selectedTip = (TipDela)Enum.Parse(typeof(TipDela), ((ComboBoxItem)TipComboBox.SelectedItem).Content.ToString());
            string slikeLinkoviText = SlikeLinkoviTextBox.Text;

            if (selectedZanr == null)
            {
                MessageBox.Show("Please select a Zanr.");
                return;
            }

            var slikeLinkovi = slikeLinkoviText.Split(',').ToList();

            MuzickoDelo newMuzickoDelo = MuzickoDeloController.Create(naziv, selectedZanr, opis, selectedTip);
            newMuzickoDelo.slikeLinkovi = slikeLinkovi;
            foreach (var izvodjac in selectedIzvodjaci)
            {
                newMuzickoDelo.Izvodjaci.Add(izvodjac);
            }

            MessageBox.Show("Music work created successfully!");
            this.Close();
        }
    }
}
