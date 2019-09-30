namespace Otel_Otomasyon
{
    partial class UIGirisForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_KullaniciAdi = new MetroFramework.Controls.MetroTextBox();
            this.txt_Sifre = new MetroFramework.Controls.MetroTextBox();
            this.btn_SistemYetkilisi = new MetroFramework.Controls.MetroButton();
            this.btn_Musteri = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // txt_KullaniciAdi
            // 
            // 
            // 
            // 
            this.txt_KullaniciAdi.CustomButton.Image = null;
            this.txt_KullaniciAdi.CustomButton.Location = new System.Drawing.Point(144, 1);
            this.txt_KullaniciAdi.CustomButton.Name = "";
            this.txt_KullaniciAdi.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_KullaniciAdi.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_KullaniciAdi.CustomButton.TabIndex = 1;
            this.txt_KullaniciAdi.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_KullaniciAdi.CustomButton.UseSelectable = true;
            this.txt_KullaniciAdi.CustomButton.Visible = false;
            this.txt_KullaniciAdi.Lines = new string[0];
            this.txt_KullaniciAdi.Location = new System.Drawing.Point(166, 132);
            this.txt_KullaniciAdi.MaxLength = 32767;
            this.txt_KullaniciAdi.Name = "txt_KullaniciAdi";
            this.txt_KullaniciAdi.PasswordChar = '\0';
            this.txt_KullaniciAdi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_KullaniciAdi.SelectedText = "";
            this.txt_KullaniciAdi.SelectionLength = 0;
            this.txt_KullaniciAdi.SelectionStart = 0;
            this.txt_KullaniciAdi.ShortcutsEnabled = true;
            this.txt_KullaniciAdi.Size = new System.Drawing.Size(166, 23);
            this.txt_KullaniciAdi.TabIndex = 1;
            this.txt_KullaniciAdi.UseSelectable = true;
            this.txt_KullaniciAdi.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_KullaniciAdi.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_Sifre
            // 
            // 
            // 
            // 
            this.txt_Sifre.CustomButton.Image = null;
            this.txt_Sifre.CustomButton.Location = new System.Drawing.Point(144, 1);
            this.txt_Sifre.CustomButton.Name = "";
            this.txt_Sifre.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_Sifre.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_Sifre.CustomButton.TabIndex = 1;
            this.txt_Sifre.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_Sifre.CustomButton.UseSelectable = true;
            this.txt_Sifre.CustomButton.Visible = false;
            this.txt_Sifre.Lines = new string[0];
            this.txt_Sifre.Location = new System.Drawing.Point(166, 161);
            this.txt_Sifre.MaxLength = 32767;
            this.txt_Sifre.Name = "txt_Sifre";
            this.txt_Sifre.PasswordChar = '*';
            this.txt_Sifre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Sifre.SelectedText = "";
            this.txt_Sifre.SelectionLength = 0;
            this.txt_Sifre.SelectionStart = 0;
            this.txt_Sifre.ShortcutsEnabled = true;
            this.txt_Sifre.Size = new System.Drawing.Size(166, 23);
            this.txt_Sifre.TabIndex = 2;
            this.txt_Sifre.UseSelectable = true;
            this.txt_Sifre.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_Sifre.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btn_SistemYetkilisi
            // 
            this.btn_SistemYetkilisi.Location = new System.Drawing.Point(166, 230);
            this.btn_SistemYetkilisi.Name = "btn_SistemYetkilisi";
            this.btn_SistemYetkilisi.Size = new System.Drawing.Size(166, 87);
            this.btn_SistemYetkilisi.TabIndex = 3;
            this.btn_SistemYetkilisi.Text = "Sistem Yetkilisi\r\nOlarak Gir!";
            this.btn_SistemYetkilisi.UseSelectable = true;
            this.btn_SistemYetkilisi.Click += new System.EventHandler(this.btn_SistemYetkilisi_Click);
            // 
            // btn_Musteri
            // 
            this.btn_Musteri.Location = new System.Drawing.Point(518, 230);
            this.btn_Musteri.Name = "btn_Musteri";
            this.btn_Musteri.Size = new System.Drawing.Size(175, 87);
            this.btn_Musteri.TabIndex = 4;
            this.btn_Musteri.Text = "Müşteri Olarak Gir!";
            this.btn_Musteri.UseSelectable = true;
            this.btn_Musteri.Click += new System.EventHandler(this.btn_Musteri_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(48, 132);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(86, 20);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Kullanıcı Adı:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(95, 164);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(39, 20);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Şifre:";
            // 
            // UIGirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btn_Musteri);
            this.Controls.Add(this.btn_SistemYetkilisi);
            this.Controls.Add(this.txt_Sifre);
            this.Controls.Add(this.txt_KullaniciAdi);
            this.Name = "UIGirisForm";
            this.Text = "Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txt_KullaniciAdi;
        private MetroFramework.Controls.MetroTextBox txt_Sifre;
        private MetroFramework.Controls.MetroButton btn_SistemYetkilisi;
        private MetroFramework.Controls.MetroButton btn_Musteri;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}

