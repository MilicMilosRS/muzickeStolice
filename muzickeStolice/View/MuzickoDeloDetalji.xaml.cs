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
    /// Interaction logic for MuzickoDeloDetalji.xaml
    /// </summary>
    public partial class MuzickoDeloDetalji : Window
    {
        class OcenaDTO
        {
            public string Tekst { get; set; }
            public int Vrednost { get; set; }

            public OcenaDTO(string tekst, int vrednost)
            {
                Tekst = tekst;
                Vrednost = vrednost;
            }
        }

        MuzickoDelo delo;

        public MuzickoDeloDetalji(int muzickoDeloId)
        {
            InitializeComponent();

            MuzickoDelo? md = MuzickoDeloController.Read(muzickoDeloId);
            if (md == null)
                this.Close();
            delo = md;

            tbNaziv.Text = md.Naziv;
            tbOpis.Text = md.Opis;
            tbZanr.Text = md.ZanrDela.Naziv;

            List<Bend> bendovi = BendController.GetBendoviNaDelu(muzickoDeloId);
            foreach(Bend b in bendovi)
            {
                Label clanLabel = new Label();
                clanLabel.Content = b.Naziv;
                clanLabel.Cursor = Cursors.Hand;
                clanLabel.Foreground = Brushes.Blue;
                clanLabel.MouseDown += (i, m) =>
                {
                    BendDetalji bd = new BendDetalji(b.Id);
                    bd.Show();
                    this.Close();
                };
                spIzvodjaci.Children.Add(clanLabel);
            }

            List<Osoba> osobe = OsobaController.GetOsobeNaDelu(muzickoDeloId);
            foreach (Osoba o in osobe)
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
                spIzvodjaci.Children.Add(clanLabel);
            }

            List<Izdanje> izdanja = IzdanjeController.GetIzdanjaDela(md);
            foreach (Izdanje i in izdanja)
            {
                Label izdanjeLabel = new Label();
                izdanjeLabel.Content = i.DatumIzdanja.ToString() + " " + i.Tip.ToString();
                izdanjeLabel.Cursor = Cursors.Hand;
                izdanjeLabel.Foreground = Brushes.Blue;
                spIzdanja.Children.Add(izdanjeLabel);
            }

            foreach (string url in md.slikeLinkovi)
            {
                if (url == null || url == "")
                    continue;
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(url));
                spSlike.Children.Add(img);
            }

            cbOcena.IsEnabled = false;
            cbOcena.Items.Add(new OcenaDTO("Neocenjen", 0));
            cbOcena.Items.Add(new OcenaDTO("★☆☆☆☆", 1));
            cbOcena.Items.Add(new OcenaDTO("★★☆☆☆", 2));
            cbOcena.Items.Add(new OcenaDTO("★★★☆☆", 3));
            cbOcena.Items.Add(new OcenaDTO("★★★★☆", 4));
            cbOcena.Items.Add(new OcenaDTO("★★★★★", 5));
            cbOcena.DisplayMemberPath = "Tekst";
            cbOcena.SelectedIndex = 0;

            bMojaRecnzija.Visibility = Visibility.Collapsed;
            if(KorisnikController.Ulogovani != null)
            {
                Ocena? ocena = OcenaController.Read(KorisnikController.Ulogovani.Email, md.Ocenljivo);
                if (ocena != null)
                    cbOcena.SelectedIndex = ocena.Vrednost;
                cbOcena.IsEnabled = true;
                cbOcena.SelectionChanged += cbOcena_SelectionChanged;

                bMojaRecnzija.Visibility = Visibility.Visible;

                if (KorisnikController.Ulogovani.Tip == TipKorisnika.Urednik)
                    bIzdanje.Visibility = Visibility.Visible;
            }
        }

        private void cbOcena_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OcenaDTO dto = (OcenaDTO)cbOcena.SelectedItem;
            Ocena? ocena = OcenaController.Read(KorisnikController.Ulogovani.Email, delo.Ocenljivo);

            if (dto.Vrednost == 0)
            {
                if (ocena != null)
                    OcenaController.Delete(KorisnikController.Ulogovani.Email, delo.Ocenljivo);
            }
            else
            {
                if (ocena == null)
                    OcenaController.Create(KorisnikController.Ulogovani.Email, delo.Ocenljivo, dto.Vrednost);
                else
                    OcenaController.Update(KorisnikController.Ulogovani.Email, delo.Ocenljivo, dto.Vrednost);
            }
        }

        private void bMojaRecnzija_Click(object sender, RoutedEventArgs e)
        {
            Ocena? ocena = OcenaController.Read(KorisnikController.Ulogovani.Email, delo.Ocenljivo);
            if(ocena == null)
            {
                MessageBox.Show("Morate prvo oceniti delo");
                return;
            }
            RecenzijaCRUD r = new RecenzijaCRUD(ocena);
            r.Show();
        }

        private void bIzdanje_Click(object sender, RoutedEventArgs e)
        {
            CreateIzdanje ci = new CreateIzdanje(delo);
            ci.ShowDialog();
        }
    }
}
