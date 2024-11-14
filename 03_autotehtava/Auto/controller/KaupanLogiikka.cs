using Autokauppa.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokauppa.controller
{
    public class KaupanLogiikka
    {
        DatabaseHallinta dbModel = new();

        public bool TestDatabaseConnection()
        {
            return dbModel.ConnectDatabase();
        }

        public bool SaveAuto(model.Auto newAuto) 
        {
            bool didItGoIntoDatabase = dbModel.SaveAutoIntoDatabase(newAuto);
            return didItGoIntoDatabase;
        }

        public Auto GetAutoFromDatabase(int id)
        {
            return dbModel.GetAutoFromDatabase(id);
        }

        internal List<AutonMallit> GetAutonMallit()
        {
            return dbModel.GetAutonMallit();
        }
    }
}
