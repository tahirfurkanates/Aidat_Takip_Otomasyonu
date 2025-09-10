namespace AidatTakip
{
    partial class FormOdemeListe
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
            this.lblBaslangic = new System.Windows.Forms.Label();
            this.lblBitis = new System.Windows.Forms.Label();
            this.lblYontemFiltre = new System.Windows.Forms.Label();
            this.gridOdemeler = new System.Windows.Forms.DataGridView();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.lblUyeAra = new System.Windows.Forms.Label();
            this.dtBaslangic = new System.Windows.Forms.DateTimePicker();
            this.cmbYontemFiltre = new System.Windows.Forms.ComboBox();
            this.dtBitis = new System.Windows.Forms.DateTimePicker();
            this.txtUyeAra = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridOdemeler)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBaslangic
            // 
            this.lblBaslangic.AutoSize = true;
            this.lblBaslangic.Location = new System.Drawing.Point(27, 26);
            this.lblBaslangic.Name = "lblBaslangic";
            this.lblBaslangic.Size = new System.Drawing.Size(67, 16);
            this.lblBaslangic.TabIndex = 0;
            this.lblBaslangic.Text = "Baslangıç";
            // 
            // lblBitis
            // 
            this.lblBitis.AutoSize = true;
            this.lblBitis.Location = new System.Drawing.Point(403, 26);
            this.lblBitis.Name = "lblBitis";
            this.lblBitis.Size = new System.Drawing.Size(32, 16);
            this.lblBitis.TabIndex = 0;
            this.lblBitis.Text = "Bitiş";
            // 
            // lblYontemFiltre
            // 
            this.lblYontemFiltre.AutoSize = true;
            this.lblYontemFiltre.Location = new System.Drawing.Point(403, 63);
            this.lblYontemFiltre.Name = "lblYontemFiltre";
            this.lblYontemFiltre.Size = new System.Drawing.Size(53, 16);
            this.lblYontemFiltre.TabIndex = 0;
            this.lblYontemFiltre.Text = "Yöntem";
            // 
            // gridOdemeler
            // 
            this.gridOdemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOdemeler.Location = new System.Drawing.Point(12, 104);
            this.gridOdemeler.Name = "gridOdemeler";
            this.gridOdemeler.RowHeadersWidth = 51;
            this.gridOdemeler.RowTemplate.Height = 24;
            this.gridOdemeler.Size = new System.Drawing.Size(849, 468);
            this.gridOdemeler.TabIndex = 1;
            this.gridOdemeler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.girdOdemeler_CellContentClick);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(266, 590);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(99, 46);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(391, 590);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(99, 46);
            this.btnDuzenle.TabIndex = 2;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(517, 590);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(99, 46);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lblUyeAra
            // 
            this.lblUyeAra.AutoSize = true;
            this.lblUyeAra.Location = new System.Drawing.Point(27, 63);
            this.lblUyeAra.Name = "lblUyeAra";
            this.lblUyeAra.Size = new System.Drawing.Size(56, 16);
            this.lblUyeAra.TabIndex = 0;
            this.lblUyeAra.Text = "Üye Ara";
            // 
            // dtBaslangic
            // 
            this.dtBaslangic.Location = new System.Drawing.Point(102, 21);
            this.dtBaslangic.Name = "dtBaslangic";
            this.dtBaslangic.Size = new System.Drawing.Size(200, 22);
            this.dtBaslangic.TabIndex = 3;
            // 
            // cmbYontemFiltre
            // 
            this.cmbYontemFiltre.FormattingEnabled = true;
            this.cmbYontemFiltre.Location = new System.Drawing.Point(471, 60);
            this.cmbYontemFiltre.Name = "cmbYontemFiltre";
            this.cmbYontemFiltre.Size = new System.Drawing.Size(121, 24);
            this.cmbYontemFiltre.TabIndex = 4;
            // 
            // dtBitis
            // 
            this.dtBitis.Location = new System.Drawing.Point(471, 21);
            this.dtBitis.Name = "dtBitis";
            this.dtBitis.Size = new System.Drawing.Size(200, 22);
            this.dtBitis.TabIndex = 3;
            // 
            // txtUyeAra
            // 
            this.txtUyeAra.Location = new System.Drawing.Point(102, 60);
            this.txtUyeAra.Name = "txtUyeAra";
            this.txtUyeAra.Size = new System.Drawing.Size(122, 22);
            this.txtUyeAra.TabIndex = 5;
            // 
            // FormOdemeListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 658);
            this.Controls.Add(this.txtUyeAra);
            this.Controls.Add(this.cmbYontemFiltre);
            this.Controls.Add(this.dtBitis);
            this.Controls.Add(this.dtBaslangic);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.gridOdemeler);
            this.Controls.Add(this.lblYontemFiltre);
            this.Controls.Add(this.lblBitis);
            this.Controls.Add(this.lblUyeAra);
            this.Controls.Add(this.lblBaslangic);
            this.Name = "FormOdemeListe";
            this.Text = "FormOdemeListe";
            this.Load += new System.EventHandler(this.FormOdemeListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridOdemeler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslangic;
        private System.Windows.Forms.Label lblBitis;
        private System.Windows.Forms.Label lblYontemFiltre;
        private System.Windows.Forms.DataGridView gridOdemeler;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label lblUyeAra;
        private System.Windows.Forms.DateTimePicker dtBaslangic;
        private System.Windows.Forms.ComboBox cmbYontemFiltre;
        private System.Windows.Forms.DateTimePicker dtBitis;
        private System.Windows.Forms.TextBox txtUyeAra;
    }
}