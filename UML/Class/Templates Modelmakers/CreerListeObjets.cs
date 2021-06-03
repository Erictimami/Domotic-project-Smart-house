
///<summary> 
/// Cr�ation d'une liste d'objets avec cr�ation automatis�e de la liste
/// Attention, vous devez cr�er toutes les listes utiles avant de les utiliser
/// dans la classe de base qui appellera les listes 	
///</summary> 


//MMWIN:ADDARRAYCLASS;Language=C#
//MMWIN:DEFINEMACRO:ItemClass=Classe des objets de la liste
//MMWIN:DEFINEMACRO:ItemCount=Nombre d'objets dans la liste
//MMWIN:DEFINEMACRO:Items=Nom public de la liste d'objets

public class TCodeTemplate : System.Object
{
    public void AjouterElement(<!ItemClass!> aItem)
    {   
        //  Classe permettant d'ajouter un objet de type <!ItemClass!> � la liste
        // Ne pas oublier de mettre using System.Collections; en haut du programme
        f<!Items!>.Add(aItem);  // ajoute l'objet � la liste
    }

    public int <!ItemCount!>
    {  
        get
        {
            return f<!Items!>.Count;   // <!ItemCount!> donne le nombre de "<!ItemClass!>" de la classe <!ClassName!>;
        }
    }
    public <!ItemClass!> this[int Index]
    {   
        get
        {
            return f<!Items!>[Index] as <!ItemClass!>; // permet de lire/�crire l'�l�ment <!ItemClass!>[0], <!ItemClass!>[1] ....
        }
    }
   
    public double CalculDeQuelqueChose() 
    {// exemple de parcours avec foreach - par exemple pour additionner le poids de tous les �l�ments
	    double resultat=0;
		foreach (<!ItemClass!> aItem in f<!Items!>)
			{
			  // resultat +=aItem.Poids / 1000.0;  exemple
			}
		return resultat;
    }
    private ArrayList  f<!Items!> = new ArrayList(); // f<!Items!> est le champ cach� dans la classe qui stocke les <!ItemClass!>
}
