namespace AidatTakip
{
    partial class FormRaporUyeEkstresi
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
            this.cmbUye = new System.Windows.Forms.ComboBox();
            this.gridEkstre = new System.Windows.Forms.DataGridView();
            this.lblTopAidat = new System.Windows.Forms.Label();
            this.lblTopOdeme = new System.Windows.Forms.Label();
            this.lblGenelBakiye = new System.Windows.Forms.Label();
            this.btnListele = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridEkstre)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUye
            // 
            this.lblUye.AutoSize = true;
            this.lblUye.Location = new System.Drawing.Point(22, 20);
            this.lblUye.Name = "lblUye";
            this.lblUye.Size = new System.Drawing.Size(32, 16);
            this.lblUye.TabIndex = 0;
            this.lblUye.Text = "Üye";
            // 
            // cmbUye
            // 
            this.cmbUye.FormattingEnabled = true;
            this.cmbUye.Location = new System.Drawing.Point(72, 17);
            this.cmbUye.Name = "cmbUye";
            this.cmbUye.Size = new System.Drawing.Size(121, 24);
            this.cmbUye.TabIndex = 1;
            // 
            // gridEkstre
            // 
            this.gridEkstre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEkstre.Location = new System.Drawing.Point(12, 49);
            this.gridEkstre.Name = "gridEkstre";
            this.gridEkstre.RowHeadersWidth = 51;
            this.gridEkstre.RowTemplate.Height = 24;
            this.gridEkstre.Size = new System.Drawing.Size(797, 387);
            this.gridEkstre.TabIndex = 3;
            // 
            // lblTopAidat
            // 
            this.lblTopAidat.AutoSize = true;
            this.lblTopAidat.Location = new System.Drawing.Point(162, 456);
            this.lblTopAidat.Name = "lblTopAidat";
            this.lblTopAidat.Size = new System.Drawing.Size(101, 16);
            this.lblTopAidat.TabIndex = 4;
            this.lblTopAidat.Text = "Toplam Aidat: 0";
            // 
            // lblTopOdeme
            // 
            this.lblTopOdeme.AutoSize = true;
            this.lblTopOdeme.Location = new System.Drawing.Point(321, 456);
            this.lblTopOdeme.Name = "lblTopOdeme";
            this.lblTopOdeme.Size = new System.Drawing.Size(115, 16);
            this.lblTopOdeme.TabIndex = 4;
            this.lblTopOdeme.Text = "Toplam Odeme: 0";
            // 
            // lblGenelBakiye
            // 
            this.lblGenelBakiye.AutoSize = true;
            this.lblGenelBakiye.Location = new System.Drawing.Point(489, 456);
            this.lblGenelBakiye.Name = "lblGenelBakiye";
            this.lblGenelBakiye.Size = new System.Drawing.Size(159, 16);
            this.lblGenelBakiye.TabIndex = 4;
            this.lblGenelBakiye.Text = "Bakiye (Aidat - Odeme): 0";
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(221, 14);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(91, 28);
            this.btnListele.TabIndex = 5;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            // 
            // FormRaporUyeEkstresi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 490);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.lblGenelBakiye);
            this.Controls.Add(this.lblTopOdeme);
            this.Controls.Add(this.lblTopAidat);
            this.Controls.Add(this.gridEkstre);
            this.Controls.Add(this.cmbUye);
            this.Controls.Add(this.lblUye);
            this.Name = "FormRaporUyeEkstresi";
            this.Text = "FormRaporUyeEkstresi";
            this.Load += new System.EventHandler(this.FormRaporUyeEkstresi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEkstre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUye;
        private System.Windows.Forms.ComboBox cmbUye;
        private System.Windows.Forms.DataGridView gridEkstre;
        private System.Windows.Forms.Label lblTopAidat;
        private System.Windows.Forms.Label lblTopOdeme;
        private System.Windows.Forms.Label lblGenelBakiye;
        private System.Windows.Forms.Button btnListele;
    }
}