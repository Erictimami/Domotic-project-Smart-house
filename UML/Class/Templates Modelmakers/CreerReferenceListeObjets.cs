// Ajout dans la classe principale d'une référence
// à une liste d'objets définie auparavant 

//MMWIN:ADDARRAYCLASS;Language=C#
//MMWIN:DEFINEMACRO:NomListe = nom de la liste d'objets liés (sans le T devant)
//MMWIN:DEFINEMACRO:TypeElement = Type de chaque objet de la liste



public class TCodeTemplate: System.Object {

        public void AjouterElement(<!TypeElement!> aItem)
        {
          f<!NomListe!>.AjouterElement(aItem);  // ajouter l'objet à la liste si AjouterElement existe dans la classe liste
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
            // exemple de parcours de la liste liée - par exemple pour créer un catalogue
            string resultat = "Liste";
            //  for(int i=0;i<f<!NomListe!>.NbEnfants;i++)
            //  {
            //     resultat += f<!NomListe!>[i].ToString(); // exemple si ToString() existe dans la classe liste
            //  }
            return resultat;
        }  
        private T<!NomListe!> f<!NomListe!> = new T<!NomListe!>();// Référence locale à ma classe liste liée
	}

