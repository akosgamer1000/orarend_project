﻿using System;
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
        Dictionary<string, string> map = new Dictionary<string, string>()
        {
            {"info","018" },
            {"Labor","09" },
            {"Tesi","004" },
            {"Web","018" },
            {"Prog","018" },
            {"Hálózat","018" },

        };



        public void feltöltés(Osztaly s, Osztaly k,Osztaly l)
        {
			elérhetőtantárgyak = new List<string>();
			fel(s);
            classroomselector(s);

            switch (melyosz)
            {
                case 0:
                for(int i = 1; i < 6; i++)
                {
                    Nap u = new Nap(i, napior(list[i-1],s));
                    s.Orarend.Add(u);
               
                }
                    break;
                case 1:
                    for (int i = 1; i < 6; i++)
                    {
                        Nap u = new Nap(i, napior2(list[i - 1], s));
                        s.Orarend.Add(u);

                    }
                    break;
                case 2:
                    for (int i = 1; i < 6; i++)
                    {
                        Nap u = new Nap(i, napior3(list[i - 1], s));
                        s.Orarend.Add(u);

                    }
                    break;
            }
        }
        public void váltás(Osztaly s,Osztaly k , Osztaly i) 
        {
            for (int l = 0; l < 5; l++)
            {

            switch (melyosz)
            {
                case 0:
                    feltöltés(s,k,i);
                    melyosz++;
                    break;
                case 1:
                    feltöltés(k,s,i);
                    melyosz++;
                    break;
                case 2:
                    feltöltés(i,k,s);
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
     
        public List<Ora> napior(int caunt,Osztaly s)
        {
            Random r= new Random();
            List<Ora> list = new List<Ora>();
            int randomcaunt = caunt;
            string kiválaszott = "";
            for ( int i = 0;i < randomcaunt; i++)
            {
                List <string> l = new List<string>(elérhetőtantárgyak);
                int rx = r.Next(elérhetőtantárgyak.Count);
                while (!l.Contains(kiválaszott))
                {
                    kiválaszott = elérhetőtantárgyak[rx];
                }
                l.Remove(kiválaszott);
                string szake = "normal";
                if(map.ContainsKey(kiválaszott))
                {
                    szake = "szak";
                    classroom = map[kiválaszott];
                }
                s.Oraszam[kiválaszott]--;
                list.Add(new Ora(kiválaszott, "tanár", new Terem(classroom,szake)));
                classroomselector(s);
                check(s);
            }

            return list;


        }
        public List<Ora> napior2(int caunt, Osztaly s)
        {
            Random r = new Random();
            List<Ora> list = new List<Ora>();
            int randomcaunt = caunt;
            string kiválaszott = "";
            for (int i = 0; i < randomcaunt; i++)
            {
                List<string> l = new List<string>(elérhetőtantárgyak);
                int rx = r.Next(elérhetőtantárgyak.Count);
                while (!l.Contains(kiválaszott))
                {
                    kiválaszott = elérhetőtantárgyak[rx];
                }
                l.Remove(kiválaszott);
                string szake = "normal";
                if (map.ContainsKey(kiválaszott))
                {
                    szake = "szak";
                    classroom = map[kiválaszott];
                }
                s.Oraszam[kiválaszott]--;
                list.Add(new Ora(kiválaszott, "tanár", new Terem(classroom, szake)));
                classroomselector(s);
                check(s);
            }

            return list;


        }
        public List<Ora> napior3(int caunt, Osztaly s)
        {
            Random r = new Random();
            List<Ora> list = new List<Ora>();
            int randomcaunt = caunt;
            string kiválaszott = "";
            for (int i = 0; i < randomcaunt; i++)
            {
                List<string> l = new List<string>(elérhetőtantárgyak);
                int rx = r.Next(elérhetőtantárgyak.Count);
                while (!l.Contains(kiválaszott))
                {
                    kiválaszott = elérhetőtantárgyak[rx];
                }
                l.Remove(kiválaszott);
                string szake = "normal";
                if (map.ContainsKey(kiválaszott))
                {
                    szake = "szak";
                    classroom = map[kiválaszott];
                }
                s.Oraszam[kiválaszott]--;
                list.Add(new Ora(kiválaszott, "tanár", new Terem(classroom, szake)));
                classroomselector(s);
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
