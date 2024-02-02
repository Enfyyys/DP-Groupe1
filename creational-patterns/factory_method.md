## Fabrique / Factory Method

### Présentation


Le design pattern Fabrique (Factory) est un modèle de conception utilisé en programmation pour créer des objets sans spécifier directement leur classe concrète. Au lieu de créer des objets en utilisant un constructeur directement, une fabrique (méthode ou classe) est utilisée pour créer ces objets. Cela permet d'encapsuler la logique de création et de rendre le processus plus flexible, réutilisable et extensible.

En termes simples :
* Au lieu de créer un objet en utilisant new, on utilise une fabrique qui connaît les détails de la création.
* La fabrique crée l'objet souhaité en cachant les détails de l'implémentation.
* Cela permet de changer le type d'objet créé sans changer le code qui l'utilise.

### Avantages

* Noms descriptifs : Les méthodes de fabrication n'ont pas l'obligation d'avoir un nom de constructeur identique au nom de la classe, ce qui perment d'avoir un nom qui décrit mieux leur fonction.
* Encapsulation : Les méthodes de fabrication permettent d'encapsuler la création des objets, en utilisant par exemple un switch sur le type d'un objet au lieu de faire une fonction par type d'objet.

### Inconvénients

* Complexité accrue : L'introduction du pattern Factory peut introduire de la complexité supplémentaire, en particulier pour des systèmes simples.
* Difficulté de compréhension pour les débutants : Les développeurs novices peuvent trouver difficile de comprendre la notion de factory et son utilisation.

### Présentation UML

Dans l'UML suivant, la classe FabriqueVehicule appelle la classe Vehicule qui crée une voiture ou une moto en fonction du typeVehicule passé en paramètre.

![image](https://github.com/Enfyyys/DP-Groupe1/assets/90694706/42a4fb2d-25e2-43a4-b1e0-fd8384e5887b)

### Implémentation en C#

```C#
class Program
{
    static void Main()
    {
        FabriqueVehicule fabrique = new FabriqueVehicule();

        // Création d'une voiture
        Vehicule voiture = fabrique.Create("voiture");
        voiture.Demarrer();

        // Création d'une moto
        Vehicule moto = fabrique.Create("moto");
        moto.Demarrer();

        // Tentative de création d'un type inconnu
        try
        {
            Vehicule vehiculeInconnu = fabrique.Create("camion");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public abstract class Vehicule
{
    public abstract void Demarrer();
}

public class Voiture : Vehicule
{
    public override void Demarrer()
    {
        Console.WriteLine("La voiture démarre.");
    }
}

public class Moto : Vehicule
{
    public override void Demarrer()
    {
        Console.WriteLine("La moto démarre.");
    }
}

public class FabriqueVehicule
{
    public Vehicule Create(string typeVehicule)
    {
        if (typeVehicule.Equals("voiture", StringComparison.OrdinalIgnoreCase))
        {
            return new Voiture();
        }
        else if (typeVehicule.Equals("moto", StringComparison.OrdinalIgnoreCase))
        {
            return new Moto();
        }

        throw new InvalidOperationException("Impossible de créer une " + typeVehicule);
    }
}

```