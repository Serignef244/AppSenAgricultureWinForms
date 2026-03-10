namespace AppSenAgriculture.Views.Securite
{
    partial class frmChangerMotDePasse
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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPolicy = new System.Windows.Forms.Label();
            this.lblAncienMotDePasse = new System.Windows.Forms.Label();
            this.lblNouveauMotDePasse = new System.Windows.Forms.Label();
            this.lblConfirmerMotDePasse = new System.Windows.Forms.Label();
            this.txtAncienMotDePasse = new System.Windows.Forms.TextBox();
            this.txtNouveauMotDePasse = new System.Windows.Forms.TextBox();
            this.txtConfirmerMotDePasse = new System.Windows.Forms.TextBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(30, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(218, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Changer mot de passe";
            // 
            // lblPolicy
            // 
            this.lblPolicy.AutoSize = true;
            this.lblPolicy.Location = new System.Drawing.Point(31, 56);
            this.lblPolicy.Name = "lblPolicy";
            this.lblPolicy.Size = new System.Drawing.Size(412, 29);
            this.lblPolicy.TabIndex = 1;
            this.lblPolicy.Text = "8 caracteres minimum, majuscule, chiffre et special";
            // 
            // lblAncienMotDePasse
            // 
            this.lblAncienMotDePasse.AutoSize = true;
            this.lblAncienMotDePasse.Location = new System.Drawing.Point(31, 112);
            this.lblAncienMotDePasse.Name = "lblAncienMotDePasse";
            this.lblAncienMotDePasse.Size = new System.Drawing.Size(194, 29);
            this.lblAncienMotDePasse.TabIndex = 2;
            this.lblAncienMotDePasse.Text = "Ancien mot de passe";
            // 
            // lblNouveauMotDePasse
            // 
            this.lblNouveauMotDePasse.AutoSize = true;
            this.lblNouveauMotDePasse.Location = new System.Drawing.Point(31, 192);
            this.lblNouveauMotDePasse.Name = "lblNouveauMotDePasse";
            this.lblNouveauMotDePasse.Size = new System.Drawing.Size(209, 29);
            this.lblNouveauMotDePasse.TabIndex = 4;
            this.lblNouveauMotDePasse.Text = "Nouveau mot de passe";
            // 
            // lblConfirmerMotDePasse
            // 
            this.lblConfirmerMotDePasse.AutoSize = true;
            this.lblConfirmerMotDePasse.Location = new System.Drawing.Point(31, 272);
            this.lblConfirmerMotDePasse.Name = "lblConfirmerMotDePasse";
            this.lblConfirmerMotDePasse.Size = new System.Drawing.Size(215, 29);
            this.lblConfirmerMotDePasse.TabIndex = 6;
            this.lblConfirmerMotDePasse.Text = "Confirmer mot de passe";
            // 
            // txtAncienMotDePasse
            // 
            this.txtAncienMotDePasse.Location = new System.Drawing.Point(35, 144);
            this.txtAncienMotDePasse.Name = "txtAncienMotDePasse";
            this.txtAncienMotDePasse.PasswordChar = '*';
            this.txtAncienMotDePasse.Size = new System.Drawing.Size(420, 35);
            this.txtAncienMotDePasse.TabIndex = 3;
            // 
            // txtNouveauMotDePasse
            // 
            this.txtNouveauMotDePasse.Location = new System.Drawing.Point(35, 224);
            this.txtNouveauMotDePasse.Name = "txtNouveauMotDePasse";
            this.txtNouveauMotDePasse.PasswordChar = '*';
            this.txtNouveauMotDePasse.Size = new System.Drawing.Size(420, 35);
            this.txtNouveauMotDePasse.TabIndex = 5;
            // 
            // txtConfirmerMotDePasse
            // 
            this.txtConfirmerMotDePasse.Location = new System.Drawing.Point(35, 304);
            this.txtConfirmerMotDePasse.Name = "txtConfirmerMotDePasse";
            this.txtConfirmerMotDePasse.PasswordChar = '*';
            this.txtConfirmerMotDePasse.Size = new System.Drawing.Size(420, 35);
            this.txtConfirmerMotDePasse.TabIndex = 7;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(305, 363);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(150, 40);
            this.btnValider.TabIndex = 8;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // frmChangerMotDePasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 430);
            this.ControlBox = false;
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.txtConfirmerMotDePasse);
            this.Controls.Add(this.lblConfirmerMotDePasse);
            this.Controls.Add(this.txtNouveauMotDePasse);
            this.Controls.Add(this.lblNouveauMotDePasse);
            this.Controls.Add(this.txtAncienMotDePasse);
            this.Controls.Add(this.lblAncienMotDePasse);
            this.Controls.Add(this.lblPolicy);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangerMotDePasse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Changer mot de passe";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPolicy;
        private System.Windows.Forms.Label lblAncienMotDePasse;
        private System.Windows.Forms.Label lblNouveauMotDePasse;
        private System.Windows.Forms.Label lblConfirmerMotDePasse;
        private System.Windows.Forms.TextBox txtAncienMotDePasse;
        private System.Windows.Forms.TextBox txtNouveauMotDePasse;
        private System.Windows.Forms.TextBox txtConfirmerMotDePasse;
        private System.Windows.Forms.Button btnValider;
    }
}
