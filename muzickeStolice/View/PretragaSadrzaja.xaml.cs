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
        }

        ObservableCollection<Osoba> prikazaneOsobe = new ObservableCollection<Osoba>();
        ObservableCollection<Bend> prikazaniBendovi = new ObservableCollection<Bend>();


        private void bPretrazi_Click(object sender, RoutedEventArgs e)
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

        private void bDetalji_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
