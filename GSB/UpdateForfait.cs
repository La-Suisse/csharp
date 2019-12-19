using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB
{
    public partial class UpdateForfait : Form
    {
        string idForfait;
        public UpdateForfait(string id, string valeur)
        {
            InitializeComponent();
            textBoxAncienneQte.Text = valeur;
            idForfait = id;
        }

        private void UpdateForfait_Load(object sender, EventArgs e)
        {

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNouvelleQte.Text))
            {
                MessageBox.Show("Veuillez saisir une nouvelle quantité" ,"Erreur");
            }
            else
            {
                try
                {
                    Program.mydb.OpenConnection();
                    MySqlCommand commandHorsForfait = Program.mydb.connection.CreateCommand();
                    commandHorsForfait.CommandText = "UPDATE forfait SET quantite=@qte WHERE id=@id;";
                    commandHorsForfait.Parameters.AddWithValue("@id", idForfait);
                    commandHorsForfait.Parameters.AddWithValue("@qte", textBoxNouvelleQte.Text);
                    commandHorsForfait.ExecuteNonQuery();
                    Program.mydb.CloseConnection();
                    MessageBox.Show("Modification réussie avec succès." ,"Succès");
                    Hide();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur");
                }
            }
        }
    }
}
