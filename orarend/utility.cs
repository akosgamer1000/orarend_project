using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orarend
{
    internal class utility
    {


        string classroom = "";
        List<int> list = new List<int>() {4,4,4,4,4 };
        List<string> elérhetőtantárgyak;
   
        public void tárgyak(Osztaly s)
        {
            elérhetőtantárgyak = new List<string>();
            foreach(KeyValuePair<string,int> p in s.Oraszam)
            {
                elérhetőtantárgyak.Add(p.Key);
            }
        }

        public void feltöltés(Osztaly s)
        {
            tárgyak(s);
            classroomselector(s);
            for(int i = 1; i < 6; i++)
            {
                Nap u = new Nap(i, napior(list[i-1],s));
                s.Orarend.Add(u);
               
            }
        }

        public void classroomselector(Osztaly s)
        {
            switch (s.Nev)
            {
                case "12A":
                    classroom = "218";
                    break;
                case "12B":
                    classroom = "208";
                    break;
                case "12C":
                    classroom = "202";
                    break;

            }
        }
        public List<Ora> napior(int caunt,Osztaly s)
        {
            Random r= new Random();
            List<Ora> list = new List<Ora>();
            int randomcaunt = caunt - 1;
            s.Oraszam["Matematika"]--;
            list.Add(new Ora("Matematika","tanár",classroom));
            for( int i = 0;i < randomcaunt; i++)
            {
                
                int rx = r.Next(elérhetőtantárgyak.Count);
                string kiválaszott = elérhetőtantárgyak[rx];
                s.Oraszam[kiválaszott]--;
                list.Add(new Ora(kiválaszott, "tanár", classroom));
                check(s);
            }

            return list;


        }
        public void check(Osztaly s)
        {
            foreach(KeyValuePair<string, int> kvp in s.Oraszam)
            {
                if (kvp.Value == 0)
                {
                    elérhetőtantárgyak.Remove(kvp.Key);
                }
            }
           
        }
    }
}
