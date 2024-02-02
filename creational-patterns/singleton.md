## Singleton

### Présentation

Le design pattern Singleton est un modèle de conception qui garantit qu'une classe n'a qu'une seule instance et fournit un point d'accès global à cette instance. Cela est particulièrement utile lorsque vous avez besoin d'une seule instance d'une classe pour coordonner les actions à travers le système, comme dans le cas des gestionnaires de configuration, de journaux, ou de connexions à une base de données.

En termes simples :
* Le Singleton garantit qu'il n'y a qu'une seule instance d'une classe.
* Il fournit un point d'accès global à cette instance.
* Cela peut être utile lorsque vous voulez contrôler l'accès à une ressource unique.

### Avantages

* Instance unique : Garantit qu'une classe n'a qu'une seule instance dans toute l'application, ce qui est utile lorsque vous avez besoin d'un point d'accès global à cette instance.
* Lazy Loading : Permet le chargement paresseux (lazy loading) de l'instance, c'est-à-dire que l'instance n'est créée que lorsqu'elle est effectivement demandée, ce qui peut améliorer les performances au démarrage de l'application.

### Inconvénients

* Violation du principe de responsabilité unique : Peut violer le principe de responsabilité unique en combinant la responsabilité de la gestion de l'instance unique avec d'autres responsabilités, rendant la classe moins modulaire.
* Difficulté de l'héritage : Peut rendre l'héritage difficile, car la classe Singleton a une instance unique et statique qui peut ne pas être appropriée pour les sous-classes.

### Présentation UML

![image](https://github.com/Enfyyys/DP-Groupe1/assets/90694706/0f94894c-1382-403b-b1c2-d7b7ee0e6109)

### Implémentation en C#

```C#
// Classe Singleton
public class Singleton
{
    // Instance unique
    private static Singleton instance;

    // Verrouillage pour assurer la thread-safety lors de la création de l'instance
    private static readonly object lockObject = new object();

    // Constructeur privé pour empêcher la création directe d'instances
    private Singleton() { }

    // Méthode pour obtenir l'instance unique du Singleton
    public static Singleton GetInstance()
    {
        // Vérifie si l'instance n'a pas déjà été créée
        if (instance == null)
        {
            // Utilisation du verrouillage pour assurer la thread-safety
            lock (lockObject)
            {
                // Vérification à nouveau après l'obtention du verrou pour éviter la création multiple par des threads concurrents
                if (instance == null)
                {
                    instance = new Singleton();
                }
            }
        }

        return instance;
    }

    // Méthode exemple de fonctionnalité du Singleton
    public void DisplayMessage()
    {
        Console.WriteLine("Hello from Singleton!");
    }
}

// Exemple d'utilisation du Singleton
class Program
{
    static void Main()
    {
        // Obtention de l'instance unique du Singleton
        Singleton singletonInstance = Singleton.GetInstance();

        // Utilisation de la fonctionnalité du Singleton
        singletonInstance.DisplayMessage();
    }
}
```