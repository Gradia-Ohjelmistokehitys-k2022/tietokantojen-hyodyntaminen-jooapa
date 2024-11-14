using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;



namespace Autokauppa.model
{
    public class DatabaseHallinta
    {
        string yhteysTiedot;
        SqlConnection dbYhteys;
        SqlDataReader reader;

        public DatabaseHallinta()
        {
            yhteysTiedot =
             "Server=(localdb)\\MSSQLLocalDB;" +
             "Database=Autokoulu;" +
             "Trusted_Connection=True;";
        }

        public bool ConnectDatabase()
        {
            dbYhteys = new SqlConnection(yhteysTiedot);
            try
            {
                dbYhteys.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void DisconnectDatabase()
        {
            dbYhteys.Close();
        }

        public bool SaveAutoIntoDatabase(Auto newAuto)
        {
            bool palaute = false;
            return palaute;
        }

        public Auto GetAutoFromDatabase(int id)
        {
            ConnectDatabase();
            string query = @"SELECT * FROM auto
                            ORDER BY(SELECT NULL)
                            OFFSET " + id + @" ROWS
                            FETCH NEXT 1 ROWS ONLY;"
            ;
            SqlCommand command = new(query, dbYhteys);
            reader = command.ExecuteReader();
            Auto auto = new Auto();
            while (reader.Read())
            {
                auto.ID = reader.GetInt32(0);
                auto.Hinta = reader.GetDecimal(1);
                auto.Rekisteri_paivamaara = reader.GetDateTime(2);
                auto.Moottorin_tilavuus = reader.GetDecimal(3);
                auto.Mittarilukema = reader.GetInt32(4);
                auto.AutonMerkkiID = reader.GetInt32(5);
                auto.AutonMalliID = reader.GetInt32(6);
                auto.VaritID = reader.GetInt32(7);
                auto.PolttoaineID = reader.GetInt32(8);
            }
            DisconnectDatabase();
            return auto;
        }

        internal List<AutonMallit> GetAutonMallit()
        {
            ConnectDatabase();
            string query = @"SELECT * FROM autonmallit;";
            SqlCommand command = new(query, dbYhteys);
            reader = command.ExecuteReader();
            List<AutonMallit> mallit = new();
            while (reader.Read())
            {
                AutonMallit malli = new()
                {
                    ID = reader.GetInt32(0),
                    AutonMalli = reader.GetString(1),
                    AutonMerkkiID = reader.GetInt32(2)
                };
                mallit.Add(malli);
            }
            DisconnectDatabase();
            return mallit;
        }

        internal string GetAutonMalli(int id)
        {
            ConnectDatabase();
            string query = @"SELECT * FROM autonmallit
                            WHERE ID = " + id + ";";
            SqlCommand command = new(query, dbYhteys);
            reader = command.ExecuteReader();
            string malli = "";
            while (reader.Read())
            {
                malli = reader.GetString(1);
            }
            DisconnectDatabase();
            return malli;
        }
    }
}
