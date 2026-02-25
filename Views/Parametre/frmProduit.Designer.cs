namespace AppSenAgriculture.Views.Parametre
{
    partial class frmProduit
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
            this.dgProduits = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLibelleProduit = new System.Windows.Forms.TextBox();
            this.txtDescriptionProduit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrixMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrixMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCategorie = new System.Windows.Forms.ComboBox();
            this.cmbUnite = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnSelection = new System.Windows.Forms.Button();
            this.gbRecherche = new System.Windows.Forms.GroupBox();
            this.btnReinitialiserRecherche = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.txtRecherchePrixMin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRechercheDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRechercheLibelle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduits)).BeginInit();
            this.gbRecherche.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgProduits
            // 
            this.dgProduits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProduits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProduits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProduits.Location = new System.Drawing.Point(400, 185);
            this.dgProduits.Name = "dgProduits";
            this.dgProduits.RowHeadersWidth = 62;
            this.dgProduits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgProduits.Size = new System.Drawing.Size(666, 332);
            this.dgProduits.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Libelle Produit";
            // 
            // txtLibelleProduit
            // 
            this.txtLibelleProduit.Location = new System.Drawing.Point(24, 50);
            this.txtLibelleProduit.Name = "txtLibelleProduit";
            this.txtLibelleProduit.Size = new System.Drawing.Size(352, 35);
            this.txtLibelleProduit.TabIndex = 2;
            // 
            // txtDescriptionProduit
            // 
            this.txtDescriptionProduit.Location = new System.Drawing.Point(24, 121);
            this.txtDescriptionProduit.Multiline = true;
            this.txtDescriptionProduit.Name = "txtDescriptionProduit";
            this.txtDescriptionProduit.Size = new System.Drawing.Size(352, 35);
            this.txtDescriptionProduit.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // txtPrixMin
            // 
            this.txtPrixMin.Location = new System.Drawing.Point(24, 192);
            this.txtPrixMin.Name = "txtPrixMin";
            this.txtPrixMin.Size = new System.Drawing.Size(352, 35);
            this.txtPrixMin.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Prix Min";
            // 
            // txtPrixMax
            // 
            this.txtPrixMax.Location = new System.Drawing.Point(24, 263);
            this.txtPrixMax.Name = "txtPrixMax";
            this.txtPrixMax.Size = new System.Drawing.Size(352, 35);
            this.txtPrixMax.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Prix Max";
            // 
            // cmbCategorie
            // 
            this.cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategorie.FormattingEnabled = true;
            this.cmbCategorie.Location = new System.Drawing.Point(24, 334);
            this.cmbCategorie.Name = "cmbCategorie";
            this.cmbCategorie.Size = new System.Drawing.Size(352, 37);
            this.cmbCategorie.TabIndex = 10;
            this.cmbCategorie.SelectedIndexChanged += new System.EventHandler(this.cmbCategorie_SelectedIndexChanged);
            // 
            // cmbUnite
            // 
            this.cmbUnite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnite.FormattingEnabled = true;
            this.cmbUnite.Location = new System.Drawing.Point(24, 405);
            this.cmbUnite.Name = "cmbUnite";
            this.cmbUnite.Size = new System.Drawing.Size(352, 37);
            this.cmbUnite.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Categorie";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "Unite de mesure";
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(24, 469);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(82, 36);
            this.btnAjouter.TabIndex = 13;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(112, 469);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(82, 36);
            this.btnModifier.TabIndex = 14;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(200, 469);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(82, 36);
            this.btnSupprimer.TabIndex = 15;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnSelection
            // 
            this.btnSelection.Location = new System.Drawing.Point(288, 469);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(88, 36);
            this.btnSelection.TabIndex = 16;
            this.btnSelection.Text = "Charger";
            this.btnSelection.UseVisualStyleBackColor = true;
            this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
            // 
            // gbRecherche
            // 
            this.gbRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRecherche.Controls.Add(this.btnReinitialiserRecherche);
            this.gbRecherche.Controls.Add(this.btnRechercher);
            this.gbRecherche.Controls.Add(this.txtRecherchePrixMin);
            this.gbRecherche.Controls.Add(this.label9);
            this.gbRecherche.Controls.Add(this.txtRechercheDescription);
            this.gbRecherche.Controls.Add(this.label8);
            this.gbRecherche.Controls.Add(this.txtRechercheLibelle);
            this.gbRecherche.Controls.Add(this.label7);
            this.gbRecherche.Location = new System.Drawing.Point(400, 12);
            this.gbRecherche.Name = "gbRecherche";
            this.gbRecherche.Size = new System.Drawing.Size(666, 156);
            this.gbRecherche.TabIndex = 17;
            this.gbRecherche.TabStop = false;
            this.gbRecherche.Text = "Recherche produit";
            // 
            // btnReinitialiserRecherche
            // 
            this.btnReinitialiserRecherche.Location = new System.Drawing.Point(546, 104);
            this.btnReinitialiserRecherche.Name = "btnReinitialiserRecherche";
            this.btnReinitialiserRecherche.Size = new System.Drawing.Size(96, 32);
            this.btnReinitialiserRecherche.TabIndex = 7;
            this.btnReinitialiserRecherche.Text = "Reset";
            this.btnReinitialiserRecherche.UseVisualStyleBackColor = true;
            this.btnReinitialiserRecherche.Click += new System.EventHandler(this.btnReinitialiserRecherche_Click);
            // 
            // btnRechercher
            // 
            this.btnRechercher.Location = new System.Drawing.Point(444, 104);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(96, 32);
            this.btnRechercher.TabIndex = 6;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // txtRecherchePrixMin
            // 
            this.txtRecherchePrixMin.Location = new System.Drawing.Point(444, 62);
            this.txtRecherchePrixMin.Name = "txtRecherchePrixMin";
            this.txtRecherchePrixMin.Size = new System.Drawing.Size(198, 35);
            this.txtRecherchePrixMin.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(440, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 29);
            this.label9.TabIndex = 4;
            this.label9.Text = "Prix Min ";
            // 
            // txtRechercheDescription
            // 
            this.txtRechercheDescription.Location = new System.Drawing.Point(227, 62);
            this.txtRechercheDescription.Name = "txtRechercheDescription";
            this.txtRechercheDescription.Size = new System.Drawing.Size(198, 35);
            this.txtRechercheDescription.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 29);
            this.label8.TabIndex = 2;
            this.label8.Text = "Description";
            // 
            // txtRechercheLibelle
            // 
            this.txtRechercheLibelle.Location = new System.Drawing.Point(14, 62);
            this.txtRechercheLibelle.Name = "txtRechercheLibelle";
            this.txtRechercheLibelle.Size = new System.Drawing.Size(198, 35);
            this.txtRechercheLibelle.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Libelle";
            // 
            // frmProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 542);
            this.ControlBox = false;
            this.Controls.Add(this.gbRecherche);
            this.Controls.Add(this.btnSelection);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbUnite);
            this.Controls.Add(this.cmbCategorie);
            this.Controls.Add(this.txtPrixMax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrixMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescriptionProduit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLibelleProduit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgProduits);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmProduit";
            this.Text = "Produit";
            this.Load += new System.EventHandler(this.frmProduit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProduits)).EndInit();
            this.gbRecherche.ResumeLayout(false);
            this.gbRecherche.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProduits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLibelleProduit;
        private System.Windows.Forms.TextBox txtDescriptionProduit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrixMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrixMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCategorie;
        private System.Windows.Forms.ComboBox cmbUnite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnSelection;
        private System.Windows.Forms.GroupBox gbRecherche;
        private System.Windows.Forms.Button btnReinitialiserRecherche;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.TextBox txtRecherchePrixMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRechercheDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRechercheLibelle;
        private System.Windows.Forms.Label label7;
    }
}
