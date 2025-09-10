namespace AidatTakip
{
    partial class FormRaporBorcluListe
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
            this.cmbYil = new System.Windows.Forms.ComboBox();
            this.lblAy = new System.Windows.Forms.Label();
            this.cmbAy = new System.Windows.Forms.ComboBox();
            this.btnListele = new System.Windows.Forms.Button();
            this.gridBorclular = new System.Windows.Forms.DataGridView();
            this.lblTopKalan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridBorclular)).BeginInit();
            this.SuspendLayout();
            // 
            // lblYil
            // 
            this.lblYil.AutoSize = true;
            this.lblYil.Location = new System.Drawing.Point(87, 24);
            this.lblYil.Name = "lblYil";
            this.lblYil.Size = new System.Drawing.Size(22, 16);
            this.lblYil.TabIndex = 0;
            this.lblYil.Text = "Yıl";
            // 
            // cmbYil
            // 
            this.cmbYil.FormattingEnabled = true;
            this.cmbYil.Location = new System.Drawing.Point(146, 21);
            this.cmbYil.Name = "cmbYil";
            this.cmbYil.Size = new System.Drawing.Size(121, 24);
            this.cmbYil.TabIndex = 1;
            // 
            // lblAy
            // 
            this.lblAy.AutoSize = true;
            this.lblAy.Location = new System.Drawing.Point(341, 24);
            this.lblAy.Name = "lblAy";
            this.lblAy.Size = new System.Drawing.Size(23, 16);
            this.lblAy.TabIndex = 0;
            this.lblAy.Text = "Ay";
            // 
            // cmbAy
            // 
            this.cmbAy.FormattingEnabled = true;
            this.cmbAy.Location = new System.Drawing.Point(400, 21);
            this.cmbAy.Name = "cmbAy";
            this.cmbAy.Size = new System.Drawing.Size(121, 24);
            this.cmbAy.TabIndex = 1;
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(567, 16);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(111, 33);
            this.btnListele.TabIndex = 2;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            // 
            // gridBorclular
            // 
            this.gridBorclular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBorclular.Location = new System.Drawing.Point(12, 61);
            this.gridBorclular.Name = "gridBorclular";
            this.gridBorclular.RowHeadersWidth = 51;
            this.gridBorclular.RowTemplate.Height = 24;
            this.gridBorclular.Size = new System.Drawing.Size(776, 301);
            this.gridBorclular.TabIndex = 3;
            // 
            // lblTopKalan
            // 
            this.lblTopKalan.AutoSize = true;
            this.lblTopKalan.Location = new System.Drawing.Point(56, 398);
            this.lblTopKalan.Name = "lblTopKalan";
            this.lblTopKalan.Size = new System.Drawing.Size(104, 16);
            this.lblTopKalan.TabIndex = 4;
            this.lblTopKalan.Text = "Toplam Kalan: 0";
            // 
            // FormRaporBorcluListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTopKalan);
            this.Controls.Add(this.gridBorclular);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.cmbAy);
            this.Controls.Add(this.cmbYil);
            this.Controls.Add(this.lblAy);
            this.Controls.Add(this.lblYil);
            this.Name = "FormRaporBorcluListe";
            this.Text = "FormRaporBorcluListe";
            this.Load += new System.EventHandler(this.FormRaporBorcluListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBorclular)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblYil;
        private System.Windows.Forms.ComboBox cmbYil;
        private System.Windows.Forms.Label lblAy;
        private System.Windows.Forms.ComboBox cmbAy;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.DataGridView gridBorclular;
        private System.Windows.Forms.Label lblTopKalan;
    }
}