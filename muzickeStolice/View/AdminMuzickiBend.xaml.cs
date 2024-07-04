using muzickeStolice.Controller;
using muzickeStolice.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace muzickeStolice.View
{
    public partial class AdminMuzickiBend : Window
    {
        public AdminMuzickiBend()
        {
            InitializeComponent();
            LoadBendovi();
        }

        private void LoadBendovi()
        {
            var bendovi = DatabaseController.database.Bendovi.ToList();
            BendoviDataGrid.ItemsSource = bendovi;
        }

        private void CreateBendButton_Click(object sender, RoutedEventArgs e)
        {
            CreateBendWindow createWindow = new CreateBendWindow();
            createWindow.ShowDialog();
            LoadBendovi();
        }

        private void EditBendButton_Click(object sender, RoutedEventArgs e)
        {
            if (BendoviDataGrid.SelectedItem is Bend selectedBend)
            {
                EditBendWindow editWindow = new EditBendWindow(selectedBend);
                editWindow.ShowDialog();
                LoadBendovi();
            }
            else
            {
                MessageBox.Show("Please select a bend to edit.");
            }
        }
    }
}
