using System;
using System.Windows;
using muzickeStolice.Controller;
using muzickeStolice.Model;

namespace muzickeStolice.View
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            BendDetalji bd = new BendDetalji(10);
            bd.Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            Korisnik? user = KorisnikController.Login(email, password);

            if (user != null)
            {
                if (user.Tip == TipKorisnika.Obican)
                {

                }  else if(user.Tip == TipKorisnika.Urednik)
                {

                }
                else
                {
                    OpenAdminMain();
                }
            }
            else
            {
                MessageBox.Show("Email ili sifra nisu tacni");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }
        private void OpenAdminMain()
        {
            AdminMain adminMain = new AdminMain();
            adminMain.Show();
            this.Close();
        }
    }
}
