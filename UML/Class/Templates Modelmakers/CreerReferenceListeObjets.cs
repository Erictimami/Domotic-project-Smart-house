// Ajout dans la classe principale d'une r�f�rence
// � une liste d'objets d�finie auparavant 

//MMWIN:ADDARRAYCLASS;Language=C#
//MMWIN:DEFINEMACRO:NomListe = nom de la liste d'objets li�s (sans le T devant)
//MMWIN:DEFINEMACRO:TypeElement = Type de chaque objet de la liste



public class TCodeTemplate: System.Object {

        public void AjouterElement(<!TypeElement!> aItem)
        {
          f<!NomListe!>.AjouterElement(aItem);  // ajouter l'objet � la liste si AjouterElement existe dans la classe liste
        }
        
        public T<!NomListe!> <!NomListe!>
        {
            get
            {
                return f<!NomListe!>;   // 
            }
        }
		
      

        public string ListeDeQuelqueChose()
        {
            // exemple de parcours de la liste li�e - par exemple pour cr�er un catalogue
            string resultat = "Liste";
            //  for(int i=0;i<f<!NomListe!>.NbEnfants;i++)
            //  {
            //     resultat += f<!NomListe!>[i].ToString(); // exemple si ToString() existe dans la classe liste
            //  }
            return resultat;
        }  
        private T<!NomListe!> f<!NomListe!> = new T<!NomListe!>();// R�f�rence locale � ma classe liste li�e
	}

