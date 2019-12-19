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
    public partial class Form1 : Form
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string cle = "41lac27ga35";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public string cryptageVigenere(string mot)
        {
            string leMotCode = "";
            int longueurCle = cle.Length;
            int longueurMot = mot.Length;
            var tmp = 0;
            var i = 0;
            while(i < longueurMot)
            {
                leMotCode += cryptageLettre(mot[i].ToString(), cle[tmp].ToString());
                tmp++;
                if (tmp == longueurCle)
                {
                    tmp = 0;
                }
                i++;
            }
            return leMotCode;
        }

        public int rangDansAlphabet(string lettre)
        {
            int N = alphabet.Length;
            int j = 0;
            int rang = 0;
            while (j < N)
            {
                if (lettre == alphabet[j].ToString())
                {
                    rang = j;
                }
                j++;
            }
            return rang;
        }

        public string lettreAlphabet(int rang)
        {
            int N = alphabet.Length;
            if (rang >= N)
            {
                rang -= N;
            }
            if (rang < 0)
            {
                rang += N;
            }
            return alphabet[rang].ToString();
        }

        public string cryptageLettre(string lettre, string cle)
        {
            return lettreAlphabet(rangDansAlphabet(lettre) + rangDansAlphabet(cle));
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // On signal si une des case identifiant ou mot de passe est vide
            if (string.IsNullOrEmpty(txtId.Text.ToString()) || string.IsNullOrEmpty(txtPassword.Text.ToString()))
            {
                MessageBox.Show("Une case n'est pas remplie lors de la saisie de vos identifiants", "Erreur");
            }
            else
            {
                // On met un try si jamais on est pas connecté au wifi
                try
                {
                    // On créer la commande pour chercher si un utilisateur correspond à l'identifiant et au mot de passe saisi
                    MySqlCommand command = Program.mydb.connection.CreateCommand();
                    command.CommandText = "select * from utilisateur where identifiant = @id and mdp = @mdp and mon_type_id = 2";
                    // On ajoute les paramètres
                    command.Parameters.AddWithValue("@id", txtId.Text.ToString());
                    command.Parameters.AddWithValue("@mdp", cryptageVigenere(txtPassword.Text.ToString()));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows) // Si le reader a des colonnes, alors c'est que le login est bon
                        {
                            Hide();
                            Program.mydb.CloseConnection();
                            var ListUser = new ListUser();
                            ListUser.Show();
                        }
                        else // Sinon on affiche un message d'erreur
                        {
                            MessageBox.Show("Erreur lors de la saisie des identifiants", "Erreur");
                        }
                    }
                }
                catch (Exception ex) // En cas de problème lors de la requête
                {
                    MessageBox.Show("Vous n'êtes pas connecté au Wi-Fi.", "Erreur");
                }
            }
        }
    }
}
