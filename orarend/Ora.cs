using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orarend
{
    internal class Ora
    {
        private string tantargyNev;
        private string tanar;
        private string terem;

        public Ora(string tantargyNev, string tanar, string terem)
        {
            this.tantargyNev = tantargyNev;
            this.tanar = tanar;
            this.terem = terem;
        }

        public string TantargyNev { get => tantargyNev; set => tantargyNev = value; }
        public string Tanar { get => tanar; set => tanar = value; }
        public string Terem { get => terem; set => terem = value; }

        public override string ToString()
        {
            return $"{this.tantargyNev} óra; {this.terem} teremben, {this.tanar}-al.";
        }
    }
}
