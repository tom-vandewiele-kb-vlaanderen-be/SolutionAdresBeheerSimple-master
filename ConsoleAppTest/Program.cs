using AdresBeheerBusinessLogic;
using AdresBeheerManager;
using System;
using System.Collections.Generic;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Gemeente g1 = new Gemeente(10051, 1, "Zele");
            //Gemeente g2 = new Gemeente(10052, 1, "Gent");
            Adresbeheerder m = new Adresbeheerder();
            //m.VoegGemeenteToe(10052,"Gent");            

           //Dictionary<string, object> attr = new Dictionary<string, object>();
           //attr.Add("NIScode", 10051);
           //attr.Add("gemeentenaam", "Berlare");
           //m.UpdateGemeente(attr);


           //m.VoegStraatToe("dorpstraat",10051);
           //m.VoegStraatToe("molenstraat", 10052);
            Dictionary<string, object> attrS = new Dictionary<string, object>();
            attrS.Add("NIScode", 10052);
            attrS.Add("straatnaam", "Kleine dorpstraat");
            attrS.Add("straatID", 1);
            //m.UpdateStraat(attrS);

            Straat s1 = m.SelecteerStraat(2);
            Gemeente t2 = m.SelecteerGemeente(10052);

            Console.WriteLine("end");
        }
    }
}
