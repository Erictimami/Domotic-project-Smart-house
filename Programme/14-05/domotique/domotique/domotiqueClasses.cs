using System;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using MccDaq;

namespace domotique
{
    /// <summary>
    /// Classe Consigne
    /// </summary>
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

        /// <summary>
        /// Permet de convertir un jour de la semaine en int
        /// </summary>
        /// <param name="jour"></param>
        /// <returns>integer correspondant au jour de la semaine</returns>
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

        /// <summary>
        /// Permet de convertir un int en string qui correspond au jour
        /// </summary>
        /// <param name="jour"></param>
        /// <returns>string correspondant au jour de la semaine</returns>
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

    /// <summary>
    /// Classe contenant la liste des consignes
    /// </summary>
    public class TListeConsignes : System.Object
    {
        public TListeConsignes()
        {
        }
        private List<TConsigne> fConsignes = new List<TConsigne>();

        /// <summary>
        /// Permet d'ajouter une consigne à la liste
        /// </summary>
        /// <param name="aItem"></param>
        public void AjouterElement(TConsigne aItem)
        {
            //  Classe permettant d'ajouter un objet de type TConsigne à la liste
            // Ne pas oublier de mettre using System.Collections; en haut du programme
            fConsignes.Add(aItem);  // ajoute l'objet à la liste
        }

        /// <summary>
        /// Permet de supprimer une consigne de la liste
        /// </summary>
        /// <param name="index">integer</param>
        public void SupprimerElement(int index)
        {
            //  Classe permettant d'ajouter un objet de type TConsigne à la liste
            // Ne pas oublier de mettre using System.Collections; en haut du programme
            fConsignes.RemoveAt(index);  // ajoute l'objet à la liste
            //fConsignes.Remove(cons);
        }

        /// <summary>
        /// Permet de supprimer une consigne de la liste
        /// </summary>
        /// <param name="cons">Objet TConsigne</param>
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

    /// <summary>
    /// Classe contenant la liste des ouvertures
    /// </summary>
    public class TListeOuvertures : IEnumerable
    {
        public TListeOuvertures()
        {
        }

        private ArrayList fOuvertures = new ArrayList();
        //private List<TOuverture> fOuvertures = new List<TOuverture>();

        /// <summary>
        /// Permet d'ajouter une ouverture à la liste
        /// </summary>
        /// <param name="aItem"></param>
        public void AjouterElement(TOuverture aItem)
        {
            //  Classe permettant d'ajouter un objet de type TOuverture à la liste
            // Ne pas oublier de mettre using System.Collections; en haut du programme
            fOuvertures.Add(aItem);  // ajoute l'objet à la liste
        }

        /// <summary>
        /// Permet de trouver une ouverture à partir de son nom
        /// </summary>
        /// <param name="nomOuverture"></param>
        /// <returns>Integer qui est l'index de l'ouverture dans la liste</returns>
        public int TrouverOuverture(String nomOuverture)
        {
            foreach (TOuverture aItem in fOuvertures)
            {
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

    /// <summary>
    /// Classe contenant la liste des parois
    /// </summary>
    public class TListeParois : IEnumerable
    {
        public TListeParois()
        {
        }
        private ArrayList fParois = new ArrayList();

        /// <summary>
        /// Permet d'ajouter une paroi à la liste
        /// </summary>
        /// <param name="aItem"></param>
        public void AjouterElement(TParoi aItem)
        {
            //  Classe permettant d'ajouter un objet de type TParoi à la liste
            // Ne pas oublier de mettre using System.Collections; en haut du programme
            fParois.Add(aItem);  // ajoute l'objet à la liste
        }

        /// <summary>
        /// Permet de trouver une Paroi en fonction de son nom
        /// </summary>
        /// <param name="nomOuverture"></param>
        /// <returns>Integer qui représente l'index de la paroi dans la liste</returns>
        public int TrouverParoi(String nomOuverture)
        {
            foreach (TParoi aItem in fParois)
            {
                if (aItem.ListeOuvertures.TrouverOuverture(nomOuverture) != -1)
                {
                    return fParois.IndexOf(aItem);
                }
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

    /// <summary>
    /// Classe contenant la liste des pièces
    /// </summary>
    public class TListePieces : IEnumerable
    {
        public TListePieces()
        {
        }
        private ArrayList fPieces = new ArrayList();

        /// <summary>
        /// Permet d'ajouter une pièce à la liste
        /// </summary>
        /// <param name="aItem"></param>
        public void AjouterElement(TPiece aItem)
        {
            //  Classe permettant d'ajouter un objet de type Tpiece à la liste
            // Ne pas oublier de mettre using System.Collections; en haut du programme
            fPieces.Add(aItem);  // ajoute l'objet à la liste
        }

        /// <summary>
        /// Permet de trouver une pièce en fonction de son nom
        /// </summary>
        /// <param name="nomOuverture"></param>
        /// <returns>Integer représentant l'index dans la liste</returns>
        public int TrouverPiece(String nomOuverture)
        {
            // exemple de parcours avec foreach - par exemple pour additionner le poids de tous les éléments
            //double resultat = 0;
            foreach (TPiece aItem in fPieces)
            {
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

    /// <summary>
    /// Classe maison
    /// </summary>
    public class TMaison : System.Object
    {
        public const int hauteur = 3; // Constante de hauteur des murs

        public TMaison(Form1 AlaForme, bool ALampe, int ATemperatureExt, ref TextBox ATexboxTExt, Boolean Avirtuel, TrackBar ATrackBar, StatusStrip AStatusStrip, RadioButton ARreel, RadioButton ARvirtuel)
        {
            lampe = ALampe;
            temperatureExt = ATemperatureExt;
            laForme = AlaForme; // Form1
            textBoxTExt = ATexboxTExt;
            textBoxTExt.Text = ATemperatureExt.ToString();
            virtuel = Avirtuel; // Mode virtuel ou reel
            trackBar = ATrackBar;
            statusstrip = AStatusStrip;
            Rreel = ARreel;
            Rvirtuel = ARvirtuel;

        }
        private TListePieces fListePieces = new TListePieces();

        /// <summary>
        /// Permet d'ajouter une pièce à la liste des pièces
        /// </summary>
        /// <param name="aItem"></param>
        public void AjouterPiece(TPiece aItem)
        {
            fListePieces.AjouterElement(aItem);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
        }


        public MccDaq.MccBoard Board
        {
            get
            {
                return board;   //
            }
        }
        private MccDaq.MccBoard board;

        public RadioButton RReel
        {
            get
            {
                return Rreel;   //
            }
        }
        private RadioButton Rreel;

        public RadioButton RVirtuel
        {
            get
            {
                return Rvirtuel;   //
            }
        }
        private RadioButton Rvirtuel;


        public MccDaq.ErrorInfo ULStat
        {
            get
            {
                return ulstat;   //
            }
            set
            {
                ulstat = value;
            }
        }
        private MccDaq.ErrorInfo ulstat;

        public StatusStrip StatusStrip
        {
            get
            {
                return statusstrip;   //
            }
        }
        private StatusStrip statusstrip;


        /// <summary>
        /// Fonction qui permet de gérer la maison, aussi bien en mode virtuel que réel
        /// </summary>
        /// 
        Boolean msgError = false;
        public void gerer()
        {
            if (this.Virtuel == false) // On regarde si on se trouve en mode reel
            {

                // Vérification erreurs DAQ
                if (this.ULStat.Value.ToString() != "NoErrors")
                {
                    if (msgError == false)
                    {
                        msgError = true;
                        var result = MessageBox.Show("DAQ non connecté. Voulez-vous repasser en mode virtuel?", "Erreur connecion DAQ!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);
                        if (result == DialogResult.Yes)
                        {
                            this.Virtuel = true;
                            msgError = false;
                        }
                        else
                        {
                            msgError = false;
                        }
                    }
                }
                else
                {

                    float ch0;
                    float ch1;
                    float ch2;
                    float ch3;


                    System.UInt16 DataValue0;
                    System.UInt16 DataValue1;
                    System.UInt16 DataValue2;
                    System.UInt16 DataValue3;

                    int chan0 = 0;
                    int chan1 = 1;
                    int chan2 = 2;
                    int chan3 = 3;
                    MccDaq.Range Range;
                    Range = Range.Bip10Volts;

                    // Acquisition des température
                    this.ULStat = this.Board.AIn(chan0, Range, out DataValue0); //acquisition
                    this.ULStat = this.Board.AIn(chan1, Range, out DataValue1); //acquisition
                    this.ULStat = this.Board.AIn(chan2, Range, out DataValue2); //acquisition
                    this.ULStat = this.Board.AIn(chan3, Range, out DataValue3); //acquisition

                    // Conversion de celles-ci
                    this.ULStat = this.Board.ToEngUnits(Range, DataValue0, out ch0); //conversion
                    this.ULStat = this.Board.ToEngUnits(Range, DataValue1, out ch1); //conversion
                    this.ULStat = this.Board.ToEngUnits(Range, DataValue2, out ch2); //conversion
                    this.ULStat = this.Board.ToEngUnits(Range, DataValue3, out ch3); //conversion

                    // Initialisation températures
                    this.ListePieces[0].Temperature = Convert.ToDouble(ch1) * 10;
                    this.ListePieces[1].Temperature = Convert.ToDouble(ch0) * 10;
                    this.ListePieces[2].Temperature = Convert.ToDouble(ch3) * 10;
                    this.TemperatureExt = Convert.ToDouble(ch2) * 10;

                    // Acquisition ouvertures
                    short D1;
                    this.ULStat = this.Board.DIn(MccDaq.DigitalPortType.FirstPortB, out D1);
                    String valeur = null;
                    for (int i = 0; i <= 7; i++)
                    {
                        if ((D1 & (1 << i)) != 0)
                            valeur = valeur + "1";
                        else
                            valeur = valeur + "0";
                    }

                    // Initialisation des ouvertures
                    this.ListePieces[0].ListeParois[0].ListeOuvertures[0].Ouvert = Convert.ToBoolean(Convert.ToInt32(valeur[7].ToString()));
                    this.ListePieces[2].ListeParois[1].ListeOuvertures[0].Ouvert = Convert.ToBoolean(Convert.ToInt32(valeur[7].ToString()));

                    this.ListePieces[0].ListeParois[1].ListeOuvertures[0].Ouvert = Convert.ToBoolean(Convert.ToInt32(valeur[6].ToString()));
                    this.ListePieces[1].ListeParois[1].ListeOuvertures[0].Ouvert = Convert.ToBoolean(Convert.ToInt32(valeur[6].ToString()));


                    this.ListePieces[0].ListeParois[2].ListeOuvertures[2].Ouvert = Convert.ToBoolean(Convert.ToInt32(valeur[1].ToString()));
                    this.ListePieces[0].ListeParois[2].ListeOuvertures[1].Ouvert = Convert.ToBoolean(Convert.ToInt32(valeur[4].ToString()));
                    this.ListePieces[0].ListeParois[2].ListeOuvertures[0].Ouvert = Convert.ToBoolean(Convert.ToInt32(valeur[2].ToString()));

                    this.ListePieces[1].ListeParois[0].ListeOuvertures[0].Ouvert = Convert.ToBoolean(Convert.ToInt32(valeur[3].ToString()));

                    this.ListePieces[2].ListeParois[0].ListeOuvertures[0].Ouvert = Convert.ToBoolean(Convert.ToInt32(valeur[5].ToString()));

                    foreach (TPiece piece in this.ListePieces)
                    {

                        if ((piece.OuvertureExtOuverte() || (piece.OuvertureCommuneOuvert() != null && piece.OuvertureExtPieceVoisine() != null)))
                        {
                            piece.Radiateur = false;
                            if (piece.Nom == "Salon")
                            {
                                int pinChauffageSalon = 1; // 1 en sortie (pin 22)
                                this.ULStat = this.Board.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageSalon, MccDaq.DigitalLogicState.Low);
                            }
                            else if (piece.Nom == "Chambre")
                            {
                                int pinChauffageChambre = 0; // 3 en sortie (pin 24)
                                this.ULStat = this.Board.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageChambre, MccDaq.DigitalLogicState.Low);
                            }
                            else if (piece.Nom == "Cuisine")
                            {
                                int pinChauffageCuisine = 3; // 0 en sortie (pin 21)
                                this.ULStat = this.Board.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageCuisine, MccDaq.DigitalLogicState.Low);
                            }
                        }
                        else
                        {
                            if (piece.Consigne > piece.Temperature)
                            {
                                piece.Radiateur = true;
                                if (piece.Nom == "Salon")
                                {
                                    int pinChauffageSalon = 1; // 1 en sortie (pin 22)
                                    this.ULStat = this.Board.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageSalon, MccDaq.DigitalLogicState.High);
                                }
                                else if (piece.Nom == "Chambre")
                                {
                                    int pinChauffageChambre = 0; // 3 en sortie (pin 24)
                                    this.ULStat = this.Board.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageChambre, MccDaq.DigitalLogicState.High);
                                }
                                else if (piece.Nom == "Cuisine")
                                {
                                    int pinChauffageCuisine = 3; // 0 en sortie (pin 21)
                                    this.ULStat = this.Board.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageCuisine, MccDaq.DigitalLogicState.High);
                                }
                            }
                            else
                            {
                                piece.Radiateur = false;
                                if (piece.Nom == "Salon")
                                {
                                    int pinChauffageSalon = 1; // 1 en sortie (pin 22)
                                    this.ULStat = this.Board.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageSalon, MccDaq.DigitalLogicState.Low);
                                }
                                else if (piece.Nom == "Chambre")
                                {
                                    int pinChauffageChambre = 0; // 3 en sortie (pin 24)
                                    this.ULStat = this.Board.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageChambre, MccDaq.DigitalLogicState.Low);
                                }
                                else if (piece.Nom == "Cuisine")
                                {
                                    int pinChauffageCuisine = 3; // 0 en sortie (pin 21)
                                    this.ULStat = this.Board.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageCuisine, MccDaq.DigitalLogicState.Low);
                                }
                            }
                        }

                        /*int pinChauffageCuisine = 0; // 0 en sortie (pin 21)
                        ULStat = DaqBoard.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageCuisine, MccDaq.DigitalLogicState.Low);
                        ULStat = DaqBoard.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageCuisine, MccDaq.DigitalLogicState.High);

                        int pinChauffageSalon = 1; // 1 en sortie (pin 22)
                        ULStat = DaqBoard.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageSalon, MccDaq.DigitalLogicState.Low);

                        int pinLampeExt = 2; // 2 en sortie (pin 23)
                        ULStat = DaqBoard.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinLampeExt, MccDaq.DigitalLogicState.Low);

                        int pinChauffageChambre = 3; // 3 en sortie (pin 24)
                        ULStat = DaqBoard.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinChauffageChambre, MccDaq.DigitalLogicState.Low);*/


                    }
                    //this.ListePieces[0].Temperature = 
                }
            }
            else
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
                        TParoi paroiCommune = piece.OuvertureCommuneOuvert();
                        if ((paroiCommune != null))
                        {
                            TPiece pieceVoisine = piece.OuvertureExtPieceVoisine();
                            if (piece.OuvertureExtPieceVoisine() != null)
                            {
                                if (pieceVoisine == paroiCommune.Piece1 || pieceVoisine == paroiCommune.Piece2)
                                {
                                    piece.Radiateur = false;
                                }
                                else if (pieceVoisine.OuvertureCommuneOuvert() != null)
                                {
                                    piece.Radiateur = false;
                                }

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



                        /*      if (piece.OuvertureExtPieceVoisine() == null)
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
                            int intervalle;
                            intervalle = TrackBar.Value;
                            if (intervalle != 1)
                            {
                                intervalle = (intervalle - 1) * 5 * 60;
                            }
                            double temperatureKelvin = piece.Temperature + 273.15;
                            apportT = (apport / masseAir) / 1004;
                            apportT = (apportT / 100) * intervalle;
                            piece.Temperature = piece.Temperature + apportT;
                        }

                    }

                }
            }
        }


        /// <summary>
        /// Permet d'inverser une chaine de caractères
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Reverse(string text)
        {
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }

        /*public void gerer()
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
                        int intervalle;
                        intervalle = TrackBar.Value;
                        if (intervalle != 1)
                        {
                            intervalle = (intervalle - 1) * 5 * 60;
                        }
                        double temperatureKelvin = piece.Temperature + 273.15;
                        apportT = (apport / masseAir) / 1004;
                        apportT = (apportT / 100) * intervalle;
                        piece.Temperature = piece.Temperature + apportT;
                    }

                }

            }


            
        }*/

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

        public double TemperatureExt
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
        private double temperatureExt;

        public TrackBar TrackBar
        {
            get
            {
                return trackBar;
            }
        }
        private TrackBar trackBar;


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

        public Boolean Virtuel
        {
            get
            {
                return virtuel;
            }
            set
            {
                if (virtuel != value)
                {
                    virtuel = value;
                    if (virtuel == false)
                    {
                        this.ULStat = MccDaq.MccService.ErrHandling(MccDaq.ErrorReporting.DontPrint, MccDaq.ErrorHandling.DontStop);
                        board = new MccDaq.MccBoard(0);
                        this.ULStat = board.DConfigPort(MccDaq.DigitalPortType.FirstPortA, MccDaq.DigitalPortDirection.DigitalOut);
                        this.ULStat = board.DConfigPort(MccDaq.DigitalPortType.FirstPortB, MccDaq.DigitalPortDirection.DigitalIn);
                        StatusStrip.Items[0].Text = "Mode Réel";
                        RReel.Checked = true;
                        RVirtuel.Checked = false;
                        foreach (TPiece piece in this.ListePieces)
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
                        StatusStrip.Items[0].Text = "Mode Virtuel";
                        RReel.Checked = false;
                        RVirtuel.Checked = true;
                        foreach (TPiece piece in this.ListePieces)
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
        private Boolean virtuel;


    }

    /// <summary>
    /// Classe ouvertures
    /// </summary>
    public class TOuverture : System.Object
    {
        public TOuverture(ref Label aLabel, int ACoefficientThermo, int ASurface, SqlConnection ACon, Label ALalbelHeure, Label ALabelDate, ref Boolean AStatusBDD, Boolean AModifiable, TMaison AMaison)
        {
            coefficientThermo = ACoefficientThermo;
            surface = ASurface;
            label = aLabel;
            con = ACon;
            labelHeure = ALalbelHeure;
            labelDate = ALabelDate;
            statusBDD = AStatusBDD;
            modifiable = AModifiable; // Indique si l'on peut cliquer sur les ouvertures
            maison = AMaison;
        }

        public Label Label
        {
            get
            {
                return label;
            }
        }
        private Label label;

        public TMaison Maison
        {
            get
            {
                return maison;
            }
        }
        private TMaison maison;

        public Boolean StatusBDD
        {
            get
            {
                return statusBDD;
            }
        }
        private Boolean statusBDD;

        public Boolean Modifiable
        {
            get
            {
                return modifiable;
            }
            set
            {
                if (modifiable != value)
                {
                    modifiable = value;
                    label.Enabled = value;
                }
            }
        }
        private Boolean modifiable;


        public Label LabelHeure
        {
            get
            {
                return labelHeure;
            }
        }
        private Label labelHeure;

        public Label LabelDate
        {
            get
            {
                return labelDate;
            }
        }
        private Label labelDate;


        public SqlConnection Con
        {
            get
            {
                return con;
            }
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

        /// <summary>
        /// Permet d'indiquer si l'ouverture est ouverte ou non
        /// </summary>
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
                            // Enregistrement des logs dand la DB
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

    /// <summary>
    /// Classe paroi
    /// </summary>
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

        /// <summary>
        /// Permet d'ajouter une ouverture à la liste
        /// </summary>
        /// <param name="aItem"></param>
        public void AjouterOuverture(TOuverture aItem)
        {
            fListeOuvertures.AjouterElement(aItem);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
        }

        /// <summary>
        /// Permet d'indiquer si une paroi possède une ouverture vers l'extérieur qui est ouverte
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Permet d'indiquer si la paroi contient une ouverture commune ouverte
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Calcule de la surface réel de la paroi (surfacetotal - surface des ouvertures)
        /// </summary>
        public void calculerSurfaceReel()
        {

            foreach (TOuverture ov in this.ListeOuvertures)
            {
                SurfaceReel = SurfaceReel - ov.Surface;
            }
        }

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
                return fListeOuvertures;
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

    /// <summary>
    /// Classe pièce
    /// </summary>
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

        /// <summary>
        /// Permet de savoir si la pièce possède une ouverture vers l'extérieur qui est ouverte
        /// </summary>
        /// <returns></returns>
        public Boolean OuvertureExtOuverte()
        {
            foreach (TParoi paroi in this.ListeParois)
            {
                if (paroi.OuvertureExtOuverte()) return true;
            }
            return false;
        }

        /// <summary>
        /// Permet de savoir si la pièce possède une ouverture commmune ouverte
        /// </summary>
        /// <returns>La paroi commune au 2 pièce</returns>
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

        /// <summary>
        /// Permet d'ajouter une consigne à la liste
        /// </summary>
        /// <param name="aItem"></param>
        public void AjouterConsigne(TConsigne aItem)
        {
            fListeConsignes.AjouterElement(aItem);
        }

        /// <summary>
        /// Permet de supprimer une consigne de la liste
        /// </summary>
        /// <param name="index">Integer représentant l'index de la liste</param>
        public void SupprimerConsigne(int index)
        {
            fListeConsignes.SupprimerElement(index);
        }

        /// <summary>
        /// Permet de supprimer une consigne de la liste
        /// </summary>
        /// <param name="cons">Objet consigne</param>
        public void SupprimerConsigne2(TConsigne cons)
        {
            fListeConsignes.SupprimerElement2(cons);
        }


        /// <summary>
        /// Permet de savoir si une pièce voisine possède une ouverture vers l'extérieur qui est ouverte
        /// </summary>
        /// <returns></returns>
        public TPiece OuvertureExtPieceVoisine()
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
                    if (pieceVoisine.OuvertureExtOuverte()) return pieceVoisine;
                }
            }
            return null;

        }

        /// <summary>
        /// Permet d'ajouter une paroi à la liste
        /// </summary>
        /// <param name="aItem"></param>
        public void AjouterParoi(TParoi aItem)
        {
            fListeParois.AjouterElement(aItem);
        }

        /// <summary>
        /// Permet de trier la liste des consignes en fonction du jour/heure
        /// </summary>
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

        public TListeConsignes ListeConsignes
        {
            get
            {
                return fListeConsignes;
            }
        }

        public TListeParois ListeParois
        {
            get
            {
                return fListeParois;
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
        }
        private TextBox textBoxT;

        public Button ButtonChauffage
        {
            get
            {
                return buttonChauffage;
            }
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

