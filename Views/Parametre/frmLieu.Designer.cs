namespace AppSenAgriculture.Views.Parametre
{
    partial class frmLieu
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
            this.gbRegions = new System.Windows.Forms.GroupBox();
            this.btnSupprimerRegion = new System.Windows.Forms.Button();
            this.btnAjouterRegion = new System.Windows.Forms.Button();
            this.txtNomRegion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgRegions = new System.Windows.Forms.DataGridView();
            this.gbDepartements = new System.Windows.Forms.GroupBox();
            this.btnSupprimerDepartement = new System.Windows.Forms.Button();
            this.btnAjouterDepartement = new System.Windows.Forms.Button();
            this.cmbRegionDepartement = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomDepartement = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgDepartements = new System.Windows.Forms.DataGridView();
            this.gbRegions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRegions)).BeginInit();
            this.gbDepartements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDepartements)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRegions
            // 
            this.gbRegions.Controls.Add(this.btnSupprimerRegion);
            this.gbRegions.Controls.Add(this.btnAjouterRegion);
            this.gbRegions.Controls.Add(this.txtNomRegion);
            this.gbRegions.Controls.Add(this.label1);
            this.gbRegions.Controls.Add(this.dgRegions);
            this.gbRegions.Location = new System.Drawing.Point(17, 17);
            this.gbRegions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbRegions.Name = "gbRegions";
            this.gbRegions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbRegions.Size = new System.Drawing.Size(496, 525);
            this.gbRegions.TabIndex = 0;
            this.gbRegions.TabStop = false;
            this.gbRegions.Text = "Regions";
            // 
            // btnSupprimerRegion
            // 
            this.btnSupprimerRegion.Location = new System.Drawing.Point(149, 125);
            this.btnSupprimerRegion.Name = "btnSupprimerRegion";
            this.btnSupprimerRegion.Size = new System.Drawing.Size(119, 35);
            this.btnSupprimerRegion.TabIndex = 4;
            this.btnSupprimerRegion.Text = "Supprimer";
            this.btnSupprimerRegion.UseVisualStyleBackColor = true;
            this.btnSupprimerRegion.Click += new System.EventHandler(this.btnSupprimerRegion_Click);
            // 
            // btnAjouterRegion
            // 
            this.btnAjouterRegion.Location = new System.Drawing.Point(20, 125);
            this.btnAjouterRegion.Name = "btnAjouterRegion";
            this.btnAjouterRegion.Size = new System.Drawing.Size(111, 35);
            this.btnAjouterRegion.TabIndex = 3;
            this.btnAjouterRegion.Text = "Ajouter";
            this.btnAjouterRegion.UseVisualStyleBackColor = true;
            this.btnAjouterRegion.Click += new System.EventHandler(this.btnAjouterRegion_Click);
            // 
            // txtNomRegion
            // 
            this.txtNomRegion.Location = new System.Drawing.Point(20, 78);
            this.txtNomRegion.Name = "txtNomRegion";
            this.txtNomRegion.Size = new System.Drawing.Size(453, 26);
            this.txtNomRegion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom Region";
            // 
            // dgRegions
            // 
            this.dgRegions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRegions.Location = new System.Drawing.Point(20, 184);
            this.dgRegions.Name = "dgRegions";
            this.dgRegions.Size = new System.Drawing.Size(453, 319);
            this.dgRegions.TabIndex = 0;
            // 
            // gbDepartements
            // 
            this.gbDepartements.Controls.Add(this.btnSupprimerDepartement);
            this.gbDepartements.Controls.Add(this.btnAjouterDepartement);
            this.gbDepartements.Controls.Add(this.cmbRegionDepartement);
            this.gbDepartements.Controls.Add(this.label3);
            this.gbDepartements.Controls.Add(this.txtNomDepartement);
            this.gbDepartements.Controls.Add(this.label2);
            this.gbDepartements.Controls.Add(this.dgDepartements);
            this.gbDepartements.Location = new System.Drawing.Point(530, 17);
            this.gbDepartements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDepartements.Name = "gbDepartements";
            this.gbDepartements.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDepartements.Size = new System.Drawing.Size(571, 525);
            this.gbDepartements.TabIndex = 1;
            this.gbDepartements.TabStop = false;
            this.gbDepartements.Text = "Departements";
            // 
            // btnSupprimerDepartement
            // 
            this.btnSupprimerDepartement.Location = new System.Drawing.Point(150, 128);
            this.btnSupprimerDepartement.Name = "btnSupprimerDepartement";
            this.btnSupprimerDepartement.Size = new System.Drawing.Size(119, 35);
            this.btnSupprimerDepartement.TabIndex = 6;
            this.btnSupprimerDepartement.Text = "Supprimer";
            this.btnSupprimerDepartement.UseVisualStyleBackColor = true;
            this.btnSupprimerDepartement.Click += new System.EventHandler(this.btnSupprimerDepartement_Click);
            // 
            // btnAjouterDepartement
            // 
            this.btnAjouterDepartement.Location = new System.Drawing.Point(20, 128);
            this.btnAjouterDepartement.Name = "btnAjouterDepartement";
            this.btnAjouterDepartement.Size = new System.Drawing.Size(112, 35);
            this.btnAjouterDepartement.TabIndex = 5;
            this.btnAjouterDepartement.Text = "Ajouter";
            this.btnAjouterDepartement.UseVisualStyleBackColor = true;
            this.btnAjouterDepartement.Click += new System.EventHandler(this.btnAjouterDepartement_Click);
            // 
            // cmbRegionDepartement
            // 
            this.cmbRegionDepartement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegionDepartement.FormattingEnabled = true;
            this.cmbRegionDepartement.Location = new System.Drawing.Point(275, 132);
            this.cmbRegionDepartement.Name = "cmbRegionDepartement";
            this.cmbRegionDepartement.Size = new System.Drawing.Size(274, 28);
            this.cmbRegionDepartement.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Region associee";
            // 
            // txtNomDepartement
            // 
            this.txtNomDepartement.Location = new System.Drawing.Point(20, 78);
            this.txtNomDepartement.Name = "txtNomDepartement";
            this.txtNomDepartement.Size = new System.Drawing.Size(529, 26);
            this.txtNomDepartement.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom Departement";
            // 
            // dgDepartements
            // 
            this.dgDepartements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDepartements.Location = new System.Drawing.Point(20, 184);
            this.dgDepartements.Name = "dgDepartements";
            this.dgDepartements.Size = new System.Drawing.Size(529, 319);
            this.dgDepartements.TabIndex = 0;
            // 
            // frmLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 559);
            this.ControlBox = false;
            this.Controls.Add(this.gbDepartements);
            this.Controls.Add(this.gbRegions);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLieu";
            this.Text = "Lieu";
            this.Load += new System.EventHandler(this.frmLieu_Load);
            this.gbRegions.ResumeLayout(false);
            this.gbRegions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRegions)).EndInit();
            this.gbDepartements.ResumeLayout(false);
            this.gbDepartements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDepartements)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRegions;
        private System.Windows.Forms.Button btnSupprimerRegion;
        private System.Windows.Forms.Button btnAjouterRegion;
        private System.Windows.Forms.TextBox txtNomRegion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgRegions;
        private System.Windows.Forms.GroupBox gbDepartements;
        private System.Windows.Forms.Button btnSupprimerDepartement;
        private System.Windows.Forms.Button btnAjouterDepartement;
        private System.Windows.Forms.ComboBox cmbRegionDepartement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomDepartement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgDepartements;
    }
}
