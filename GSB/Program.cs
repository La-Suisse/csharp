using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB
{
    static class Program
    {
        public static DB mydb;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //mydb = new DB("192.168.2.4", "bdcdudit1", "sqlcdudit", "savary");
            mydb = new DB("192.168.2.4", "bdldelaroche7", "sqlldelaroche", "savary");
            //mydb = new DB("192.168.135.201", "gsb", "dev1", "P@ssw0rd");

            //Ouvre la connexion
            if (mydb.OpenConnection() != true)
            {
                Application.Exit();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //Ferme la connexion
            mydb.CloseConnection();
        }
    }
}
