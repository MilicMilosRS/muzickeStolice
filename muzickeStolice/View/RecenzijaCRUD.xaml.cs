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
    /// Interaction logic for RecenzijaCRUD.xaml
    /// </summary>
    public partial class RecenzijaCRUD : Window
    {
        Recenzija recenzija;
        Ocena ocena;

        public RecenzijaCRUD(Ocena o)
        {
            InitializeComponent();

            ocena = o;

            Recenzija? r = RecenzijaController.Read(o);
            if (r != null)
                recenzija = r;
            else
                recenzija = RecenzijaController.Create(o, "");

            tbTekst.Text = recenzija.Tekst;
            if (recenzija.Prihvacena)
                lStanje.Content += " Prihvacena";
            else
                lStanje.Content += " Nije prihvacena";
        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            Recenzija? r = RecenzijaController.Read(ocena);
            if (r != null)
                RecenzijaController.Delete(ocena);
            Close();
        }

        private void bPostavi_Click(object sender, RoutedEventArgs e)
        {
            Recenzija? r = RecenzijaController.Read(ocena);
            if (r != null)
                RecenzijaController.Update(ocena, tbTekst.Text);
            Close();
        }
    }
}
