using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Globalization;

namespace domotique
{
    public partial class Form1 : Form
    {
        public Boolean statusBDD; // Status de connection BDD
        TimeSpan interval; // Interval défini par la trackbar
        DateTime date;
        TMaison maMaison;
        private SqlConnection con; //pour la connection
        private string strcon; //pour la chaine de connection
        public string req; //faire les requêtes
        public SqlDataReader rdr; //transités les données(traitement)
        private ListView list;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            date = DateTime.Now;
            String dt;
            dt = String.Format("{0:HH:mm:ss}", date);
            labelHeure.Text = dt;
            dt = String.Format("{0:d/MM/yyyy}", date);
            labelDate.Text = dt;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            labelHeure.Location = new Point(this.ClientSize.Width / 2 - labelHeure.Width / 2, labelHeure.Location.Y);
            interval = new TimeSpan(1, 0, 0);
            panelMaison.Location = new Point(this.ClientSize.Width / 2 - panelMaison.Width / 2, panelMaison.Location.Y);
            splitContainer.SplitterWidth = 20;
            strcon = @"Data Source=TATCHI-PC\SQLEXPRESS;Initial Catalog=domotique;Integrated Security=True;Pooling=False;Connection Timeout=2";
            con = new SqlConnection(strcon);
            try
            {
                con.Open(); // Connection à la BDD
                statusBDD = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                statusBDD = false;
                var result = MessageBox.Show("Erreur de connexion à la base de donnée. Voulez-vous quand même continuer?", "Erreur connecion BDD!",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Error);
                if (result == DialogResult.No)
                {
                    Application.Exit();
                }
                else
                {
                    setStatusBDD(false);

                }

            }
            initialiserMaison(con);
            chargConsignes(con);
            timerHeure.Start();
            foreach (TPiece piece in this.maMaison.ListePieces)
            {
                piece.TrierListeConsignes();
            }


        }

        private void setStatusBDD(Boolean status)
        {
            if (status == false)
            {
                statusBDD = false;
                tabControlMaison.Controls.Remove(tabPageLogs);
            }
            else
            {
                statusBDD = true;
            }
        }


        /// <summary>
        /// Permet de charger les consignes contenu en BDD en mémoire
        /// </summary>
        /// <param name="con"></param>
        private void chargConsignes(SqlConnection con)
        {
            if (statusBDD == true)
            {
                SqlDataReader DataReader;
                try
                {

                    String maRequete;

                    maRequete = "SELECT * from domotique.dbo.Consigne";
                    SqlCommand myCommand = new SqlCommand(maRequete, con);
                    DataReader = myCommand.ExecuteReader();
                    while (DataReader.Read())
                    {
                        TConsigne cons = new TConsigne(DataReader.GetInt32(2), DataReader.GetInt32(1), DataReader.GetInt32(3));
                        maMaison.ListePieces[DataReader.GetInt32(4) - 4].AjouterConsigne(cons);
                    }
                    DataReader.Close();
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Initialise les différents objets de la maison
        /// </summary>
        /// <param name="con"></param>
        private void initialiserMaison(SqlConnection con)
        {
            var me = this;
            maMaison = new TMaison(this, false, 10, ref textBoxTExterieurActuelle, true, trackBar);

            TPiece monSalon = new TPiece("Salon", false, 15, 27, 1500, ref textBoxTSalonActuelle, ref textBoxTSalonConsigne, ref buttonChauffeSalon);
            TPiece maChambre = new TPiece("Chambre", false, 20, 15, 1000, ref textBoxTChambreActuelle, ref textBoxTChambreConsigne, ref buttonChauffeChambre);
            TPiece maCuisine = new TPiece("Cuisine", false, 20, 12, 500, ref textBoxTCuisineActuelle, ref textBoxTCuisineConsigne, ref buttonChauffeCuisine);

            TOuverture FCuisine = new TOuverture(ref labelFenetreCuisine, 3, 1, con, labelHeure, labelDate, ref statusBDD, true, maMaison);
            TOuverture PCuisine = new TOuverture(ref labelPorteCuisine, 2, 2, con, labelHeure, labelDate, ref statusBDD, true, maMaison);
            TOuverture FChambre = new TOuverture(ref labelFenetreChambre, 3, 1, con, labelHeure, labelDate, ref statusBDD, true, maMaison);
            TOuverture PChambre = new TOuverture(ref labelPorteChambre, 2, 2, con, labelHeure, labelDate, ref statusBDD, true, maMaison);
            TOuverture FSalon1 = new TOuverture(ref labelFenetreSalon, 3, 1, con, labelHeure, labelDate, ref statusBDD, true, maMaison);
            TOuverture FSalon2 = new TOuverture(ref labelFenetreSalon2, 3, 1, con, labelHeure, labelDate, ref statusBDD, true, maMaison);
            TOuverture PSalon = new TOuverture(ref labelPorteSalon, 2, 2, con, labelHeure, labelDate, ref statusBDD, true, maMaison);

            TParoi ParoiFenetreCuisine = new TParoi(maCuisine, 1, null, 12);
            TParoi ParoiFenetreChambre = new TParoi(maChambre, 1, null, 15);
            TParoi ParoiPorteCuisine = new TParoi(maCuisine, 1, monSalon, 12);
            TParoi ParoiPorteChambre = new TParoi(maChambre, 1, monSalon, 15);
            TParoi ParoiSalon = new TParoi(monSalon, 1, null, 27);
            TParoi ParoiCuisineGauche = new TParoi(maCuisine, 1, null, 9);
            TParoi ParoiSalonGauche = new TParoi(monSalon, 1, null, 9);
            TParoi ParoiMilieu = new TParoi(maCuisine, 1, maChambre, 9);
            TParoi ParoiChambreDroite = new TParoi(maChambre, 1, null, 9);
            TParoi ParoiSalonDroite = new TParoi(monSalon, 1, null, 9);

            ParoiFenetreCuisine.AjouterOuverture(FCuisine);
            ParoiFenetreChambre.AjouterOuverture(FChambre);
            ParoiPorteCuisine.AjouterOuverture(PCuisine);
            ParoiPorteChambre.AjouterOuverture(PChambre);
            ParoiSalon.AjouterOuverture(FSalon1);
            ParoiSalon.AjouterOuverture(PSalon);
            ParoiSalon.AjouterOuverture(FSalon2);

            ParoiFenetreCuisine.calculerSurfaceReel();
            ParoiFenetreChambre.calculerSurfaceReel();
            ParoiPorteCuisine.calculerSurfaceReel();
            ParoiPorteChambre.calculerSurfaceReel();
            ParoiSalon.calculerSurfaceReel();

            maCuisine.AjouterParoi(ParoiFenetreCuisine);
            maCuisine.AjouterParoi(ParoiPorteCuisine);
            maCuisine.AjouterParoi(ParoiCuisineGauche);
            maCuisine.AjouterParoi(ParoiMilieu);

            maChambre.AjouterParoi(ParoiFenetreChambre);
            maChambre.AjouterParoi(ParoiPorteChambre);
            maChambre.AjouterParoi(ParoiMilieu);
            maChambre.AjouterParoi(ParoiChambreDroite);


            monSalon.AjouterParoi(ParoiPorteCuisine);
            monSalon.AjouterParoi(ParoiPorteChambre);
            monSalon.AjouterParoi(ParoiSalon);
            monSalon.AjouterParoi(ParoiSalonGauche);
            monSalon.AjouterParoi(ParoiSalonDroite);

            maMaison.AjouterPiece(monSalon);
            maMaison.AjouterPiece(maChambre);
            maMaison.AjouterPiece(maCuisine);
        }

        /// <summary>
        /// Fonction qui se lance toute les secondes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerHeure_Tick(object sender, EventArgs e)
        {
            String dt2;
            int intervalle = trackBar.Value;
            if (intervalle != 1)
            {
                intervalle = (intervalle - 1) * 5 * 60;
            }
            date = date.AddSeconds(intervalle);
            dt2 = String.Format("{0:HHmmss}", date);
            if (Convert.ToInt32(dt2) > 220000 || Convert.ToInt32(dt2) < 60000)
            {
                this.maMaison.Lampe = true;
            }
            else
            {
                this.maMaison.Lampe = false;
            }
            dt2 = String.Format("{0:HH:mm:ss}", date);
            labelHeure.Text = dt2;
            dt2 = String.Format("{0:d/MM/yyyy}", date);
            labelDate.Text = dt2;
            chercherConsigne();
            maMaison.gerer();

        }

        /// <summary>
        /// Permet de garder les proportion lors du redimensionnement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelMaison_Paint(object sender, PaintEventArgs e)
        {
            labelFenetreCuisine.Location = new Point(splitContainer.Panel1.Size.Width / 2 - labelFenetreCuisine.Width / 2 + splitContainer.Location.X, labelFenetreCuisine.Location.Y);
            labelPorteCuisine.Location = new Point(splitContainer.Panel1.Size.Width / 2 - labelPorteCuisine.Width / 2 + splitContainer.Location.X, labelPorteCuisine.Location.Y);
            labelFenetreChambre.Location = new Point((splitContainer.Panel2.Size.Width / 2 - labelFenetreChambre.Width / 2) + splitContainer.Panel1.Width + splitContainer.SplitterWidth + splitContainer.Location.X, labelFenetreChambre.Location.Y);
            labelPorteChambre.Location = new Point((splitContainer.Panel2.Size.Width / 2 - labelPorteChambre.Width / 2) + splitContainer.Panel1.Width + splitContainer.SplitterWidth + splitContainer.Location.X, labelPorteChambre.Location.Y);
            labelFenetreSalon.Location = new Point(panelSalon.Size.Width / 5 - labelFenetreSalon.Width / 2, labelFenetreSalon.Location.Y);
            labelPorteSalon.Location = new Point(panelSalon.Size.Width / 2 - labelPorteSalon.Width / 2, labelPorteSalon.Location.Y);
            labelFenetreSalon2.Location = new Point(Convert.ToInt16(panelSalon.Size.Width / 1.2) - labelFenetreSalon2.Width / 2, labelFenetreSalon2.Location.Y);
        }

        /// <summary>
        /// Fonction qui se déclenche lors du click sur le boutton permettant d'ajouter une consigne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAjouterConsigne_Click(object sender, EventArgs e)
        {
            Boolean existeDeja = false;
            DateTime date;
            String dt;
            date = Convert.ToDateTime(comboBoxHeure.SelectedItem.ToString());
            dt = String.Format("{0:HHmmss}", date);
            TConsigne maConsigne = new TConsigne(Convert.ToInt32(dt), comboBoxJour.SelectedItem.ToString(), Convert.ToInt32(comboBoxTemperature.SelectedItem.ToString()));

            foreach (TConsigne cons in maMaison.ListePieces[tabControlPieces.SelectedIndex].ListeConsignes)
            {
                if ((maConsigne.Jour == cons.Jour) && (maConsigne.Heure == cons.Heure))
                {
                    existeDeja = true;
                    var result = MessageBox.Show("Une consigne existe deja à cette date la. Voulez-vous l'écraser?", "Erreur!",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Error);
                    if (result == DialogResult.Yes)
                    {
                        String maRequete;
                        maRequete = "DELETE FROM domotique.dbo.Consigne WHERE jour = '" + cons.Jour + "' and heure = '" + cons.Heure + "' and temperature = '" + cons.Temperature + "'";
                        SqlCommand myCommand = new SqlCommand(maRequete, con);
                        myCommand.ExecuteNonQuery();
                        maMaison.ListePieces[tabControlPieces.SelectedIndex].SupprimerConsigne2(cons);
                        maMaison.ListePieces[tabControlPieces.SelectedIndex].AjouterConsigne(maConsigne);

                        if (statusBDD == true)
                        {
                            String maRequete2;
                            int piece = tabControlPieces.SelectedIndex + 4;
                            maRequete2 = "INSERT INTO domotique.dbo.Consigne VALUES ('" + maConsigne.Jour + "' , '" + maConsigne.Heure + "', '" + maConsigne.Temperature + "', '" + piece + "')";
                            SqlCommand myCommand2 = new SqlCommand(maRequete2, con);
                            myCommand2.ExecuteNonQuery();
                        }

                        break;
                    }
                }
            }

            if (existeDeja == false)
            {

                if (statusBDD == true)
                {
                    String maRequete;
                    int piece = tabControlPieces.SelectedIndex + 4;
                    maRequete = "INSERT INTO domotique.dbo.Consigne VALUES ('" + maConsigne.Jour + "' , '" + maConsigne.Heure + "', '" + maConsigne.Temperature + "', '" + piece + "')";
                    SqlCommand myCommand = new SqlCommand(maRequete, con);
                    myCommand.ExecuteNonQuery();
                    maMaison.ListePieces[tabControlPieces.SelectedIndex].AjouterConsigne(maConsigne);
                }
            }
            maMaison.ListePieces[tabControlPieces.SelectedIndex].TrierListeConsignes();
            AfficherConsignes();

        }

        /// <summary>
        /// Permet d'afficher les consignes
        /// </summary>
        public void AfficherConsignes()
        {
            var list = (ListView)tabControlPieces.Controls[tabControlPieces.SelectedIndex].Controls[0];
            list.Items.Clear();
            for (int i = 0; i < maMaison.ListePieces[tabControlPieces.SelectedIndex].ListeConsignes.NbConsignes; i++)
            {
                ListViewItem it = new ListViewItem();
                String heure = maMaison.ListePieces[tabControlPieces.SelectedIndex].ListeConsignes[i].Heure.ToString();
                String heure2;

                if (heure.Length == 5)
                {
                    heure2 = heure[0].ToString() + ":" + heure[1].ToString() + heure[2].ToString() + ":" + heure[3].ToString() + heure[4].ToString();

                }
                else
                {
                    heure2 = heure[0].ToString() + heure[1].ToString() + ":" + heure[2].ToString() + heure[3].ToString() + ":" + heure[4].ToString() + heure[5].ToString();
                }

                it.SubItems[0].Text = maMaison.ListePieces[tabControlPieces.SelectedIndex].ListeConsignes[i].convertIntToJour(maMaison.ListePieces[tabControlPieces.SelectedIndex].ListeConsignes[i].Jour);
                it.SubItems.Add(heure2);
                it.SubItems.Add(maMaison.ListePieces[tabControlPieces.SelectedIndex].ListeConsignes[i].Temperature.ToString());
                list.Items.Add(it);
            }


        }

        private void comboBoxJour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxJour.SelectedIndex.ToString() != "-1" && comboBoxHeure.SelectedIndex.ToString() != "-1" && comboBoxTemperature.SelectedIndex.ToString() != "-1")
            {
                buttonAjouterConsigne.Enabled = true;
            }
            else
            {
                buttonAjouterConsigne.Enabled = false;
            }

        }

        private void labelFenetreCuisine_Click(object sender, EventArgs e)
        {
            var send = (Label)sender;
            int piece, paroi, ouverture;
            piece = maMaison.ListePieces.TrouverPiece(send.Name.ToString());
            paroi = maMaison.ListePieces[piece].ListeParois.TrouverParoi(send.Name.ToString());
            ouverture = maMaison.ListePieces[piece].ListeParois[paroi].ListeOuvertures.TrouverOuverture(send.Name.ToString());


            if (maMaison.ListePieces[piece].ListeParois[paroi].ListeOuvertures[ouverture].Ouvert == true)
            {
                maMaison.ListePieces[piece].ListeParois[paroi].ListeOuvertures[ouverture].Ouvert = false;
            }
            else
            {
                maMaison.ListePieces[piece].ListeParois[paroi].ListeOuvertures[ouverture].Ouvert = true;
            }
        }

        private void pictureBoxLampe_Click(object sender, EventArgs e)
        {
            if (maMaison.Lampe == false)
            {
                maMaison.Lampe = true;
            }
            else
            {
                maMaison.Lampe = false;
            }
        }

        public void chercherConsigne()
        {
            DateTime date, date2;
            String dt, dt2;
            int jourActuel, jourConsigne;
            date = Convert.ToDateTime(labelHeure.Text);
            dt = String.Format("{0:HH:mm:ss}", date);
            date = Convert.ToDateTime(labelDate.Text);
            dt2 = String.Format("{0:d/MM/yyyy}", date);
            date = Convert.ToDateTime(dt2 + " " + dt);

            jourActuel = convertJourToInt(date.ToString("dddd", new CultureInfo("fr-FR")));
            DateTime dateActuelle = new DateTime(2012, 1, jourActuel, date.Hour, date.Minute, date.Second);
            TimeSpan pptdiffTemps = new TimeSpan();
            int index = -1;

            for (int j = 0; j < maMaison.ListePieces.NbPieces; j++)
            {

                for (int i = 0; i < maMaison.ListePieces[j].ListeConsignes.NbConsignes; i++)
                {

                    String heure = maMaison.ListePieces[j].ListeConsignes[i].Heure.ToString();
                    int jourCons = maMaison.ListePieces[j].ListeConsignes[i].Jour;
                    String heure2;

                    if (heure.Length == 5)
                    {
                        heure2 = heure[0].ToString() + ":" + heure[1].ToString() + heure[2].ToString() + ":" + heure[3].ToString() + heure[4].ToString();

                    }
                    else
                    {
                        heure2 = heure[0].ToString() + heure[1].ToString() + ":" + heure[2].ToString() + heure[3].ToString() + ":" + heure[4].ToString() + heure[5].ToString();
                    }

                    DateTime jourC = DateTime.Parse(heure2);
                    DateTime dateConsigne = new DateTime(2012, 1, jourCons, jourC.Hour, jourC.Minute, jourC.Second);
                    TimeSpan diffTemps = dateConsigne - dateActuelle;

                    if (index == -1)
                    {
                        pptdiffTemps = diffTemps;
                        index = i;
                    }
                    if (diffTemps.Duration() < pptdiffTemps.Duration() && diffTemps.Seconds < 0)
                    {
                        pptdiffTemps = diffTemps;
                        index = i;
                    }

                }

                if (maMaison.ListePieces[j].ListeConsignes.NbConsignes > 0)
                {
                    maMaison.ListePieces[j].Consigne = maMaison.ListePieces[j].ListeConsignes[index].Temperature;
                }
                else
                {
                    maMaison.ListePieces[j].Consigne = 20;
                }
                index = -1;
            }
        }


        public int convertJourToInt(String jour)
        {
            switch (jour)
            {
                case "lundi":
                    return 1;
                case "mardi":
                    return 2;
                case "mercredi":
                    return 3;
                case "jeudi":
                    return 4;
                case "vendredi":
                    return 5;
                case "samedi":
                    return 6;
                case "dimanche":
                    return 7;
            }
            return 0;
        }

        public String convertIntToJour(int jour)
        {
            switch (jour)
            {
                case 1:
                    return "lundi";
                case 2:
                    return "mardi";
                case 3:
                    return "mercredi";
                case 4:
                    return "jeudi";
                case 5:
                    return "vendredi";
                case 6:
                    return "samedi";
                case 7:
                    return "dimanche";
            }
            return "";
        }

        private void tabPageLogs_Enter(object sender, EventArgs e)
        {
            String maRequete;
            SqlDataReader DataReader;
            //maRequete = "SELECT PK_LogPiece, date, etat, nom  from domotique.dbo.LogPiece INNER JOIN domotique.dbo.Ouverture ON FK_Ouverture = PK_Ouverture";
            maRequete = "SELECT PK_LogPiece, date, etat, Ouverture.nom, Piece.nom, pp.nom  from domotique.dbo.LogPiece INNER JOIN domotique.dbo.Ouverture ON FK_Ouverture = PK_Ouverture INNER JOIN domotique.dbo.Piece ON FK_Piece1 = PK_Piece INNER JOIN domotique.dbo.Piece as pp ON FK_Piece2 = pp.PK_Piece";
            SqlCommand myCommand = new SqlCommand(maRequete, con);
            DataReader = myCommand.ExecuteReader();
            DateTime date;
            String dt, heure, etat;
            int ouvert;
            dataGridViewLogPiece.Rows.Clear();

            while (DataReader.Read())
            {
                date = DataReader.GetDateTime(1);
                ouvert = Convert.ToInt32(DataReader.GetValue(2));

                heure = String.Format("{0:HH:mm:ss}", date);
                dt = String.Format("{0:d/MM/yyyy}", date);

                if (ouvert == 1)
                {
                    etat = "Ouvert";
                }
                else
                {
                    etat = "Fermé";
                }
                dataGridViewLogPiece.Rows.Add(dt, heure, DataReader.GetValue(3).ToString(), etat, DataReader.GetValue(4), DataReader.GetValue(5));
            }
            DataReader.Close();
        }

        private void buttonSupprimerConsigne_Click(object sender, EventArgs e)
        {
            int rows = -1;
            foreach (ListViewItem aItem in list.SelectedItems)
            {
                rows = aItem.Index;
            }

            int jour = convertJourToInt(list.SelectedItems[0].SubItems[0].Text);
            int heure = Convert.ToInt32(list.SelectedItems[0].SubItems[1].Text.Replace(":", ""));
            int temperature = Convert.ToInt32(list.SelectedItems[0].SubItems[2].Text);
            int piece = tabControlPieces.SelectedIndex + 4;
            maMaison.ListePieces[tabControlPieces.SelectedIndex].SupprimerConsigne(rows);
            maMaison.ListePieces[tabControlPieces.SelectedIndex].TrierListeConsignes();
            AfficherConsignes();

            if (statusBDD == true)
            {
                try
                {
                    String maRequete;
                    maRequete = "DELETE FROM domotique.dbo.Consigne where jour = '" + jour + "'and heure = '" + heure + "'and temperature = '" + temperature + "'and FK_Piece = '" + piece + "'";
                    SqlCommand myCommand = new SqlCommand(maRequete, con);
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }
            }
        }

        private void listViewSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            list = (ListView)sender;
            int rows = -1;
            foreach (ListViewItem aItem in list.SelectedItems)
            {
                rows = aItem.Index;
            }
            if (rows == -1)
            {
                buttonSupprimerConsigne.Enabled = false;
            }
            else
            {
                buttonSupprimerConsigne.Enabled = true;
            }
        }

        private void tabPageConsignes_Enter(object sender, EventArgs e)
        {
            buttonSupprimerConsigne.Enabled = false;
            AfficherConsignes();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            maMaison.TemperatureExt = maMaison.TemperatureExt + 1;
        }

        private void buttonMoins_Click(object sender, EventArgs e)
        {
            maMaison.TemperatureExt = maMaison.TemperatureExt - 1;
        }

        private void labelHeure_Click(object sender, EventArgs e)
        {
            Debug.Print(maMaison.ListePieces[0].ListeParois[2].OuvertureExtOuverte().ToString());
        }

        private void radioButtonVirtuel_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonReel.Checked)
            {
                statusStrip1.Items[0].Text = "Mode Réel";
                maMaison.Virtuel = false;
                foreach (TPiece piece in maMaison.ListePieces)
                {
                    foreach (TParoi paroi in piece.ListeParois)
                    {
                        foreach (TOuverture ov in paroi.ListeOuvertures)
                        {
                            ov.Modifiable = false;
                        }
                    }
                }
            }
            else
            {
                statusStrip1.Items[0].Text = "Mode Virtuel";
                maMaison.Virtuel = true;
                foreach (TPiece piece in maMaison.ListePieces)
                {
                    foreach (TParoi paroi in piece.ListeParois)
                    {
                        foreach (TOuverture ov in paroi.ListeOuvertures)
                        {
                            ov.Modifiable = true;
                        }
                    }
                }
            }

        }

    }
}
