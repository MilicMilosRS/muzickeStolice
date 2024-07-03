using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for PregledRecenzija.xaml
    /// </summary>
    public partial class PregledRecenzija : Window
    {
        public class RecenzijaDTO
        {
            public Recenzija rec { get; set; }
            public string Delo { get; set; }
            public string Prihvaceno { get; set; }
            public string Ocena { get; set; }

            public RecenzijaDTO(Recenzija r)
            {
                rec = r;
                Ocenljivo primalac = DatabaseController.database.Ocenljivosti.FirstOrDefault(oc => oc.ID == r.primalacId);
                Delo = OcenljivoController.GetNazivDela(primalac);
                Prihvaceno = r.Prihvacena ? "Da" : "Ne";
                Ocena = "";
                for (int i = 0; i < r.Ocena.Vrednost; i++)
                    Ocena += '★';
                for (int i = r.Ocena.Vrednost; i < 5; i++)
                    Ocena += '☆';
            }
        }

        public ObservableCollection<RecenzijaDTO> Recenzije = new ObservableCollection<RecenzijaDTO>();
        public PregledRecenzija(List<Recenzija> rec)
        {
            reloadTable(rec);
            InitializeComponent();
            dg.ItemsSource = Recenzije;
        }

        private void reloadTable(List<Recenzija> rec)
        {
            Recenzije.Clear();
            foreach (Recenzija r in rec)
                Recenzije.Add(new RecenzijaDTO(r));
        }

        private void bPrihvati_Click(object sender, RoutedEventArgs e)
        {
            RecenzijaDTO? dto = (RecenzijaDTO?)dg.SelectedItem;
            if (dto == null)
                return;
            dto.rec.Prihvacena = true;
            DatabaseController.database.SaveChanges();
            List<Recenzija> rec = RecenzijaController.GetNeprihvacene();
            reloadTable(rec);
        }

        private void bDetalji_Click(object sender, RoutedEventArgs e)
        {
            RecenzijaDTO? dto = (RecenzijaDTO?)dg.SelectedItem;
            if (dto == null)
                return;
            MessageBox.Show(dto.rec.Tekst, dto.Ocena);
        }
    }
}
