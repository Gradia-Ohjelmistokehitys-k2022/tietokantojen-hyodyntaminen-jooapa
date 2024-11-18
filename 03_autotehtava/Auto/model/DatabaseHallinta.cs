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
        private SqlConnection dbYhteys;
        private SqlDataReader reader;

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
            //string query = @"SELECT * FROM auto
            //                ORDER BY(SELECT NULL)
            //                OFFSET " + id + @" ROWS
            //                FETCH NEXT 1 ROWS ONLY;"
            string query = @"SELECT * FROM auto
                            ORDER BY hinta ASC
                            OFFSET " + id + @" ROWS
                            FETCH NEXT 1 ROWS ONLY;";
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

        internal string GetAutonMerkki(int id)
        {
            ConnectDatabase();
            string query = @"SELECT * FROM AutonMerkki
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

        internal string GetPolttoaine(int id)
        {
            ConnectDatabase();
            string query = @"SELECT * FROM Polttoaine
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

        internal string GetVari(int id)
        {
            ConnectDatabase();
            string query = @"SELECT * FROM Varit
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

        internal List<AutonMerkki> GetAutonMerkit()
        {
            ConnectDatabase();
            string query = @"SELECT * FROM AutonMerkki;";
            SqlCommand command = new(query, dbYhteys);
            reader = command.ExecuteReader();
            List<AutonMerkki> merkit = new();
            while (reader.Read())
            {
                AutonMerkki merkki = new()
                {
                    ID = reader.GetInt32(0),
                    Merkki = reader.GetString(1)
                };
                merkit.Add(merkki);
            }
            DisconnectDatabase();
            return merkit;
        }

        internal List<Polttoaine> GetPolttoaineet()
        {

            ConnectDatabase();
            string query = @"SELECT * FROM Polttoaine;";
            SqlCommand command = new(query, dbYhteys);
            reader = command.ExecuteReader();
            List<Polttoaine> polttoaineet = new();
            while (reader.Read())
            {
                Polttoaine polttoaine = new()
                {
                    ID = reader.GetInt32(0),
                    PolttoaineNimi = reader.GetString(1)
                };
                polttoaineet.Add(polttoaine);
            }
            DisconnectDatabase();
            return polttoaineet;
        }
        internal List<Varit> GetVarit()
        {
            ConnectDatabase();
            string query = @"SELECT * FROM Varit;";
            SqlCommand command = new(query, dbYhteys);
            reader = command.ExecuteReader();
            List<Varit> varit = new();
            while (reader.Read())
            {
                Varit vari = new()
                {
                    ID = reader.GetInt32(0),
                    Vari = reader.GetString(1)
                };
                varit.Add(vari);
            }
            DisconnectDatabase();
            return varit;
        }

        internal int GetAutoIDLength()
        {
            ConnectDatabase();
            string query = @"SELECT COUNT(*) FROM auto;";
            SqlCommand command = new(query, dbYhteys);
            reader = command.ExecuteReader();
            int length = 0;
            while (reader.Read())
            {
                length = reader.GetInt32(0);
            }
            DisconnectDatabase();
            return length;
        }
    }
}
