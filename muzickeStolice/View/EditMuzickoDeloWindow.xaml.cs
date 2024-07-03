using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using muzickeStolice.Controller;
using muzickeStolice.Model;

namespace muzickeStolice.View
{
    public partial class EditMuzickoDeloWindow : Window
    {
        private MuzickoDelo muzickoDelo;

        public EditMuzickoDeloWindow(MuzickoDelo selectedDelo)
        {
            InitializeComponent();
            muzickoDelo = selectedDelo;
            LoadZanrovi();
            LoadDetails();
        }

        private void LoadZanrovi()
        {
            var zanrovi = DatabaseController.database.Zanrovi.ToList();
            ZanrComboBox.ItemsSource = zanrovi;
            ZanrComboBox.DisplayMemberPath = "Naziv";
        }

        private void LoadDetails()
        {
            NazivTextBox.Text = muzickoDelo.Naziv;
            ZanrComboBox.SelectedItem = muzickoDelo.ZanrDela;
            OpisTextBox.Text = muzickoDelo.Opis;
            TipComboBox.SelectedItem = muzickoDelo.Tip.ToString();
            SlikeLinkoviTextBox.Text = string.Join(",", muzickoDelo.slikeLinkovi);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            muzickoDelo.Naziv = NazivTextBox.Text;
            muzickoDelo.ZanrDela = ZanrComboBox.SelectedItem as Zanr;
            muzickoDelo.Opis = OpisTextBox.Text;
            muzickoDelo.Tip= (TipDela)Enum.Parse(typeof(TipDela), ((ComboBoxItem)TipComboBox.SelectedItem).Content.ToString());
            muzickoDelo.slikeLinkovi = SlikeLinkoviTextBox.Text.Split(',').ToList();

            DatabaseController.database.SaveChanges();
            MessageBox.Show("Music work updated successfully!");
            this.Close();
        }
    }
}
