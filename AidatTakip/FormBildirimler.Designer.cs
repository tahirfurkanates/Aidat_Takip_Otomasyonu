namespace AidatTakip
{
    partial class FormBildirimler
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
            this.lblYil = new System.Windows.Forms.Label();
            this.lblAy = new System.Windows.Forms.Label();
            this.cmbYil = new System.Windows.Forms.ComboBox();
            this.cmbAy = new System.Windows.Forms.ComboBox();
            this.btnListele = new System.Windows.Forms.Button();
            this.chkSadeceEmailiOlanlar = new System.Windows.Forms.CheckBox();
            this.grpSablon = new System.Windows.Forms.GroupBox();
            this.lblIpuclari = new System.Windows.Forms.Label();
            this.lblGovde = new System.Windows.Forms.Label();
            this.txtGovde = new System.Windows.Forms.TextBox();
            this.txtKonu = new System.Windows.Forms.TextBox();
            this.lblKonu = new System.Windows.Forms.Label();
            this.gridBorclular = new System.Windows.Forms.DataGridView();
            this.gridLog = new System.Windows.Forms.DataGridView();
            this.btnGonder = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.grpSablon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBorclular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLog)).BeginInit();
            this.SuspendLayout();
            // 
            // lblYil
            // 
            this.lblYil.AutoSize = true;
            this.lblYil.Location = new System.Drawing.Point(53, 30);
            this.lblYil.Name = "lblYil";
            this.lblYil.Size = new System.Drawing.Size(22, 16);
            this.lblYil.TabIndex = 0;
            this.lblYil.Text = "Yıl";
            // 
            // lblAy
            // 
            this.lblAy.AutoSize = true;
            this.lblAy.Location = new System.Drawing.Point(349, 30);
            this.lblAy.Name = "lblAy";
            this.lblAy.Size = new System.Drawing.Size(23, 16);
            this.lblAy.TabIndex = 0;
            this.lblAy.Text = "Ay";
            // 
            // cmbYil
            // 
            this.cmbYil.FormattingEnabled = true;
            this.cmbYil.Location = new System.Drawing.Point(103, 27);
            this.cmbYil.Name = "cmbYil";
            this.cmbYil.Size = new System.Drawing.Size(121, 24);
            this.cmbYil.TabIndex = 1;
            // 
            // cmbAy
            // 
            this.cmbAy.FormattingEnabled = true;
            this.cmbAy.Location = new System.Drawing.Point(399, 27);
            this.cmbAy.Name = "cmbAy";
            this.cmbAy.Size = new System.Drawing.Size(121, 24);
            this.cmbAy.TabIndex = 1;
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(690, 22);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(118, 32);
            this.btnListele.TabIndex = 2;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            // 
            // chkSadeceEmailiOlanlar
            // 
            this.chkSadeceEmailiOlanlar.AutoSize = true;
            this.chkSadeceEmailiOlanlar.Location = new System.Drawing.Point(901, 26);
            this.chkSadeceEmailiOlanlar.Name = "chkSadeceEmailiOlanlar";
            this.chkSadeceEmailiOlanlar.Size = new System.Drawing.Size(157, 20);
            this.chkSadeceEmailiOlanlar.TabIndex = 3;
            this.chkSadeceEmailiOlanlar.Text = "Sadece emaili olanlar";
            this.chkSadeceEmailiOlanlar.UseVisualStyleBackColor = true;
            // 
            // grpSablon
            // 
            this.grpSablon.Controls.Add(this.lblIpuclari);
            this.grpSablon.Controls.Add(this.lblGovde);
            this.grpSablon.Controls.Add(this.txtGovde);
            this.grpSablon.Controls.Add(this.txtKonu);
            this.grpSablon.Controls.Add(this.lblKonu);
            this.grpSablon.Location = new System.Drawing.Point(680, 76);
            this.grpSablon.Name = "grpSablon";
            this.grpSablon.Size = new System.Drawing.Size(529, 375);
            this.grpSablon.TabIndex = 5;
            this.grpSablon.TabStop = false;
            this.grpSablon.Text = "Sablon";
            // 
            // lblIpuclari
            // 
            this.lblIpuclari.Location = new System.Drawing.Point(28, 302);
            this.lblIpuclari.Name = "lblIpuclari";
            this.lblIpuclari.Size = new System.Drawing.Size(495, 50);
            this.lblIpuclari.TabIndex = 3;
            this.lblIpuclari.Text = "Kullanilabilir degiskenler: {AdSoyad} {Blok} {DaireNo} {Yil} {Ay} {Tutar} {Odenen" +
    "} {Kalan}";
            // 
            // lblGovde
            // 
            this.lblGovde.AutoSize = true;
            this.lblGovde.Location = new System.Drawing.Point(19, 77);
            this.lblGovde.Name = "lblGovde";
            this.lblGovde.Size = new System.Drawing.Size(48, 16);
            this.lblGovde.TabIndex = 2;
            this.lblGovde.Text = "Gövde";
            // 
            // txtGovde
            // 
            this.txtGovde.Location = new System.Drawing.Point(86, 74);
            this.txtGovde.Name = "txtGovde";
            this.txtGovde.Size = new System.Drawing.Size(437, 22);
            this.txtGovde.TabIndex = 1;
            // 
            // txtKonu
            // 
            this.txtKonu.Location = new System.Drawing.Point(88, 30);
            this.txtKonu.Name = "txtKonu";
            this.txtKonu.Size = new System.Drawing.Size(435, 22);
            this.txtKonu.TabIndex = 1;
            // 
            // lblKonu
            // 
            this.lblKonu.AutoSize = true;
            this.lblKonu.Location = new System.Drawing.Point(19, 33);
            this.lblKonu.Name = "lblKonu";
            this.lblKonu.Size = new System.Drawing.Size(37, 16);
            this.lblKonu.TabIndex = 0;
            this.lblKonu.Text = "Konu";
            // 
            // gridBorclular
            // 
            this.gridBorclular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBorclular.Location = new System.Drawing.Point(24, 76);
            this.gridBorclular.Name = "gridBorclular";
            this.gridBorclular.RowHeadersWidth = 51;
            this.gridBorclular.RowTemplate.Height = 24;
            this.gridBorclular.Size = new System.Drawing.Size(650, 426);
            this.gridBorclular.TabIndex = 6;
            // 
            // gridLog
            // 
            this.gridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLog.Location = new System.Drawing.Point(24, 528);
            this.gridLog.Name = "gridLog";
            this.gridLog.RowHeadersWidth = 51;
            this.gridLog.RowTemplate.Height = 24;
            this.gridLog.Size = new System.Drawing.Size(1039, 87);
            this.gridLog.TabIndex = 7;
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(296, 624);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(83, 47);
            this.btnGonder.TabIndex = 8;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Location = new System.Drawing.Point(416, 624);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(83, 47);
            this.btnAyarlar.TabIndex = 8;
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.UseVisualStyleBackColor = true;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // FormBildirimler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 683);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.gridLog);
            this.Controls.Add(this.gridBorclular);
            this.Controls.Add(this.grpSablon);
            this.Controls.Add(this.chkSadeceEmailiOlanlar);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.cmbAy);
            this.Controls.Add(this.cmbYil);
            this.Controls.Add(this.lblAy);
            this.Controls.Add(this.lblYil);
            this.Name = "FormBildirimler";
            this.Text = "FormBildirimler";
            this.Load += new System.EventHandler(this.FormBildirimler_Load);
            this.grpSablon.ResumeLayout(false);
            this.grpSablon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBorclular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblYil;
        private System.Windows.Forms.Label lblAy;
        private System.Windows.Forms.ComboBox cmbYil;
        private System.Windows.Forms.ComboBox cmbAy;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.CheckBox chkSadeceEmailiOlanlar;
        private System.Windows.Forms.GroupBox grpSablon;
        private System.Windows.Forms.TextBox txtKonu;
        private System.Windows.Forms.Label lblKonu;
        private System.Windows.Forms.Label lblIpuclari;
        private System.Windows.Forms.Label lblGovde;
        private System.Windows.Forms.TextBox txtGovde;
        private System.Windows.Forms.DataGridView gridBorclular;
        private System.Windows.Forms.DataGridView gridLog;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Button btnAyarlar;
    }
}