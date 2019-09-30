using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyon
{
    public class HashMapChain
    {
        public IlAgaci ilAgaci;
        public LinkedHashEntry[] tablo;
        public int boyut;

        public HashMapChain(IlAgaci ilAgaci,List<Otel> oteller)
        {
            this.ilAgaci = ilAgaci;
            BoyutAyarla();

            tablo = new LinkedHashEntry[boyut];
            for (int i = 0; i < boyut; i++)
                tablo[i] = null;

            for (int i = 0; i < oteller.Count; i++)
            {
                VeriEkle(oteller[i]);
            }

        }


        public void BoyutAyarla()
        {
            List<IlDugumu> ilDugumleri = new List<IlDugumu>();

            ilAgaci.InOrder();

            ilDugumleri = ilAgaci.DugumleriYazdir();

            boyut = ilDugumleri.Count;
        }

        int GetKeyValue(string ilAdi)
        {
            List<IlDugumu> ilDugumu = new List<IlDugumu>();

            ilAgaci.InOrder();

            ilDugumu = ilAgaci.DugumleriYazdir();

            int key = -1;

            for (int i = 0; i < ilDugumu.Count; i++)
            {
                if (ilDugumu[i].ilAdi == ilAdi)
                {
                    key = i;
                }
            }

            return key;
        }

        public void VeriEkle(Otel otel)
        { 
            int hash = GetKeyValue(otel.il);

            if (tablo[hash] == null)
                tablo[hash] = new LinkedHashEntry(otel.adi, otel);
            else
            {
                LinkedHashEntry entry = tablo[hash];
                while (entry.sonraki != null && entry.anahtar != otel.adi)
                    entry = entry.sonraki;
                if (entry.anahtar == otel.adi)
                    entry.otelBilgileri = otel;
                else
                    entry.sonraki = new LinkedHashEntry(otel.adi, otel);
            }
        }

        public List<Otel> VeriAl(string ilIsmi)
        {
            int hash = GetKeyValue(ilIsmi);
            List<Otel> oteller = new List<Otel>();
  
            if (tablo[hash] == null)
                return null;
            else
            {
                LinkedHashEntry entry = tablo[hash];

                while (entry != null)
                {
                    oteller.Add(entry.otelBilgileri);
                    entry = entry.sonraki;
                }
                    
            }

            return oteller;
        }

        public List<Otel> VeriAl(string ilIsmi, string ilceIsmi)
        {
            List<Otel> tempOteller = new List<Otel>();
            List<Otel> oteller = new List<Otel>();
            oteller = VeriAl(ilIsmi);


            for (int i = 0; i < oteller.Count; i++)
            {
                if (oteller[i].ilce == ilceIsmi)
                {
                    tempOteller.Add(oteller[i]);

                }
            }

            return tempOteller;
        }

        public List<Otel> PuanliIlVeriAl(string ilIsmi)
        {
            int hash = GetKeyValue(ilIsmi);
            List<Otel> oteller = new List<Otel>();

            if (tablo[hash] == null)
                return null;
            else
            {
                LinkedHashEntry entry = tablo[hash];

                while (entry != null)
                {
                    oteller.Add(entry.otelBilgileri);
                    entry = entry.sonraki;
                }

            }
            
            PuanliHeap puanliHeap = new PuanliHeap(oteller.Count);

            for (int i = 0; i < oteller.Count; i++)
                puanliHeap.Insert(oteller[i]);

            return puanliHeap.SiraliVeriAl();
        }

        public List<Otel> PuanliIlIlceVeriAl(string ilIsmi, string ilceIsmi)
        {
            
                List<Otel> tempOteller = new List<Otel>();
                List<Otel> oteller = new List<Otel>();
                oteller = VeriAl(ilIsmi);


                for (int i = 0; i < oteller.Count; i++)
                {
                    if (oteller[i].ilce == ilceIsmi)
                    {
                        tempOteller.Add(oteller[i]);

                    }
                }

                PuanliHeap puanliHeap = new PuanliHeap(oteller.Count);

                for (int i = 0; i < oteller.Count; i++)
                    puanliHeap.Insert(oteller[i]);

                return puanliHeap.SiraliVeriAl();
            

        }


        public List<Otel> YildizliIlVeriAl(string ilIsmi)
        {
            int hash = GetKeyValue(ilIsmi);
            List<Otel> oteller = new List<Otel>();

            if (tablo[hash] == null)
                return null;
            else
            {
                LinkedHashEntry entry = tablo[hash];

                while (entry != null)
                {
                    oteller.Add(entry.otelBilgileri);
                    entry = entry.sonraki;
                }

            }

            YildizliHeap yildizliHeap = new YildizliHeap(oteller.Count);

            for (int i = 0; i < oteller.Count; i++)
                yildizliHeap.Insert(oteller[i]);

            return yildizliHeap.SiraliVeriAl();

        }

        public List<Otel> YildizliIlIlceVeriAl(string ilIsmi, string ilceIsmi)
        {
            List<Otel> tempOteller = new List<Otel>();
            List<Otel> oteller = new List<Otel>();
            oteller = VeriAl(ilIsmi);

            for (int i = 0; i < oteller.Count; i++)
            {
                if (oteller[i].ilce == ilceIsmi)
                {
                    tempOteller.Add(oteller[i]);

                }
            }

            YildizliHeap yildizliHeap = new YildizliHeap(oteller.Count);

            for (int i = 0; i < oteller.Count; i++)
                yildizliHeap.Insert(oteller[i]);

            return yildizliHeap.SiraliVeriAl();


        }






    }
}
