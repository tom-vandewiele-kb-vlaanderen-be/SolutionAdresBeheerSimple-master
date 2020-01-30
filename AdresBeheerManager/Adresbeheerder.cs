using System;
using System.Collections.Generic;
using System.Text;
using AdresBeheerBusinessLogic;
using AdresBeheerRepository;

namespace AdresBeheerManager
{
    public class Adresbeheerder //businesslogica
    {
        private AdresContext ctx;
        private IUnitOfWork u;

        public Adresbeheerder()
        {
            this.ctx = new AdresContext();
            this.u = new UnitOfWork(ctx);
        }
        public Gemeente SelecteerGemeente(int id)
        {
            return u.adresRepo.getGemeente(id);
        }
        public void VoegGemeenteToe(int NIScode,string gemeentenaam)
        {
            Gemeente g = new Gemeente(NIScode, 1, gemeentenaam);
            u.adresRepo.addGemeente(g);
            u.Complete();
        }        
        public void UpdateGemeente(IDictionary<string,object> attributen)
        {
            int NIScode = (int)attributen["NIScode"];
            Gemeente g = SelecteerGemeente(NIScode);
            foreach(var a in attributen)
            {
                switch(a.Key)
                {
                    case "gemeentenaam": g.updateGemeentenaam((string)a.Value); break;
                }
            }
            //u.adresRepo.updateGemeente(g);
            u.Complete();
        }

        public Straat SelecteerStraat(int id)
        {
            return u.adresRepo.getStraat(id);
        }
        public void VoegStraatToe(string straatnaam,int NIScode)
        {
            Gemeente g = SelecteerGemeente(NIScode);
            Straat s = new Straat(straatnaam, g);
            u.adresRepo.addStraat(s);
            u.Complete();
        }
        public void UpdateStraat(IDictionary<string, object> attributen)
        {
            int straatid = (int)attributen["straatID"];
            Straat s = SelecteerStraat(straatid);
            Gemeente g;
            foreach (var a in attributen)
            {
                switch (a.Key)
                {
                    case "straatnaam": s.updateStraatnaam((string)a.Value); break;
                    case "NIScode": g = SelecteerGemeente((int)a.Value);
                        s.updateGemeente(g); break;
                }
            }
            u.Complete();
        }

        public Adres SelecteerAdres(int id)
        {
            return u.adresRepo.getAdres(id);
        }
        public void VoegAdresToe()
        {

            u.Complete();
        }
    }
}
