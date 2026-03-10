namespace AppSenAgriculture
{
    partial class frmMDI
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
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnQuitterApp = new System.Windows.Forms.Button();
            this.btnDeconnexion = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnCommande = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.btnLieu = new System.Windows.Forms.Button();
            this.btnCategorie = new System.Windows.Forms.Button();
            this.btnProduit = new System.Windows.Forms.Button();
            this.lblSidebarCaption = new System.Windows.Forms.Label();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblTopSubtitle = new System.Windows.Forms.Label();
            this.lblTopTitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(15)))));
            this.pnlSidebar.Controls.Add(this.btnQuitterApp);
            this.pnlSidebar.Controls.Add(this.btnDeconnexion);
            this.pnlSidebar.Controls.Add(this.btnStock);
            this.pnlSidebar.Controls.Add(this.btnCommande);
            this.pnlSidebar.Controls.Add(this.btnClient);
            this.pnlSidebar.Controls.Add(this.btnLieu);
            this.pnlSidebar.Controls.Add(this.btnCategorie);
            this.pnlSidebar.Controls.Add(this.btnProduit);
            this.pnlSidebar.Controls.Add(this.lblSidebarCaption);
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(230, 661);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnQuitterApp
            // 
            this.btnQuitterApp.FlatAppearance.BorderSize = 0;
            this.btnQuitterApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitterApp.Font = new System.Drawing.Font("Source Sans 3", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuitterApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.btnQuitterApp.Location = new System.Drawing.Point(20, 578);
            this.btnQuitterApp.Name = "btnQuitterApp";
            this.btnQuitterApp.Size = new System.Drawing.Size(190, 42);
            this.btnQuitterApp.TabIndex = 9;
            this.btnQuitterApp.Text = "Quitter";
            this.btnQuitterApp.UseVisualStyleBackColor = true;
            this.btnQuitterApp.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // btnDeconnexion
            // 
            this.btnDeconnexion.FlatAppearance.BorderSize = 0;
            this.btnDeconnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeconnexion.Font = new System.Drawing.Font("Source Sans 3", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeconnexion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.btnDeconnexion.Location = new System.Drawing.Point(20, 530);
            this.btnDeconnexion.Name = "btnDeconnexion";
            this.btnDeconnexion.Size = new System.Drawing.Size(190, 42);
            this.btnDeconnexion.TabIndex = 8;
            this.btnDeconnexion.Text = "Se deconnecter";
            this.btnDeconnexion.UseVisualStyleBackColor = true;
            this.btnDeconnexion.Click += new System.EventHandler(this.seDeToolStripMenuItem_Click);
            // 
            // btnStock
            // 
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Source Sans 3", 12F, System.Drawing.FontStyle.Bold);
            this.btnStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.btnStock.Location = new System.Drawing.Point(20, 377);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(190, 42);
            this.btnStock.TabIndex = 7;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // btnCommande
            // 
            this.btnCommande.FlatAppearance.BorderSize = 0;
            this.btnCommande.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommande.Font = new System.Drawing.Font("Source Sans 3", 12F, System.Drawing.FontStyle.Bold);
            this.btnCommande.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.btnCommande.Location = new System.Drawing.Point(20, 329);
            this.btnCommande.Name = "btnCommande";
            this.btnCommande.Size = new System.Drawing.Size(190, 42);
            this.btnCommande.TabIndex = 6;
            this.btnCommande.Text = "Commandes";
            this.btnCommande.UseVisualStyleBackColor = true;
            this.btnCommande.Click += new System.EventHandler(this.commandeToolStripMenuItem_Click);
            // 
            // btnClient
            // 
            this.btnClient.FlatAppearance.BorderSize = 0;
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClient.Font = new System.Drawing.Font("Source Sans 3", 12F, System.Drawing.FontStyle.Bold);
            this.btnClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.btnClient.Location = new System.Drawing.Point(20, 281);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(190, 42);
            this.btnClient.TabIndex = 5;
            this.btnClient.Text = "Clients";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.clientToolStripMenuItem_Click);
            // 
            // btnLieu
            // 
            this.btnLieu.FlatAppearance.BorderSize = 0;
            this.btnLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLieu.Font = new System.Drawing.Font("Source Sans 3", 12F, System.Drawing.FontStyle.Bold);
            this.btnLieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.btnLieu.Location = new System.Drawing.Point(20, 233);
            this.btnLieu.Name = "btnLieu";
            this.btnLieu.Size = new System.Drawing.Size(190, 42);
            this.btnLieu.TabIndex = 4;
            this.btnLieu.Text = "Lieux";
            this.btnLieu.UseVisualStyleBackColor = true;
            this.btnLieu.Click += new System.EventHandler(this.lieuToolStripMenuItem_Click);
            // 
            // btnCategorie
            // 
            this.btnCategorie.FlatAppearance.BorderSize = 0;
            this.btnCategorie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorie.Font = new System.Drawing.Font("Source Sans 3", 12F, System.Drawing.FontStyle.Bold);
            this.btnCategorie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.btnCategorie.Location = new System.Drawing.Point(20, 185);
            this.btnCategorie.Name = "btnCategorie";
            this.btnCategorie.Size = new System.Drawing.Size(190, 42);
            this.btnCategorie.TabIndex = 3;
            this.btnCategorie.Text = "Categories";
            this.btnCategorie.UseVisualStyleBackColor = true;
            this.btnCategorie.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // btnProduit
            // 
            this.btnProduit.FlatAppearance.BorderSize = 0;
            this.btnProduit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduit.Font = new System.Drawing.Font("Source Sans 3", 12F, System.Drawing.FontStyle.Bold);
            this.btnProduit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.btnProduit.Location = new System.Drawing.Point(20, 137);
            this.btnProduit.Name = "btnProduit";
            this.btnProduit.Size = new System.Drawing.Size(190, 42);
            this.btnProduit.TabIndex = 2;
            this.btnProduit.Text = "Produits";
            this.btnProduit.UseVisualStyleBackColor = true;
            this.btnProduit.Click += new System.EventHandler(this.produitToolStripMenuItem_Click);
            // 
            // lblSidebarCaption
            // 
            this.lblSidebarCaption.AutoSize = true;
            this.lblSidebarCaption.Font = new System.Drawing.Font("Source Sans 3", 10.5F);
            this.lblSidebarCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(137)))), ((int)(((byte)(42)))));
            this.lblSidebarCaption.Location = new System.Drawing.Point(21, 84);
            this.lblSidebarCaption.Name = "lblSidebarCaption";
            this.lblSidebarCaption.Size = new System.Drawing.Size(136, 18);
            this.lblSidebarCaption.TabIndex = 1;
            this.lblSidebarCaption.Text = "Terre, stock et ventes";
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.AutoSize = true;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Playfair Display", 18F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.lblSidebarTitle.Location = new System.Drawing.Point(19, 48);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(184, 30);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "AppSenAgriculture";
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.pnlTopBar.Controls.Add(this.lblTopSubtitle);
            this.pnlTopBar.Controls.Add(this.lblTopTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(230, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(837, 78);
            this.pnlTopBar.TabIndex = 1;
            // 
            // lblTopSubtitle
            // 
            this.lblTopSubtitle.AutoSize = true;
            this.lblTopSubtitle.Font = new System.Drawing.Font("Source Sans 3", 11F);
            this.lblTopSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(74)))), ((int)(((byte)(60)))));
            this.lblTopSubtitle.Location = new System.Drawing.Point(31, 43);
            this.lblTopSubtitle.Name = "lblTopSubtitle";
            this.lblTopSubtitle.Size = new System.Drawing.Size(313, 19);
            this.lblTopSubtitle.TabIndex = 1;
            this.lblTopSubtitle.Text = "Pilotage des produits, clients, commandes et stock";
            // 
            // lblTopTitle
            // 
            this.lblTopTitle.AutoSize = true;
            this.lblTopTitle.Font = new System.Drawing.Font("Playfair Display", 20F, System.Drawing.FontStyle.Bold);
            this.lblTopTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(24)))), ((int)(((byte)(16)))));
            this.lblTopTitle.Location = new System.Drawing.Point(28, 9);
            this.lblTopTitle.Name = "lblTopTitle";
            this.lblTopTitle.Size = new System.Drawing.Size(232, 34);
            this.lblTopTitle.TabIndex = 0;
            this.lblTopTitle.Text = "Tableau de bord";
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1067, 661);
            this.ControlBox = false;
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Source Sans 3", 12F);
            this.IsMdiContainer = true;
            this.Name = "frmMDI";
            this.Text = "Sen Agriculture :: Tableau de bord";
            this.Load += new System.EventHandler(this.frmMDI_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnQuitterApp;
        private System.Windows.Forms.Button btnDeconnexion;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnCommande;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnLieu;
        private System.Windows.Forms.Button btnCategorie;
        private System.Windows.Forms.Button btnProduit;
        private System.Windows.Forms.Label lblSidebarCaption;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblTopSubtitle;
        private System.Windows.Forms.Label lblTopTitle;
    }
}
