using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMySQL
{
    internal class Gyarto
    {
        string nev;
        int darab;
        double maxAr;
        double atlagAr;

        public Gyarto(string nev, int darab, double maxAr, double atlagAr)
        {
            this.nev = nev;
            this.darab = darab;
            this.maxAr = maxAr;
            this.atlagAr = atlagAr;
        }

        public string Nev { get => nev; }
        public int Darab { get => darab; }
        public double MaxAr { get => maxAr; }
        public double AtlagAr { get => atlagAr; }
    }
}
