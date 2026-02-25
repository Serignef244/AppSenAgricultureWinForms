namespace AppSenAgriculture.Views.Commande
{
    partial class frmCommande
    {
        private System.ComponentModel.IContainer components = null;

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
            this.btnNouvelleCommande = new System.Windows.Forms.Button();
            this.btnSupprimerCommande = new System.Windows.Forms.Button();
            this.btnDetailsCommande = new System.Windows.Forms.Button();
            this.lblFiltreStatut = new System.Windows.Forms.Label();
            this.cmbFiltreStatut = new System.Windows.Forms.ComboBox();
            this.lblRechercheClient = new System.Windows.Forms.Label();
            this.txtRechercheClient = new System.Windows.Forms.TextBox();
            this.lblRechercheProduit = new System.Windows.Forms.Label();
            this.txtRechercheProduit = new System.Windows.Forms.TextBox();
            this.lblRechercheDate = new System.Windows.Forms.Label();
            this.dtpRechercheDate = new System.Windows.Forms.DateTimePicker();
            this.dgCommandes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgCommandes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNouvelleCommande
            // 
            this.btnNouvelleCommande.Location = new System.Drawing.Point(20, 20);
            this.btnNouvelleCommande.Name = "btnNouvelleCommande";
            this.btnNouvelleCommande.Size = new System.Drawing.Size(160, 28);
            this.btnNouvelleCommande.TabIndex = 0;
            this.btnNouvelleCommande.Text = "Nouvelle commande";
            this.btnNouvelleCommande.UseVisualStyleBackColor = true;
            this.btnNouvelleCommande.Click += new System.EventHandler(this.btnNouvelleCommande_Click);
            // 
            // btnSupprimerCommande
            // 
            this.btnSupprimerCommande.Location = new System.Drawing.Point(186, 20);
            this.btnSupprimerCommande.Name = "btnSupprimerCommande";
            this.btnSupprimerCommande.Size = new System.Drawing.Size(110, 28);
            this.btnSupprimerCommande.TabIndex = 1;
            this.btnSupprimerCommande.Text = "Supprimer";
            this.btnSupprimerCommande.UseVisualStyleBackColor = true;
            this.btnSupprimerCommande.Click += new System.EventHandler(this.btnSupprimerCommande_Click);
            // 
            // btnDetailsCommande
            // 
            this.btnDetailsCommande.Location = new System.Drawing.Point(302, 20);
            this.btnDetailsCommande.Name = "btnDetailsCommande";
            this.btnDetailsCommande.Size = new System.Drawing.Size(150, 28);
            this.btnDetailsCommande.TabIndex = 2;
            this.btnDetailsCommande.Text = "Details / Valider";
            this.btnDetailsCommande.UseVisualStyleBackColor = true;
            this.btnDetailsCommande.Click += new System.EventHandler(this.btnDetailsCommande_Click);
            // 
            // lblFiltreStatut
            // 
            this.lblFiltreStatut.AutoSize = true;
            this.lblFiltreStatut.Location = new System.Drawing.Point(620, 28);
            this.lblFiltreStatut.Name = "lblFiltreStatut";
            this.lblFiltreStatut.Size = new System.Drawing.Size(37, 13);
            this.lblFiltreStatut.TabIndex = 3;
            this.lblFiltreStatut.Text = "Statut";
            // 
            // cmbFiltreStatut
            // 
            this.cmbFiltreStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltreStatut.FormattingEnabled = true;
            this.cmbFiltreStatut.Items.AddRange(new object[] {
            "Tous",
            "En cours",
            "Validee"});
            this.cmbFiltreStatut.Location = new System.Drawing.Point(663, 24);
            this.cmbFiltreStatut.Name = "cmbFiltreStatut";
            this.cmbFiltreStatut.Size = new System.Drawing.Size(192, 21);
            this.cmbFiltreStatut.TabIndex = 4;
            this.cmbFiltreStatut.SelectedIndexChanged += new System.EventHandler(this.cmbFiltreStatut_SelectedIndexChanged);
            // 
            // lblRechercheClient
            // 
            this.lblRechercheClient.AutoSize = true;
            this.lblRechercheClient.Location = new System.Drawing.Point(20, 64);
            this.lblRechercheClient.Name = "lblRechercheClient";
            this.lblRechercheClient.Size = new System.Drawing.Size(36, 13);
            this.lblRechercheClient.TabIndex = 4;
            this.lblRechercheClient.Text = "Client";
            // 
            // txtRechercheClient
            // 
            this.txtRechercheClient.Location = new System.Drawing.Point(23, 80);
            this.txtRechercheClient.Name = "txtRechercheClient";
            this.txtRechercheClient.Size = new System.Drawing.Size(240, 20);
            this.txtRechercheClient.TabIndex = 5;
            this.txtRechercheClient.TextChanged += new System.EventHandler(this.txtRechercheClient_TextChanged);
            // 
            // lblRechercheProduit
            // 
            this.lblRechercheProduit.AutoSize = true;
            this.lblRechercheProduit.Location = new System.Drawing.Point(280, 64);
            this.lblRechercheProduit.Name = "lblRechercheProduit";
            this.lblRechercheProduit.Size = new System.Drawing.Size(44, 13);
            this.lblRechercheProduit.TabIndex = 6;
            this.lblRechercheProduit.Text = "Produit";
            // 
            // txtRechercheProduit
            // 
            this.txtRechercheProduit.Location = new System.Drawing.Point(283, 80);
            this.txtRechercheProduit.Name = "txtRechercheProduit";
            this.txtRechercheProduit.Size = new System.Drawing.Size(240, 20);
            this.txtRechercheProduit.TabIndex = 7;
            this.txtRechercheProduit.TextChanged += new System.EventHandler(this.txtRechercheProduit_TextChanged);
            // 
            // lblRechercheDate
            // 
            this.lblRechercheDate.AutoSize = true;
            this.lblRechercheDate.Location = new System.Drawing.Point(540, 64);
            this.lblRechercheDate.Name = "lblRechercheDate";
            this.lblRechercheDate.Size = new System.Drawing.Size(30, 13);
            this.lblRechercheDate.TabIndex = 8;
            this.lblRechercheDate.Text = "Date";
            // 
            // dtpRechercheDate
            // 
            this.dtpRechercheDate.Checked = false;
            this.dtpRechercheDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRechercheDate.Location = new System.Drawing.Point(543, 80);
            this.dtpRechercheDate.Name = "dtpRechercheDate";
            this.dtpRechercheDate.ShowCheckBox = true;
            this.dtpRechercheDate.Size = new System.Drawing.Size(150, 20);
            this.dtpRechercheDate.TabIndex = 9;
            this.dtpRechercheDate.ValueChanged += new System.EventHandler(this.dtpRechercheDate_ValueChanged);
            // 
            // dgCommandes
            // 
            this.dgCommandes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCommandes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCommandes.Location = new System.Drawing.Point(20, 112);
            this.dgCommandes.MultiSelect = false;
            this.dgCommandes.Name = "dgCommandes";
            this.dgCommandes.ReadOnly = true;
            this.dgCommandes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCommandes.Size = new System.Drawing.Size(890, 448);
            this.dgCommandes.TabIndex = 4;
            this.dgCommandes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCommandes_CellDoubleClick);
            // 
            // frmCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 620);
            this.ControlBox = false;
            this.Controls.Add(this.dgCommandes);
            this.Controls.Add(this.dtpRechercheDate);
            this.Controls.Add(this.lblRechercheDate);
            this.Controls.Add(this.txtRechercheProduit);
            this.Controls.Add(this.lblRechercheProduit);
            this.Controls.Add(this.txtRechercheClient);
            this.Controls.Add(this.lblRechercheClient);
            this.Controls.Add(this.cmbFiltreStatut);
            this.Controls.Add(this.lblFiltreStatut);
            this.Controls.Add(this.btnDetailsCommande);
            this.Controls.Add(this.btnSupprimerCommande);
            this.Controls.Add(this.btnNouvelleCommande);
            this.Name = "frmCommande";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Commande";
            ((System.ComponentModel.ISupportInitialize)(this.dgCommandes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgCommandes;
        private System.Windows.Forms.Button btnNouvelleCommande;
        private System.Windows.Forms.Button btnSupprimerCommande;
        private System.Windows.Forms.Button btnDetailsCommande;
        private System.Windows.Forms.Label lblFiltreStatut;
        private System.Windows.Forms.ComboBox cmbFiltreStatut;
        private System.Windows.Forms.Label lblRechercheClient;
        private System.Windows.Forms.TextBox txtRechercheClient;
        private System.Windows.Forms.Label lblRechercheProduit;
        private System.Windows.Forms.TextBox txtRechercheProduit;
        private System.Windows.Forms.Label lblRechercheDate;
        private System.Windows.Forms.DateTimePicker dtpRechercheDate;
    }
}
