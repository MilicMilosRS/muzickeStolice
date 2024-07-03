using System;
using System.Windows;
using muzickeStolice.Controller;
using muzickeStolice.Model;

namespace muzickeStolice.View
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string korisnickoIme = UsernameTextBox.Text;
            string lozinka = PasswordBox.Password;

            try
            {
                string verificationCode = Guid.NewGuid().ToString();

                EmailService.SendVerificationEmail(email, verificationCode);

                TemporaryUserStorage.AddTemporaryUser(new Korisnik(email, korisnickoIme, lozinka, TipKorisnika.Obican), verificationCode);

                MessageBox.Show("Email je poslat, pogledajte mail za verifikacioni kod.");

                VerificationWindow verificationWindow = new VerificationWindow(email,korisnickoIme,lozinka);
                verificationWindow.ShowDialog();

                Korisnik? verifiedUser = VerificationController.Verify(email, verificationCode);
                if (verifiedUser != null)
                {
                    MessageBox.Show("Verifikacija uspesna");
                }
                else
                {
                    MessageBox.Show("Verifikacija neuspesna.");
                }

                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
