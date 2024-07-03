using System.Collections.Generic;
using muzickeStolice.Model;

namespace muzickeStolice.Controller
{
    public static class TemporaryUserStorage
    {
        private static List<(Korisnik User, string VerificationCode)> _temporaryUsers = new List<(Korisnik User, string VerificationCode)>();

        public static void AddTemporaryUser(Korisnik user, string verificationCode)
        {
            _temporaryUsers.Add((user, verificationCode));
        }
        public static Korisnik? GetKorisnikByEmailAndCode(string email, string verificationCode)
        {
            var userTuple = _temporaryUsers.Find(u => u.User.Email == email && u.VerificationCode == verificationCode);
            if (userTuple != default)
            {
                return userTuple.User;
            }
            return null;
        }

        public static bool VerifyUser(string email, string verificationCode)
        {
            var userTuple = _temporaryUsers.Find(u => u.User.Email == email && u.VerificationCode == verificationCode);
            if (userTuple != default)
            {
                KorisnikController.Create(userTuple.User.Email, userTuple.User.KorisnickoIme, userTuple.User.Lozinka, userTuple.User.Tip);
                _temporaryUsers.Remove(userTuple);
                return true;
            }
            return false;
        }
    }
}
