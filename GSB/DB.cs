using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devart.Data.MySql;

namespace GSB
{
    class DB
    {
        public MySqlConnection connection;

        public DB(string server, string db, string login, string password)
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + db + ";" + "UID=" + login + ";" + "PASSWORD=" + password + ";CharSet=utf8;";
            connection = new MySqlConnection(connectionString);
        }

        //Ouvrir la connection à la base
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        //Fermer la connexion à la base
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }
}
