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
    public partial class UIGirisForm : MetroForm
    {
        public UIGirisForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        

        private void btn_SistemYetkilisi_Click(object sender, EventArgs e)
        {
            if (txt_KullaniciAdi.Text == "admin" && txt_Sifre.Text == "1234")
            {

                UIYetkiliForm yetkiliForm = new UIYetkiliForm();

                yetkiliForm.ShowDialog();
            }

            else { MessageBox.Show("Kullanıcı adı veya şifre yanlış!");}
        }

        private void btn_Musteri_Click(object sender, EventArgs e)
        {
            UIMusteriForm uIMusteriForm = new UIMusteriForm();

            uIMusteriForm.ShowDialog();
        }
    }
}
