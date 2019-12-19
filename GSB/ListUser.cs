using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB
{
    public partial class ListUser : Form
    {
        string idFiche, idUser;
        public ListUser()
        {
            InitializeComponent();
        }

        private void ListUser_Load(object sender, EventArgs e)
        {
            // On initialise tout
            initialiser();

            // On affiche le fait de pouvoir annuler la validation uniquement sur une fiche validée
            labelDevalider.Visible = false;

            // Définition de la taille des 4 list view
            listViewUsers.Bounds = new Rectangle(new Point(20, 45), new Size(200, 315));
            listViewFiches.Bounds = new Rectangle(new Point(240, 20), new Size(170, 340));
            listViewForfaits.Bounds = new Rectangle(new Point(430, 20), new Size(280, 120));
            listViewHorsForfaits.Bounds = new Rectangle(new Point(430, 170), new Size(280, 170));
            listViewUsers.View = View.Details;
            listViewUsers.AllowColumnReorder = true;
            listViewUsers.FullRowSelect = true;
            listViewUsers.GridLines = true;

            // Création de la commande pour avoir tous les clients (utilisateur type 1)
            MySqlDataAdapter msda = new MySqlDataAdapter("select * from utilisateur where mon_type_id = 1 order by nom,prenom;", Program.mydb.connection);
            DataSet DS = new DataSet();
            msda.Fill(DS); // Remplissage du DataSet grâce à l'adapteur

            // Ce qui est marqué dans la textbox de recherche, identique au "placeholder" en html
            textBoxSearch.Text = "Rechercher un client...";
            textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Mode de suggestion
            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource; // Nous allons définir notre propre source d'autocomplete
            var collection = new AutoCompleteStringCollection();

            // Ajout de chaque utilisateur à la ListViewUsers
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                string nom = DS.Tables[0].Rows[i].ItemArray[1].ToString(); // Récupération nom
                string prenom = DS.Tables[0].Rows[i].ItemArray[2].ToString(); // Récupération prénom
                ListViewItem item = new ListViewItem(DS.Tables[0].Rows[i].ItemArray[0].ToString()); // Récupération ID
                item.SubItems.Add(nom);
                item.SubItems.Add(prenom);
                listViewUsers.Items.AddRange(new ListViewItem[] { item }); // Ajout de l'item

                // On récupère les noms et prénoms pour le moment ou le comptable saisi la barre de recherche
                collection.Add(nom);
                collection.Add(prenom);
            }
            textBoxSearch.AutoCompleteCustomSource = collection; // Source de l'auto-suggestion
            Controls.Add(textBoxSearch);

            // Définition des headers de la ListViewUser
            listViewUsers.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listViewUsers.Columns.Add("Nom", -2, HorizontalAlignment.Left);
            listViewUsers.Columns.Add("Prénom", -2, HorizontalAlignment.Left);

            listViewUsers.Columns[0].Dispose();

            listViewUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); // Pour redéfinir la taille des colonnes
            Controls.Add(listViewUsers);
            Program.mydb.CloseConnection();
        }
        private void listViewUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // On récupère l'identifiant du client sélectionné et on affiche toutes ses fiches
            idUser = e.Item.SubItems[0].Text;
            listFichesByUser(idUser);
        }

        private void listViewFiches_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // On récupère l'identifiant de la fiche sélectionnée et on affiche tous ses frais
            idFiche = e.Item.SubItems[0].Text;
            listFraisByFiche(idFiche);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try // En cas d'erreur lors de l'exécution
            {
                Program.mydb.OpenConnection();
                MySqlCommand command = Program.mydb.connection.CreateCommand();

                // Requête paramétrée pour valider la fiche sélectionnée
                command.CommandText = "UPDATE fiche_frais SET mon_etat_id=4 WHERE id=@id;";
                command.Parameters.AddWithValue("@id", idFiche);
                command.ExecuteNonQuery(); // Pour exécuter une requête UPDATE (ou alter table etc...)
                Program.mydb.CloseConnection();

                // On récupère la somme totale des frais non forfaitisés de la fiche sélectionnée
                float totalPrix = 0;
                string sql = "select sum(prix) from hors_forfait where ma_fiche_id =" + idFiche + ";";
                MySqlDataAdapter msda = new MySqlDataAdapter(sql, Program.mydb.connection);
                DataSet DS = new DataSet();
                msda.Fill(DS);
                if (!string.IsNullOrEmpty(DS.Tables[0].Rows[0].ItemArray[0].ToString()))
                {
                    string prix = DS.Tables[0].Rows[0].ItemArray[0].ToString();
                    totalPrix += int.Parse(prix); // On stock tout dans la variable totalPrix
                }

                // On récupère le prix d'un frais forfaitisé et la valeur pour un frais forfaitisé à l'unité
                sql = "select prix, quantite from forfait inner join type_frais ON forfait.mon_type_id = type_frais.id WHERE forfait.ma_fiche_id =" + idFiche + ";";
                MySqlDataAdapter msda2 = new MySqlDataAdapter(sql, Program.mydb.connection);
                DataSet DS2 = new DataSet();
                msda2.Fill(DS2);

                // Pour chaque occurence, on multiplie le nombre de frais forfaitisés par son prix à l'unité
                for (int i = 0; i < DS2.Tables[0].Rows.Count; i++)
                {
                    // On ajoute tout à la variable totalPrix
                    totalPrix += float.Parse(DS2.Tables[0].Rows[i].ItemArray[0].ToString()) * float.Parse(DS2.Tables[0].Rows[i].ItemArray[1].ToString());
                }
                Program.mydb.OpenConnection();
                
                MySqlCommand commandMontant = Program.mydb.connection.CreateCommand();
                // Requête paramétrée pour mettre le montant la fiche validée
                commandMontant.CommandText = "UPDATE fiche_frais SET montant=@montant WHERE id=@id;";
                commandMontant.Parameters.AddWithValue("@montant", totalPrix.ToString());
                commandMontant.Parameters.AddWithValue("@id", idFiche);
                commandMontant.ExecuteNonQuery(); // Pour exécuter une requête UPDATE (ou alter table etc...)
                Program.mydb.CloseConnection();

                // On affiche tous les frais sur la fiche présente pour éviter au comptable de re-clicker sur la fiche
                listFichesByUser(idUser);
                listFraisByFiche(idFiche);
            }
            catch (Exception ex) // En cas d'erreur on affiche cette erreur
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
            idFiche = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg, entete;

            // Récupération des items checkés que le comptable veut supprimer
            ListView.CheckedListViewItemCollection checkedItemsHorsForfaits = listViewHorsForfaits.CheckedItems;
            
            // Si l'utilisateur n'a rien checké, erreur
            if (checkedItemsHorsForfaits.Count == 0)
            {
                msg = "Veuillez saisir le/les forfaits à supprimer.";
                entete = "Erreur";
            }
            else
            {
                try // Au cas ou il y ai une erreur
                {
                    // On update chaque hors forfait sélectionné
                    foreach (ListViewItem itemHorsForfait in checkedItemsHorsForfaits)
                    {
                        Program.mydb.OpenConnection();
                        MySqlCommand commandHorsForfait = Program.mydb.connection.CreateCommand();
                        commandHorsForfait.CommandText = "UPDATE hors_forfait SET prix=0 WHERE id=@idHorsForfait;";
                        commandHorsForfait.Parameters.AddWithValue("@idHorsForfait", itemHorsForfait.SubItems[0].Text);
                        commandHorsForfait.ExecuteNonQuery();
                        Program.mydb.CloseConnection();
                    }

                    // Corps et entête du message qui sera affiché
                    msg = "Modification réussie.";
                    entete = "Succès";

                    // On affiche tous les frais de la fiche pour laquelle on vient de supprimer les frais
                    listFraisByFiche(idFiche);
                }
                catch(Exception ex)
                {
                    msg = ex.Message; // On récupère le message d'erreur
                    entete = "Erreur";
                }
            }
            MessageBox.Show(msg, entete); // Affichage du message
        }

        private void labelDevalider_Click(object sender, EventArgs e) // Si le comptable a oublié de vérifier les frais
        {            
            try // En cas d'erreur lors de la requête
            {
                // Requête pour remettre à "clôturée" une fiche que l'on avait validé
                Program.mydb.OpenConnection();
                MySqlCommand commandHorsForfait = Program.mydb.connection.CreateCommand();
                commandHorsForfait.CommandText = "UPDATE fiche_frais SET mon_etat_id=3, montant=null WHERE id=@id;";
                commandHorsForfait.Parameters.AddWithValue("@id", idFiche);
                commandHorsForfait.ExecuteNonQuery();
                Program.mydb.CloseConnection();

                // On affiche tous les frais de l'utilisateur sélectionné pour voir la modification
                listFichesByUser(idUser);
                listFraisByFiche(idFiche);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Bouton qui permet de sortir de l'application
            Application.Exit();
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            // Si on clique sur la barre de recherche, on enlève le placeholder
            if (textBoxSearch.Text == "Rechercher un client...")
            {
                textBoxSearch.Text = null;
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            // Quand on sort de la barre de recherche, on affiche le placeholder
            if (string.IsNullOrEmpty(textBoxSearch.Text))
            {
                textBoxSearch.Text = "Rechercher un client...";
            }
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e) // Dans la barre de recherche
        {
            // On initialise tout
            initialiser();

            // On clear les list view
            listViewForfaits.Clear();
            listViewHorsForfaits.Clear();
            listViewFiches.Clear();

            labelRemboursement.Text = "Remboursement total: non défini";

            if (textBoxSearch.Text != "Rechercher un client...")
            {
                try // En cas d'erreur lors des requêtes vers la base de donnée
                {
                    // Création de la commande, on recherche en fonction de ce qui est présent dans la barre de recherche
                    string sql = "SELECT * FROM utilisateur WHERE utilisateur.mon_type_id = 1 AND(utilisateur.nom LIKE '%" + textBoxSearch.Text.ToString() + "%' OR utilisateur.prenom LIKE '%" + textBoxSearch.Text.ToString() + "%')";

                    MySqlDataAdapter msda = new MySqlDataAdapter(sql, Program.mydb.connection);
                    DataSet DS = new DataSet();
                    msda.Fill(DS);

                    // On efface les précédents résultats
                    listViewUsers.Clear();

                    // Ajout de chaque utilisateur à la ListViewUsers
                    for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(DS.Tables[0].Rows[i].ItemArray[0].ToString()); // Récupération ID
                        item.SubItems.Add(DS.Tables[0].Rows[i].ItemArray[1].ToString()); // Récupération nom
                        item.SubItems.Add(DS.Tables[0].Rows[i].ItemArray[2].ToString()); // Récupération prénom
                        listViewUsers.Items.AddRange(new ListViewItem[] { item }); // Ajout de l'item
                    }

                    // Définition des headers de la ListViewUser
                    listViewUsers.Columns.Add("ID", -2, HorizontalAlignment.Left);
                    listViewUsers.Columns.Add("Nom", -2, HorizontalAlignment.Left);
                    listViewUsers.Columns.Add("Prénom", -2, HorizontalAlignment.Left);

                    listViewUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); // Pour redéfinir la taille des colonnes
                    Controls.Add(listViewUsers);
                    Program.mydb.CloseConnection();

                }
                catch (Exception ex)
                {
                    // Affichage du message en cas d'erreur
                    MessageBox.Show(ex.Message, "Erreur");
                }
            }
            else
            {
                // Si aucune donnée de saisie
                MessageBox.Show("Aucune donnée n'a été saisie", "Erreur");
            }
        }

        public void listFichesByUser(string id)
        {
            // On remet les ListView à 0 pour éviter les erreurs
            listViewFiches.Clear();
            listViewForfaits.Clear();
            listViewHorsForfaits.Clear();
            listViewFiches.View = View.Details;
            listViewFiches.AllowColumnReorder = true;
            listViewFiches.FullRowSelect = true;
            listViewFiches.GridLines = true;

            // Requête pour obtenir les fiches de l'utilisateur sélectionné
            string sql = "SELECT * FROM fiche_frais WHERE mon_utilisateur_id =" + id + " ORDER BY date DESC;";

            try
            {
                // Création de l'adaptateur
                MySqlDataAdapter msda = new MySqlDataAdapter(sql, Program.mydb.connection);
                DataSet DS = new DataSet();
                msda.Fill(DS);

                // On affiche toutes les fiches de frais de l'utilisateur
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(DS.Tables[0].Rows[i].ItemArray[0].ToString());
                    string etat = DS.Tables[0].Rows[i].ItemArray[1].ToString();
                    switch (etat) // Pour ne pas afficher 1-3-4-5 mais les libellés
                    {
                        case "1":
                            etat = "En cours";
                            break;
                        case "3":
                            etat = "Clôturée";
                            break;
                        case "4":
                            etat = "Validée";
                            break;
                        case "5":
                            etat = "Remboursée";
                            break;
                        default:
                            MessageBox.Show("Erreur état fiche", "Erreur"); // En cas d'erreur
                            break;
                    }
                    item.SubItems.Add(etat);

                    // Parse la date pour n'avoir que le mois et l'année
                    DateTime date = DateTime.Parse(DS.Tables[0].Rows[i].ItemArray[3].ToString());
                    string newDate = date.Month.ToString() + "/" + date.Year.ToString();
                    item.SubItems.Add(newDate);

                    listViewFiches.Items.AddRange(new ListViewItem[] { item });
                }

                // Ajout des headers à ListViewFiches
                listViewFiches.Columns.Add("ID", -2, HorizontalAlignment.Left);
                listViewFiches.Columns.Add("Etat", -2, HorizontalAlignment.Left);
                listViewFiches.Columns.Add("Date", -2, HorizontalAlignment.Left);

                listViewFiches.Columns[0].Dispose();

                listViewFiches.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                Controls.Add(listViewFiches);
                Program.mydb.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        public void listFraisByFiche(string id)
        {
            // On initialise tout
            initialiser();

            // On récupère l'état de la fiche sélectionnée
            MySqlDataAdapter msdaFiche = new MySqlDataAdapter("select mon_etat_id, montant from fiche_frais where id = " + idFiche + ";", Program.mydb.connection);
            DataSet DSFiche = new DataSet();
            msdaFiche.Fill(DSFiche);
            string etat = DSFiche.Tables[0].Rows[0].ItemArray[0].ToString();

            // Si la fiche est validée ou remboursée, on affiche le montant car il a été calculé
            if (etat == "4" || etat == "5")
            {
                labelRemboursement.Text = "Remboursement total: " + DSFiche.Tables[0].Rows[0].ItemArray[1].ToString() + "€";
            }
            else // Sinon on affiche comme quoi le remboursement n'a pas été défini
            {
                labelRemboursement.Text = "Remboursement total: non défini";
            }

            // Si la fiche est validée, alors on peut revenir en arrière et la mettre en clôturée pour revérifier les frais
            if (etat == "4")
            {
                labelDevalider.Visible = true;
            }
            else
            {
                labelDevalider.Visible = false;
            }

            Program.mydb.CloseConnection();

            // On réinitialise les forfaits et hors forfaits 
            listViewForfaits.Clear();
            listViewHorsForfaits.Clear();

            // Si la fiche est est clôturée, on peut modifier les frais
            if (etat == "3")
            {
                btnDelete.Enabled = true;
                btnDelete.BackColor = Color.Red;
                btnValider.Enabled = true;
                btnValider.BackColor = Color.LimeGreen;
                btnModif.Enabled = true;
                btnModif.BackColor = Color.Red;
            }
            else // Sinon c'est impossible
            {
                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.Gray;
                btnValider.Enabled = false;
                btnValider.BackColor = Color.Gray;
                btnModif.Enabled = false;
                btnModif.BackColor = Color.Gray;
            }
            listViewForfaits.View = View.Details;
            listViewForfaits.AllowColumnReorder = true;
            listViewForfaits.FullRowSelect = true;
            listViewForfaits.GridLines = true;
            listViewForfaits.Sorting = System.Windows.Forms.SortOrder.Ascending;

            try // Try Catch en cas d'erreur lors des requêtes
            {
                // Requête sql pour afficher les frais forfaitisés en fonction de l'ID de la fiche sélectionnée
                string sql = "select * from forfait where ma_fiche_id =" + id + ";";

                MySqlDataAdapter msda = new MySqlDataAdapter(sql, Program.mydb.connection);
                DataSet DS = new DataSet();
                msda.Fill(DS);
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(DS.Tables[0].Rows[i].ItemArray[0].ToString());
                    string libelle = DS.Tables[0].Rows[i].ItemArray[1].ToString();
                    switch (libelle) // On modifie le libellé pour ne pas avoir un numéro
                    {
                        case "5":
                            libelle = "repas";
                            break;
                        case "6":
                            libelle = "étape";
                            break;
                        case "7":
                            libelle = "nuitée";
                            break;
                        case "8":
                            libelle = "kilométrage";
                            break;
                        default:
                            MessageBox.Show("Erreur saisie libellé", "Erreur");
                            break;
                    }
                    item.SubItems.Add(libelle);
                    item.SubItems.Add(DS.Tables[0].Rows[i].ItemArray[3].ToString());
                    listViewForfaits.Items.AddRange(new ListViewItem[] { item });
                }
            }
            catch (Exception ex)
            {
                // Affichage du message en cas d'erreur
                MessageBox.Show(ex.Message, "Erreur");
            }
            // On ajoute les headers aux colonnes du listViewForfaits
            listViewForfaits.Columns.Add("ID", 0, HorizontalAlignment.Left);
            listViewForfaits.Columns.Add("Libellé", -2, HorizontalAlignment.Left);
            listViewForfaits.Columns.Add("Quantité", -2, HorizontalAlignment.Left);

            listViewForfaits.Columns[0].Dispose();

            // On resize les headers en fonction de ce que l'on a récupéré pour tout réadapter
            listViewForfaits.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            Controls.Add(listViewForfaits);

            listViewHorsForfaits.View = View.Details;
            listViewHorsForfaits.AllowColumnReorder = true;
            listViewHorsForfaits.FullRowSelect = true;
            listViewHorsForfaits.GridLines = true;
            listViewHorsForfaits.Sorting = System.Windows.Forms.SortOrder.Ascending;

            try // Try Catch en cas d'erreur
            {
                // Les frais non forfaitisés en fonction de la fiche sélectionnée
                string sql2 = "select * from hors_forfait where ma_fiche_id =" + id + ";";

                MySqlDataAdapter msda = new MySqlDataAdapter(sql2, Program.mydb.connection);
                DataSet DS = new DataSet();
                msda.Fill(DS);
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(DS.Tables[0].Rows[i].ItemArray[0].ToString());
                    // Parse la date pour avoir sous forme dd/mm/yyyy
                    DateTime date = DateTime.Parse(DS.Tables[0].Rows[i].ItemArray[2].ToString());
                    string newDate = date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString();
                    item.SubItems.Add(newDate);
                    item.SubItems.Add(DS.Tables[0].Rows[i].ItemArray[3].ToString());
                    item.SubItems.Add(DS.Tables[0].Rows[i].ItemArray[4].ToString());
                    listViewHorsForfaits.Items.AddRange(new ListViewItem[] { item });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }

            // Ajout des 4 headers aux colonnes de la liste view des frais non forfaitisés
            listViewHorsForfaits.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listViewHorsForfaits.Columns.Add("Date", -2, HorizontalAlignment.Left);
            listViewHorsForfaits.Columns.Add("Libellé", -2, HorizontalAlignment.Left);
            listViewHorsForfaits.Columns.Add("Prix", -2, HorizontalAlignment.Left);

            listViewHorsForfaits.Columns[0].Dispose();

            // On resize les colonnes en fonction de ce qui a été récupéré
            listViewHorsForfaits.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            Controls.Add(listViewHorsForfaits);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://lesjoiesducode.fr/random");
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItemsForfaits = listViewForfaits.CheckedItems;
            if (checkedItemsForfaits.Count == 0)
            {
                MessageBox.Show("Aucun forfait sélectionné.", "Erreur");
            }
            else if (checkedItemsForfaits.Count > 1)
            {
                MessageBox.Show("Veuillez ne cocher qu'un forfait à la fois.", "Erreur");
            }
            else
            {
                var updateForfait = new UpdateForfait(listViewForfaits.CheckedItems[0].SubItems[0].Text, listViewForfaits.CheckedItems[0].SubItems[2].Text);
                updateForfait.Show();
                listFichesByUser(idUser);
            }
        }

        public void initialiser()
        {
            // On initialise les boutons
            btnDelete.Enabled = false;
            btnDelete.BackColor = Color.Gray;
            btnValider.Enabled = false;
            btnValider.BackColor = Color.Gray;
            btnModif.Enabled = false;
            btnModif.BackColor = Color.Gray;

            labelDevalider.Visible = false;

            labelRemboursement.Text = "Remboursement total: non défini";
        }
    }
}