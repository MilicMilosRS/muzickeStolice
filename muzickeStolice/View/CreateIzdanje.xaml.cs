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
    /// Interaction logic for CreateIzdanje.xaml
    /// </summary>
    public partial class CreateIzdanje : Window
    {
        MuzickoDelo delo;

        public CreateIzdanje(MuzickoDelo md)
        {
            InitializeComponent();
            cbTip.ItemsSource = Enum.GetValues(typeof(TipIzdanja)).Cast<TipIzdanja>();
            cbTip.SelectedIndex = 0;
            delo = md;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime? dt = datetimePicker.SelectedDate;
            if(dt == null)
            {
                MessageBox.Show("Odaberite datum");
                return;
            }

            IzdanjeController.Create(delo.Id, (TipIzdanja)cbTip.SelectedItem, DateOnly.FromDateTime(dt.Value));
            this.Close();
        }
    }
}
