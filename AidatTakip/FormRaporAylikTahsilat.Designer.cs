namespace AidatTakip
{
    partial class FormRaporAylikTahsilat
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
            this.lblAy = new System.Windows.Forms.Label();
            this.lblYil = new System.Windows.Forms.Label();
            this.cmbYil = new System.Windows.Forms.ComboBox();
            this.cmbAy = new System.Windows.Forms.ComboBox();
            this.btnListele = new System.Windows.Forms.Button();
            this.gridDetay = new System.Windows.Forms.DataGridView();
            this.lblTopBekleyen = new System.Windows.Forms.Label();
            this.lblTopKismi = new System.Windows.Forms.Label();
            this.lblTopOdendi = new System.Windows.Forms.Label();
            this.lblTopKalan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetay)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAy
            // 
            this.lblAy.AutoSize = true;
            this.lblAy.Location = new System.Drawing.Point(280, 31);
            this.lblAy.Name = "lblAy";
            this.lblAy.Size = new System.Drawing.Size(23, 16);
            this.lblAy.TabIndex = 0;
            this.lblAy.Text = "Ay";
            // 
            // lblYil
            // 
            this.lblYil.AutoSize = true;
            this.lblYil.Location = new System.Drawing.Point(24, 31);
            this.lblYil.Name = "lblYil";
            this.lblYil.Size = new System.Drawing.Size(22, 16);
            this.lblYil.TabIndex = 0;
            this.lblYil.Text = "Yıl";
            // 
            // cmbYil
            // 
            this.cmbYil.FormattingEnabled = true;
            this.cmbYil.Location = new System.Drawing.Point(74, 28);
            this.cmbYil.Name = "cmbYil";
            this.cmbYil.Size = new System.Drawing.Size(121, 24);
            this.cmbYil.TabIndex = 1;
            // 
            // cmbAy
            // 
            this.cmbAy.FormattingEnabled = true;
            this.cmbAy.Location = new System.Drawing.Point(330, 28);
            this.cmbAy.Name = "cmbAy";
            this.cmbAy.Size = new System.Drawing.Size(121, 24);
            this.cmbAy.TabIndex = 1;
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(527, 23);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(125, 33);
            this.btnListele.TabIndex = 2;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            // 
            // gridDetay
            // 
            this.gridDetay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetay.Location = new System.Drawing.Point(12, 71);
            this.gridDetay.Name = "gridDetay";
            this.gridDetay.RowHeadersWidth = 51;
            this.gridDetay.RowTemplate.Height = 24;
            this.gridDetay.Size = new System.Drawing.Size(685, 331);
            this.gridDetay.TabIndex = 3;
            this.gridDetay.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetay_CellContentClick);
            // 
            // lblTopBekleyen
            // 
            this.lblTopBekleyen.AutoSize = true;
            this.lblTopBekleyen.Location = new System.Drawing.Point(116, 442);
            this.lblTopBekleyen.Name = "lblTopBekleyen";
            this.lblTopBekleyen.Size = new System.Drawing.Size(77, 16);
            this.lblTopBekleyen.TabIndex = 4;
            this.lblTopBekleyen.Text = "Bekleyen: 0";
            // 
            // lblTopKismi
            // 
            this.lblTopKismi.AutoSize = true;
            this.lblTopKismi.Location = new System.Drawing.Point(243, 442);
            this.lblTopKismi.Name = "lblTopKismi";
            this.lblTopKismi.Size = new System.Drawing.Size(55, 16);
            this.lblTopKismi.TabIndex = 4;
            this.lblTopKismi.Text = "Kismi: 0 ";
            // 
            // lblTopOdendi
            // 
            this.lblTopOdendi.AutoSize = true;
            this.lblTopOdendi.Location = new System.Drawing.Point(353, 442);
            this.lblTopOdendi.Name = "lblTopOdendi";
            this.lblTopOdendi.Size = new System.Drawing.Size(64, 16);
            this.lblTopOdendi.TabIndex = 4;
            this.lblTopOdendi.Text = "Odendi: 0";
            // 
            // lblTopKalan
            // 
            this.lblTopKalan.AutoSize = true;
            this.lblTopKalan.Location = new System.Drawing.Point(469, 442);
            this.lblTopKalan.Name = "lblTopKalan";
            this.lblTopKalan.Size = new System.Drawing.Size(96, 16);
            this.lblTopKalan.TabIndex = 4;
            this.lblTopKalan.Text = "Genel Kalan: 0 ";
            // 
            // FormRaporAylikTahsilat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 495);
            this.Controls.Add(this.lblTopKalan);
            this.Controls.Add(this.lblTopOdendi);
            this.Controls.Add(this.lblTopKismi);
            this.Controls.Add(this.lblTopBekleyen);
            this.Controls.Add(this.gridDetay);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.cmbAy);
            this.Controls.Add(this.cmbYil);
            this.Controls.Add(this.lblYil);
            this.Controls.Add(this.lblAy);
            this.Name = "FormRaporAylikTahsilat";
            this.Text = "FormRaporAylikTahsilat";
            this.Load += new System.EventHandler(this.FormRaporAylikTahsilat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAy;
        private System.Windows.Forms.Label lblYil;
        private System.Windows.Forms.ComboBox cmbYil;
        private System.Windows.Forms.ComboBox cmbAy;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.DataGridView gridDetay;
        private System.Windows.Forms.Label lblTopBekleyen;
        private System.Windows.Forms.Label lblTopKismi;
        private System.Windows.Forms.Label lblTopOdendi;
        private System.Windows.Forms.Label lblTopKalan;
    }
}