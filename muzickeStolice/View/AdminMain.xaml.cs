using System.Linq;
using System.Windows;
using muzickeStolice.Controller;
using muzickeStolice.Model;

namespace muzickeStolice.View
{
    public partial class AdminMain : Window
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        private void MuzickiBandButton_Click(object sender, RoutedEventArgs e)
        {
            AdminMuzickiBend bendWindow = new AdminMuzickiBend();
            bendWindow.ShowDialog();
        }

        private void MuzickoDeloButton_Click(object sender, RoutedEventArgs e)
        {
            AdminMuzickoDelo deloWindow = new AdminMuzickoDelo();
            deloWindow.ShowDialog();
        }

        private void OsobaButton_Click(object sender, RoutedEventArgs e)
        {
            AdminOsoba osobaWindow = new AdminOsoba();
            osobaWindow.ShowDialog();
        }
    }
}
