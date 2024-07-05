using muzickeStolice.Controller;
using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace muzickeStolice.View
{
    /// <summary>
    /// Interaction logic for Glasanje.xaml
    /// </summary>
    public partial class Glasanje : Window
    {
        Korisnik k;
        int? godina;

        public class DeloDTO
        {
            private MuzickoDelo md { get; set; }
            public MuzickoDelo getDelo()
            {
                return md;
            }

            public int ID { get; set; }
            public string Naziv { get; set; }

            public DeloDTO(MuzickoDelo m)
            {
                md = m;
                ID = m.Id;
                Naziv = m.Naziv;
            }
        }

        ObservableCollection<DeloDTO> prikazanaDela = new ObservableCollection<DeloDTO>();

        public Glasanje()
        {
            InitializeComponent();
            if (KorisnikController.Ulogovani != null)
                k = KorisnikController.Ulogovani;
            else
                this.Close();

            dg.ItemsSource = prikazanaDela;
        }

        private void AzurirajPodatke()
        {
            lOdabrani.Content = "";

            if (godina == null)
                return;
            GlasZaAlbum? glas = GlasZaAlbumController.Read(k, godina.Value);
            if (glas != null)
                lOdabrani.Content = "Omiljeni album iz ove godine vam je '" + glas.Album.Naziv + "'";

            List<MuzickoDelo> dela = MuzickoDeloController.GetDelaIzGodine(godina.Value);
            prikazanaDela.Clear();
            foreach (MuzickoDelo delo in dela)
                prikazanaDela.Add(new DeloDTO(delo));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            godina = null;
            int god;
            if (int.TryParse(tbGod.Text, out god))
                godina = god;
            AzurirajPodatke();
        }

        private void bGlasaj_Click(object sender, RoutedEventArgs e)
        {
            DeloDTO? delo = (DeloDTO)dg.SelectedItem;
            if (delo != null)
                GlasZaAlbumController.CreateOrUpdate(k, delo.getDelo(), godina.Value);
            else
                MessageBox.Show("Prvo izaberite delo");
            AzurirajPodatke();
        }
    }
}
