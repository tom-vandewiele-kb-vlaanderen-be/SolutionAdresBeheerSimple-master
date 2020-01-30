using AdresBeheerBusinessLogic;
using System;
using System.Collections.Generic;

namespace AdresBeheerRepository
{
    public interface IAdresRepository : IDisposable
    {
        void addGemeente(Gemeente gemeente);
        Gemeente getGemeente(int id);
        Gemeente getGemeente(string gemeentenaam);
        void updateGemeente(Gemeente gemeente);
        void addStraat(Straat straat);
        Straat getStraat(int id);
        Straat getStraat(string straatnaam, string gemeentenaam);
        void updateStraat(Straat straat);
        void addAdres(Adres adres);
        Adres getAdres(int id);
        Adres getAdres(string straatnaam, string gemeentenaam, string huisnummer);
        void updateAdres(Adres adres);
        IEnumerable<Straat> getStratenGemeente(string gemeentenaam);
        IEnumerable<Adres> getAdressenStraat(int straatID);
    }
}
