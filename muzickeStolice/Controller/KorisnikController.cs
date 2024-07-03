using muzickeStolice.Model;
using System;
using System.Collections.Generic;

namespace muzickeStolice.Controller
{
    static public class KorisnikController
    {
        static public Korisnik? Ulogovani;
        static public Korisnik? Read(string email)
        {
            foreach (Korisnik k in DatabaseController.database.Korisnici)
                if (k.Email == email)
                    return k;
            return null;
        }

        static public Korisnik? ReadKorIme(string korisnickoIme)
        {
            foreach (Korisnik k in DatabaseController.database.Korisnici)
                if (k.KorisnickoIme == korisnickoIme)
                    return k;
            return null;
        }

        static public Korisnik Create(string email, string korisnickoIme, string lozinka, TipKorisnika tip)
        {
            if (Read(email) != null)
                throw new ArgumentException("Email je vec zauzet");
            if (ReadKorIme(korisnickoIme) != null)
                throw new ArgumentException("Korisnicko ime je vec zauzeto");
            Korisnik k = new Korisnik(email, korisnickoIme, lozinka, tip);
            DatabaseController.database.Korisnici.Add(k);
            DatabaseController.database.SaveChanges();
            return k;
        }

        static public void Update(string email, Korisnik k2)
        {
            Korisnik? k = Read(email);
            if (k == null)
                return;
            k.Lozinka = k2.Lozinka;
            k.Tip = k2.Tip;
            DatabaseController.database.SaveChanges();
        }

        static public void Delete(string email)
        {
            Korisnik? k = Read(email);
            if (k == null)
                return;
            DatabaseController.database.Korisnici.Remove(k);
            DatabaseController.database.SaveChanges();
        }

        static public Korisnik? Login(string email, string lozinka)
        {
            Korisnik? k = Read(email);
            if (k != null && k.Lozinka == lozinka)
            {
                Ulogovani = k;
                return k;
            }
            return null;
        }
    static private List<Korisnik> FlattenAndSortScoreMap(Dictionary<int, List<Korisnik>> scoreMap)
    {
        List<Korisnik> flattenedList = new List<Korisnik>();

        foreach (var scoreEntry in scoreMap.OrderByDescending(entry => entry.Key))
        {
            flattenedList.AddRange(scoreEntry.Value);
        }

        return flattenedList;
    }
    static public List<Korisnik> EvaluateUsers(Korisnik ja)
    {
        Dictionary<int, List<Korisnik>> scoreMap = new Dictionary<int, List<Korisnik>>();

        foreach (Korisnik k in DatabaseController.database.Korisnici.Where(k => k != ja))
        {
            int score = 0;

            List<Ocena> oceneJa = OcenaController.getOcenaForKorisnik(ja.Email);
            List<Ocena> oceneK = OcenaController.getOcenaForKorisnik(k.Email);

            foreach (Ocena oJa in oceneJa)
            {
                foreach (Ocena oK in oceneK)
                {
                    if (oJa.Primalac == oK.Primalac)
                    {
                        int razlika = Math.Abs(oJa.Vrednost - oK.Vrednost);

                        if (razlika == 0)
                            score += 3;
                        else if (razlika == 1)
                            score += 2;
                        else if (razlika == 2)
                            score += 1;
                        else if (razlika == 3)
                            score += 0;
                        else if (razlika == 4)
                            score -= 1;
                    }
                }
            }

            bool foundMatchingZanr = false;
            foreach (Plejlista pJa in PlejlistaController.getKorisnikPlejliste(ja.Email))
            {
                if (foundMatchingZanr)
                    break;

                foreach (Plejlista pK in PlejlistaController.getKorisnikPlejliste(k.Email))
                {
                    if (pJa.Zanr == pK.Zanr)
                    {
                        score += 10;
                        foundMatchingZanr = true;
                        break;
                    }
                }
            }

            if (!scoreMap.ContainsKey(score))
                scoreMap[score] = new List<Korisnik>();

            scoreMap[score].Add(k);
        }
        List<Korisnik> sortedUsers = FlattenAndSortScoreMap(scoreMap);

        return sortedUsers;
    }
}
}
