using MetroFramework.Forms;
using Otel_Otomasyon.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Otomasyon
{
    public partial class UIOtelYorumPuanVerme : MetroForm
    {
        public UIOtelYorumPuanVerme(Otel otel)
        {
            this.otel = otel;
            InitializeComponent();
        }
        Otel otel;
        Musteri musteri;
        MusteriRepository musteriRepository;
        MusteriIslemleri musteriIslemleri;

        private void UIOtelYorumPuanVerme_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Dogrula_Click(object sender, EventArgs e)
        {
            musteriRepository = new MusteriRepository();

            musteri = musteriRepository.MusteriBul(txt_MusteriTCKimlikNo.Text);

            if(musteri != null)
            {
                txt_MusteriTCKimlikNo.Enabled = false;
                btn_Dogrula.Enabled = false;
                chck_Puan.Visible = true;
                chck_Yorum.Visible = true;
                btn_Gonder.Visible = true;

            }

            else
            {
                GorunumuBasaDondur();
            }

        }

        private void GorunumuBasaDondur()
        {
            chck_Puan.Visible = false;
            chck_Yorum.Visible = false;
            btn_Gonder.Visible = false;
            grp_Puan.Visible = false;
            grp_Yorum.Visible = false;

        }

        private void chck_Yorum_CheckedChanged(object sender, EventArgs e)
        {
            grp_Yorum.Visible = !grp_Yorum.Visible;
        }

        private void chck_Puan_CheckedChanged(object sender, EventArgs e)
        {
            grp_Puan.Visible = !grp_Puan.Visible;
        }


        private void btn_Gonder_Click(object sender, EventArgs e)
        {
            if(grp_Puan.Visible && grp_Yorum.Visible)
            {
                musteriIslemleri = new MusteriIslemleri();
                Yorumcu yorumcu = new Yorumcu();

                yorumcu.tamAdi = txt_İsimSoyisim.Text;
                yorumcu.yorum = txt_Yorum.Text;
                yorumcu.konakladigiOtelID = musteri.konakladigiOtelID;
                yorumcu.ePosta = txt_EPosta.Text;
                yorumcu.tcKimlikNo = musteri.tcKimlikNo;

                musteriIslemleri.OtelePuanVer(int.Parse(cmb_Puan.Text), otel);

                musteriIslemleri.OteleYorumYap(yorumcu, otel);

                musteriRepository.MusteriSil(musteri);
            }

            else if(grp_Puan.Visible && !grp_Yorum.Visible)
            {
                musteriIslemleri = new MusteriIslemleri();

                musteriIslemleri.OtelePuanVer(int.Parse(cmb_Puan.Text),otel);

                musteriRepository.MusteriSil(musteri);
            }

            else
            {
                musteriIslemleri = new MusteriIslemleri();
                Yorumcu yorumcu = new Yorumcu();

                yorumcu.tamAdi = txt_İsimSoyisim.Text;
                yorumcu.yorum = txt_Yorum.Text;
                yorumcu.konakladigiOtelID = musteri.konakladigiOtelID;
                yorumcu.ePosta = txt_EPosta.Text;
                yorumcu.tcKimlikNo = musteri.tcKimlikNo;

                musteriIslemleri.OteleYorumYap(yorumcu, otel);

                musteriRepository.MusteriSil(musteri);

            }

            this.Close();
        }


    }
}
