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
    /// Interaction logic for UrednikMain.xaml
    /// </summary>
    public partial class UrednikMain : Window
    {
        public UrednikMain()
        {
            InitializeComponent();
        }

        private void bPretraga_Click(object sender, RoutedEventArgs e)
        {
            PretragaSadrzaja ps = new PretragaSadrzaja();
            ps.Show();
        }

        private void bRecenzije_Click(object sender, RoutedEventArgs e)
        {
            List<Recenzija> rec = RecenzijaController.GetNeprihvacene();
            PregledRecenzija pr = new PregledRecenzija(rec);
            pr.Show();
        }

        private void bOsobe_Click(object sender, RoutedEventArgs e)
        {
            AdminOsoba ao = new AdminOsoba();
            ao.Show();
            this.Close();
        }

        private void bBendovi_Click(object sender, RoutedEventArgs e)
        {
            AdminMuzickiBend ab = new AdminMuzickiBend();
            ab.Show();
            this.Close();
        }

        private void bDela_Click(object sender, RoutedEventArgs e)
        {
            AdminMuzickoDelo amd = new AdminMuzickoDelo();
            amd.Show();
            this.Close();
        }
    }
}
