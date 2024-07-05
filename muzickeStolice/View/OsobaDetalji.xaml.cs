using muzickeStolice.Controller;
using muzickeStolice.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for OsobaDetalji.xaml
    /// </summary>
    public partial class OsobaDetalji : Window
    {
        Osoba o;

        public OsobaDetalji(int osobaId)
        {
            InitializeComponent();
            Osoba? os = OsobaController.Read(osobaId);
            if (os == null)
                this.Close();
            o = os;

            if (o.SlikaUrl != null && o.SlikaUrl != "")
                slika.Source = new BitmapImage(new Uri(o.SlikaUrl));
            else
                slika.Source = new BitmapImage(new Uri("https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png"));

            tbIme.Text = o.Ime;
            tbPrezime.Text = o.Prezime;
            tbBiografija.Text = o.Biografija;
            datumRodjenjaPicker.SelectedDate = new DateTime(o.DatumRodjenja, new TimeOnly(0));

            foreach (Bend b in BendController.GetBendoviSaOsobom(osobaId))
            {
                Label bendLabel = new Label();
                bendLabel.Content = b.Naziv;
                bendLabel.Cursor = Cursors.Hand;
                bendLabel.Foreground = Brushes.Blue;
                bendLabel.MouseDown += (i, m) =>
                {
                    BendDetalji bd = new BendDetalji(b.Id);
                    bd.Show();
                    this.Close();
                };
                spBendovi.Children.Add(bendLabel);
            }

            foreach (MuzickoDelo md in MuzickoDeloController.GetDelaOdOsobe(osobaId))
            {
                Label deloLabel = new Label();
                deloLabel.Content = md.Naziv;
                deloLabel.Cursor = Cursors.Hand;
                deloLabel.Foreground = Brushes.Blue;
                deloLabel.MouseDown += (i, m) =>
                {
                    MuzickoDeloDetalji mdd = new MuzickoDeloDetalji(md.Id);
                    mdd.Show();
                    this.Close();
                };
                spDela.Children.Add(deloLabel);
            }
        }
    }
}
