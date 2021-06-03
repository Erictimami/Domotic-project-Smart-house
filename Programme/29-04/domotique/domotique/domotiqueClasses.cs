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

        public void SupprimerElement(int index)
        {
            //  Classe permettant d'ajouter un objet de type TConsigne à la liste
            // Ne pas oublier de mettre using System.Collections; en haut du programme
            fConsignes.RemoveAt(index);  // ajoute l'objet à la liste
            //fConsignes.Remove(cons);
        }

        public void SupprimerElement2(TConsigne cons)
        {
            //  Classe permettant d'ajouter un objet de type TConsigne à la liste
            // Ne pas oublier de mettre using System.Collections; en haut du programme
            fConsignes.Remove(cons);  // ajoute l'objet à la liste
            //fConsignes.Remove(cons);
        }


        public IEnumerator GetEnumerator()
        {
            return fConsignes.GetEnumerator();
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

    public class TListeOuvertures : IEnumerable
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

        public IEnumerator GetEnumerator()
        {
            return fOuvertures.GetEnumerator();
        }
    }

    public class TListeParois : IEnumerable
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

        public IEnumerator GetEnumerator()
        {
            return fParois.GetEnumerator();
        }
    }

    public class TListePieces : IEnumerable
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
            return -1;
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

        public IEnumerator GetEnumerator()
        {
            return fPieces.GetEnumerator();
        }
    }

    public class TMaison : System.Object
    {
        public const int hauteur = 3;

        public TMaison(Form1 AlaForme, bool ALampe, int ATemperatureExt, ref TextBox ATexboxTExt)
        {
            lampe = ALampe;
            temperatureExt = ATemperatureExt;
            laForme = AlaForme;
            textBoxTExt = ATexboxTExt;
            textBoxTExt.Text = ATemperatureExt.ToString();

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

            foreach (TPiece piece in this.ListePieces)
            {
                if (piece.OuvertureExtOuverte())
                {
                    piece.Radiateur = false;
                    piece.Temperature = this.temperatureExt;
                }
                else
                {
                    if ((piece.OuvertureCommuneOuvert() != null))
                    {

                        if (piece.OuvertureExtPieceVoisine())
                        {
                            piece.Radiateur = false;
                        }
                        else
                        {
                            if (piece.Consigne > piece.Temperature)
                            {
                                piece.Radiateur = true;
                            }
                            else
                            {
                                piece.Radiateur = false;
                            }
                        }

                        Double temperature;
                        temperature = ((piece.OuvertureCommuneOuvert().Piece1.Temperature * piece.OuvertureCommuneOuvert().Piece1.Surface) + (piece.OuvertureCommuneOuvert().Piece2.Temperature * piece.OuvertureCommuneOuvert().Piece2.Surface)) / (piece.OuvertureCommuneOuvert().Piece1.Surface + piece.OuvertureCommuneOuvert().Piece2.Surface);
                        piece.OuvertureCommuneOuvert().Piece1.Temperature = temperature;
                        piece.OuvertureCommuneOuvert().Piece2.Temperature = temperature;

                    }


                    if (!piece.OuvertureExtPieceVoisine())
                    {
                        if (piece.Consigne > piece.Temperature)
                        {
                            piece.Radiateur = true;
                        }
                        else
                        {
                            piece.Radiateur = false;
                        }
                    }

                    /*else
                    {
                        if (piece.Consigne > piece.Temperature)
                        {
                            piece.Radiateur = true;
                        }
                        else
                        {
                            piece.Radiateur = false;
                        }
                    }*/


                    //Debug.Print(piece.Nom);
                    //}
                    //else
                    //{

                    //piece.Temperature = 40;
                    double apport = 0;
                    double apportT = 0;
                    foreach (TParoi paroi in piece.ListeParois)
                    {
                        if (paroi.Piece1 == piece)
                        {
                            if (paroi.Piece2 != null)
                            {
                                //Debug.Print(paroi.Piece2.Nom);
                                apport = apport + ((paroi.Piece2.Temperature - piece.Temperature) * paroi.SurfaceReel) / paroi.CoefficientThermo;
                                // Debug.Print(apport.ToString());
                                //Debug.Print("\n");
                            }
                            else
                            {
                                //Debug.Print("ext");
                                apport = apport + ((this.temperatureExt - piece.Temperature) * paroi.SurfaceReel) / paroi.CoefficientThermo;
                                //Debug.Print(apport.ToString());
                                //Debug.Print("\n");
                            }

                        }
                        else if (paroi.Piece1 != null)
                        {
                            //Debug.Print(paroi.Piece1.Nom);
                            apport = apport + ((paroi.Piece1.Temperature - piece.Temperature) * paroi.SurfaceReel) / paroi.CoefficientThermo;
                        }
                        else
                        {
                            //Debug.Print("ext");
                            apport = apport + ((this.temperatureExt - piece.Temperature) * paroi.SurfaceReel) / paroi.CoefficientThermo;
                        }

                        if (piece.Radiateur)
                        {
                            apport = apport + piece.CoefficientRadiateur;
                        }
                        //Debug.Print("apport" + piece.Nom + " = " + apport);
                        int masseAir = piece.Surface * hauteur;
                        //Debug.Print("masse: " + masseAir.ToString());
                        double temperatureKelvin = piece.Temperature + 273.15;
                        apportT = (apport / masseAir) / 1004;
                        //Debug.Print("apportT: " + apportT.ToString());
                        //piece.Temperature = Math.Round(piece.Temperature + apportT, 2);
                        piece.Temperature = piece.Temperature + apportT;
                    }

                }

            }


            /*foreach (TPiece piece in this.ListePieces)
            {
                foreach (TParoi paroi in piece.ListeParois)
                {
                    foreach (TOuverture ov in paroi.ListeOuvertures)
                    {
                        if (ov.Ouvert == true)
                        {
                            if (paroi.Piece1 == null)
                            {
                                //paroi.Piece2.Temperature = this.temperatureExt;
                                piece.Temperature = this.temperatureExt;
                                //break;
                            }
                            else if (paroi.Piece2 == null)
                            {
                                //paroi.Piece1.Temperature = this.temperatureExt;
                                piece.Temperature = this.temperatureExt;
                                //break;
                            }
                            else
                            {
                                int temperature;
                                temperature = Convert.ToInt32(((paroi.Piece1.Temperature * paroi.Piece1.Surface) + (paroi.Piece2.Temperature * paroi.Piece2.Surface)) / (paroi.Piece1.Surface + paroi.Piece2.Surface));
                                paroi.Piece1.Temperature = temperature;
                                paroi.Piece2.Temperature = temperature;
                                //break;
                            }
                        }
                        else
                        {

                        }
                       
                    }
                }
            }*/
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
                    textBoxTExt.Text = value.ToString();
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

        public TextBox TextBoxTExt
        {
            get
            {
                return textBoxTExt;
            }
        }
        private TextBox textBoxTExt;


    }

    public class TOuverture : System.Object
    {
        public TOuverture(ref Label aLabel, int ACoefficientThermo, int ASurface, SqlConnection ACon, Label ALalbelHeure, Label ALabelDate, ref Boolean AStatusBDD)
        {
            coefficientThermo = ACoefficientThermo;
            surface = ASurface;
            label = aLabel;
            con = ACon;
            labelHeure = ALalbelHeure;
            labelDate = ALabelDate;
            statusBDD = AStatusBDD;
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

        public Boolean StatusBDD
        {
            get
            {
                return statusBDD;
            }
            //set
            //{
            //    if (nom != value)
            //    {
            //        nom = value;
            //    }
            //}
        }
        private Boolean statusBDD;


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

                    if (StatusBDD == true)
                    {

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
            surfaceReel = surfaceTotal;

        }
        private TListeOuvertures fListeOuvertures = new TListeOuvertures();

        public void AjouterOuverture(TOuverture aItem)
        {
            fListeOuvertures.AjouterElement(aItem);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
        }

        public Boolean OuvertureExtOuverte()
        {
            foreach (TOuverture ov in this.ListeOuvertures)
            {
                if (ov.Ouvert == true)
                {
                    if (this.piece1 == null || this.piece2 == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean OuvertureCommuneOuverte()
        {
            foreach (TOuverture ov in this.ListeOuvertures)
            {
                if (ov.Ouvert == true)
                {
                    if (this.piece1 != null && this.piece2 != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void calculerSurfaceReel()
        {

            foreach (TOuverture ov in this.ListeOuvertures)
            {
                SurfaceReel = SurfaceReel - ov.Surface;
            }
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
        public TPiece(string ANom, bool ARadiateur, double ATemperature, int ASurface, int ACoefficientRadiateur, ref TextBox ATextBoxT, ref TextBox ATextBoxC, ref Button AButtonChauffage)
        {
            nom = ANom;
            radiateur = ARadiateur;
            temperature = ATemperature;
            textBoxC = ATextBoxC;
            textBoxT = ATextBoxT;
            surface = ASurface;
            textBoxT.Text = ATemperature.ToString();
            buttonChauffage = AButtonChauffage;
            coefficientRadiateur = ACoefficientRadiateur;
        }
        public TPiece()
        {
        }

        private TListeConsignes fListeConsignes = new TListeConsignes();
        private TListeParois fListeParois = new TListeParois();


        public Boolean OuvertureExtOuverte()
        {
            foreach (TParoi paroi in this.ListeParois)
            {
                if (paroi.OuvertureExtOuverte()) return true;
            }
            return false;
        }

        public TParoi OuvertureCommuneOuvert()
        {
            foreach (TParoi paroi in this.ListeParois)
            {
                if (paroi.OuvertureCommuneOuverte())
                {
                    return paroi;
                }
            }
            return null;
        }

        public void AjouterConsigne(TConsigne aItem)
        {
            fListeConsignes.AjouterElement(aItem);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
        }

        public void SupprimerConsigne(int index)
        {
            fListeConsignes.SupprimerElement(index);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
        }

        public void SupprimerConsigne2(TConsigne cons)
        {
            fListeConsignes.SupprimerElement2(cons);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
        }


        public Boolean OuvertureExtPieceVoisine()
        {
            TPiece pieceVoisine;
            foreach (TParoi paroi in this.fListeParois)
            {
                if (paroi.Piece1 == this)
                {
                    pieceVoisine = paroi.Piece2;
                }
                else
                {
                    pieceVoisine = paroi.Piece1;
                }

                if (pieceVoisine != null)
                {
                    if (pieceVoisine.OuvertureExtOuverte()) return true;
                }
            }
            return false;

        }


        public void AjouterParoi(TParoi aItem)
        {
            fListeParois.AjouterElement(aItem);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
        }

        /*public void TrierListeConsignes()
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
        }*/

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
                    int heurej = fListeConsignes[j].Heure;
                    int heureppt = fListeConsignes[ppt].Heure;


                    if (fListeConsignes[j].Jour <= fListeConsignes[ppt].Jour)
                    {
                            TConsigne test = fListeConsignes[ppt];
                            fListeConsignes[ppt] = fListeConsignes[j];
                            fListeConsignes[j] = test;

                    }
                    j++;
                }
            }

            for (i = 0; i < fListeConsignes.NbConsignes; i++)
            {
                ppt = i;
                j = i + 1;
                while (j < fListeConsignes.NbConsignes)
                {

                    if (fListeConsignes[j].Jour == fListeConsignes[ppt].Jour && fListeConsignes[j].Heure <= fListeConsignes[ppt].Heure)
                    {
                        TConsigne test = fListeConsignes[ppt];
                        fListeConsignes[ppt] = fListeConsignes[j];
                        fListeConsignes[j] = test;

                    }
                    j++;
                }
            }

        }

        /*public void TrierListeConsignes()
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
                    if (fListeConsignes[j].Jour <= fListeConsignes[ppt].Jour)
                    {
                        int heurej = fListeConsignes[j].Heure;
                        int heureppt = fListeConsignes[ppt].Heure;
                        Debug.Print(heurej.ToString());
                        Debug.Print(heureppt.ToString());

                        if (heurej > 120000)
                        {
                            heurej = heurej - 120000;
                        }

                        if (heureppt > 120000)
                        {
                            heureppt = heureppt - 120000;
                        }

                        if (heurej < heureppt)
                        {
                            TConsigne test = fListeConsignes[ppt];
                            fListeConsignes[ppt] = fListeConsignes[j];
                            fListeConsignes[j] = test;
                        }
                    }
                    j++;

                }
                listeConsignes.Add(fListeConsignes[ppt]);
            }
        }*/

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

        public TextBox TextBoxT
        {
            get
            {
                return textBoxT;
            }
            /*set
          {
              if (TextBoxT.Text = value)
              {
                  TextBoxT.Text = value;
              }
          }*/
        }
        private TextBox textBoxT;

        public Button ButtonChauffage
        {
            get
            {
                return buttonChauffage;
            }
            /*set
          {
              if (TextBoxT.Text = value)
              {
                  TextBoxT.Text = value;
              }
          }*/
        }
        private Button buttonChauffage;


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

        public int CoefficientRadiateur
        {
            get
            {
                return coefficientRadiateur;
            }
            set
            {
                if (coefficientRadiateur != value)
                {
                    coefficientRadiateur = value;
                }
            }
        }
        private int coefficientRadiateur;


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
                    if (value == true)
                    {
                        buttonChauffage.BackColor = Color.Green;
                        buttonChauffage.Text = "ON";
                    }
                    else
                    {
                        buttonChauffage.BackColor = Color.Red;
                        buttonChauffage.Text = "OFF";
                    }
                }
            }
        }
        private bool radiateur;

        public double Temperature
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
                    textBoxT.Text = value.ToString();
                }
            }
        }
        private double temperature;


        public TextBox TextBoxC
        {
            get
            {
                return textBoxC;
            }
            /*set
            {
                if (consigne != value)
                {
                    consigne = value;
                    consigne.Text = value.ToString();
                }
            }*/
        }
        private TextBox textBoxC;

        public int Consigne
        {
            get
            {
                return consigne;
            }
            set
            {
                if (consigne != value)
                {
                    consigne = value;
                    textBoxC.Text = value.ToString();
                }
            }
        }
        private int consigne;



    }
}

