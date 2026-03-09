namespace AppSenAgriculture
{
    partial class frmConnexion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdentifiant = new System.Windows.Forms.TextBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.bnSeConnecter = new System.Windows.Forms.Button();
            this.lnkMotDePasseOublie = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "identifiant";
            // 
            // txtIdentifiant
            // 
            this.txtIdentifiant.Location = new System.Drawing.Point(72, 97);
            this.txtIdentifiant.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.Size = new System.Drawing.Size(487, 26);
            this.txtIdentifiant.TabIndex = 1;
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(72, 191);
            this.txtMotDePasse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(487, 26);
            this.txtMotDePasse.TabIndex = 2;
            this.txtMotDePasse.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mot de pass";
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(72, 262);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(182, 35);
            this.btnQuitter.TabIndex = 4;
            this.btnQuitter.Text = "&Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // bnSeConnecter
            // 
            this.bnSeConnecter.Location = new System.Drawing.Point(377, 262);
            this.bnSeConnecter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnSeConnecter.Name = "bnSeConnecter";
            this.bnSeConnecter.Size = new System.Drawing.Size(182, 35);
            this.bnSeConnecter.TabIndex = 3;
            this.bnSeConnecter.Text = "&Se connecter";
            this.bnSeConnecter.UseVisualStyleBackColor = true;
            this.bnSeConnecter.Click += new System.EventHandler(this.bnSeConnecter_Click);
            // 
            // lnkMotDePasseOublie
            // 
            this.lnkMotDePasseOublie.AutoSize = true;
            this.lnkMotDePasseOublie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkMotDePasseOublie.Location = new System.Drawing.Point(420, 222);
            this.lnkMotDePasseOublie.Name = "lnkMotDePasseOublie";
            this.lnkMotDePasseOublie.Size = new System.Drawing.Size(139, 16);
            this.lnkMotDePasseOublie.TabIndex = 5;
            this.lnkMotDePasseOublie.TabStop = true;
            this.lnkMotDePasseOublie.Text = "Mot de passe oublié ?";
            this.lnkMotDePasseOublie.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMotDePasseOublie_LinkClicked);
            // 
            // frmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 338);
            this.ControlBox = false;
            this.Controls.Add(this.lnkMotDePasseOublie);
            this.Controls.Add(this.bnSeConnecter);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdentifiant);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConnexion";
            this.Text = "Sen Agricule:: Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdentifiant;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button bnSeConnecter;
        private System.Windows.Forms.LinkLabel lnkMotDePasseOublie;
    }
}

