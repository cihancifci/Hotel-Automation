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
    public partial class UIMusteriForm : MetroForm
    {

        MusteriIslemleri musteriIslemleri = new MusteriIslemleri();

        public UIMusteriForm()
        {
            InitializeComponent();
        }

        private void UIMusteriForm_Load(object sender, EventArgs e)
        {
            
        }

        private void cmb_Islemler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_Islemler.SelectedIndex == 0)
            {
                txt_OtelIsim.Visible = false;
                txt_OtelIl.Visible = true;
                txt_OtelIlce.Visible = true;

                lbl_OtelAdi.Visible = false;
                lbl_OtelIl.Visible = true;
                lbl_OtelIlce.Visible = true;

                rdo_PuanlaListele.Visible = true;
                rdo_YildizListele.Visible = true;
                rdo_SadeceListele.Visible = true;
            }

            else if (cmb_Islemler.SelectedIndex == 1)
            {
                txt_OtelIsim.Visible = false;
                txt_OtelIl.Visible = true;
                txt_OtelIlce.Visible = false;

                lbl_OtelAdi.Visible = false;
                lbl_OtelIl.Visible = true;
                lbl_OtelIlce.Visible = false;

                rdo_PuanlaListele.Visible = true;
                rdo_YildizListele.Visible = true;
                rdo_SadeceListele.Visible = true;
            }
        

            else if (cmb_Islemler.SelectedIndex == 2)
            {
                txt_OtelIsim.Visible = false;
                txt_OtelIl.Visible = false;
                txt_OtelIlce.Visible = false;

                lbl_OtelAdi.Visible = false;
                lbl_OtelIl.Visible = false;
                lbl_OtelIlce.Visible = false;

                rdo_PuanlaListele.Visible = false;
                rdo_YildizListele.Visible = false;
                rdo_SadeceListele.Visible = false;
            }

            else if (cmb_Islemler.SelectedIndex == 3)
            {
                txt_OtelIsim.Visible = true;
                txt_OtelIl.Visible = false;
                txt_OtelIlce.Visible = false;

                lbl_OtelAdi.Visible = true;
                lbl_OtelIl.Visible = false;
                lbl_OtelIlce.Visible = false;

                rdo_PuanlaListele.Visible = false;
                rdo_YildizListele.Visible = false;
                rdo_SadeceListele.Visible = false;
            }

            else if (cmb_Islemler.SelectedIndex == 4)
            {
                txt_OtelIsim.Visible = false;
                txt_OtelIl.Visible = false;
                txt_OtelIlce.Visible = false;

                lbl_OtelAdi.Visible = false;
                lbl_OtelIl.Visible = false;
                lbl_OtelIlce.Visible = false;

                rdo_PuanlaListele.Visible = false;
                rdo_YildizListele.Visible = false;
                rdo_SadeceListele.Visible = false;

            }

            else if (cmb_Islemler.SelectedIndex == 5)
            {
                txt_OtelIsim.Visible = false;
                txt_OtelIl.Visible = false;
                txt_OtelIlce.Visible = false;

                lbl_OtelAdi.Visible = false;
                lbl_OtelIl.Visible = false;
                lbl_OtelIlce.Visible = false;

                rdo_PuanlaListele.Visible = false;
                rdo_YildizListele.Visible = false;
                rdo_SadeceListele.Visible = false;

            }

            else { }
        }

        private void btn_Listele_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmb_Islemler.SelectedIndex == 0 && rdo_PuanlaListele.Checked)
                {
                    VerileriListvieweAktar(musteriIslemleri.PuanIlIlceListele(txt_OtelIl.Text, txt_OtelIlce.Text));
                }

                else if (cmb_Islemler.SelectedIndex == 0 && rdo_SadeceListele.Checked)

                {
                    VerileriListvieweAktar(musteriIslemleri.ArananIlIlceListele(txt_OtelIl.Text, txt_OtelIlce.Text));
                }

                else if (cmb_Islemler.SelectedIndex == 0 && rdo_YildizListele.Checked)
                {
                    VerileriListvieweAktar(musteriIslemleri.IlIlceYildizliListele(txt_OtelIl.Text, txt_OtelIlce.Text));
                }

                else if (cmb_Islemler.SelectedIndex == 1 && rdo_PuanlaListele.Checked)
                {
                    VerileriListvieweAktar(musteriIslemleri.PuanIlListele(txt_OtelIl.Text));
                }

                else if (cmb_Islemler.SelectedIndex == 1 && rdo_SadeceListele.Checked)

                {
                    VerileriListvieweAktar(musteriIslemleri.ArananIlListele(txt_OtelIl.Text));
                }

                else if (cmb_Islemler.SelectedIndex == 1 && rdo_YildizListele.Checked)
                {
                    VerileriListvieweAktar(musteriIslemleri.IlYildizliListele(txt_OtelIl.Text));
                }


                else if (cmb_Islemler.SelectedIndex == 2)
                {
                    VerileriListvieweAktar(musteriIslemleri.PreInPostListele("In order"));
                }

                else if (cmb_Islemler.SelectedIndex == 3)
                {
                    List<Otel> otel = new List<Otel>();

                    otel.Add(musteriIslemleri.OtelBul(txt_OtelIsim.Text));

                    VerileriListvieweAktar(otel);
                }

                else if (cmb_Islemler.SelectedIndex == 4)
                {

                    VerileriListvieweAktar(musteriIslemleri.PreInPostListele("Post order"));
                }

                else if (cmb_Islemler.SelectedIndex == 5)
                {
                    VerileriListvieweAktar(musteriIslemleri.PreInPostListele("Pre order"));
                }

                else { MessageBox.Show("Lütfen Listeleme Seçimi Yapınız!"); }

            }

            catch { MessageBox.Show("Bulunamadı!");}

        }


        private void VerileriListvieweAktar(List<Otel> oteller)
        {
            lstvw_Oteller.Items.Clear();

            string[] otelBilgi = new string[5];

            for (int i = 0; i < oteller.Count; i++)
            {
                otelBilgi[0] = oteller[i].adi;
                otelBilgi[1] = oteller[i].il;
                otelBilgi[2] = oteller[i].ilce;
                otelBilgi[3] = oteller[i].yildizSayisi.ToString();
                otelBilgi[4] = oteller[i].otelPuani.ToString();

                var item = new ListViewItem(otelBilgi);
                lstvw_Oteller.Items.Add(item);
            }

            

        }


        private void btn_DerinlikElemanYazdir_Click(object sender, EventArgs e)
        {
            int derinlik = musteriIslemleri.DerinlikHesapla();
            int elemanSayisi = musteriIslemleri.IsimOtelListele().Count;
            lbl_Derinlik.Text = "Derinlik : " + derinlik.ToString();
            lbl_ElemanSayisi.Text = "Otel Sayısı : " + elemanSayisi.ToString();
            lbl_ElemanSayisi.Visible = true;
            lbl_Derinlik.Visible = true;
        }

        private void btn_Goster_Click(object sender, EventArgs e)
        {
            try
            {
                UIOtelBilgiForm uIOtelBilgiForm = new UIOtelBilgiForm(musteriIslemleri.OtelBul(lstvw_Oteller.SelectedItems[0].Text));

                uIOtelBilgiForm.ShowDialog();
            }
            catch (Exception)
            {

               MessageBox.Show("Lütfen otel seçiniz ");
            }
           
        }


    }
}
