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
    /// Interaction logic for AdminMuzickoDelo.xaml
    /// </summary>
    public partial class AdminMuzickoDelo : Window
    {
        public AdminMuzickoDelo()
        {
            InitializeComponent();
            LoadMuzickaDela();
        }

        private void LoadMuzickaDela()
        {
            var muzickaDela = DatabaseController.database.MuzickaDela.ToList();
            MuzickaDelaDataGrid.ItemsSource = muzickaDela;
        }

        private void CreateDeloButton_Click(object sender, RoutedEventArgs e)
        {
            CreateMuzickoDeloWindow createWindow = new CreateMuzickoDeloWindow();
            createWindow.ShowDialog();
            LoadMuzickaDela();
        }

        private void EditDeloButton_Click(object sender, RoutedEventArgs e)
        {
            if (MuzickaDelaDataGrid.SelectedItem is MuzickoDelo selectedDelo)
            {
                EditMuzickoDeloWindow editWindow = new EditMuzickoDeloWindow(selectedDelo);
                editWindow.ShowDialog();
                LoadMuzickaDela();
            }
            else
            {
                MessageBox.Show("Selektujte muzicko delo da izmenite.");
            }
        }
    }
}
