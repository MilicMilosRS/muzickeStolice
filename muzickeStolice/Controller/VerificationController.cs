using muzickeStolice.Model;

namespace muzickeStolice.Controller
{
    public static class VerificationController
    {
        public static Korisnik? Verify(string email, string verificationCode)
        {
            bool isVerified = TemporaryUserStorage.VerifyUser(email, verificationCode);

            if (isVerified)
            {
                return TemporaryUserStorage.GetKorisnikByEmailAndCode(email, verificationCode);
            }
            else
            {
                return null;
            }
        }
    }
}
