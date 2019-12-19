namespace GSB
{
    partial class UpdateForfait
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForfait));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAncienneQte = new System.Windows.Forms.TextBox();
            this.textBoxNouvelleQte = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ancienne quantité";
            // 
            // textBoxAncienneQte
            // 
            this.textBoxAncienneQte.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAncienneQte.Location = new System.Drawing.Point(114, 108);
            this.textBoxAncienneQte.Name = "textBoxAncienneQte";
            this.textBoxAncienneQte.ReadOnly = true;
            this.textBoxAncienneQte.Size = new System.Drawing.Size(100, 26);
            this.textBoxAncienneQte.TabIndex = 1;
            this.textBoxAncienneQte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxNouvelleQte
            // 
            this.textBoxNouvelleQte.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNouvelleQte.Location = new System.Drawing.Point(114, 208);
            this.textBoxNouvelleQte.Name = "textBoxNouvelleQte";
            this.textBoxNouvelleQte.Size = new System.Drawing.Size(100, 26);
            this.textBoxNouvelleQte.TabIndex = 2;
            this.textBoxNouvelleQte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nouvelle quantité";
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.LimeGreen;
            this.btnValider.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.ForeColor = System.Drawing.Color.White;
            this.btnValider.Location = new System.Drawing.Point(65, 279);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(192, 33);
            this.btnValider.TabIndex = 4;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // UpdateForfait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(345, 383);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNouvelleQte);
            this.Controls.Add(this.textBoxAncienneQte);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateForfait";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modification";
            this.Load += new System.EventHandler(this.UpdateForfait_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAncienneQte;
        private System.Windows.Forms.TextBox textBoxNouvelleQte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnValider;
    }
}