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

namespace domotique
{
    public partial class Form1 : Form
    {
        public Boolean BDD;
        TimeSpan interval;
        DateTime date;
        TMaison maMaison;
        private SqlConnection con; //pour la connection
        private string strcon; //pour la chaine de connection
        public string req; //faire les requêtes
        public SqlDataReader rdr; //transités les données(traitement)

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
            timerHeure.Start();
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            labelHeure.Location = new Point(this.ClientSize.Width / 2 - labelHeure.Width / 2, labelHeure.Location.Y);
            interval = new TimeSpan(1, 0, 0);
            panelMaison.Location = new Point(this.ClientSize.Width / 2 - panelMaison.Width / 2, panelMaison.Location.Y);
            splitContainer.SplitterWidth = 20;
            
            //Debug.Print(maMaison.ListePieces[2].ListeParois[0].ListeOuvertures[0].Label.Text); 
            DateTime test;
            string date2 = labelDate.Text + " " + labelHeure.Text;
            test = Convert.ToDateTime(date2);
            Debug.Print(test.ToString());
            strcon = @"Data Source=TATCHI-PC\SQLEXPRESS;Initial Catalog=domotique;Integrated Security=True;Pooling=False";
            con = new SqlConnection(strcon);
            try
            {
                con.Open();
                Debug.Print("Connexion BDD OK!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            initialiserMaison(con);
           
            
        }


        private void initialiserMaison(SqlConnection con)
        {
            var me = this;
            maMaison = new TMaison(this, false, 10);
            
            TPiece monSalon = new TPiece("Salon", false, 20);
            TPiece maChambre = new TPiece("Chambre", false, 20);
            TPiece maCuisine = new TPiece("Cuisine", false, 20);

            TOuverture FCuisine = new TOuverture(ref labelFenetreCuisine, 20, 20, con, labelHeure, labelDate);
            TOuverture PCuisine = new TOuverture(ref labelPorteCuisine, 20, 20, con, labelHeure, labelDate);
            TOuverture FChambre = new TOuverture(ref labelFenetreChambre, 20, 20, con, labelHeure, labelDate);
            TOuverture PChambre = new TOuverture(ref labelPorteChambre, 20, 20, con, labelHeure, labelDate);
            TOuverture FSalon1 = new TOuverture(ref labelFenetreSalon, 20, 20, con, labelHeure, labelDate);
            TOuverture FSalon2 = new TOuverture(ref labelFenetreSalon2, 20, 20, con, labelHeure, labelDate);
            TOuverture PSalon = new TOuverture(ref labelPorteSalon, 20, 20, con, labelHeure, labelDate);

            TParoi ParoiFenetreCuisine = new TParoi(maCuisine, 20, null, 20);
            TParoi ParoiFenetreChambre = new TParoi(maChambre, 20, null, 20);
            TParoi ParoiPorteCuisine = new TParoi(maCuisine, 20, monSalon, 20);
            TParoi ParoiPorteChambre = new TParoi(maChambre, 20, monSalon, 20);
            TParoi ParoiSalon = new TParoi(monSalon, 20, null, 20);
            TParoi ParoiCuisineGauche = new TParoi(maCuisine, 20, null, 20);
            TParoi ParoiSalonGauche = new TParoi(monSalon, 20, null, 20);
            TParoi ParoiMilieu = new TParoi(maCuisine, 20, maChambre, 20);
            TParoi ParoiChambreDroite = new TParoi(maChambre, 20, null, 20);
            TParoi ParoiSalonDroite = new TParoi(monSalon, 20, null, 20);

            
            ParoiFenetreCuisine.AjouterOuverture(FCuisine);
            ParoiFenetreChambre.AjouterOuverture(FChambre);
            ParoiPorteCuisine.AjouterOuverture(PCuisine);
            ParoiPorteChambre.AjouterOuverture(PChambre);
            ParoiSalon.AjouterOuverture(FSalon1);
            ParoiSalon.AjouterOuverture(PSalon);
            ParoiSalon.AjouterOuverture(FSalon2);

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

            maMaison.AjouterPiece(maCuisine);
            maMaison.AjouterPiece(maChambre);
            maMaison.AjouterPiece(monSalon);

            
            
        }

        private void timerHeure_Tick(object sender, EventArgs e)
        {
            String dt2;
            int intervalle = trackBar.Value;
            if (intervalle != 1)
            {
                intervalle = (intervalle - 1) * 5 * 60;
            }
            date = date.AddSeconds(intervalle);
            dt2 = String.Format("{0:HH:mm:ss}", date);
            labelHeure.Text = dt2;
            dt2 = String.Format("{0:d/MM/yyyy}", date);
            labelDate.Text = dt2;

        }

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

        private void buttonAjouterConsigne_Click(object sender, EventArgs e)
        {
            DateTime date;
            String dt;
            date = Convert.ToDateTime(comboBoxHeure.SelectedItem.ToString());
            dt = String.Format("{0:HHmmss}", date);
            TConsigne maConsigne = new TConsigne(Convert.ToInt32(dt), comboBoxJour.SelectedItem.ToString(), Convert.ToInt32(comboBoxTemperature.SelectedItem.ToString()));
            maMaison.ListePieces[tabControlPieces.SelectedIndex].AjouterConsigne(maConsigne);
            maMaison.ListePieces[tabControlPieces.SelectedIndex].TrierListeConsignes();
            AfficherConsignes();
            listViewSalon.FullRowSelect = true;

        }

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
                    heure2 = heure[0] + ":" + heure[1] + heure[2] + ":" + heure[3] + heure[4];

                }
                else
                {
                    heure2 = heure[0] + heure[1] + ":" + heure[2] + heure[3] + ":" + heure[4] + heure[5];
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
           // Debug.Print(send.Name.ToString());
            //Debug.Print(send.Text.ToString());
            int piece, paroi, ouverture;
            //ouverture = maMaison.ListePieces[2].ListeParois[0].ListeOuvertures.TrouverOuverture(send.Text.ToString());
            //paroi = maMaison.ListePieces[2].ListeParois.TrouverParoi(send.Text.ToString());
            piece = maMaison.ListePieces.TrouverPiece(send.Name.ToString());
            paroi = maMaison.ListePieces[piece].ListeParois.TrouverParoi(send.Name.ToString());
            ouverture = maMaison.ListePieces[piece].ListeParois[paroi].ListeOuvertures.TrouverOuverture(send.Name.ToString());

            //Debug.Print(piece.ToString());

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

        private void labelHeure_Click(object sender, EventArgs e)
        {
            DateTime date;
            String dt, dt2;
            date = Convert.ToDateTime(labelHeure.Text);
            dt = String.Format("{0:HH:mm:ss}", date);
            date = Convert.ToDateTime(labelDate.Text);
            dt2 = String.Format("{0:d/MM/yyyy}", date);
            date = Convert.ToDateTime(dt2 + " " + dt);
            
            String maRequete;
            maRequete = "INSERT INTO domotique.dbo.LogPiece VALUES ('" + date + "', 1, 1)";
            SqlCommand myCommand = new SqlCommand(maRequete, con);
            try
            {
                myCommand.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Debug.Print(Ex.Message.ToString());
            }
            
        }

        private void tabPageLogs_Enter(object sender, EventArgs e)
        {
            String maRequete;
            SqlDataReader DataReader;
            maRequete = "SELECT PK_LogPiece, date, etat, nom  from domotique.dbo.LogPiece INNER JOIN domotique.dbo.Ouverture ON FK_Ouverture = PK_Ouverture";
            SqlCommand myCommand = new SqlCommand(maRequete, con);
            DataReader = myCommand.ExecuteReader();
            DateTime date;
            String dt, heure, etat;
            int ouvert;
            dataGridViewLogPiece.Rows.Clear();

            while (DataReader.Read())
            {
                //Debug.Print(DataReader.GetValue(0).ToString());

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

                //Debug.Print("date: " + dt.ToString() + " heure: " + heure.ToString());
                dataGridViewLogPiece.Rows.Add(dt, heure, DataReader.GetValue(3).ToString(), etat);
            }
            DataReader.Close();
        }

    }
}
