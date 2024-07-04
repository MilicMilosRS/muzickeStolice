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

            pretraga();
            AzurirajElemente();
        }

        ObservableCollection<Osoba> prikazaneOsobe = new ObservableCollection<Osoba>();
        ObservableCollection<Bend> prikazaniBendovi = new ObservableCollection<Bend>();

        private void AzurirajElemente()
        {
            if (KorisnikController.Ulogovani == null)
            {
                bLogin.Visibility = Visibility.Visible;
                bLogout.Visibility = Visibility.Collapsed;
                lLogin.Content = "Niste ulogovani";
            }
            else
            {
                bLogin.Visibility = Visibility.Collapsed;
                bLogout.Visibility = Visibility.Visible;
                lLogin.Content = "Ulogovani kao: " + KorisnikController.Ulogovani.Email;
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
        }

        private void dgOsobe_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            dgBendovi.UnselectAll();

        }

        private void dgBendovi_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            dgOsobe.UnselectAll();

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
    }
}
