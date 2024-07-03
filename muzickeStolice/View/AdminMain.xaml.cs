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
