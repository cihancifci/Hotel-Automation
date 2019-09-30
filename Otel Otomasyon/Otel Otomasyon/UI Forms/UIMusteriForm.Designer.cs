namespace Otel_Otomasyon
{
    partial class UIMusteriForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstvw_Oteller = new MetroFramework.Controls.MetroListView();
            this.clmn_OtelAdi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmn_Il = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmn_Ilce = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmn_YildizSayisi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmn_OtelPuan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmb_Islemler = new MetroFramework.Controls.MetroComboBox();
            this.btn_Listele = new MetroFramework.Controls.MetroButton();
            this.lbl_ListelemeTuru = new MetroFramework.Controls.MetroLabel();
            this.txt_OtelIsim = new MetroFramework.Controls.MetroTextBox();
            this.txt_OtelIl = new MetroFramework.Controls.MetroTextBox();
            this.txt_OtelIlce = new MetroFramework.Controls.MetroTextBox();
            this.lbl_OtelAdi = new MetroFramework.Controls.MetroLabel();
            this.lbl_OtelIl = new MetroFramework.Controls.MetroLabel();
            this.lbl_OtelIlce = new MetroFramework.Controls.MetroLabel();
            this.rdo_PuanlaListele = new MetroFramework.Controls.MetroRadioButton();
            this.rdo_SadeceListele = new MetroFramework.Controls.MetroRadioButton();
            this.rdo_YildizListele = new MetroFramework.Controls.MetroRadioButton();
            this.btn_Goster = new MetroFramework.Controls.MetroButton();
            this.btn_DerinlikElemanYazdir = new MetroFramework.Controls.MetroButton();
            this.lbl_Derinlik = new MetroFramework.Controls.MetroLabel();
            this.lbl_ElemanSayisi = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lstvw_Oteller
            // 
            this.lstvw_Oteller.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmn_OtelAdi,
            this.clmn_Il,
            this.clmn_Ilce,
            this.clmn_YildizSayisi,
            this.clmn_OtelPuan});
            this.lstvw_Oteller.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstvw_Oteller.FullRowSelect = true;
            this.lstvw_Oteller.Location = new System.Drawing.Point(518, 24);
            this.lstvw_Oteller.Name = "lstvw_Oteller";
            this.lstvw_Oteller.OwnerDraw = true;
            this.lstvw_Oteller.Size = new System.Drawing.Size(825, 563);
            this.lstvw_Oteller.TabIndex = 0;
            this.lstvw_Oteller.UseCompatibleStateImageBehavior = false;
            this.lstvw_Oteller.UseSelectable = true;
            this.lstvw_Oteller.View = System.Windows.Forms.View.Details;
            // 
            // clmn_OtelAdi
            // 
            this.clmn_OtelAdi.Text = "Otel Adı";
            this.clmn_OtelAdi.Width = 137;
            // 
            // clmn_Il
            // 
            this.clmn_Il.Text = "Bulunduğu İl";
            this.clmn_Il.Width = 208;
            // 
            // clmn_Ilce
            // 
            this.clmn_Ilce.Text = "Bulunduğu İlçe";
            this.clmn_Ilce.Width = 173;
            // 
            // clmn_YildizSayisi
            // 
            this.clmn_YildizSayisi.Text = "Yıldız Sayısı";
            this.clmn_YildizSayisi.Width = 114;
            // 
            // clmn_OtelPuan
            // 
            this.clmn_OtelPuan.Text = "Otel Puanı";
            this.clmn_OtelPuan.Width = 123;
            // 
            // cmb_Islemler
            // 
            this.cmb_Islemler.FormattingEnabled = true;
            this.cmb_Islemler.ItemHeight = 24;
            this.cmb_Islemler.Items.AddRange(new object[] {
            "İl-İlçe ile otel listele",
            "İl ile otel listele",
            "İnorder Listele",
            "İsimle Oteli Listele",
            "Postorder Listele",
            "Preorder Listele"});
            this.cmb_Islemler.Location = new System.Drawing.Point(47, 163);
            this.cmb_Islemler.Name = "cmb_Islemler";
            this.cmb_Islemler.Size = new System.Drawing.Size(192, 30);
            this.cmb_Islemler.Sorted = true;
            this.cmb_Islemler.TabIndex = 1;
            this.cmb_Islemler.UseSelectable = true;
            this.cmb_Islemler.SelectedIndexChanged += new System.EventHandler(this.cmb_Islemler_SelectedIndexChanged);
            // 
            // btn_Listele
            // 
            this.btn_Listele.Location = new System.Drawing.Point(263, 393);
            this.btn_Listele.Name = "btn_Listele";
            this.btn_Listele.Size = new System.Drawing.Size(192, 33);
            this.btn_Listele.TabIndex = 2;
            this.btn_Listele.Text = "Listele!";
            this.btn_Listele.UseSelectable = true;
            this.btn_Listele.Click += new System.EventHandler(this.btn_Listele_Click);
            // 
            // lbl_ListelemeTuru
            // 
            this.lbl_ListelemeTuru.AutoSize = true;
            this.lbl_ListelemeTuru.Location = new System.Drawing.Point(47, 110);
            this.lbl_ListelemeTuru.Name = "lbl_ListelemeTuru";
            this.lbl_ListelemeTuru.Size = new System.Drawing.Size(99, 20);
            this.lbl_ListelemeTuru.TabIndex = 3;
            this.lbl_ListelemeTuru.Text = "Listeleme Türü";
            // 
            // txt_OtelIsim
            // 
            // 
            // 
            // 
            this.txt_OtelIsim.CustomButton.Image = null;
            this.txt_OtelIsim.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.txt_OtelIsim.CustomButton.Name = "";
            this.txt_OtelIsim.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_OtelIsim.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_OtelIsim.CustomButton.TabIndex = 1;
            this.txt_OtelIsim.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_OtelIsim.CustomButton.UseSelectable = true;
            this.txt_OtelIsim.CustomButton.Visible = false;
            this.txt_OtelIsim.Lines = new string[0];
            this.txt_OtelIsim.Location = new System.Drawing.Point(117, 212);
            this.txt_OtelIsim.MaxLength = 32767;
            this.txt_OtelIsim.Name = "txt_OtelIsim";
            this.txt_OtelIsim.PasswordChar = '\0';
            this.txt_OtelIsim.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_OtelIsim.SelectedText = "";
            this.txt_OtelIsim.SelectionLength = 0;
            this.txt_OtelIsim.SelectionStart = 0;
            this.txt_OtelIsim.ShortcutsEnabled = true;
            this.txt_OtelIsim.Size = new System.Drawing.Size(122, 23);
            this.txt_OtelIsim.TabIndex = 4;
            this.txt_OtelIsim.UseSelectable = true;
            this.txt_OtelIsim.Visible = false;
            this.txt_OtelIsim.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_OtelIsim.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_OtelIl
            // 
            // 
            // 
            // 
            this.txt_OtelIl.CustomButton.Image = null;
            this.txt_OtelIl.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.txt_OtelIl.CustomButton.Name = "";
            this.txt_OtelIl.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_OtelIl.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_OtelIl.CustomButton.TabIndex = 1;
            this.txt_OtelIl.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_OtelIl.CustomButton.UseSelectable = true;
            this.txt_OtelIl.CustomButton.Visible = false;
            this.txt_OtelIl.Lines = new string[0];
            this.txt_OtelIl.Location = new System.Drawing.Point(117, 250);
            this.txt_OtelIl.MaxLength = 32767;
            this.txt_OtelIl.Name = "txt_OtelIl";
            this.txt_OtelIl.PasswordChar = '\0';
            this.txt_OtelIl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_OtelIl.SelectedText = "";
            this.txt_OtelIl.SelectionLength = 0;
            this.txt_OtelIl.SelectionStart = 0;
            this.txt_OtelIl.ShortcutsEnabled = true;
            this.txt_OtelIl.Size = new System.Drawing.Size(122, 23);
            this.txt_OtelIl.TabIndex = 5;
            this.txt_OtelIl.UseSelectable = true;
            this.txt_OtelIl.Visible = false;
            this.txt_OtelIl.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_OtelIl.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_OtelIlce
            // 
            // 
            // 
            // 
            this.txt_OtelIlce.CustomButton.Image = null;
            this.txt_OtelIlce.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.txt_OtelIlce.CustomButton.Name = "";
            this.txt_OtelIlce.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_OtelIlce.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_OtelIlce.CustomButton.TabIndex = 1;
            this.txt_OtelIlce.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_OtelIlce.CustomButton.UseSelectable = true;
            this.txt_OtelIlce.CustomButton.Visible = false;
            this.txt_OtelIlce.Lines = new string[0];
            this.txt_OtelIlce.Location = new System.Drawing.Point(117, 289);
            this.txt_OtelIlce.MaxLength = 32767;
            this.txt_OtelIlce.Name = "txt_OtelIlce";
            this.txt_OtelIlce.PasswordChar = '\0';
            this.txt_OtelIlce.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_OtelIlce.SelectedText = "";
            this.txt_OtelIlce.SelectionLength = 0;
            this.txt_OtelIlce.SelectionStart = 0;
            this.txt_OtelIlce.ShortcutsEnabled = true;
            this.txt_OtelIlce.Size = new System.Drawing.Size(122, 23);
            this.txt_OtelIlce.TabIndex = 6;
            this.txt_OtelIlce.UseSelectable = true;
            this.txt_OtelIlce.Visible = false;
            this.txt_OtelIlce.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_OtelIlce.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbl_OtelAdi
            // 
            this.lbl_OtelAdi.AutoSize = true;
            this.lbl_OtelAdi.Location = new System.Drawing.Point(38, 212);
            this.lbl_OtelAdi.Name = "lbl_OtelAdi";
            this.lbl_OtelAdi.Size = new System.Drawing.Size(59, 20);
            this.lbl_OtelAdi.TabIndex = 7;
            this.lbl_OtelAdi.Text = "Otel Adı";
            this.lbl_OtelAdi.Visible = false;
            // 
            // lbl_OtelIl
            // 
            this.lbl_OtelIl.AutoSize = true;
            this.lbl_OtelIl.Location = new System.Drawing.Point(79, 250);
            this.lbl_OtelIl.Name = "lbl_OtelIl";
            this.lbl_OtelIl.Size = new System.Drawing.Size(15, 20);
            this.lbl_OtelIl.TabIndex = 8;
            this.lbl_OtelIl.Text = "İl";
            this.lbl_OtelIl.Visible = false;
            // 
            // lbl_OtelIlce
            // 
            this.lbl_OtelIlce.AutoSize = true;
            this.lbl_OtelIlce.Location = new System.Drawing.Point(74, 289);
            this.lbl_OtelIlce.Name = "lbl_OtelIlce";
            this.lbl_OtelIlce.Size = new System.Drawing.Size(30, 20);
            this.lbl_OtelIlce.TabIndex = 9;
            this.lbl_OtelIlce.Text = "İlçe";
            this.lbl_OtelIlce.Visible = false;
            // 
            // rdo_PuanlaListele
            // 
            this.rdo_PuanlaListele.AutoSize = true;
            this.rdo_PuanlaListele.Location = new System.Drawing.Point(24, 370);
            this.rdo_PuanlaListele.Name = "rdo_PuanlaListele";
            this.rdo_PuanlaListele.Size = new System.Drawing.Size(128, 17);
            this.rdo_PuanlaListele.TabIndex = 10;
            this.rdo_PuanlaListele.Text = "Puana göre listele";
            this.rdo_PuanlaListele.UseSelectable = true;
            this.rdo_PuanlaListele.Visible = false;
            // 
            // rdo_SadeceListele
            // 
            this.rdo_SadeceListele.AutoSize = true;
            this.rdo_SadeceListele.Location = new System.Drawing.Point(23, 416);
            this.rdo_SadeceListele.Name = "rdo_SadeceListele";
            this.rdo_SadeceListele.Size = new System.Drawing.Size(103, 17);
            this.rdo_SadeceListele.TabIndex = 11;
            this.rdo_SadeceListele.Text = "Sadece listele";
            this.rdo_SadeceListele.UseSelectable = true;
            this.rdo_SadeceListele.Visible = false;
            // 
            // rdo_YildizListele
            // 
            this.rdo_YildizListele.AutoSize = true;
            this.rdo_YildizListele.Location = new System.Drawing.Point(24, 393);
            this.rdo_YildizListele.Name = "rdo_YildizListele";
            this.rdo_YildizListele.Size = new System.Drawing.Size(172, 17);
            this.rdo_YildizListele.TabIndex = 12;
            this.rdo_YildizListele.Text = "Yıldız sayısına göre listele";
            this.rdo_YildizListele.UseSelectable = true;
            this.rdo_YildizListele.Visible = false;
            // 
            // btn_Goster
            // 
            this.btn_Goster.Location = new System.Drawing.Point(754, 602);
            this.btn_Goster.Name = "btn_Goster";
            this.btn_Goster.Size = new System.Drawing.Size(315, 42);
            this.btn_Goster.TabIndex = 13;
            this.btn_Goster.Text = "Seçilen Otel Bilgisini Göster";
            this.btn_Goster.UseSelectable = true;
            this.btn_Goster.Click += new System.EventHandler(this.btn_Goster_Click);
            // 
            // btn_DerinlikElemanYazdir
            // 
            this.btn_DerinlikElemanYazdir.Location = new System.Drawing.Point(47, 498);
            this.btn_DerinlikElemanYazdir.Name = "btn_DerinlikElemanYazdir";
            this.btn_DerinlikElemanYazdir.Size = new System.Drawing.Size(192, 50);
            this.btn_DerinlikElemanYazdir.TabIndex = 14;
            this.btn_DerinlikElemanYazdir.Text = "Ağacın Derinliğini ve \r\nEleman Sayısını Yazdır";
            this.btn_DerinlikElemanYazdir.UseSelectable = true;
            this.btn_DerinlikElemanYazdir.Click += new System.EventHandler(this.btn_DerinlikElemanYazdir_Click);
            // 
            // lbl_Derinlik
            // 
            this.lbl_Derinlik.AutoSize = true;
            this.lbl_Derinlik.Location = new System.Drawing.Point(47, 567);
            this.lbl_Derinlik.Name = "lbl_Derinlik";
            this.lbl_Derinlik.Size = new System.Drawing.Size(0, 0);
            this.lbl_Derinlik.TabIndex = 15;
            this.lbl_Derinlik.Visible = false;
            // 
            // lbl_ElemanSayisi
            // 
            this.lbl_ElemanSayisi.AutoSize = true;
            this.lbl_ElemanSayisi.Location = new System.Drawing.Point(47, 602);
            this.lbl_ElemanSayisi.Name = "lbl_ElemanSayisi";
            this.lbl_ElemanSayisi.Size = new System.Drawing.Size(0, 0);
            this.lbl_ElemanSayisi.TabIndex = 16;
            this.lbl_ElemanSayisi.Visible = false;
            // 
            // UIMusteriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.lbl_ElemanSayisi);
            this.Controls.Add(this.lbl_Derinlik);
            this.Controls.Add(this.btn_DerinlikElemanYazdir);
            this.Controls.Add(this.btn_Goster);
            this.Controls.Add(this.rdo_YildizListele);
            this.Controls.Add(this.rdo_SadeceListele);
            this.Controls.Add(this.rdo_PuanlaListele);
            this.Controls.Add(this.lbl_OtelIlce);
            this.Controls.Add(this.lbl_OtelIl);
            this.Controls.Add(this.lbl_OtelAdi);
            this.Controls.Add(this.txt_OtelIlce);
            this.Controls.Add(this.txt_OtelIl);
            this.Controls.Add(this.txt_OtelIsim);
            this.Controls.Add(this.lbl_ListelemeTuru);
            this.Controls.Add(this.btn_Listele);
            this.Controls.Add(this.cmb_Islemler);
            this.Controls.Add(this.lstvw_Oteller);
            this.Name = "UIMusteriForm";
            this.Text = "Müşteri Formu";
            this.Load += new System.EventHandler(this.UIMusteriForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroListView lstvw_Oteller;
        private MetroFramework.Controls.MetroComboBox cmb_Islemler;
        private MetroFramework.Controls.MetroButton btn_Listele;
        private MetroFramework.Controls.MetroLabel lbl_ListelemeTuru;
        private MetroFramework.Controls.MetroTextBox txt_OtelIsim;
        private MetroFramework.Controls.MetroTextBox txt_OtelIl;
        private MetroFramework.Controls.MetroTextBox txt_OtelIlce;
        private MetroFramework.Controls.MetroLabel lbl_OtelAdi;
        private MetroFramework.Controls.MetroLabel lbl_OtelIl;
        private MetroFramework.Controls.MetroLabel lbl_OtelIlce;
        private MetroFramework.Controls.MetroRadioButton rdo_PuanlaListele;
        private MetroFramework.Controls.MetroRadioButton rdo_SadeceListele;
        private MetroFramework.Controls.MetroRadioButton rdo_YildizListele;
        private System.Windows.Forms.ColumnHeader clmn_OtelAdi;
        private System.Windows.Forms.ColumnHeader clmn_Il;
        private System.Windows.Forms.ColumnHeader clmn_Ilce;
        private System.Windows.Forms.ColumnHeader clmn_YildizSayisi;
        private MetroFramework.Controls.MetroButton btn_Goster;
        private System.Windows.Forms.ColumnHeader clmn_OtelPuan;
        private MetroFramework.Controls.MetroButton btn_DerinlikElemanYazdir;
        private MetroFramework.Controls.MetroLabel lbl_Derinlik;
        private MetroFramework.Controls.MetroLabel lbl_ElemanSayisi;
    }
}