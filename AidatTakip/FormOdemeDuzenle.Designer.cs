namespace AidatTakip
{
    partial class FormOdemeDuzenle
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
            this.lblUye = new System.Windows.Forms.Label();
            this.lblDonem = new System.Windows.Forms.Label();
            this.lblOdemeTarihi = new System.Windows.Forms.Label();
            this.lblTutar = new System.Windows.Forms.Label();
            this.lblYontem = new System.Windows.Forms.Label();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.dtOdemeTarihi = new System.Windows.Forms.DateTimePicker();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.cmbYontem = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblUye
            // 
            this.lblUye.AutoSize = true;
            this.lblUye.Location = new System.Drawing.Point(13, 13);
            this.lblUye.Name = "lblUye";
            this.lblUye.Size = new System.Drawing.Size(152, 16);
            this.lblUye.TabIndex = 0;
            this.lblUye.Text = "Üye:                Ahmet Mitat";
            // 
            // lblDonem
            // 
            this.lblDonem.AutoSize = true;
            this.lblDonem.Location = new System.Drawing.Point(13, 40);
            this.lblDonem.Name = "lblDonem";
            this.lblDonem.Size = new System.Drawing.Size(123, 16);
            this.lblDonem.TabIndex = 0;
            this.lblDonem.Text = "Donem:          2024/5";
            // 
            // lblOdemeTarihi
            // 
            this.lblOdemeTarihi.AutoSize = true;
            this.lblOdemeTarihi.Location = new System.Drawing.Point(13, 71);
            this.lblOdemeTarihi.Name = "lblOdemeTarihi";
            this.lblOdemeTarihi.Size = new System.Drawing.Size(89, 16);
            this.lblOdemeTarihi.TabIndex = 0;
            this.lblOdemeTarihi.Text = "Ödeme Tarihi";
            // 
            // lblTutar
            // 
            this.lblTutar.AutoSize = true;
            this.lblTutar.Location = new System.Drawing.Point(13, 103);
            this.lblTutar.Name = "lblTutar";
            this.lblTutar.Size = new System.Drawing.Size(38, 16);
            this.lblTutar.TabIndex = 0;
            this.lblTutar.Text = "Tutar";
            // 
            // lblYontem
            // 
            this.lblYontem.AutoSize = true;
            this.lblYontem.Location = new System.Drawing.Point(12, 133);
            this.lblYontem.Name = "lblYontem";
            this.lblYontem.Size = new System.Drawing.Size(53, 16);
            this.lblYontem.TabIndex = 0;
            this.lblYontem.Text = "Yöntem";
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(12, 168);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(63, 16);
            this.lblAciklama.TabIndex = 0;
            this.lblAciklama.Text = "Açıklama";
            // 
            // dtOdemeTarihi
            // 
            this.dtOdemeTarihi.Location = new System.Drawing.Point(118, 66);
            this.dtOdemeTarihi.Name = "dtOdemeTarihi";
            this.dtOdemeTarihi.Size = new System.Drawing.Size(200, 22);
            this.dtOdemeTarihi.TabIndex = 1;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(91, 162);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(100, 22);
            this.txtAciklama.TabIndex = 2;
            // 
            // cmbYontem
            // 
            this.cmbYontem.FormattingEnabled = true;
            this.cmbYontem.Location = new System.Drawing.Point(91, 130);
            this.cmbYontem.Name = "cmbYontem";
            this.cmbYontem.Size = new System.Drawing.Size(121, 24);
            this.cmbYontem.TabIndex = 3;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(16, 210);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 34);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(131, 210);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 34);
            this.btnIptal.TabIndex = 4;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(91, 97);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(100, 22);
            this.txtTutar.TabIndex = 2;
            // 
            // FormOdemeDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.cmbYontem);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.dtOdemeTarihi);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.lblYontem);
            this.Controls.Add(this.lblTutar);
            this.Controls.Add(this.lblOdemeTarihi);
            this.Controls.Add(this.lblDonem);
            this.Controls.Add(this.lblUye);
            this.Name = "FormOdemeDuzenle";
            this.Text = "FormOdemeDuzenle";
            this.Load += new System.EventHandler(this.FormOdemeDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUye;
        private System.Windows.Forms.Label lblDonem;
        private System.Windows.Forms.Label lblOdemeTarihi;
        private System.Windows.Forms.Label lblTutar;
        private System.Windows.Forms.Label lblYontem;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.DateTimePicker dtOdemeTarihi;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.ComboBox cmbYontem;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.TextBox txtTutar;
    }
}