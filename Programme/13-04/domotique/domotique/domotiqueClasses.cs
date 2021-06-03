using System;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;

namespace domotique
{


    public class TConsigne : System.Object
    {
        public TConsigne(int AHeure, int AJour, int ATemperature)
        {
            heure = AHeure;
            jour = AJour;
            temperature = ATemperature;
        }

        public TConsigne(int AHeure, String AJour, int ATemperature)
        {
            heure = AHeure;
            jour = convertJourToInt(AJour);
            temperature = ATemperature;
        }

        public int convertJourToInt(String jour)
        {
            switch (jour)
            {
                case "Lundi":
                    return 1;
                case "Mardi":
                    return 2;
                case "Mercredi:":
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
        }

        public String convertIntToJour(int jour)
        {
            switch (jour)
            {
                case 1:
                    return "Lundi";
                case 2:
                    return "Mardi";
                case 3:
                    return "Mercredi";
                case 4:
                    return "Jeudi";
                case 5:
                    return "Vendredi";
                case 6:
                    return "Samedi";
                case 7:
                    return "Dimanche";
            }
            return "";
        }



        public int Heure
        {
            get
            {
                return heure;
            }
            set
            {
                if (heure != value)
                {
                    heure = value;
                }
            }
        }
        private int heure;

        public int Jour
        {
            get
            {
                return jour;
            }
            set
            {
                if (jour != value)
                {
                    jour = value;
                }
            }
        }
        private int jour;

        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (temperature != value)
                {
                    temperature = value;
                }
            }
        }
        private int temperature;
    }

    public class TListeConsignes : System.Object
    {
        public TListeConsignes()
        {
        }
        private List<TConsigne> fConsignes = new List<TConsigne>();

        public void AjouterElement(TConsigne aItem)
        {
            //  Classe permettant d'ajouter un objet de type TConsigne à la liste
            // Ne pas oublier de mettre using System.Collections; en haut du programme
            fConsignes.Add(aItem);  // ajoute l'objet à la liste
        }

        public double CalculDeQuelqueChose()
        {
            // exemple de parcours avec foreach - par exemple pour additionner le poids de tous les éléments
            double resultat = 0;
            foreach (TConsigne aItem in fConsignes)
            {
                // resultat +=aItem.Poids / 1000.0;  exemple
            }
            return resultat;
        }

        public int NbConsignes
        {
            get
            {
                return fConsignes.Count;   // NbConsignes donne le nombre de "TConsigne" de la classe TListeConsignes;
            }
        }

        public TConsigne this[int Index]
        {
            get
            {
                return fConsignes[Index] as TConsigne; // permet de lire/écrire l'élément TConsigne[0], TConsigne[1] ....
            }
            set
            {
                fConsignes[Index] = value;
            }
        }
    }

    public class TListeOuvertures : System.Object
    {
        public TListeOuvertures()
        {
        }

        private ArrayList fOuvertures = new ArrayList();
        //private List<TOuverture> fOuvertures = new List<TOuverture>();

        public void AjouterElement(TOuverture aItem)
        {
            //  Classe permettant d'ajouter un objet de type TOuverture à la liste
            // Ne pas oublier de mettre using System.Collections; en haut du programme
            fOuvertures.Add(aItem);  // ajoute l'objet à la liste
        }

        public int TrouverOuverture(String nomOuverture)
        {
            // exemple de parcours avec foreach - par exemple pour additionner le poids de tous les éléments
            //double resultat = 0;
            foreach (TOuverture aItem in fOuvertures)
            {
                // resultat +=aItem.Poids / 1000.0;  exemple
                if (string.Compare(aItem.Label.Name, nomOuverture) == 0)
                {
                    return fOuvertures.IndexOf(aItem);
                }
            }
            return -1;
        }

        public int NbOuvertures
        {
            get
            {
                return fOuvertures.Count;   // NbOuvertures donne le nombre de "TOuverture" de la classe TListeOuvertures;
            }
        }

        public TOuverture this[int Index]
        {
            get
            {
                return fOuvertures[Index] as TOuverture; // permet de lire/écrire l'élément TOuverture[0], TOuverture[1] ....
            }
        }
    }

    public class TListeParois : System.Object
    {
        public TListeParois()
        {
        }
        private ArrayList fParois = new ArrayList();

        public void AjouterElement(TParoi aItem)
        {
            //  Classe permettant d'ajouter un objet de type TParoi à la liste
            // Ne pas oublier de mettre using System.Collections; en haut du programme
            fParois.Add(aItem);  // ajoute l'objet à la liste
        }

        public int TrouverParoi(String nomOuverture)
        {
            // exemple de parcours avec foreach - par exemple pour additionner le poids de tous les éléments
            //double resultat = 0;
            foreach (TParoi aItem in fParois)
            {
                if (aItem.ListeOuvertures.TrouverOuverture(nomOuverture) != -1)
                {
                    return fParois.IndexOf(aItem);
                }
                // resultat +=aItem.Poids / 1000.0;  exemple
            }
            return -1;
            
        }

        public int NbParois
        {
            get
            {
                return fParois.Count;   // NbParois donne le nombre de "TParoi" de la classe TListeParois;
            }
        }

        public TParoi this[int Index]
        {
            get
            {
                return fParois[Index] as TParoi; // permet de lire/écrire l'élément TParoi[0], TParoi[1] ....
            }
        }
    }

    public class TListePieces : System.Object
    {
        public TListePieces()
        {
        }
        private ArrayList fPieces = new ArrayList();

        public void AjouterElement(TPiece aItem)
        {
            //  Classe permettant d'ajouter un objet de type Tpiece à la liste
            // Ne pas oublier de mettre using System.Collections; en haut du programme
            fPieces.Add(aItem);  // ajoute l'objet à la liste
        }

        public int TrouverPiece(String nomOuverture)
        {
            // exemple de parcours avec foreach - par exemple pour additionner le poids de tous les éléments
            //double resultat = 0;
            foreach (TPiece aItem in fPieces)
            {
                // resultat +=aItem.Poids / 1000.0;  exemple
                if (aItem.ListeParois.TrouverParoi(nomOuverture) != -1)
                {
                    return fPieces.IndexOf(aItem);
                }
            }
            return -1 ;
        }

        public int NbPieces
        {
            get
            {
                return fPieces.Count;   // NbPieces donne le nombre de "Tpiece" de la classe TListePieces;
            }
        }

        public TPiece this[int Index]
        {
            get
            {
                return fPieces[Index] as TPiece; // permet de lire/écrire l'élément Tpiece[0], Tpiece[1] ....
            }
        }
    }

    public class TMaison : System.Object
    {
        public TMaison(Form1 AlaForme, bool ALampe, int ATemperatureExt)
        {
            lampe = ALampe;
            temperatureExt = ATemperatureExt;
            laForme = AlaForme;
        }
        private TListePieces fListePieces = new TListePieces();

        public void AjouterPiece(TPiece aItem)
        {
            fListePieces.AjouterElement(aItem);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
        }

        public string ListeDeQuelqueChose()
        {
            // exemple de parcours de la liste liée - par exemple pour créer un catalogue
            string resultat = "Liste";
            //  for(int i=0;i<fListePieces.NbEnfants;i++)
            //  {
            //     resultat += fListePieces[i].ToString(); // exemple si ToString() existe dans la classe liste
            //  }
            return resultat;
        }

        public void gerer()
        {
        }

        public bool Lampe
        {
            get
            {
                return lampe;
            }
            set
            {
                if (lampe != value)
                {
                    lampe = value;
                    if (value == true)
                    {
                        laForme.pictureBoxLampe.Image = Properties.Resources.lampeON;
                    }
                    else
                    {
                        laForme.pictureBoxLampe.Image = Properties.Resources.lampeOFF;
                    }
                }
            }
        }
        private bool lampe;

        public TListePieces ListePieces
        {
            get
            {
                return fListePieces;   //
            }
        }

        public int TemperatureExt
        {
            get
            {
                return temperatureExt;
            }
            set
            {
                if (temperatureExt != value)
                {
                    temperatureExt = value;
                }
            }
        }
        private int temperatureExt;

        public Form1 LaForme
        {
            get
            {
                return laForme;
            }
        }
        private Form1 laForme;


    }

    public class TOuverture : System.Object
    {
        public TOuverture(ref Label aLabel, int ACoefficientThermo, int ASurface, SqlConnection ACon, Label ALalbelHeure, Label ALabelDate)
        {
            coefficientThermo = ACoefficientThermo;
            surface = ASurface;
            label = aLabel;
            con = ACon;
            labelHeure = ALalbelHeure;
            labelDate = ALabelDate;
        }

        /*public int calculThermo() {
        }*/

        public Label Label
        {
            get
            {
                return label;
            }
            //set
            //{
            //    if (nom != value)
            //    {
            //        nom = value;
            //    }
            //}
        }
        private Label label;

        public Label LabelHeure
        {
            get
            {
                return labelHeure;
            }
            //set
            //{
            //    if (nom != value)
            //    {
            //        nom = value;
            //    }
            //}
        }
        private Label labelHeure;

        public Label LabelDate
        {
            get
            {
                return labelDate;
            }
            //set
            //{
            //    if (nom != value)
            //    {
            //        nom = value;
            //    }
            //}
        }
        private Label labelDate;


        public SqlConnection Con
        {
            get
            {
                return con;
            }
            //set
            //{
            //    if (nom != value)
            //    {
            //        nom = value;
            //    }
            //}
        }
        private SqlConnection con;


        public int CoefficientThermo
        {
            get
            {
                return coefficientThermo;
            }
            set
            {
                if (coefficientThermo != value)
                {
                    coefficientThermo = value;
                }
            }
        }
        private int coefficientThermo;

        public bool Ouvert
        {
            get
            {
                return ouvert;
            }
            set
            {
                if (ouvert != value)
                {
                    ouvert = value;
                    DateTime date;
                    String dt, dt2;
                    int etat;
                    SqlDataReader DataReader;
                    date = Convert.ToDateTime(labelHeure.Text);
                    dt = String.Format("{0:HH:mm:ss}", date);
                    date = Convert.ToDateTime(labelDate.Text);
                    dt2 = String.Format("{0:d/MM/yyyy}", date);
                    date = Convert.ToDateTime(dt2 + " " + dt);
                    String maRequete;
                    
                    if (value == true)
                    {
                        label.BackColor = Color.LightGreen;
                        etat = 1;
                    }
                    else
                    {
                        label.BackColor = Color.Red;
                        etat = 0;
                    }

                    
                    try
                    {
                        maRequete = "SELECT PK_Ouverture FROM domotique.dbo.Ouverture where nom = '" + Label.Text + "'";
                        SqlCommand myCommand = new SqlCommand(maRequete, con);
                        DataReader = myCommand.ExecuteReader();
                        DataReader.Read();
                        int id = DataReader.GetInt32(0);
                        DataReader.Close();

                        maRequete = "INSERT INTO domotique.dbo.LogPiece VALUES ('" + date + "', '" + etat + "', '" + id + "')";
                        myCommand = new SqlCommand(maRequete, con);
                        myCommand.ExecuteNonQuery();
                    }
                    catch (Exception Ex)
                    {
                        Debug.Print(Ex.Message.ToString());
                    }

                    
                    /*maRequete = "INSERT INTO domotique.dbo.Ouverture VALUES ('test')";
                    SqlCommand myCommand = new SqlCommand(maRequete, Con);
                    myCommand.ExecuteNonQuery();*/
                        
                }
            }
        }
        private bool ouvert;

        public int Surface
        {
            get
            {
                return surface;
            }
            set
            {
                if (surface != value)
                {
                    surface = value;
                }
            }
        }
        private int surface;
    }

    public class TParoi : System.Object
    {
        public TParoi(TPiece APiece1, int ACoefficientThermo, TPiece APiece2, int ASurfaceTotal)
        {
            piece1 = APiece1;
            coefficientThermo = ACoefficientThermo;
            piece2 = APiece2;
            surfaceTotal = ASurfaceTotal;
        }
        private TListeOuvertures fListeOuvertures = new TListeOuvertures();

        public void AjouterOuverture(TOuverture aItem)
        {
            fListeOuvertures.AjouterElement(aItem);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
        }

        public string ListeDeQuelqueChose()
        {
            // exemple de parcours de la liste liée - par exemple pour créer un catalogue
            string resultat = "Liste";
            //  for(int i=0;i<fListeOuvertures .NbEnfants;i++)
            //  {
            //     resultat += fListeOuvertures [i].ToString(); // exemple si ToString() existe dans la classe liste
            //  }
            return resultat;
        }

        /*public int calculSurfaceReel() {
        }

        public int calculThermo() {
        }*/

        public int CoefficientThermo
        {
            get
            {
                return coefficientThermo;
            }
            set
            {
                if (coefficientThermo != value)
                {
                    coefficientThermo = value;
                }
            }
        }
        private int coefficientThermo;

        public TListeOuvertures ListeOuvertures
        {
            get
            {
                return fListeOuvertures;   //
            }
        }

        public TPiece Piece1
        {
            get
            {
                return piece1;
            }
            set
            {
                if (piece1 != value)
                {
                    piece1 = value;
                }
            }
        }
        private TPiece piece1;

        public TPiece Piece2
        {
            get
            {
                return piece2;
            }
            set
            {
                if (piece2 != value)
                {
                    piece2 = value;
                }
            }
        }
        private TPiece piece2;

        public int SurfaceReel
        {
            get
            {
                return surfaceReel;
            }
            set
            {
                if (surfaceReel != value)
                {
                    surfaceReel = value;
                }
            }
        }
        private int surfaceReel;

        public int SurfaceTotal
        {
            get
            {
                return surfaceTotal;
            }
            set
            {
                if (surfaceTotal != value)
                {
                    surfaceTotal = value;
                }
            }
        }
        private int surfaceTotal;
    }

    public class TPiece : System.Object
    {
        public TPiece(string ANom, bool ARadiateur, int ATemperature)
        {
            nom = ANom;
            radiateur = ARadiateur;
            temperature = ATemperature;
        }
        private TListeConsignes fListeConsignes = new TListeConsignes();
        private TListeParois fListeParois = new TListeParois();

        public void AjouterConsigne(TConsigne aItem)
        {
            fListeConsignes.AjouterElement(aItem);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
        }

        public void AjouterParoi(TParoi aItem)
        {
            fListeParois.AjouterElement(aItem);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
        }

        public void TrierListeConsignes()
        {
            List<TConsigne> listeConsignes = new List<TConsigne>();
            int i;
            int j = 0;
            int ppt = 0;

            for (i = 0; i < fListeConsignes.NbConsignes; i++)
            {
                ppt = i;
                j = i + 1;
                while (j < fListeConsignes.NbConsignes)
                {
                    if (int.Parse(fListeConsignes[j].Jour.ToString() + fListeConsignes[j].Heure.ToString()) < int.Parse(fListeConsignes[ppt].Jour.ToString() + fListeConsignes[ppt].Heure.ToString()))
                    {

                        TConsigne test = fListeConsignes[ppt];
                        fListeConsignes[ppt] = fListeConsignes[j];
                        fListeConsignes[j] = test;
                    }
                    j++;

                }
                listeConsignes.Add(fListeConsignes[ppt]);
            }
        }

        public string ListeDeQuelqueChose1()
        {
            // exemple de parcours de la liste liée - par exemple pour créer un catalogue
            string resultat = "Liste";
            //  for(int i=0;i<fListeConsignes.NbEnfants;i++)
            //  {
            //     resultat += fListeConsignes[i].ToString(); // exemple si ToString() existe dans la classe liste
            //  }
            return resultat;
        }

        public string ListeDeQuelqueChose2()
        {
            // exemple de parcours de la liste liée - par exemple pour créer un catalogue
            string resultat = "Liste";
            //  for(int i=0;i<fListeParois.NbEnfants;i++)
            //  {
            //     resultat += fListeParois[i].ToString(); // exemple si ToString() existe dans la classe liste
            //  }
            return resultat;
        }

        /*public int calculTemperature() {
        }

        public int calculThermo() {
        }*/

        public void gerer()
        {
        }

        public TListeConsignes ListeConsignes
        {
            get
            {
                return fListeConsignes;   //
            }
        }

        public TListeParois ListeParois
        {
            get
            {
                return fListeParois;   //
            }
        }

        public TMaison Maison
        {
            get
            {
                return maison;
            }
            set
            {
                if (maison != value)
                {
                    maison = value;
                }
            }
        }
        private TMaison maison;

        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                if (nom != value)
                {
                    nom = value;
                }
            }
        }
        private string nom;

        public bool Radiateur
        {
            get
            {
                return radiateur;
            }
            set
            {
                if (radiateur != value)
                {
                    radiateur = value;
                }
            }
        }
        private bool radiateur;

        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (temperature != value)
                {
                    temperature = value;
                }
            }
        }
        private int temperature;
    }
}

