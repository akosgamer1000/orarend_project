using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace orarend
{
    internal class Nap
    {
        private string napNev; //pl.: Hétfő
        private List<Ora> orak = new List<Ora>();

        public Nap(int napSorszam, List<Ora> orak)
        {
            switch (napSorszam)
            {
                case 1:
                    this.napNev = "Hétfő";
                    break;
                case 2:
                    this.napNev = "Kedd";
                    break;
                case 3:
                    this.napNev = "Szerda";
                    break;
                case 4:
                    this.napNev = "Csütörtök";
                    break;
                case 5:
                    this.napNev = "Péntek";
                    break;
                case 6:
                    this.napNev = "Szombat";
                    break;
                case 7:
                    this.napNev = "Vasárnap";
                    break;
                default:
                    this.napNev = "Error";
                    break;
            }
            this.orak = orak;
        }

        public string NapNev { get => napNev; set => napNev = value; }
        internal List<Ora> Orak { get => orak; set => orak = value; }

        public override string ToString()
        {
            return $"A {this.napNev}i órarend: {orak}";
        }
    }
}
