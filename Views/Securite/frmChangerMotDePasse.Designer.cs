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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAncienMotDePasse = new System.Windows.Forms.Label();
            this.lblNouveauMotDePasse = new System.Windows.Forms.Label();
            this.lblConfirmerMotDePasse = new System.Windows.Forms.Label();
            this.txtAncienMotDePasse = new System.Windows.Forms.TextBox();
            this.txtNouveauMotDePasse = new System.Windows.Forms.TextBox();
            this.txtConfirmerMotDePasse = new System.Windows.Forms.TextBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAncienMotDePasse
            // 
            this.lblAncienMotDePasse.AutoSize = true;
            this.lblAncienMotDePasse.Location = new System.Drawing.Point(20, 20);
            this.lblAncienMotDePasse.Name = "lblAncienMotDePasse";
            this.lblAncienMotDePasse.Size = new System.Drawing.Size(194, 29);
            this.lblAncienMotDePasse.TabIndex = 0;
            this.lblAncienMotDePasse.Text = "Ancien mot de passe";
            // 
            // lblNouveauMotDePasse
            // 
            this.lblNouveauMotDePasse.AutoSize = true;
            this.lblNouveauMotDePasse.Location = new System.Drawing.Point(20, 90);
            this.lblNouveauMotDePasse.Name = "lblNouveauMotDePasse";
            this.lblNouveauMotDePasse.Size = new System.Drawing.Size(209, 29);
            this.lblNouveauMotDePasse.TabIndex = 1;
            this.lblNouveauMotDePasse.Text = "Nouveau mot de passe";
            // 
            // lblConfirmerMotDePasse
            // 
            this.lblConfirmerMotDePasse.AutoSize = true;
            this.lblConfirmerMotDePasse.Location = new System.Drawing.Point(20, 160);
            this.lblConfirmerMotDePasse.Name = "lblConfirmerMotDePasse";
            this.lblConfirmerMotDePasse.Size = new System.Drawing.Size(215, 29);
            this.lblConfirmerMotDePasse.TabIndex = 2;
            this.lblConfirmerMotDePasse.Text = "Confirmer mot de passe";
            // 
            // txtAncienMotDePasse
            // 
            this.txtAncienMotDePasse.Location = new System.Drawing.Point(20, 50);
            this.txtAncienMotDePasse.Name = "txtAncienMotDePasse";
            this.txtAncienMotDePasse.PasswordChar = '*';
            this.txtAncienMotDePasse.Size = new System.Drawing.Size(400, 35);
            this.txtAncienMotDePasse.TabIndex = 3;
            // 
            // txtNouveauMotDePasse
            // 
            this.txtNouveauMotDePasse.Location = new System.Drawing.Point(20, 120);
            this.txtNouveauMotDePasse.Name = "txtNouveauMotDePasse";
            this.txtNouveauMotDePasse.PasswordChar = '*';
            this.txtNouveauMotDePasse.Size = new System.Drawing.Size(400, 35);
            this.txtNouveauMotDePasse.TabIndex = 4;
            // 
            // txtConfirmerMotDePasse
            // 
            this.txtConfirmerMotDePasse.Location = new System.Drawing.Point(20, 190);
            this.txtConfirmerMotDePasse.Name = "txtConfirmerMotDePasse";
            this.txtConfirmerMotDePasse.PasswordChar = '*';
            this.txtConfirmerMotDePasse.Size = new System.Drawing.Size(400, 35);
            this.txtConfirmerMotDePasse.TabIndex = 5;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(320, 240);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(100, 34);
            this.btnValider.TabIndex = 6;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // frmChangerMotDePasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 295);
            this.ControlBox = false;
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.txtConfirmerMotDePasse);
            this.Controls.Add(this.txtNouveauMotDePasse);
            this.Controls.Add(this.txtAncienMotDePasse);
            this.Controls.Add(this.lblConfirmerMotDePasse);
            this.Controls.Add(this.lblNouveauMotDePasse);
            this.Controls.Add(this.lblAncienMotDePasse);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangerMotDePasse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Changer mot de passe";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblAncienMotDePasse;
        private System.Windows.Forms.Label lblNouveauMotDePasse;
        private System.Windows.Forms.Label lblConfirmerMotDePasse;
        private System.Windows.Forms.TextBox txtAncienMotDePasse;
        private System.Windows.Forms.TextBox txtNouveauMotDePasse;
        private System.Windows.Forms.TextBox txtConfirmerMotDePasse;
        private System.Windows.Forms.Button btnValider;
    }
}
