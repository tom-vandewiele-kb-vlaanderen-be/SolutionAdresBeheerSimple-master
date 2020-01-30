using AdresBeheerBusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdresBeheerRepository
{
    public class AdresRepository : IAdresRepository
    {
        private AdresContext ctx;
        public AdresRepository(AdresContext ctx)
        {
            this.ctx = ctx;
        }

        public void addAdres(Adres adres)
        {
            ctx.adressen.Add(adres);
        }

        public void addGemeente(Gemeente gemeente)
        {
            ctx.gemeenten.Add(gemeente);
        }

        public void addStraat(Straat straat)
        {
            ctx.straten.Add(straat);
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        public Adres getAdres(int id)
        {
            return ctx.adressen.Find(id);
        }

        public Adres getAdres(string straatnaam, string gemeentenaam, string huisnummer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Adres> getAdressenStraat(int straatID)
        {
            throw new NotImplementedException();
        }

        public Gemeente getGemeente(int id)
        {
            return ctx.gemeenten.Include(x=>x.straten).FirstOrDefault(x=>x.NIScode==id);
        }

        public Gemeente getGemeente(string gemeentenaam)
        {
            throw new NotImplementedException();
        }

        public Straat getStraat(int id)
        {
            return ctx.straten.Include(x=>x.gemeente).FirstOrDefault(x=>x.straatID==id);
        }

        public Straat getStraat(string straatnaam, string gemeentenaam)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Straat> getStratenGemeente(string gemeentenaam)
        {
            throw new NotImplementedException();
        }

        public void updateAdres(Adres adres)
        {
            ctx.adressen.Update(adres);
        }

        public void updateGemeente(Gemeente gemeente)
        {            
            ctx.gemeenten.Update(gemeente);
        }

        public void updateStraat(Straat straat)
        {
            ctx.straten.Update(straat);
        }
    }
}
