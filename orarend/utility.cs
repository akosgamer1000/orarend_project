using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Animation;

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
        Dictionary<string, string> tanár = new Dictionary<string, string>()
        {
            {"Matek","Bárczay Emese"},
            {"info","Bálint István" },
            {"Labor","Rogán Antal" },
            {"Tesi","Kovács Miklos" },
            {"Web","Bálint István" },
            {"Prog","Bálint István" },
            {"Angol","Csillag Anna" },
            {"Töri","Bálint György" },
            {"Fizika","György Miklós" },
            {"Biosz","Miklós György" },
            {"Magyar","Hajagos Máté" },
            {"Hálózat","Bálint István" }

        };

        public List<List<Ora>> Beolvasas(string fajlname)
        {
            List<List<Ora>> orarend = new List<List<Ora>>();
            Ora o = null;
            List<Ora> n = new List<Ora>();
            StreamReader sr = new StreamReader(fajlname);
            while (!sr.EndOfStream)
            {
                string[] orak = sr.ReadLine().Split(';');
                
                   
                    o = new Ora(orak[0], orak[1], new Terem(orak[2], orak[3]));
                
                n.Add(o);
            }
            orarend.Add(n);
            sr.Close();
            return orarend;
        }


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
                        Console.WriteLine($" az i = {i}");
                        Nap u = new Nap(i, napior(list[i-1],s,i));
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
                        Console.WriteLine("hellok");
                        Nap u = new Nap(i, napior3(list[i - 1], s));
                        s.Orarend.Add(u);

                    }
                    break;
            }
        }
        public List<Nap> converter(List<List<Ora>> orarendLista)
        {
            List<Nap> napok = new List<Nap>();

           

            for (int i = 0; i < orarendLista.Count; i++)
            {
                if (i < 5)
                {
                    Nap nap = new Nap(i, orarendLista[i]);
                    napok.Add(nap);
                }
                
            }

            return napok;
        }
    
        public void váltás(Osztaly s,Osztaly k , Osztaly i) 
        {
            for (int l = 0; l < 5; l++)
            {

            switch (melyosz)
            {
                case 0:
                  
                    
                        if (!File.Exists("lementettA.txt")){
                            feltöltés(s, k, i);
                            lementés(s, "lementettA.txt");
                        }
                        else
                        {
                            var p = Beolvasas("lementettA.txt");
                            s.Orarend=converter(p);

                        }
                        melyosz++;
                        break;
                case 1:
                        melyosz++;
                        if (!File.Exists("lementettB.txt"))
                        {
                         
                            feltöltés(k,s,i);
                            lementés(k, "lementettB.txt");

                        }
                        else
                        {
                            var p = Beolvasas("lementettB.txt");
                            k.Orarend = converter(p);
                        }

                        Console.WriteLine(melyosz);
                        break;
                case 2:
                    
                        
                        if (!File.Exists("lementettC.txt"))
                        {
                            
                            feltöltés(i, k, s);
                            lementés(i, "lementettC.txt");
                        }
                        else
                        {
                            var p = Beolvasas("lementettC.txt");
                            i.Orarend = converter(p);
                        }
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
     
        public List<Ora> napior(int caunt,Osztaly s,int p)
        {

			List<Ora> list = new List<Ora>();
			
           
            
            Random r= new Random();
           
            int randomcaunt = caunt;
            
            for ( int i = 0;i < randomcaunt; i++)
            {
				string kiválaszott = "s";
				List <string> l = new List<string>(elérhetőtantárgyak);
                int rx = r.Next(elérhetőtantárgyak.Count);
                while (!l.Contains(kiválaszott))
                {
					 rx = r.Next(elérhetőtantárgyak.Count);
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
               

                list.Add(new Ora(kiválaszott, tanár[kiválaszott], new Terem(classroom,szake)));
                
                
                   
                
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
          
            for (int i = 0; i < randomcaunt; i++)
            {
				string kiválaszott = "s";
				List<string> l = new List<string>(elérhetőtantárgyak);
                int rx = r.Next(elérhetőtantárgyak.Count);
                while (!l.Contains(kiválaszott))
                {
					rx = r.Next(elérhetőtantárgyak.Count);
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
                list.Add(new Ora(kiválaszott, tanár[kiválaszott], new Terem(classroom, szake)));
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
           
            for (int i = 0; i < randomcaunt; i++)
            {
				string kiválaszott = "s";
				List<string> l = new List<string>(elérhetőtantárgyak);
                int rx = r.Next(elérhetőtantárgyak.Count);
                while (!l.Contains(kiválaszott))
                {
					rx = r.Next(elérhetőtantárgyak.Count);
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
                list.Add(new Ora(kiválaszott, tanár[kiválaszott], new Terem(classroom, szake)));
                classroomselector(s);
                check(s);
            }

            return list;

        }
        public void lementés(Osztaly a,string url)
        {
            var k = new StreamWriter(url);
            foreach(var p in a.Orarend)
            {
               foreach(var g in p.Orak)
                {
                    k.WriteLine(g);
                }
            }
            k.Close();

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

