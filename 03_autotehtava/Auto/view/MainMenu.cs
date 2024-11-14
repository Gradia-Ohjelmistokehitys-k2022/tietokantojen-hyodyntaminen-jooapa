using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Autokauppa.controller;
using Autokauppa.model;


namespace Autokauppa.view
{
    public partial class MainMenu : Form
    {


        //KaupanLogiikka registerHandler;

        KaupanLogiikka registerHandler = new();
        public MainMenu()
        {
            //registerHandler = new KaupanLogiikka();
            InitializeComponent();
        }

        public void SetAutoToForm(Auto auto)
        {
            tbHinta.Text = auto.Hinta.ToString();
            tbId.Text = auto.ID.ToString();
            tbMittari.Text = auto.Mittarilukema.ToString();
            tbMottoriTlv.Text = auto.Moottorin_tilavuus.ToString();
            dtpPaiva.Value = auto.Rekisteri_paivamaara;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (registerHandler.TestDatabaseConnection())
            {
                label5.Text = "Yhteys tietokantaan toimii";
            }
            else
            {
                MessageBox.Show("Yhteys tietokantaan ei toimi");
                Environment.Exit(0);
            }
            // set the cb values
            // automerkki, malli, polttoaine, vari
            SetCBValues();

            // get the first auto from the database
            Auto auto = registerHandler.GetAutoFromDatabase(1);

            // set the auto to the form
            SetAutoToForm(auto);
        }

        private void SetCBValues()
        {
            cbMalli.Items.Clear();
            cbMerkki.Items.Clear();
            cbPolttoaine.Items.Clear();
            cbVari.Items.Clear();

            List<AutonMallit> mallit = registerHandler.GetAutonMallit();
        }

        private void gbAuto_Enter(object sender, EventArgs e)
        {

        }

        private void btnSeuraava_Click(object sender, EventArgs e)
        {

        }

        private void btnEdellinen_Click(object sender, EventArgs e)
        {

        }
    }
}
