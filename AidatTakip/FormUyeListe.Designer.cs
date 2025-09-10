namespace AidatTakip
{
    partial class FormUyeListe
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
            this.gridUyeler = new System.Windows.Forms.DataGridView();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.lblAra = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnAktifPasif = new System.Windows.Forms.Button();
            this.chkSadeceAktif = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridUyeler)).BeginInit();
            this.SuspendLayout();
            // 
            // gridUyeler
            // 
            this.gridUyeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUyeler.Location = new System.Drawing.Point(16, 15);
            this.gridUyeler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridUyeler.Name = "gridUyeler";
            this.gridUyeler.RowHeadersWidth = 51;
            this.gridUyeler.Size = new System.Drawing.Size(843, 519);
            this.gridUyeler.TabIndex = 0;
            this.gridUyeler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUyeler_CellContentClick);
            this.gridUyeler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUyeler_CellDoubleClick);
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(908, 15);
            this.txtAra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(132, 22);
            this.txtAra.TabIndex = 1;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // lblAra
            // 
            this.lblAra.AutoSize = true;
            this.lblAra.Location = new System.Drawing.Point(867, 18);
            this.lblAra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAra.Name = "lblAra";
            this.lblAra.Size = new System.Drawing.Size(28, 16);
            this.lblAra.TabIndex = 2;
            this.lblAra.Text = "Ara";
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(944, 379);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(119, 33);
            this.btnEkle.TabIndex = 3;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(944, 420);
            this.btnDuzenle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(119, 33);
            this.btnDuzenle.TabIndex = 3;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(944, 460);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(119, 33);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnAktifPasif
            // 
            this.btnAktifPasif.Location = new System.Drawing.Point(944, 501);
            this.btnAktifPasif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAktifPasif.Name = "btnAktifPasif";
            this.btnAktifPasif.Size = new System.Drawing.Size(119, 33);
            this.btnAktifPasif.TabIndex = 3;
            this.btnAktifPasif.Text = "Aktif Pasif";
            this.btnAktifPasif.UseVisualStyleBackColor = true;
            this.btnAktifPasif.Click += new System.EventHandler(this.btnAktifPasif_Click);
            // 
            // chkSadeceAktif
            // 
            this.chkSadeceAktif.AutoSize = true;
            this.chkSadeceAktif.Location = new System.Drawing.Point(872, 59);
            this.chkSadeceAktif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSadeceAktif.Name = "chkSadeceAktif";
            this.chkSadeceAktif.Size = new System.Drawing.Size(148, 20);
            this.chkSadeceAktif.TabIndex = 4;
            this.chkSadeceAktif.Text = "Sadece Aktif Üyeler";
            this.chkSadeceAktif.UseVisualStyleBackColor = true;
            this.chkSadeceAktif.CheckedChanged += new System.EventHandler(this.chkSadeceAktif_CheckedChanged);
            // 
            // FormUyeListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 603);
            this.Controls.Add(this.chkSadeceAktif);
            this.Controls.Add(this.btnAktifPasif);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.lblAra);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.gridUyeler);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormUyeListe";
            this.Text = "FormUyeListe";
            this.Load += new System.EventHandler(this.FormUyeListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUyeler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridUyeler;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Label lblAra;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnAktifPasif;
        private System.Windows.Forms.CheckBox chkSadeceAktif;
    }
}