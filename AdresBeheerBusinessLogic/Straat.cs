using AdresBeheerExceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdresBeheerBusinessLogic
{
    public class Straat 
    {
        [Key]
        public int straatID { get; private set; }
        //public int straatStatus { get; private set; }
        [Required]
        public string straatnaam { get; private set; }
        public int versieNr { get; private set; }
        public List<Adres> adressen { get; private set; }
        [Required]
        public Gemeente gemeente { get; private set; }

        public Straat(string straatnaam, Gemeente gemeente)
        {
            this.gemeente = gemeente;
            this.straatnaam = straatnaam;
            this.adressen = new List<Adres>();
            if (gemeente == null) throw new StraatException("Straat constructor - gemeente is null");
            if (!gemeente.geefStraten().Contains(this)) gemeente.voegStraatToe(this);
        }
        public Straat(int straatID, int versieNr, Gemeente gemeente)
        {
            this.straatID = straatID;
            this.versieNr = versieNr;
            this.gemeente = gemeente;
            this.adressen = new List<Adres>();
            if (gemeente == null) throw new StraatException("Straat constructor - gemeente is null");
            if (!gemeente.geefStraten().Contains(this)) gemeente.voegStraatToe(this);
        }
        public Straat(int straatID, int versieNr, string straatnaam, Gemeente gemeente)
        {
            this.straatID = straatID;
            this.versieNr = versieNr;
            this.gemeente = gemeente;
            this.straatnaam = straatnaam;
            this.adressen = new List<Adres>();
            if (gemeente == null) throw new StraatException("Straat constructor - gemeente is null");
            if (!gemeente.geefStraten().Contains(this)) gemeente.voegStraatToe(this);
        }

        private Straat()
        {
            this.adressen = new List<Adres>();
        }

        public void voegAdresToe(Adres adres)
        {
            if (adres == null) throw new StraatException("voegAdresToe - straat is null");
            if (!adres.straat.Equals(this)) throw new StraatException("voegAdresToe - verschillende straten");
            if (!adressen.Contains(adres))
            {
                adressen.Add(adres);
                this.versieNr++;
            }
            else throw new StraatException("voegAdresToe - adres bestaat reeds");
        }
        public void verwijderAdres(Adres adres)
        {
            if (adres == null) throw new StraatException("verwijderAdres - straat is null");
            if (adressen.Contains(adres))
            {
                adressen.Remove(adres);
                this.versieNr++;
            }
            else throw new StraatException("verwijderAdres - adres bestaat niet");
        }
        public void updateStraatnaam(string straatnaam)
        {
            if (String.Equals(this.straatnaam, straatnaam)) throw new StraatException("updateStraatnaam - straatnaam is equal");
            this.straatnaam = straatnaam;
            this.versieNr++;
        }
        public IList<Adres> geefAdressen()
        {
            return new ReadOnlyCollection<Adres>(this.adressen);
        }
        public int geefAantalAdressen()
        {
            return this.adressen.Count;
        }
        public void updateGemeente(Gemeente gemeente)
        {
            if (gemeente == null) throw new StraatException("updateGemeente - gemeente is null");
            if (!this.gemeente.Equals(gemeente))
            {
                gemeente.voegStraatToe(this);
                this.gemeente.verwijderStraat(this);
                this.gemeente = gemeente;
            }
            else throw new StraatException("updateGemeente - gemeente is equal");
        }

        public override bool Equals(object obj)
        {
            return obj is Straat straat &&
                   straatID == straat.straatID &&
                   straatnaam == straat.straatnaam &&
                   versieNr == straat.versieNr;
        }

        public override int GetHashCode()
        {
            var hashCode = -1020771104;
            hashCode = hashCode * -1521134295 + straatID.GetHashCode();
            hashCode = hashCode * -1521134295 + versieNr.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"Straat(Id:{straatID},VersieNr:{versieNr},naam:{straatnaam},aantal adresses:{geefAantalAdressen()})";
        }
    }
}
