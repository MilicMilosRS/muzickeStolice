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
    /// Interaction logic for BendDetalji.xaml
    /// </summary>
    public partial class BendDetalji : Window
    {
        public BendDetalji(int bendId)
        {
            InitializeComponent();

            Bend? b = BendController.Read(bendId);
            if (b == null)
                this.Close();

            tbNaziv.Text = b.Naziv;
            tbOpis.Text = b.Opis;
            datumOsnivanjaPicker.SelectedDate = new DateTime(b.DatumOsnivanja, new TimeOnly(0));

            foreach (Osoba o in b.clanovi)
            {
                Label clanLabel = new Label();
                clanLabel.Content = o.Ime + " " + o.Prezime;
                clanLabel.Cursor = Cursors.Hand;
                clanLabel.Foreground = Brushes.Blue;
                clanLabel.MouseDown += (i, m) =>
                {
                    OsobaDetalji od = new OsobaDetalji(o.ID);
                    od.Show();
                    this.Close();
                };
                spClanovi.Children.Add(clanLabel);
            }

            foreach (MuzickoDelo md in MuzickoDeloController.GetDelaOdBenda(bendId))
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

            foreach (string url in b.slikeLinkovi)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(url));
                spSlike.Children.Add(img);
            }
        }
    }
}
