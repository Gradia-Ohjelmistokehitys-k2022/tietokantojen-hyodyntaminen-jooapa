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
        int currentAutoID = 1;

        public MainMenu()
        {
            //registerHandler = new KaupanLogiikka();
            InitializeComponent();
        }

        public void SetAutoToForm(Auto auto)
        {
            //print to ocnsole 
            Console.WriteLine(auto.ID);
            Console.WriteLine(auto.Hinta);
            Console.WriteLine(auto.Mittarilukema);
            Console.WriteLine(auto.Moottorin_tilavuus);
            Console.WriteLine(auto.Rekisteri_paivamaara);
            Console.WriteLine(auto.AutonMalliID);
            Console.WriteLine(auto.PolttoaineID);
            Console.WriteLine(auto.VaritID);
            Console.WriteLine(auto.AutonMerkkiID);

            tbHinta.Text = auto.Hinta.ToString();
            tbId.Text = auto.ID.ToString();
            tbMittari.Text = auto.Mittarilukema.ToString();
            tbMottoriTlv.Text = auto.Moottorin_tilavuus.ToString();
            dtpPaiva.Value = auto.Rekisteri_paivamaara;
            // Get the auton malli from the database
            cbMalli.Text = registerHandler.GetAutonMalliNimi(auto.AutonMalliID);
            cbMerkki.Text = registerHandler.GetAutonMerkkiNimi(auto.AutonMerkkiID);
            cbPolttoaine.Text = registerHandler.GetPolttoaineNimi(auto.PolttoaineID);
            cbVari.Text = registerHandler.GetVariNimi(auto.VaritID);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (registerHandler.TestDatabaseConnection())
            {
                //label5.Text = "Yhteys tietokantaan toimii";
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
            Auto auto = registerHandler.GetAutoFromDatabase(currentAutoID);

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
            List<AutonMerkki> merkit = registerHandler.GetAutonMerkit();
            List<Polttoaine> polttoaineet = registerHandler.GetPolttoaineet();
            List<Varit> varit = registerHandler.GetVarit();

            foreach (var item in mallit)
            {
                cbMalli.Items.Add(item.AutonMalli);
            }
            foreach (var item in merkit)
            {
                cbMerkki.Items.Add(item.Merkki);
            }
            foreach (var item in polttoaineet)
            {
                cbPolttoaine.Items.Add(item.PolttoaineNimi);
            }
            foreach (var item in varit)
            {
                cbVari.Items.Add(item.Vari);
            }
        }

        private void gbAuto_Enter(object sender, EventArgs e)
        {

        }

        private void btnSeuraava_Click(object sender, EventArgs e)
        {
            SetCBValues();
            currentAutoID++;
            Auto auto = registerHandler.GetAutoFromDatabase(currentAutoID);
            SetAutoToForm(auto);
        }

        private void btnEdellinen_Click(object sender, EventArgs e)
        {
            SetCBValues();
            currentAutoID--;
            Auto auto = registerHandler.GetAutoFromDatabase(currentAutoID);
            SetAutoToForm(auto);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void testaaTietokantaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (registerHandler.TestDatabaseConnection())
            {
                MessageBox.Show("Yhteys tietokantaan toimii");
            }
            else
            {
                MessageBox.Show("Yhteys tietokantaan ei toimi");
            }
        }

        private void btnTallenna_Click(object sender, EventArgs e)
        {
            int id = currentAutoID;
            decimal hinta = decimal.Parse(tbHinta.Text);
            int mittarilukema = int.Parse(tbMittari.Text);
            decimal moottorin_tilavuus = decimal.Parse(tbMottoriTlv.Text);
            DateTime rekisteri_paivamaara = dtpPaiva.Value;
            int autonMalliID = registerHandler.GetAutonMalliID(cbMalli.Text);
            int autonMerkkiID = registerHandler.GetAutonMerkkiID(cbMerkki.Text);
            int polttoaineID = registerHandler.GetPolttoaineID(cbPolttoaine.Text);
            int varitID = registerHandler.GetVariID(cbVari.Text);

        }
    }
}
