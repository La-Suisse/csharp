namespace GSB
{
    partial class ListUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListUser));
            this.labelTitleUser = new System.Windows.Forms.Label();
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.listViewFiches = new System.Windows.Forms.ListView();
            this.labelListeFiches = new System.Windows.Forms.Label();
            this.labelFraisForfaits = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewForfaits = new System.Windows.Forms.ListView();
            this.listViewHorsForfaits = new System.Windows.Forms.ListView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.labelDevalider = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelRemboursement = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnModif = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitleUser
            // 
            this.labelTitleUser.AutoSize = true;
            this.labelTitleUser.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleUser.Location = new System.Drawing.Point(21, 0);
            this.labelTitleUser.Name = "labelTitleUser";
            this.labelTitleUser.Size = new System.Drawing.Size(132, 20);
            this.labelTitleUser.TabIndex = 0;
            this.labelTitleUser.Text = "Liste des clients";
            // 
            // listViewUsers
            // 
            this.listViewUsers.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewUsers.HideSelection = false;
            this.listViewUsers.Location = new System.Drawing.Point(35, 123);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(121, 97);
            this.listViewUsers.TabIndex = 1;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewUsers_ItemSelectionChanged);
            // 
            // listViewFiches
            // 
            this.listViewFiches.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewFiches.HideSelection = false;
            this.listViewFiches.Location = new System.Drawing.Point(348, 123);
            this.listViewFiches.Name = "listViewFiches";
            this.listViewFiches.Size = new System.Drawing.Size(121, 68);
            this.listViewFiches.TabIndex = 2;
            this.listViewFiches.UseCompatibleStateImageBehavior = false;
            this.listViewFiches.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewFiches_ItemSelectionChanged);
            // 
            // labelListeFiches
            // 
            this.labelListeFiches.AutoSize = true;
            this.labelListeFiches.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListeFiches.Location = new System.Drawing.Point(313, 0);
            this.labelListeFiches.Name = "labelListeFiches";
            this.labelListeFiches.Size = new System.Drawing.Size(149, 20);
            this.labelListeFiches.TabIndex = 3;
            this.labelListeFiches.Text = "Liste de ses fiches";
            // 
            // labelFraisForfaits
            // 
            this.labelFraisForfaits.AutoSize = true;
            this.labelFraisForfaits.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFraisForfaits.Location = new System.Drawing.Point(567, 0);
            this.labelFraisForfaits.Name = "labelFraisForfaits";
            this.labelFraisForfaits.Size = new System.Drawing.Size(198, 20);
            this.labelFraisForfaits.TabIndex = 4;
            this.labelFraisForfaits.Text = "Liste des frais forfaitisés";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(567, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Liste des frais non forfaitisés";
            // 
            // listViewForfaits
            // 
            this.listViewForfaits.CheckBoxes = true;
            this.listViewForfaits.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewForfaits.HideSelection = false;
            this.listViewForfaits.Location = new System.Drawing.Point(625, 84);
            this.listViewForfaits.Name = "listViewForfaits";
            this.listViewForfaits.Size = new System.Drawing.Size(121, 97);
            this.listViewForfaits.TabIndex = 6;
            this.listViewForfaits.UseCompatibleStateImageBehavior = false;
            // 
            // listViewHorsForfaits
            // 
            this.listViewHorsForfaits.CheckBoxes = true;
            this.listViewHorsForfaits.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewHorsForfaits.HideSelection = false;
            this.listViewHorsForfaits.Location = new System.Drawing.Point(605, 293);
            this.listViewHorsForfaits.Name = "listViewHorsForfaits";
            this.listViewHorsForfaits.Size = new System.Drawing.Size(121, 97);
            this.listViewHorsForfaits.TabIndex = 7;
            this.listViewHorsForfaits.UseCompatibleStateImageBehavior = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(974, 322);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 68);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Refuser les frais";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.LimeGreen;
            this.btnValider.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.ForeColor = System.Drawing.SystemColors.Control;
            this.btnValider.Location = new System.Drawing.Point(974, 3);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(148, 68);
            this.btnValider.TabIndex = 9;
            this.btnValider.Text = "Valider la fiche";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // labelDevalider
            // 
            this.labelDevalider.AutoSize = true;
            this.labelDevalider.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDevalider.Location = new System.Drawing.Point(971, 74);
            this.labelDevalider.Name = "labelDevalider";
            this.labelDevalider.Size = new System.Drawing.Size(134, 17);
            this.labelDevalider.TabIndex = 11;
            this.labelDevalider.Text = "Annuler la validation";
            this.labelDevalider.Click += new System.EventHandler(this.labelDevalider_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(26, 26);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(265, 26);
            this.textBoxSearch.TabIndex = 13;
            this.textBoxSearch.Enter += new System.EventHandler(this.textBoxSearch_Enter);
            this.textBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyUp);
            this.textBoxSearch.Leave += new System.EventHandler(this.textBoxSearch_Leave);
            // 
            // labelRemboursement
            // 
            this.labelRemboursement.AutoSize = true;
            this.labelRemboursement.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemboursement.Location = new System.Drawing.Point(571, 425);
            this.labelRemboursement.Name = "labelRemboursement";
            this.labelRemboursement.Size = new System.Drawing.Size(255, 20);
            this.labelRemboursement.TabIndex = 14;
            this.labelRemboursement.Text = "Remboursement total: non défini";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(453, 459);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(233, 17);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Copyright GSB - Tous droits réservés";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnModif
            // 
            this.btnModif.BackColor = System.Drawing.Color.Red;
            this.btnModif.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModif.ForeColor = System.Drawing.Color.White;
            this.btnModif.Location = new System.Drawing.Point(974, 113);
            this.btnModif.Name = "btnModif";
            this.btnModif.Size = new System.Drawing.Size(146, 68);
            this.btnModif.TabIndex = 17;
            this.btnModif.Text = "Modifier";
            this.btnModif.UseVisualStyleBackColor = false;
            this.btnModif.Click += new System.EventHandler(this.btnModif_Click);
            // 
            // ListUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1132, 483);
            this.Controls.Add(this.btnModif);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.labelRemboursement);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelDevalider);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listViewHorsForfaits);
            this.Controls.Add(this.listViewForfaits);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFraisForfaits);
            this.Controls.Add(this.labelListeFiches);
            this.Controls.Add(this.listViewFiches);
            this.Controls.Add(this.listViewUsers);
            this.Controls.Add(this.labelTitleUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1150, 530);
            this.MinimumSize = new System.Drawing.Size(1150, 530);
            this.Name = "ListUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSB - Vous êtes connecté";
            this.Load += new System.EventHandler(this.ListUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleUser;
        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.ListView listViewFiches;
        private System.Windows.Forms.Label labelListeFiches;
        private System.Windows.Forms.Label labelFraisForfaits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewForfaits;
        private System.Windows.Forms.ListView listViewHorsForfaits;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Label labelDevalider;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelRemboursement;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnModif;
    }
}