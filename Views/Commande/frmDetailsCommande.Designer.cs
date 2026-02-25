namespace AppSenAgriculture.Views.Commande
{
    partial class frmDetailsCommande
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblProduit;
        private System.Windows.Forms.Label lblQuantite;
        private System.Windows.Forms.Label lblPrixUnitaire;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblMeta = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblProduit = new System.Windows.Forms.Label();
            this.cmbProduit = new System.Windows.Forms.ComboBox();
            this.lblQuantite = new System.Windows.Forms.Label();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.lblPrixUnitaire = new System.Windows.Forms.Label();
            this.txtPrixUnitaire = new System.Windows.Forms.TextBox();
            this.btnAjouterDetail = new System.Windows.Forms.Button();
            this.btnModifierDetail = new System.Windows.Forms.Button();
            this.btnSupprimerDetail = new System.Windows.Forms.Button();
            this.btnChargerDetail = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.lblTotalCommande = new System.Windows.Forms.Label();
            this.dgDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(289, 13);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Nouvelle commande (brouillon non enregistre)";
            // 
            // lblMeta
            // 
            this.lblMeta.AutoSize = true;
            this.lblMeta.Location = new System.Drawing.Point(20, 35);
            this.lblMeta.Name = "lblMeta";
            this.lblMeta.Size = new System.Drawing.Size(292, 13);
            this.lblMeta.TabIndex = 1;
            this.lblMeta.Text = "Statut: Brouillon | Date commande: - | Date modification: -";
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(620, 15);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(33, 13);
            this.lblClient.TabIndex = 2;
            this.lblClient.Text = "Client";
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(620, 30);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(338, 21);
            this.cmbClient.TabIndex = 3;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // lblProduit
            // 
            this.lblProduit.AutoSize = true;
            this.lblProduit.Location = new System.Drawing.Point(20, 65);
            this.lblProduit.Name = "lblProduit";
            this.lblProduit.Size = new System.Drawing.Size(41, 13);
            this.lblProduit.TabIndex = 4;
            this.lblProduit.Text = "Produit";
            // 
            // cmbProduit
            // 
            this.cmbProduit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduit.FormattingEnabled = true;
            this.cmbProduit.Location = new System.Drawing.Point(20, 90);
            this.cmbProduit.Name = "cmbProduit";
            this.cmbProduit.Size = new System.Drawing.Size(300, 21);
            this.cmbProduit.TabIndex = 5;
            // 
            // lblQuantite
            // 
            this.lblQuantite.AutoSize = true;
            this.lblQuantite.Location = new System.Drawing.Point(340, 65);
            this.lblQuantite.Name = "lblQuantite";
            this.lblQuantite.Size = new System.Drawing.Size(47, 13);
            this.lblQuantite.TabIndex = 6;
            this.lblQuantite.Text = "Quantite";
            // 
            // txtQuantite
            // 
            this.txtQuantite.Location = new System.Drawing.Point(340, 90);
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Size = new System.Drawing.Size(120, 20);
            this.txtQuantite.TabIndex = 7;
            // 
            // lblPrixUnitaire
            // 
            this.lblPrixUnitaire.AutoSize = true;
            this.lblPrixUnitaire.Location = new System.Drawing.Point(480, 65);
            this.lblPrixUnitaire.Name = "lblPrixUnitaire";
            this.lblPrixUnitaire.Size = new System.Drawing.Size(59, 13);
            this.lblPrixUnitaire.TabIndex = 8;
            this.lblPrixUnitaire.Text = "Prix unitaire";
            // 
            // txtPrixUnitaire
            // 
            this.txtPrixUnitaire.Location = new System.Drawing.Point(480, 90);
            this.txtPrixUnitaire.Name = "txtPrixUnitaire";
            this.txtPrixUnitaire.Size = new System.Drawing.Size(120, 20);
            this.txtPrixUnitaire.TabIndex = 9;
            // 
            // btnAjouterDetail
            // 
            this.btnAjouterDetail.Location = new System.Drawing.Point(620, 87);
            this.btnAjouterDetail.Name = "btnAjouterDetail";
            this.btnAjouterDetail.Size = new System.Drawing.Size(80, 23);
            this.btnAjouterDetail.TabIndex = 10;
            this.btnAjouterDetail.Text = "Ajouter";
            this.btnAjouterDetail.UseVisualStyleBackColor = true;
            this.btnAjouterDetail.Click += new System.EventHandler(this.btnAjouterDetail_Click);
            // 
            // btnModifierDetail
            // 
            this.btnModifierDetail.Location = new System.Drawing.Point(706, 87);
            this.btnModifierDetail.Name = "btnModifierDetail";
            this.btnModifierDetail.Size = new System.Drawing.Size(80, 23);
            this.btnModifierDetail.TabIndex = 11;
            this.btnModifierDetail.Text = "Modifier";
            this.btnModifierDetail.UseVisualStyleBackColor = true;
            this.btnModifierDetail.Click += new System.EventHandler(this.btnModifierDetail_Click);
            // 
            // btnSupprimerDetail
            // 
            this.btnSupprimerDetail.Location = new System.Drawing.Point(792, 87);
            this.btnSupprimerDetail.Name = "btnSupprimerDetail";
            this.btnSupprimerDetail.Size = new System.Drawing.Size(90, 23);
            this.btnSupprimerDetail.TabIndex = 12;
            this.btnSupprimerDetail.Text = "Supprimer";
            this.btnSupprimerDetail.UseVisualStyleBackColor = true;
            this.btnSupprimerDetail.Click += new System.EventHandler(this.btnSupprimerDetail_Click);
            // 
            // btnChargerDetail
            // 
            this.btnChargerDetail.Location = new System.Drawing.Point(888, 87);
            this.btnChargerDetail.Name = "btnChargerDetail";
            this.btnChargerDetail.Size = new System.Drawing.Size(70, 23);
            this.btnChargerDetail.TabIndex = 13;
            this.btnChargerDetail.Text = "Charger";
            this.btnChargerDetail.UseVisualStyleBackColor = true;
            this.btnChargerDetail.Click += new System.EventHandler(this.btnChargerDetail_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(20, 128);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(120, 24);
            this.btnEnregistrer.TabIndex = 14;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(146, 128);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(120, 24);
            this.btnValider.TabIndex = 15;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // lblTotalCommande
            // 
            this.lblTotalCommande.AutoSize = true;
            this.lblTotalCommande.Location = new System.Drawing.Point(760, 132);
            this.lblTotalCommande.Name = "lblTotalCommande";
            this.lblTotalCommande.Size = new System.Drawing.Size(49, 13);
            this.lblTotalCommande.TabIndex = 16;
            this.lblTotalCommande.Text = "Total: 0";
            // 
            // dgDetails
            // 
            this.dgDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetails.Location = new System.Drawing.Point(20, 165);
            this.dgDetails.MultiSelect = false;
            this.dgDetails.Name = "dgDetails";
            this.dgDetails.ReadOnly = true;
            this.dgDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetails.Size = new System.Drawing.Size(938, 375);
            this.dgDetails.TabIndex = 17;
            // 
            // frmDetailsCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 600);
            this.Controls.Add(this.dgDetails);
            this.Controls.Add(this.lblTotalCommande);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnChargerDetail);
            this.Controls.Add(this.btnSupprimerDetail);
            this.Controls.Add(this.btnModifierDetail);
            this.Controls.Add(this.btnAjouterDetail);
            this.Controls.Add(this.txtPrixUnitaire);
            this.Controls.Add(this.lblPrixUnitaire);
            this.Controls.Add(this.txtQuantite);
            this.Controls.Add(this.lblQuantite);
            this.Controls.Add(this.cmbProduit);
            this.Controls.Add(this.lblProduit);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblMeta);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmDetailsCommande";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Details commande";
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgDetails;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.ComboBox cmbProduit;
        private System.Windows.Forms.TextBox txtQuantite;
        private System.Windows.Forms.TextBox txtPrixUnitaire;
        private System.Windows.Forms.Label lblTotalCommande;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblMeta;
        private System.Windows.Forms.Button btnAjouterDetail;
        private System.Windows.Forms.Button btnModifierDetail;
        private System.Windows.Forms.Button btnSupprimerDetail;
        private System.Windows.Forms.Button btnChargerDetail;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnValider;
    }
}
