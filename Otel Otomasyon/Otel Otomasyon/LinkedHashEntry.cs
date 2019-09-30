using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyon
{
    public class LinkedHashEntry
    {
        public string anahtar;
        public Otel otelBilgileri;
        public LinkedHashEntry sonraki;

        public LinkedHashEntry(string anahtar, Otel otel)
        {
            this.anahtar = anahtar;
            this.otelBilgileri = otel;
            this.sonraki = null;
        }
    }
}
