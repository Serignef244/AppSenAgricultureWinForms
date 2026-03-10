namespace AppSenAgriculture
{
    partial class frmConnexion
    {
        /// <summary>
        /// Variable necessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisees.
        /// </summary>
        /// <param name="disposing">true si les ressources managees doivent etre supprimees ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code genere par le Concepteur Windows Form

        /// <summary>
        /// Methode requise pour la prise en charge du concepteur.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHero = new System.Windows.Forms.Panel();
            this.lblHeroCaption = new System.Windows.Forms.Label();
            this.lblHeroTitle = new System.Windows.Forms.Label();
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblHint = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdentifiant = new System.Windows.Forms.TextBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.bnSeConnecter = new System.Windows.Forms.Button();
            this.lnkMotDePasseOublie = new System.Windows.Forms.LinkLabel();
            this.panelHero.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHero
            // 
            this.panelHero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(22)))));
            this.panelHero.Controls.Add(this.lblHeroCaption);
            this.panelHero.Controls.Add(this.lblHeroTitle);
            this.panelHero.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelHero.Location = new System.Drawing.Point(0, 0);
            this.panelHero.Name = "panelHero";
            this.panelHero.Size = new System.Drawing.Size(286, 420);
            this.panelHero.TabIndex = 0;
            // 
            // lblHeroCaption
            // 
            this.lblHeroCaption.AutoSize = true;
            this.lblHeroCaption.Font = new System.Drawing.Font("Source Sans 3", 12F);
            this.lblHeroCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.lblHeroCaption.Location = new System.Drawing.Point(34, 187);
            this.lblHeroCaption.Name = "lblHeroCaption";
            this.lblHeroCaption.Size = new System.Drawing.Size(204, 20);
            this.lblHeroCaption.TabIndex = 1;
            this.lblHeroCaption.Text = "Gestion agricole et suivi terrain";
            // 
            // lblHeroTitle
            // 
            this.lblHeroTitle.AutoSize = true;
            this.lblHeroTitle.Font = new System.Drawing.Font("Playfair Display", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.lblHeroTitle.Location = new System.Drawing.Point(31, 137);
            this.lblHeroTitle.Name = "lblHeroTitle";
            this.lblHeroTitle.Size = new System.Drawing.Size(226, 38);
            this.lblHeroTitle.TabIndex = 0;
            this.lblHeroTitle.Text = "Sen Agriculture";
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.panelCard.Controls.Add(this.lblHint);
            this.panelCard.Controls.Add(this.label1);
            this.panelCard.Controls.Add(this.txtIdentifiant);
            this.panelCard.Controls.Add(this.txtMotDePasse);
            this.panelCard.Controls.Add(this.label2);
            this.panelCard.Controls.Add(this.btnQuitter);
            this.panelCard.Controls.Add(this.bnSeConnecter);
            this.panelCard.Controls.Add(this.lnkMotDePasseOublie);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(286, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(434, 420);
            this.panelCard.TabIndex = 1;
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Source Sans 3", 12F);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(74)))), ((int)(((byte)(60)))));
            this.lblHint.Location = new System.Drawing.Point(49, 48);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(278, 20);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "Connectez-vous pour acceder au tableau de bord";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Source Sans 3", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(24)))), ((int)(((byte)(16)))));
            this.label1.Location = new System.Drawing.Point(49, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Identifiant";
            // 
            // txtIdentifiant
            // 
            this.txtIdentifiant.BackColor = System.Drawing.Color.White;
            this.txtIdentifiant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentifiant.Font = new System.Drawing.Font("Source Sans 3", 13F);
            this.txtIdentifiant.Location = new System.Drawing.Point(53, 126);
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.Size = new System.Drawing.Size(330, 29);
            this.txtIdentifiant.TabIndex = 2;
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.BackColor = System.Drawing.Color.White;
            this.txtMotDePasse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotDePasse.Font = new System.Drawing.Font("Source Sans 3", 13F);
            this.txtMotDePasse.Location = new System.Drawing.Point(53, 211);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(330, 29);
            this.txtMotDePasse.TabIndex = 4;
            this.txtMotDePasse.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Source Sans 3", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(24)))), ((int)(((byte)(16)))));
            this.label2.Location = new System.Drawing.Point(49, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mot de passe";
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.White;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(137)))), ((int)(((byte)(42)))));
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Source Sans 3", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuitter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(24)))), ((int)(((byte)(16)))));
            this.btnQuitter.Location = new System.Drawing.Point(53, 306);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(150, 40);
            this.btnQuitter.TabIndex = 6;
            this.btnQuitter.Text = "&Quitter";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // bnSeConnecter
            // 
            this.bnSeConnecter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(137)))), ((int)(((byte)(42)))));
            this.bnSeConnecter.FlatAppearance.BorderSize = 0;
            this.bnSeConnecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnSeConnecter.Font = new System.Drawing.Font("Source Sans 3", 11F, System.Drawing.FontStyle.Bold);
            this.bnSeConnecter.ForeColor = System.Drawing.Color.White;
            this.bnSeConnecter.Location = new System.Drawing.Point(233, 306);
            this.bnSeConnecter.Name = "bnSeConnecter";
            this.bnSeConnecter.Size = new System.Drawing.Size(150, 40);
            this.bnSeConnecter.TabIndex = 5;
            this.bnSeConnecter.Text = "&Se connecter";
            this.bnSeConnecter.UseVisualStyleBackColor = false;
            this.bnSeConnecter.Click += new System.EventHandler(this.bnSeConnecter_Click);
            // 
            // lnkMotDePasseOublie
            // 
            this.lnkMotDePasseOublie.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(101)))), ((int)(((byte)(26)))));
            this.lnkMotDePasseOublie.AutoSize = true;
            this.lnkMotDePasseOublie.Font = new System.Drawing.Font("Source Sans 3", 10.5F, System.Drawing.FontStyle.Underline);
            this.lnkMotDePasseOublie.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(22)))));
            this.lnkMotDePasseOublie.Location = new System.Drawing.Point(228, 250);
            this.lnkMotDePasseOublie.Name = "lnkMotDePasseOublie";
            this.lnkMotDePasseOublie.Size = new System.Drawing.Size(129, 18);
            this.lnkMotDePasseOublie.TabIndex = 7;
            this.lnkMotDePasseOublie.TabStop = true;
            this.lnkMotDePasseOublie.Text = "Mot de passe oublie ?";
            this.lnkMotDePasseOublie.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMotDePasseOublie_LinkClicked);
            // 
            // frmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(720, 420);
            this.ControlBox = false;
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panelHero);
            this.Font = new System.Drawing.Font("Source Sans 3", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmConnexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sen Agriculture :: Connexion";
            this.panelHero.ResumeLayout(false);
            this.panelHero.PerformLayout();
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHero;
        private System.Windows.Forms.Label lblHeroCaption;
        private System.Windows.Forms.Label lblHeroTitle;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdentifiant;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button bnSeConnecter;
        private System.Windows.Forms.LinkLabel lnkMotDePasseOublie;
    }
}
