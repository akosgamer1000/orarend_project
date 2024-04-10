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
        List<int> list = new List<int>() {5,5,5,5,5 };
        List<string> elérhetőtantárgyak;
        int melyosz = 0;


        public void feltöltés(Osztaly s)
        {
			elérhetőtantárgyak = new List<string>();
			fel(s);
            classroomselector(s);
           
            for(int i = 1; i < 6; i++)
            {
                Nap u = new Nap(i, napior(list[i-1],s));
                s.Orarend.Add(u);
               
            }
        }
        public void váltás(Osztaly s,Osztaly k , Osztaly i) 
        {
            for (int l = 0; l < 5; l++)
            {

            switch (melyosz)
            {
                case 0:
                    feltöltés(s);
                    melyosz++;
                    break;
                case 1:
                    feltöltés(k);
                    melyosz++;
                    break;
                case 2:
                    feltöltés(i);
                        melyosz++;
                    break;
            }
            }
        }
        public void fel(Osztaly s)
        {
            foreach(KeyValuePair<string,int> kvp in s.Oraszam)
            {
                if (!elérhetőtantárgyak.Contains(kvp.Key))
                {
                    elérhetőtantárgyak.Add(kvp.Key);
                }
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
        public void napiorswitch(Osztaly s, Osztaly k, Osztaly i)
        {
            switch (melyosz)
            {
                case 0:
                    napior(s,c);
                    break;
            }
        }
        public List<Ora> napior(int caunt,Osztaly s)
        {
            Random r= new Random();
            List<Ora> list = new List<Ora>();
            int randomcaunt = caunt;
            
            for( int i = 0;i < randomcaunt; i++)
            {
                
                int rx = r.Next(elérhetőtantárgyak.Count);
                string kiválaszott = elérhetőtantárgyak[rx];
                s.Oraszam[kiválaszott]--;
                list.Add(new Ora(kiválaszott, "tanár", new Terem(kiválaszott,"szak")));
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
