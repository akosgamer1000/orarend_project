using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orarend
{
    internal class Terem
    {
        private string name;
        private string tipe;

        public Terem(string name, string tipe)
        {
            this.name = name;
            this.tipe = tipe;
        }

        public string Name { get => name; set => name = value; }
        public string Tipe { get => tipe; set => tipe = value; }
    }
}
