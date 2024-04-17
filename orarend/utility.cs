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
                        if (!File.Exists("lementettA.txt")){
                        
                        lementés(s, "lementettA.txt");
                        }
                    break;
                case 1:
                    feltöltés(k,s,i);
                    melyosz++;
						//lementés(k, "lementettB.txt");
						break;
                case 2:
                    feltöltés(i,k,s);
                        melyosz++;
						//lementés(i, "lementettC.txt");
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
			try
            {
                Console.WriteLine("Belépés");
                var k = new StreamReader("lementettA.txt");
                if (k.ReadLine() == null)
                { 
                    throw new Exception(); 
                }
                    for(int l = 1; l < p; l++)
                    {
                        for(int c = 0; c < 5; c++)
                        {
                            k.ReadLine();
                        }        
                    }
                    for (int sor = 0; sor < 5; sor++)
                {
                    var o = k.ReadLine().Split(';');
                    list.Add(new Ora(o[0], o[1], new Terem(o[2], o[3])));
                }
                k.Close();
                return list;

            }
            catch (Exception e) {
            
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
