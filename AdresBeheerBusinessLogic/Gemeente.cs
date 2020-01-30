using AdresBeheerExceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdresBeheerBusinessLogic
{
    public class Gemeente 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NIScode { get; private set; }
        [Required]
        public int versieNr { get; private set; }
        public string gemeentenaam { get; private set; }
        public List<Straat> straten {get; private set;}

        public Gemeente(int NIScode, int versieNr, string gemeentenaam)
        {
            this.NIScode = NIScode;
            this.versieNr = versieNr;
            this.gemeentenaam = gemeentenaam;
            this.straten = new List<Straat>();
        }
        public void updateGemeentenaam(string gemeentenaam)
        {
            if (String.Equals(this.gemeentenaam, gemeentenaam)) throw new GemeenteException("updateGemeente - gemeentenaam is equel");
            this.gemeentenaam = gemeentenaam;
            versieNr++;
        }
        public void voegStraatToe(Straat straat)
        {
            if (straat == null) throw new GemeenteException("voegStraatToe - straat is null");
            if (!this.straten.Contains(straat))
            {
                this.straten.Add(straat);
                versieNr++;
            }
            else throw new GemeenteException("voegStraatToe - straat bestaat reeds");
        }
        public void verwijderStraat(Straat straat)
        {
            if (straat == null) throw new GemeenteException("verwijderStraat - straat is null");
            if (this.straten.Contains(straat))
            {
                this.straten.Remove(straat);
                versieNr++;
            }
            else throw new GemeenteException("verwijderStraat - straat bestaat niet");
        }
        public int geefAantalStraten()
        {
            return straten.Count;
        }
        public IList<Straat> geefStraten()
        {
            return new ReadOnlyCollection<Straat>(this.straten);
        }

        public override bool Equals(object obj)
        {
            return obj is Gemeente gemeente &&
                   NIScode == gemeente.NIScode &&
                   versieNr == gemeente.versieNr;
        }

        public override int GetHashCode()
        {
            var hashCode = 1808661509;
            hashCode = hashCode * -1521134295 + NIScode.GetHashCode();
            hashCode = hashCode * -1521134295 + versieNr.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return $"Gemeente(Id:{NIScode},VersieNr:{versieNr},naam:{gemeentenaam},aantal straten:{geefAantalStraten()})";
        }
    }
}
