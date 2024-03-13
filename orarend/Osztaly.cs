using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orarend
{
    internal class Osztaly
    {
        private string nev;
        private char osztalyíTipu;
        //private int evfolyam;
        private List<Nap> orarend;
        private Dictionary<string, int> oraszam;

        public Osztaly(string nev, List<Nap> orarend)
        {
            this.nev = nev;
            this.orarend = orarend; // new List<Nap>();
        }

        public string Nev { get => nev; set => nev = value; }
        public char OsztalyíTipu { get => osztalyíTipu; set => osztalyíTipu = value; }
        //public int Evfolyam { get => evfolyam; set => evfolyam = value; }
        public Dictionary<string, int> Oraszam { get => oraszam; set => oraszam = value; }
        internal List<Nap> Orarend { get => orarend; set => orarend = value; }

        public void  OraszamMegadas()
        {
            //Az óraszámokat itt álítja be a különböző osztályokhoz (még meg kell beszélni), az osztály neve alapján (pl.: 12E --> E)
            switch (this.nev.ToUpper().Last())
            {
                case 'A':
                    this.osztalyíTipu = 'A';
                    this.oraszam = new Dictionary<string, int>();
                        oraszam.Add("Labor", 4);
                        oraszam.Add("Tesi", 4);
                        oraszam.Add("Matek", 4);
                        oraszam.Add("Angol", 3);
                        oraszam.Add("Magyar", 4);
                        oraszam.Add("Töri", 4); 
                        oraszam.Add("Fizika", 1);
                        oraszam.Add("Biosz", 1);
                    break;
                case 'B':
                    this.osztalyíTipu = 'B';
                    this.oraszam = new Dictionary<string, int>();
                    oraszam.Add("Web", 2);
                    oraszam.Add("Tesi", 4);
                    oraszam.Add("Matek", 4);
                    oraszam.Add("Angol", 3);
                    oraszam.Add("Magyar", 4);
                    oraszam.Add("Töri", 4);
                    oraszam.Add("Prog", 2);
                    oraszam.Add("Hálózat", 2);
                    break;
                    break;
                case 'C':
                    this.osztalyíTipu = 'C';
                    this.oraszam = new Dictionary<string, int>();
                    oraszam.Add("Labor", 3);
                    oraszam.Add("Tesi", 4);
                    oraszam.Add("Matek", 4);
                    oraszam.Add("Angol", 2);
                    oraszam.Add("Magyar", 4);
                    oraszam.Add("Töri", 4);
                    oraszam.Add("Fizika", 2);
                    oraszam.Add("Biosz", 2);
                    break;
                    break;
                default:
                    this.osztalyíTipu = 'Z'; // ha nem jó, akkor ezt írja ki
                    break;
            }
        }

        public override string ToString()
        {
            return $"A {this.nev} órarendje: {this.orarend}";
        }

    }

}
