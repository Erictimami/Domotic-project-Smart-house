using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace domotique
{
    public partial class Form1 : Form
    {
        TimeSpan interval;
        DateTime date;
        TMaison maMaison;

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
            labelHeure.Location = new Point(this.ClientSize.Width / 2 - labelHeure.Width/2, labelHeure.Location.Y);
            interval = new TimeSpan(1, 0, 0);
            panelMaison.Location = new Point(this.ClientSize.Width / 2 - panelMaison.Width / 2, panelMaison.Location.Y);
            splitContainer.SplitterWidth = 20;
            /*dataGridView.Rows.Add(24);
            dataGridView.Rows[0].Cells[0].Value = "test";
            dataGridView.Rows[0].Cells[1].Value = "test2";
            dataGridView.Rows[0].Cells[1].ReadOnly = true;           
            dataGridView.Rows[1].Cells[1].Value = "test3";*/
            initialiserMaison();
           
        }


        private void initialiserMaison()
        {
            maMaison = new TMaison(false, 10);
            TPiece monSalon = new TPiece("Salon", false, 20);
            TPiece maChambre = new TPiece("Chambre", false, 20);
            TPiece maCuisine = new TPiece("Cuisine", false, 20);
            maMaison.AjouterPiece(monSalon);
            maMaison.AjouterPiece(maChambre);
            maMaison.AjouterPiece(maCuisine);            
        }

        private void timerHeure_Tick(object sender, EventArgs e)
        {
            String dt2;
            int intervalle = trackBar.Value;
            if (intervalle != 1)
            {
                intervalle = (intervalle - 1)*5*60;
            }
            date = date.AddSeconds(intervalle);
            dt2 = String.Format("{0:HH:mm:ss}", date);
            labelHeure.Text = dt2;
            dt2 = String.Format("{0:d/MM/yyyy}", date);
            labelDate.Text = dt2;

        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
           /* int intervalle;
            intervalle = trackBar.Value;
            if (intervalle == 1)
            {
                labelTrackbar.Text = "1 seconde";
            }else
            {
                labelTrackbar.Text = intervalle / 60
            }*/
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
           // Debug.Print(maMaison.ListePieces[tabControlPieces.SelectedIndex].Nom);
            //Debug.Print(comboBoxHeure.SelectedItem.ToString()); 
            date = Convert.ToDateTime(comboBoxHeure.SelectedItem.ToString());
            dt = String.Format("{0:HHmmss}", date);
            //Debug.Print(dt);
            //Debug.Print(convertJourToInt(comboBoxJour.SelectedItem.ToString()).ToString());
           // Debug.Print(comboBoxTemperature.SelectedItem.ToString());
            TConsigne maConsigne = new TConsigne(Convert.ToInt32(dt), comboBoxJour.SelectedItem.ToString(), Convert.ToInt32(comboBoxTemperature.SelectedItem.ToString()));
            maMaison.ListePieces[tabControlPieces.SelectedIndex].AjouterConsigne(maConsigne);
            //Debug.Print(maMaison.ListePieces[tabControlPieces.SelectedIndex].ListeConsignes[0].Heure.ToStri)ng());
            maMaison.ListePieces[tabControlPieces.SelectedIndex].TrierListeConsignes(); 
            Debug.Print(tabControlPieces.Controls[tabControlPieces.SelectedIndex].Controls[0].Name.ToString());
            /*ListViewItem it = new ListViewItem();
            it.SubItems[0].Text = "loi";
            it.SubItems.Add("test");
            it.SubItems.Add("test2");
            listViewSalon.Items.Add(it); */
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

  


       /* public int convertJourToInt(String jour)
        {
            switch (jour)
            {
                case "Lundi":
                    return 1;
                case "Mardi":
                    return 2;
                case "Mercredi":
                    return 3;
                case "Jeudi":
                    return 4;
                case "Vendredi":
                    return 5;
                case "Samedi":
                    return 6;
                case "Dimanche":
                    return 7;
            }
            return 0;
        }*/

    }
}
