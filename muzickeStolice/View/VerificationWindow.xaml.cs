using System.Windows;
using muzickeStolice.Controller;

namespace muzickeStolice.View
{
    public partial class VerificationWindow : Window
    {
        private string _email;
        private string _korisnickoIme;
        private string _lozinka;
        private int _pokusaji;


        public VerificationWindow(string email,string korisnickoIme, string lozinka)
        {
            InitializeComponent();
            _email = email;
            _korisnickoIme = korisnickoIme;
            _lozinka = lozinka;
            _pokusaji = 0;
        }

        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            string verificationCode = VerificationCodeTextBox.Text;

            if (TemporaryUserStorage.VerifyUser(_email, verificationCode))
            {
                MessageBox.Show("Verifikacija uspesna");
                KorisnikController.Create(_email,_korisnickoIme,_lozinka,Model.TipKorisnika.Obican);
            }
            else
            {
                _pokusaji++;

                MessageBox.Show("Verifikacioni kod je neuspesan.");
                if (_pokusaji>= 3)
                {
                    MessageBox.Show("Premašen je broj dozvoljenih pokušaja.");
                    Close(); 
                }
            }
        }
    }
}
