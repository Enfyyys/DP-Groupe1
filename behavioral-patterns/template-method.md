## Patron de méthode ( Méthode socle, Template Method)

### Présentation

Le design patterns Patron de méthode permet de mettre le squelette d’un algorithme dans la classe mère, mais laisse les sous-classes redéfinir certaines étapes de l’algorithme sans changer sa structure.

### Avantage

- On permet aux clients de redéfinir certaines parties d’un grand algorithme. Elles sont ainsi moins affectées par les modifications apportées aux autres parties de l’algorithme.
- On peut remonter le code dupliqué dans la classe mère.

### Inconvénient

### UML

![UML_Patron_de_Methode](https://github.com/Enfyyys/DP-Groupe1/assets/103527909/f7b92e6b-a7dc-4497-a181-4964b3863bb8)

### Exemple C#

```C#
using System;

public class Program
{
    
	abstract class Construire_maison
    {
		public void Construire()
        {
			this.Faire_les_fondations();
			this.Poser_le_sol();
			this.monter_les_murs();
			this.Posez_le_toit();
        }
		
        protected virtual void Faire_les_fondations()
        {
            Console.WriteLine("Fondation posée");
        }
		protected virtual void Poser_le_sol()
        {
            Console.WriteLine("Sol posée");
        }
		protected virtual void monter_les_murs()
        {
            Console.WriteLine("Mur monté");
        }
		protected virtual void Posez_le_toit()
        {
            Console.WriteLine("Toit posée");
        }
    }
	
	class Construire_un_immeuble : Construire_maison
	{
		protected override void monter_les_murs()
        {
            Console.WriteLine("Mur monté");
        }
		protected override void Posez_le_toit()
        {
            Console.WriteLine("Toit posée");
        }
	}
	
	class Construire_un_bunker : Construire_maison
	{
		protected override void monter_les_murs()
        {
            Console.WriteLine("Mur monté");
        }
		protected override void Posez_le_toit()
        {
            Console.WriteLine("Toit posée");
        }
		protected override void Faire_les_fondations()
        {
            Console.WriteLine("Fondation posée");
        }
	}

    class Client{
		public void Construire(Construire_maison construire_maison){
			construire_maison.Construire();
		}
	}
	
    public static void Main()
    {
        var client = new Client();
		client.Construire(new Construire_un_immeuble());
		client.Construire(new Construire_un_bunker());
    }
}

```