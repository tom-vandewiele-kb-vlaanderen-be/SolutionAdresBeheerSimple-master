using AdresBeheerExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdresBeheerBusinessLogic
{
    public class Adres 
    {
        [Key]
        public int adresID { get; private set; }
        [Required]
        public string huisnummer { get; private set; }
        public string busnummer { get; private set; }
        public string appartementnummer { get; private set; }
        public string adresLabel { get; private set; }
        [Required]
        public int versieNr { get; private set; }
        [Required]
        public Straat straat { get; private set; }

        public Adres(int adresID, string huisnummer, int versieNr, Straat straat)
        {
            this.adresID = adresID;
            this.huisnummer = huisnummer;
            this.versieNr = versieNr;
            if (straat == null) throw new AdresException("Adres constructor - straat is null");
            this.straat = straat;
            if (!straat.geefAdressen().Contains(this)) straat.voegAdresToe(this);
        }

        private Adres()
        {
        }

        public void updateHuisnummer(string huisnummer)
        {
            if (String.IsNullOrWhiteSpace(huisnummer)) throw new AdresException("updateHuisnummer - huisnummmer is null or empty");
            if (!String.Equals(this.huisnummer, huisnummer))
            {
                this.huisnummer = huisnummer;
                this.versieNr++;
            }
            else throw new AdresException("updateHuisnummer - huisnummmer is equal");
        }
        public void updateBusnummer(string busnummer)
        {
            if (!String.Equals(busnummer, this.busnummer))
            {
                this.busnummer = busnummer;
                this.versieNr++;
            }
            else throw new AdresException("updateBusnummer - busnummer is equal");
        }
        public void updateAppartementnummer(string appartementnummer)
        {
            if (!String.Equals(this.appartementnummer, appartementnummer))
            {
                this.appartementnummer = appartementnummer;
                this.versieNr++;
            }
            else throw new AdresException("updateAppartementnummer is equal");
        }
        public void updateAdreslabel(string adreslabel)
        {
            if (!String.Equals(this.adresLabel, adresLabel))
            {
                this.adresLabel = adresLabel;
                this.versieNr++;
            }
            else throw new AdresException("updateAdresLabel - label is equal");
        }
        public void updateStraat(Straat straat)
        {
            if (straat == null) throw new AdresException("updateStraat - straat is null");
            if (!this.straat.Equals(straat))
            {
                //verwijder adres in huidige straat en voeg toe aan nieuwe straat
                this.straat.verwijderAdres(this);
                straat.voegAdresToe(this);
                this.straat = straat;
                versieNr++;
            }
            else throw new AdresException($"updateStraat - straat is equal");
        }

        public override bool Equals(object obj)
        {
            return obj is Adres adres &&
                   adresID == adres.adresID &&
                   versieNr == adres.versieNr;
        }

        public override int GetHashCode()
        {
            var hashCode = -2091304864;
            hashCode = hashCode * -1521134295 + adresID.GetHashCode();
            hashCode = hashCode * -1521134295 + versieNr.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return $"Adres(Id:{adresID},versieNr:{versieNr},huisnummer:{huisnummer},label:{adresLabel})";
        }
    }
}
