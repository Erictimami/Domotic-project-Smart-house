namespace domotique
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.labelTrackbar1s = new System.Windows.Forms.Label();
            this.panelMaison = new System.Windows.Forms.Panel();
            this.labelFenetreSalon2 = new System.Windows.Forms.Label();
            this.labelPorteSalon = new System.Windows.Forms.Label();
            this.labelFenetreSalon = new System.Windows.Forms.Label();
            this.labelPorteChambre = new System.Windows.Forms.Label();
            this.labelPorteCuisine = new System.Windows.Forms.Label();
            this.labelFenetreChambre = new System.Windows.Forms.Label();
            this.labelFenetreCuisine = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelSalon = new System.Windows.Forms.Panel();
            this.labelTrackbar1h = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelHeure = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Lundi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mardi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerHeure = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.panelMaison.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(985, 667);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.trackBar);
            this.tabPage1.Controls.Add(this.labelTrackbar1s);
            this.tabPage1.Controls.Add(this.panelMaison);
            this.tabPage1.Controls.Add(this.labelTrackbar1h);
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.labelDate);
            this.tabPage1.Controls.Add(this.labelHeure);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(977, 641);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vue Principale";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(85, 481);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 132);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // trackBar
            // 
            this.trackBar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.trackBar.AutoSize = false;
            this.trackBar.BackColor = System.Drawing.Color.White;
            this.trackBar.LargeChange = 1;
            this.trackBar.Location = new System.Drawing.Point(548, 16);
            this.trackBar.Maximum = 13;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(322, 30);
            this.trackBar.TabIndex = 4;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar.Value = 1;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // labelTrackbar1s
            // 
            this.labelTrackbar1s.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTrackbar1s.AutoSize = true;
            this.labelTrackbar1s.BackColor = System.Drawing.SystemColors.Control;
            this.labelTrackbar1s.Location = new System.Drawing.Point(552, 49);
            this.labelTrackbar1s.Name = "labelTrackbar1s";
            this.labelTrackbar1s.Size = new System.Drawing.Size(20, 13);
            this.labelTrackbar1s.TabIndex = 5;
            this.labelTrackbar1s.Text = "1S";
            // 
            // panelMaison
            // 
            this.panelMaison.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMaison.BackColor = System.Drawing.Color.Gray;
            this.panelMaison.Controls.Add(this.labelFenetreSalon2);
            this.panelMaison.Controls.Add(this.labelPorteSalon);
            this.panelMaison.Controls.Add(this.labelFenetreSalon);
            this.panelMaison.Controls.Add(this.labelPorteChambre);
            this.panelMaison.Controls.Add(this.labelPorteCuisine);
            this.panelMaison.Controls.Add(this.labelFenetreChambre);
            this.panelMaison.Controls.Add(this.labelFenetreCuisine);
            this.panelMaison.Controls.Add(this.splitContainer);
            this.panelMaison.Controls.Add(this.panelSalon);
            this.panelMaison.Location = new System.Drawing.Point(137, 87);
            this.panelMaison.Name = "panelMaison";
            this.panelMaison.Size = new System.Drawing.Size(669, 375);
            this.panelMaison.TabIndex = 8;
            this.panelMaison.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMaison_Paint);
            // 
            // labelFenetreSalon2
            // 
            this.labelFenetreSalon2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelFenetreSalon2.BackColor = System.Drawing.Color.Red;
            this.labelFenetreSalon2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFenetreSalon2.ForeColor = System.Drawing.Color.Black;
            this.labelFenetreSalon2.Location = new System.Drawing.Point(467, 352);
            this.labelFenetreSalon2.Name = "labelFenetreSalon2";
            this.labelFenetreSalon2.Size = new System.Drawing.Size(117, 23);
            this.labelFenetreSalon2.TabIndex = 9;
            this.labelFenetreSalon2.Text = "Fenetre Salon";
            this.labelFenetreSalon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPorteSalon
            // 
            this.labelPorteSalon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelPorteSalon.BackColor = System.Drawing.Color.Red;
            this.labelPorteSalon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPorteSalon.ForeColor = System.Drawing.Color.Black;
            this.labelPorteSalon.Location = new System.Drawing.Point(266, 352);
            this.labelPorteSalon.Name = "labelPorteSalon";
            this.labelPorteSalon.Size = new System.Drawing.Size(117, 23);
            this.labelPorteSalon.TabIndex = 8;
            this.labelPorteSalon.Text = "Porte Entrée";
            this.labelPorteSalon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFenetreSalon
            // 
            this.labelFenetreSalon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelFenetreSalon.BackColor = System.Drawing.Color.Red;
            this.labelFenetreSalon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFenetreSalon.ForeColor = System.Drawing.Color.Black;
            this.labelFenetreSalon.Location = new System.Drawing.Point(58, 352);
            this.labelFenetreSalon.Name = "labelFenetreSalon";
            this.labelFenetreSalon.Size = new System.Drawing.Size(117, 23);
            this.labelFenetreSalon.TabIndex = 7;
            this.labelFenetreSalon.Text = "Fenetre Salon";
            this.labelFenetreSalon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPorteChambre
            // 
            this.labelPorteChambre.BackColor = System.Drawing.Color.Red;
            this.labelPorteChambre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPorteChambre.ForeColor = System.Drawing.Color.Black;
            this.labelPorteChambre.Location = new System.Drawing.Point(403, 186);
            this.labelPorteChambre.Name = "labelPorteChambre";
            this.labelPorteChambre.Size = new System.Drawing.Size(117, 19);
            this.labelPorteChambre.TabIndex = 6;
            this.labelPorteChambre.Text = "Porte Chambre";
            this.labelPorteChambre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPorteCuisine
            // 
            this.labelPorteCuisine.BackColor = System.Drawing.Color.Red;
            this.labelPorteCuisine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPorteCuisine.ForeColor = System.Drawing.Color.Black;
            this.labelPorteCuisine.Location = new System.Drawing.Point(71, 186);
            this.labelPorteCuisine.Name = "labelPorteCuisine";
            this.labelPorteCuisine.Size = new System.Drawing.Size(117, 19);
            this.labelPorteCuisine.TabIndex = 5;
            this.labelPorteCuisine.Text = "Porte Cuisine";
            this.labelPorteCuisine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFenetreChambre
            // 
            this.labelFenetreChambre.BackColor = System.Drawing.Color.Red;
            this.labelFenetreChambre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFenetreChambre.ForeColor = System.Drawing.Color.Black;
            this.labelFenetreChambre.Location = new System.Drawing.Point(403, 0);
            this.labelFenetreChambre.Name = "labelFenetreChambre";
            this.labelFenetreChambre.Size = new System.Drawing.Size(117, 23);
            this.labelFenetreChambre.TabIndex = 5;
            this.labelFenetreChambre.Text = "Fenetre Chambre";
            this.labelFenetreChambre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFenetreCuisine
            // 
            this.labelFenetreCuisine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelFenetreCuisine.BackColor = System.Drawing.Color.Red;
            this.labelFenetreCuisine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFenetreCuisine.ForeColor = System.Drawing.Color.Black;
            this.labelFenetreCuisine.Location = new System.Drawing.Point(71, 0);
            this.labelFenetreCuisine.Name = "labelFenetreCuisine";
            this.labelFenetreCuisine.Size = new System.Drawing.Size(117, 23);
            this.labelFenetreCuisine.TabIndex = 4;
            this.labelFenetreCuisine.Text = "Fenetre Cuisine";
            this.labelFenetreCuisine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(19, 23);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.PowderBlue;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.Khaki;
            this.splitContainer.Size = new System.Drawing.Size(625, 163);
            this.splitContainer.SplitterDistance = 270;
            this.splitContainer.SplitterWidth = 20;
            this.splitContainer.TabIndex = 3;
            // 
            // panelSalon
            // 
            this.panelSalon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSalon.BackColor = System.Drawing.Color.PeachPuff;
            this.panelSalon.Location = new System.Drawing.Point(19, 205);
            this.panelSalon.Name = "panelSalon";
            this.panelSalon.Size = new System.Drawing.Size(625, 147);
            this.panelSalon.TabIndex = 2;
            // 
            // labelTrackbar1h
            // 
            this.labelTrackbar1h.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTrackbar1h.AutoSize = true;
            this.labelTrackbar1h.BackColor = System.Drawing.SystemColors.Control;
            this.labelTrackbar1h.Location = new System.Drawing.Point(844, 49);
            this.labelTrackbar1h.Name = "labelTrackbar1h";
            this.labelTrackbar1h.Size = new System.Drawing.Size(21, 13);
            this.labelTrackbar1h.TabIndex = 6;
            this.labelTrackbar1h.Text = "1H";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(3, 616);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(971, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(98, 17);
            this.toolStripStatusLabel.Text = "Mode Simulation";
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(901, 7);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(60, 15);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "labelDate";
            // 
            // labelHeure
            // 
            this.labelHeure.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelHeure.AutoSize = true;
            this.labelHeure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeure.Location = new System.Drawing.Point(440, 16);
            this.labelHeure.Name = "labelHeure";
            this.labelHeure.Size = new System.Drawing.Size(87, 17);
            this.labelHeure.TabIndex = 1;
            this.labelHeure.Text = "labelHeure";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(977, 641);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consignes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lundi,
            this.Mardi});
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(977, 550);
            this.dataGridView.TabIndex = 2;
            // 
            // Lundi
            // 
            this.Lundi.HeaderText = "Lundi";
            this.Lundi.Name = "Lundi";
            // 
            // Mardi
            // 
            this.Mardi.HeaderText = "Mardi";
            this.Mardi.Name = "Mardi";
            // 
            // timerHeure
            // 
            this.timerHeure.Interval = 1000;
            this.timerHeure.Tick += new System.EventHandler(this.timerHeure_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 667);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Controle maison";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.panelMaison.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelHeure;
        private System.Windows.Forms.Timer timerHeure;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label labelTrackbar1s;
        private System.Windows.Forms.Label labelTrackbar1h;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Panel panelMaison;
        private System.Windows.Forms.Panel panelSalon;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label labelFenetreCuisine;
        private System.Windows.Forms.Label labelFenetreChambre;
        private System.Windows.Forms.Label labelPorteCuisine;
        private System.Windows.Forms.Label labelPorteChambre;
        private System.Windows.Forms.Label labelFenetreSalon;
        private System.Windows.Forms.Label labelPorteSalon;
        private System.Windows.Forms.Label labelFenetreSalon2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lundi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mardi;
    }
}

