namespace AppSenAgriculture.Views.Stock
{
    partial class frmStock
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
            this.lblProduit = new System.Windows.Forms.Label();
            this.cmbProduit = new System.Windows.Forms.ComboBox();
            this.lblPrixMinMax = new System.Windows.Forms.Label();
            this.lblQuantiteDisponible = new System.Windows.Forms.Label();
            this.lblQuantite = new System.Windows.Forms.Label();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.btnApprovisionner = new System.Windows.Forms.Button();
            this.dgStock = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProduit
            // 
            this.lblProduit.AutoSize = true;
            this.lblProduit.Location = new System.Drawing.Point(20, 20);
            this.lblProduit.Name = "lblProduit";
            this.lblProduit.Size = new System.Drawing.Size(90, 29);
            this.lblProduit.TabIndex = 0;
            this.lblProduit.Text = "Produit";
            // 
            // cmbProduit
            // 
            this.cmbProduit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduit.FormattingEnabled = true;
            this.cmbProduit.Location = new System.Drawing.Point(20, 45);
            this.cmbProduit.Name = "cmbProduit";
            this.cmbProduit.Size = new System.Drawing.Size(340, 37);
            this.cmbProduit.TabIndex = 1;
            this.cmbProduit.SelectedIndexChanged += new System.EventHandler(this.cmbProduit_SelectedIndexChanged);
            // 
            // lblPrixMinMax
            // 
            this.lblPrixMinMax.AutoSize = true;
            this.lblPrixMinMax.Location = new System.Drawing.Point(380, 49);
            this.lblPrixMinMax.Name = "lblPrixMinMax";
            this.lblPrixMinMax.Size = new System.Drawing.Size(170, 29);
            this.lblPrixMinMax.TabIndex = 2;
            this.lblPrixMinMax.Text = "Prix min/max: -";
            // 
            // lblQuantiteDisponible
            // 
            this.lblQuantiteDisponible.AutoSize = true;
            this.lblQuantiteDisponible.Location = new System.Drawing.Point(620, 49);
            this.lblQuantiteDisponible.Name = "lblQuantiteDisponible";
            this.lblQuantiteDisponible.Size = new System.Drawing.Size(212, 29);
            this.lblQuantiteDisponible.TabIndex = 3;
            this.lblQuantiteDisponible.Text = "Stock disponible: -";
            // 
            // lblQuantite
            // 
            this.lblQuantite.AutoSize = true;
            this.lblQuantite.Location = new System.Drawing.Point(20, 92);
            this.lblQuantite.Name = "lblQuantite";
            this.lblQuantite.Size = new System.Drawing.Size(103, 29);
            this.lblQuantite.TabIndex = 4;
            this.lblQuantite.Text = "Quantite";
            // 
            // txtQuantite
            // 
            this.txtQuantite.Location = new System.Drawing.Point(20, 116);
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Size = new System.Drawing.Size(160, 35);
            this.txtQuantite.TabIndex = 5;
            // 
            // btnApprovisionner
            // 
            this.btnApprovisionner.Location = new System.Drawing.Point(200, 112);
            this.btnApprovisionner.Name = "btnApprovisionner";
            this.btnApprovisionner.Size = new System.Drawing.Size(196, 32);
            this.btnApprovisionner.TabIndex = 6;
            this.btnApprovisionner.Text = "Approvisionner";
            this.btnApprovisionner.UseVisualStyleBackColor = true;
            this.btnApprovisionner.Click += new System.EventHandler(this.btnApprovisionner_Click);
            // 
            // dgStock
            // 
            this.dgStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStock.Location = new System.Drawing.Point(20, 165);
            this.dgStock.MultiSelect = false;
            this.dgStock.Name = "dgStock";
            this.dgStock.ReadOnly = true;
            this.dgStock.RowHeadersWidth = 62;
            this.dgStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStock.Size = new System.Drawing.Size(880, 360);
            this.dgStock.TabIndex = 8;
            // 
            // frmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 545);
            this.ControlBox = false;
            this.Controls.Add(this.dgStock);
            this.Controls.Add(this.btnApprovisionner);
            this.Controls.Add(this.txtQuantite);
            this.Controls.Add(this.lblQuantite);
            this.Controls.Add(this.lblQuantiteDisponible);
            this.Controls.Add(this.lblPrixMinMax);
            this.Controls.Add(this.cmbProduit);
            this.Controls.Add(this.lblProduit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock";
            ((System.ComponentModel.ISupportInitialize)(this.dgStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblProduit;
        private System.Windows.Forms.ComboBox cmbProduit;
        private System.Windows.Forms.Label lblPrixMinMax;
        private System.Windows.Forms.Label lblQuantiteDisponible;
        private System.Windows.Forms.Label lblQuantite;
        private System.Windows.Forms.TextBox txtQuantite;
        private System.Windows.Forms.Button btnApprovisionner;
        private System.Windows.Forms.DataGridView dgStock;
    }
}
