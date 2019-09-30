using Otel_Otomasyon.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyon
{
    public class MusteriIslemleri
    {
        private OtelAgaci otelAgaci = new OtelAgaci();
        private HashMapChain hashMap;
        private IlAgaci ilAgaci;
        private OtelRepository otelRepository = new OtelRepository();
        private YorumcuRepository yorumcuRepository = new YorumcuRepository();

        public MusteriIslemleri()
            
        {
            List<Otel> oteller = new List<Otel>();

            oteller = otelRepository.OtelleriAl();
            yorumcuRepository.YorumculariAl(oteller);

            OtelAgaciOlustur(oteller);

            ilAgaci = new IlAgaci(oteller);
            

            hashMap = new HashMapChain(ilAgaci,oteller);
            
        }

        public List<Otel> IsimOtelListele()
        {
            List<Otel> tempOtelList = new List<Otel>();
            otelAgaci.InOrder();

            for(int i = 0; i < otelAgaci.DugumleriYazdir().Count; i++)
            {
                tempOtelList.Add(otelAgaci.DugumleriYazdir()[i].otel);
            }

            return tempOtelList;
            
        }
        
        public List<Otel> ArananIlListele(string il)
        {
            return hashMap.VeriAl(il);
        }

        public List<Otel> ArananIlIlceListele(string il,string ilce)
        {
            return hashMap.VeriAl(il, ilce);
        }

        public void OtelePuanVer(int puan,Otel otel)
        {

            otel.oySayisi += 1;

            otel.otelPuani = (otel.otelPuani * (otel.oySayisi-1) + puan) / otel.oySayisi;



            otelRepository.OtelGuncelle(otel);
            
           
        }

        public void OteleYorumYap(Yorumcu yorumYapan, Otel otel)
        {

            otel.yorumcu.YorumEkle(yorumYapan);

            yorumcuRepository.YorumEkle(yorumYapan);

        }

        public List<Otel> PuanIlListele(string il)
        {
            return hashMap.PuanliIlVeriAl(il);
        }

        public List<Otel> PuanIlIlceListele(string il,string ilce)
        {
           return  hashMap.PuanliIlIlceVeriAl(il,ilce);

        }

        public List<Otel> IlYildizliListele(string il)
        {
            return hashMap.YildizliIlVeriAl(il);
        }

        public List<Otel> IlIlceYildizliListele(string il,string ilce)
        {
            return hashMap.YildizliIlIlceVeriAl(il, ilce);

        }

        public List<Otel> PreInPostListele(string duzey)
        {
            List<Otel> tempOtelList = new List<Otel>();

            if (duzey == "Pre order")
            {
                otelAgaci.PreOrder();
                for (int i = 0; i < otelAgaci.DugumleriYazdir().Count; i++)
                {
                    tempOtelList.Add(otelAgaci.DugumleriYazdir()[i].otel);
                }

                return tempOtelList;

            }

            else if (duzey == "In order")
            {
                otelAgaci.InOrder();

                for (int i = 0; i < otelAgaci.DugumleriYazdir().Count; i++)
                {
                    tempOtelList.Add(otelAgaci.DugumleriYazdir()[i].otel);
                }

                return tempOtelList;
            }

            else if (duzey == "Post order")
            {
                otelAgaci.PostOrder();

                for (int i = 0; i < otelAgaci.DugumleriYazdir().Count; i++)
                {
                    tempOtelList.Add(otelAgaci.DugumleriYazdir()[i].otel);
                }

                return tempOtelList;

            }

            else { System.Windows.Forms.MessageBox.Show("Yanlış Değer girdiniz"); return null; }
        }

        public int DerinlikHesapla()
        {
            return otelAgaci.DerinlikBul()-1;
        }

        public int OtelSayisiAl()
        {
            return otelAgaci.OtelSayisiGoster();
        }

        public List<string> YorumlariAl(Otel otel)
        {
            Otel tmpOtel = new Otel();

            tmpOtel = otelAgaci.OtelAra(otel.adi).otel;

            return tmpOtel.YorumlariAl();
        }

        public void OtelAgaciOlustur(List<Otel> oteller)
        {

            for (int i = 0; i < oteller.Count; i++)
            {
                otelAgaci.Ekle(oteller[i]);
            }
        }

        public Otel OtelBul(string otelAdi)
        {
            return otelAgaci.OtelAra(otelAdi).otel;
        }
    }
}
