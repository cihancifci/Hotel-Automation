using MetroFramework.Forms;
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
    public partial class UIOtelBilgiForm : MetroForm
    {
        Otel otel;
        MusteriIslemleri MusteriIslemleri = new MusteriIslemleri();
        public UIOtelBilgiForm(Otel otel)
        {
            this.otel = otel;
            InitializeComponent();
        }
        

        private void UIOtelBilgiForm_Load(object sender, EventArgs e)
        {

            txt_OtelAdi.Text = otel.adi;
            txt_OtelAdres.Text = otel.adres;
            txt_OdaTipi.Text = otel.odaTipi;
            txt_OtelEPosta.Text = otel.ePosta;
            txt_OtelTelefon.Text = otel.telefon;
            txt_YildizSayisi.Text = otel.yildizSayisi.ToString();
            txt_Il.Text = otel.il;
            txt_Ilce.Text = otel.ilce;
            txt_OdaSayisi.Text = otel.odaSayisi.ToString();
            txt_Puan.Text = otel.otelPuani.ToString();
            List<string> yorumlar = new List<string>();
            yorumlar = otel.YorumlariAl();
 
            string[] yorumSatir = new string[3];

            for (int i = 0; i < yorumlar.Count; i++)
            {

                yorumSatir = yorumlar[i].Split('\n');

                for (int j = 0; j < yorumSatir.Length; j++)
                {
                    lstbx_Yorumlar.Items.Add(yorumSatir[j]);
                }


            }


        }



        private void btn_Degerlendir_Click(object sender, EventArgs e)
        {
            UIOtelYorumPuanVerme uIOtelYorumPuanVerme = new UIOtelYorumPuanVerme(otel);

            uIOtelYorumPuanVerme.ShowDialog();
        }
    }
}
