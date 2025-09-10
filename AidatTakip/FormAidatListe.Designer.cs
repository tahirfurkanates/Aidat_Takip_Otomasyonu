namespace AidatTakip
{
    partial class FormAidatListe
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
            this.cmbYil = new System.Windows.Forms.ComboBox();
            this.lblYil = new System.Windows.Forms.Label();
            this.cmbAy = new System.Windows.Forms.ComboBox();
            this.lblAy = new System.Windows.Forms.Label();
            this.lblUyeAra = new System.Windows.Forms.Label();
            this.txtUyeAra = new System.Windows.Forms.TextBox();
            this.cmbDurum = new System.Windows.Forms.ComboBox();
            this.lblDurum = new System.Windows.Forms.Label();
            this.gridAidatlar = new System.Windows.Forms.DataGridView();
            this.btnTopluOlustur = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnOdemeGir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOzetBekleyen = new System.Windows.Forms.Label();
            this.lblOzetKismi = new System.Windows.Forms.Label();
            this.lblOzetOdendi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridAidatlar)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbYil
            // 
            this.cmbYil.FormattingEnabled = true;
            this.cmbYil.Location = new System.Drawing.Point(85, 22);
            this.cmbYil.Name = "cmbYil";
            this.cmbYil.Size = new System.Drawing.Size(121, 24);
            this.cmbYil.TabIndex = 0;
            // 
            // lblYil
            // 
            this.lblYil.AutoSize = true;
            this.lblYil.Location = new System.Drawing.Point(22, 25);
            this.lblYil.Name = "lblYil";
            this.lblYil.Size = new System.Drawing.Size(22, 16);
            this.lblYil.TabIndex = 1;
            this.lblYil.Text = "Yıl";
            // 
            // cmbAy
            // 
            this.cmbAy.FormattingEnabled = true;
            this.cmbAy.Location = new System.Drawing.Point(85, 62);
            this.cmbAy.Name = "cmbAy";
            this.cmbAy.Size = new System.Drawing.Size(121, 24);
            this.cmbAy.TabIndex = 0;
            // 
            // lblAy
            // 
            this.lblAy.AutoSize = true;
            this.lblAy.Location = new System.Drawing.Point(22, 65);
            this.lblAy.Name = "lblAy";
            this.lblAy.Size = new System.Drawing.Size(23, 16);
            this.lblAy.TabIndex = 1;
            this.lblAy.Text = "Ay";
            // 
            // lblUyeAra
            // 
            this.lblUyeAra.AutoSize = true;
            this.lblUyeAra.Location = new System.Drawing.Point(22, 103);
            this.lblUyeAra.Name = "lblUyeAra";
            this.lblUyeAra.Size = new System.Drawing.Size(56, 16);
            this.lblUyeAra.TabIndex = 1;
            this.lblUyeAra.Text = "Üye Ara";
            // 
            // txtUyeAra
            // 
            this.txtUyeAra.Location = new System.Drawing.Point(85, 100);
            this.txtUyeAra.Name = "txtUyeAra";
            this.txtUyeAra.Size = new System.Drawing.Size(121, 22);
            this.txtUyeAra.TabIndex = 2;
            // 
            // cmbDurum
            // 
            this.cmbDurum.FormattingEnabled = true;
            this.cmbDurum.Location = new System.Drawing.Point(85, 139);
            this.cmbDurum.Name = "cmbDurum";
            this.cmbDurum.Size = new System.Drawing.Size(121, 24);
            this.cmbDurum.TabIndex = 0;
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(22, 142);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(46, 16);
            this.lblDurum.TabIndex = 1;
            this.lblDurum.Text = "Durum";
            // 
            // gridAidatlar
            // 
            this.gridAidatlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAidatlar.Location = new System.Drawing.Point(222, 7);
            this.gridAidatlar.Name = "gridAidatlar";
            this.gridAidatlar.RowHeadersWidth = 51;
            this.gridAidatlar.RowTemplate.Height = 24;
            this.gridAidatlar.Size = new System.Drawing.Size(792, 573);
            this.gridAidatlar.TabIndex = 3;
            this.gridAidatlar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAidatlar_CellContentClick);
            // 
            // btnTopluOlustur
            // 
            this.btnTopluOlustur.Location = new System.Drawing.Point(59, 192);
            this.btnTopluOlustur.Name = "btnTopluOlustur";
            this.btnTopluOlustur.Size = new System.Drawing.Size(112, 23);
            this.btnTopluOlustur.TabIndex = 4;
            this.btnTopluOlustur.Text = "Toplu Oluştur";
            this.btnTopluOlustur.UseVisualStyleBackColor = true;
            this.btnTopluOlustur.Click += new System.EventHandler(this.btnTopluOlustur_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(59, 272);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(112, 23);
            this.btnDuzenle.TabIndex = 4;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(59, 310);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(112, 23);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(59, 231);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(112, 23);
            this.btnEkle.TabIndex = 4;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnOdemeGir
            // 
            this.btnOdemeGir.Location = new System.Drawing.Point(59, 349);
            this.btnOdemeGir.Name = "btnOdemeGir";
            this.btnOdemeGir.Size = new System.Drawing.Size(112, 23);
            this.btnOdemeGir.TabIndex = 4;
            this.btnOdemeGir.Text = "Ödeme Gir";
            this.btnOdemeGir.UseVisualStyleBackColor = true;
            this.btnOdemeGir.Click += new System.EventHandler(this.btnOdemeGir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // lblOzetBekleyen
            // 
            this.lblOzetBekleyen.AutoSize = true;
            this.lblOzetBekleyen.Location = new System.Drawing.Point(82, 404);
            this.lblOzetBekleyen.Name = "lblOzetBekleyen";
            this.lblOzetBekleyen.Size = new System.Drawing.Size(77, 16);
            this.lblOzetBekleyen.TabIndex = 5;
            this.lblOzetBekleyen.Text = "Bekleyen: 0";
            // 
            // lblOzetKismi
            // 
            this.lblOzetKismi.AutoSize = true;
            this.lblOzetKismi.Location = new System.Drawing.Point(82, 443);
            this.lblOzetKismi.Name = "lblOzetKismi";
            this.lblOzetKismi.Size = new System.Drawing.Size(52, 16);
            this.lblOzetKismi.TabIndex = 5;
            this.lblOzetKismi.Text = "Kismi: 0";
            // 
            // lblOzetOdendi
            // 
            this.lblOzetOdendi.AutoSize = true;
            this.lblOzetOdendi.Location = new System.Drawing.Point(82, 484);
            this.lblOzetOdendi.Name = "lblOzetOdendi";
            this.lblOzetOdendi.Size = new System.Drawing.Size(64, 16);
            this.lblOzetOdendi.TabIndex = 5;
            this.lblOzetOdendi.Text = "Ödendi: 0";
            // 
            // FormAidatListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 585);
            this.Controls.Add(this.lblOzetOdendi);
            this.Controls.Add(this.lblOzetKismi);
            this.Controls.Add(this.lblOzetBekleyen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOdemeGir);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnTopluOlustur);
            this.Controls.Add(this.gridAidatlar);
            this.Controls.Add(this.txtUyeAra);
            this.Controls.Add(this.lblUyeAra);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.lblAy);
            this.Controls.Add(this.cmbDurum);
            this.Controls.Add(this.lblYil);
            this.Controls.Add(this.cmbAy);
            this.Controls.Add(this.cmbYil);
            this.Name = "FormAidatListe";
            this.Text = "FormAidatListe";
            this.Load += new System.EventHandler(this.FormAidatListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAidatlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbYil;
        private System.Windows.Forms.Label lblYil;
        private System.Windows.Forms.ComboBox cmbAy;
        private System.Windows.Forms.Label lblAy;
        private System.Windows.Forms.Label lblUyeAra;
        private System.Windows.Forms.TextBox txtUyeAra;
        private System.Windows.Forms.ComboBox cmbDurum;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.DataGridView gridAidatlar;
        private System.Windows.Forms.Button btnTopluOlustur;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnOdemeGir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOzetBekleyen;
        private System.Windows.Forms.Label lblOzetKismi;
        private System.Windows.Forms.Label lblOzetOdendi;
    }
}