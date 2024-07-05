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
    /// Interaction logic for PretragaSadrzaja.xaml
    /// </summary>
    public partial class PretragaSadrzaja : Window
    {
        public PretragaSadrzaja()
        {
            InitializeComponent();
            dgOsobe.ItemsSource = prikazaneOsobe;
            dgBendovi.ItemsSource = prikazaniBendovi;
            dgDela.ItemsSource = prikazanaDela;

            pretraga();
            AzurirajElemente();
        }

        ObservableCollection<Osoba> prikazaneOsobe = new ObservableCollection<Osoba>();
        ObservableCollection<Bend> prikazaniBendovi = new ObservableCollection<Bend>();
        ObservableCollection<MuzickoDelo> prikazanaDela = new ObservableCollection<MuzickoDelo>();

        private void AzurirajElemente()
        {
            if (KorisnikController.Ulogovani == null)
            {
                bLogin.Visibility = Visibility.Visible;
                bLogout.Visibility = Visibility.Collapsed;
                lLogin.Content = "Niste ulogovani";
                bAdmin.Visibility = Visibility.Collapsed;
                bGlasanje.Visibility = Visibility.Collapsed;
            }
            else
            {
                bLogin.Visibility = Visibility.Collapsed;
                bLogout.Visibility = Visibility.Visible;
                bGlasanje.Visibility = Visibility.Visible;
                lLogin.Content = "Ulogovani kao: " + KorisnikController.Ulogovani.Email;
                if (KorisnikController.Ulogovani.Tip == TipKorisnika.Urednik ||
                    KorisnikController.Ulogovani.Tip == TipKorisnika.Admin)
                    bAdmin.Visibility = Visibility.Visible;
            }
            UpdateLayout();
        }

        private void pretraga()
        {
            List<Osoba> osobe = OsobaController.Filter(tbPretraga.Text, null);
            prikazaneOsobe.Clear();
            foreach (Osoba o in osobe)
                prikazaneOsobe.Add(o);

            List<Bend> bendovi = BendController.Filter(tbPretraga.Text);
            prikazaniBendovi.Clear();
            foreach (Bend b in bendovi)
                prikazaniBendovi.Add(b);

            foreach (MuzickoDelo md in DatabaseController.database.MuzickaDela)
                if (md.Naziv.ToLower().Contains(tbPretraga.Text.ToLower()))
                    prikazanaDela.Add(md);
        }

        private void bPretrazi_Click(object sender, RoutedEventArgs e)
        {
            pretraga();
        }

        private void bDetalji_Click(object sender, RoutedEventArgs e)
        {
            if(dgOsobe.SelectedItem != null)
            {
                Osoba o = (Osoba)dgOsobe.SelectedItem;
                OsobaDetalji od = new OsobaDetalji(o.ID);
                od.Show();
            }
            else if(dgBendovi.SelectedItem != null)
            {
                Bend b = (Bend)dgBendovi.SelectedItem;
                BendDetalji bd = new BendDetalji(b.Id);
                bd.Show();
            }
            else if(dgDela.SelectedItem != null)
            {
                MuzickoDelo md = (MuzickoDelo)dgDela.SelectedItem;
                MuzickoDeloDetalji mdd = new MuzickoDeloDetalji(md.Id);
                mdd.Show();
            }
        }

        private void dgOsobe_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            dgBendovi.UnselectAll();
            dgDela.UnselectAll();
        }

        private void dgBendovi_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            dgOsobe.UnselectAll();
            dgDela.UnselectAll();
        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.ShowDialog();
            AzurirajElemente();
        }

        private void bLogout_Click(object sender, RoutedEventArgs e)
        {
            KorisnikController.Ulogovani = null;
            AzurirajElemente();
        }

        private void bAdmin_Click(object sender, RoutedEventArgs e)
        {
            Korisnik? k = KorisnikController.Ulogovani;
            if(k != null)
            {
                if(k.Tip == TipKorisnika.Admin)
                {
                    AdminMain am = new AdminMain();
                    am.ShowDialog();
                }
                else if (k.Tip == TipKorisnika.Urednik)
                {
                    UrednikMain um = new UrednikMain();
                    um.ShowDialog();
                }
            }
        }

        private void bGlasanje_Click(object sender, RoutedEventArgs e)
        {
            Glasanje g = new Glasanje();
            g.Show();
        }

        private void dgDela_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            dgBendovi.UnselectAll();
            dgOsobe.UnselectAll();
        }
    }
}
