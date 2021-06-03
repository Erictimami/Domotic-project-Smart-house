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
            dataGridView.Rows.Add(24);
            dataGridView.Rows[0].Cells[0].Value = "test";
            dataGridView.Rows[0].Cells[1].Value = "test2";
            dataGridView.Rows[0].Cells[1].ReadOnly = true;
            
            dataGridView.Rows[1].Cells[1].Value = "test3";
            
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

    }
}
