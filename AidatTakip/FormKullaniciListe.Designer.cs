namespace AidatTakip
{
    partial class FormKullaniciListe
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
            this.lblAra = new System.Windows.Forms.Label();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.btnListele = new System.Windows.Forms.Button();
            this.chkSadeceAktif = new System.Windows.Forms.CheckBox();
            this.gridKullanicilar = new System.Windows.Forms.DataGridView();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnSifreYenile = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridKullanicilar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAra
            // 
            this.lblAra.AutoSize = true;
            this.lblAra.Location = new System.Drawing.Point(28, 28);
            this.lblAra.Name = "lblAra";
            this.lblAra.Size = new System.Drawing.Size(28, 16);
            this.lblAra.TabIndex = 0;
            this.lblAra.Text = "Ara";
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(78, 25);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(225, 22);
            this.txtAra.TabIndex = 1;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(336, 28);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(28, 16);
            this.lblRol.TabIndex = 2;
            this.lblRol.Text = "Rol";
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(386, 22);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(121, 24);
            this.cmbRol.TabIndex = 3;
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(726, 17);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(98, 33);
            this.btnListele.TabIndex = 4;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            // 
            // chkSadeceAktif
            // 
            this.chkSadeceAktif.AutoSize = true;
            this.chkSadeceAktif.Location = new System.Drawing.Point(563, 24);
            this.chkSadeceAktif.Name = "chkSadeceAktif";
            this.chkSadeceAktif.Size = new System.Drawing.Size(102, 20);
            this.chkSadeceAktif.TabIndex = 5;
            this.chkSadeceAktif.Text = "Sadece Aktif";
            this.chkSadeceAktif.UseVisualStyleBackColor = true;
            this.chkSadeceAktif.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // gridKullanicilar
            // 
            this.gridKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKullanicilar.Location = new System.Drawing.Point(12, 65);
            this.gridKullanicilar.Name = "gridKullanicilar";
            this.gridKullanicilar.RowTemplate.Height = 24;
            this.gridKullanicilar.Size = new System.Drawing.Size(1121, 527);
            this.gridKullanicilar.TabIndex = 6;
            this.gridKullanicilar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridKullanicilar_CellContentClick);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(184, 632);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(80, 36);
            this.btnEkle.TabIndex = 7;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(350, 632);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(80, 36);
            this.btnDuzenle.TabIndex = 7;
            this.btnDuzenle.Text = "Duzenle";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(527, 632);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(80, 36);
            this.btnSil.TabIndex = 7;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            // 
            // btnSifreYenile
            // 
            this.btnSifreYenile.Location = new System.Drawing.Point(686, 632);
            this.btnSifreYenile.Name = "btnSifreYenile";
            this.btnSifreYenile.Size = new System.Drawing.Size(115, 36);
            this.btnSifreYenile.TabIndex = 7;
            this.btnSifreYenile.Text = "Sifre Yenile";
            this.btnSifreYenile.UseVisualStyleBackColor = true;
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(864, 632);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(80, 36);
            this.btnKapat.TabIndex = 7;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            // 
            // FormKullaniciListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 705);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnSifreYenile);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.gridKullanicilar);
            this.Controls.Add(this.chkSadeceAktif);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.lblAra);
            this.Name = "FormKullaniciListe";
            this.Text = "FormKullaniciListe";
            this.Load += new System.EventHandler(this.FormKullaniciListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridKullanicilar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAra;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.CheckBox chkSadeceAktif;
        private System.Windows.Forms.DataGridView gridKullanicilar;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnSifreYenile;
        private System.Windows.Forms.Button btnKapat;
    }
}