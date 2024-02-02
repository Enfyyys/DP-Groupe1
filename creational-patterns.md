# Patrons de création :

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

```
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


## Fabrique absraite / Abstarct Factory

### Présentation

Le design pattern Fabrique Abstraite (Abstract Factory) est une extension du pattern Fabrique. Il fournit une interface pour créer des familles d'objets liés ou dépendants sans spécifier leurs classes concrètes. En d'autres termes, il permet de créer des ensembles d'objets connexes sans détailler la façon dont ils sont créés, offrant ainsi une plus grande abstraction.

En termes simples :
* La Fabrique Abstraite fournit une interface pour créer des familles d'objets liés.
* Elle permet de créer des ensembles d'objets connexes sans spécifier les classes concrètes.
* Cela facilite le changement d'une famille d'objets à une autre sans modifier le code client.

### Avantages

* Flexibilité : Il facilite l'ajout de nouvelles familles d'objets sans modifier le code existant. En introduisant de nouvelles classes de fabriques, vous pouvez étendre le système de manière modulaire.
* Encapsulation : Le design pattern de la fabrique abstraite permet d'encapsuler la création d'objets complexes, fournissant ainsi une interface abstraite pour la création d'objets tout en masquant les détails d'implémentation.

### Inconvénients

* Complexité accrue : L'introduction d'une hiérarchie de fabriques et de produits peut rendre le code plus complexe, surtout si le nombre de produits et de familles de produits augmente.
* Surcharge de classes : Une multitude de classes peut être créée pour représenter différentes familles de produits, ce qui peut entraîner une surcharge de classes et une complexité accrue.

### Présentation UML

Supposons que nous ayons un système de création de formes géométriques (cercle et carré, par exemple). Voici comment on peut utiliser le pattern de la fabrique abstraite pour créer ces formes :

![image](https://github.com/Enfyyys/DP-Groupe1/assets/90694706/4fc4d95a-2ca2-437a-9551-47b9effa8bc0)

### Implémentation en C#

```
// Produits abstraits
interface IShape
{
    void Draw();
}

class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}

class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Square");
    }
}

// Fabrique abstraite
interface IShapeFactory
{
    IShape CreateShape();
}

// Implémentations concrètes de la fabrique abstraite
class CircleFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        return new Circle();
    }
}

class SquareFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        return new Square();
    }
}

// Client
class Client
{
    private IShapeFactory shapeFactory;

    public Client(IShapeFactory factory)
    {
        shapeFactory = factory;
    }

    public void DrawShape()
    {
        IShape shape = shapeFactory.CreateShape();
        shape.Draw();
    }
}

class Program
{
    static void Main()
    {
        // Utilisation avec un cercle
        Client clientWithCircle = new Client(new CircleFactory());
        clientWithCircle.DrawShape();

        // Utilisation avec un carré
        Client clientWithSquare = new Client(new SquareFactory());
        clientWithSquare.DrawShape();
    }
}

```


## Monteur / Builder

### Présentation

Le design pattern Monteur (Builder) est un modèle de conception utilisé pour construire des objets complexes en étapes successives. Il sépare la construction d'un objet complexe de sa représentation, permettant ainsi de créer différentes représentations de l'objet en utilisant le même processus de construction. Le Monteur fournit une interface pour la construction étape par étape d'un objet complexe.

En termes simples :
* Le Monteur permet de construire des objets complexes étape par étape.
* Il sépare le processus de construction de la représentation finale de l'objet.
* Cela offre une flexibilité pour créer différentes représentations du même objet.

### Avantages

* Séparation des responsabilités : Permet de séparer la construction d'un objet complexe de sa représentation, facilitant ainsi la gestion des différentes étapes de construction.
* Réutilisation du code : Encourage la réutilisation du code, car le même processus de construction peut être utilisé pour créer des objets avec différentes représentations.

### Inconvénients

* Code boilerplate : L'ajout de classes supplémentaires pour les constructeurs peut entraîner une quantité de code boilerplate, ce qui peut rendre le code source plus verbeux.
* Surcharge de classes : Si plusieurs variantes de constructeurs sont nécessaires, cela peut entraîner une multiplication des classes, ce qui peut rendre la gestion du code plus complexe.

### Présentation UML

Dans cet exemple, 'Car' est le produit complexe que nous voulons construire. 'ICarBuilder' est l'interface définissant les étapes de construction, et 'SportsCarBuilder' est une implémentation concrète de ce monteur pour construire une voiture de sport spécifique. Le 'CarDirector' utilise le monteur pour construire la voiture étape par étape.

![image](https://github.com/Enfyyys/DP-Groupe1/assets/90694706/fb281fb7-b066-4d93-b29f-4456917a1781)

### Implémentation en C#

```
// Produit : Classe représentant l'objet complexe à construire
class Car
{
    public string Model { get; set; }
    public string Engine { get; set; }
    public string Transmission { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Car Model: {Model}, Engine: {Engine}, Transmission: {Transmission}");
    }
}

// Monteur : Interface définissant les étapes de construction
interface ICarBuilder
{
    void SetModel();
    void SetEngine();
    void SetTransmission();
    Car GetCar();
}

// ConcreteMonteur : Implémente l'interface ICarBuilder pour construire une voiture spécifique
class SportsCarBuilder : ICarBuilder
{
    private Car car = new Car();

    public void SetModel()
    {
        car.Model = "Sports Car";
    }

    public void SetEngine()
    {
        car.Engine = "V8";
    }

    public void SetTransmission()
    {
        car.Transmission = "Automatic";
    }

    public Car GetCar()
    {
        return car;
    }
}

// Directeur : Construit un objet complexe en utilisant un Monteur
class CarDirector
{
    public Car Construct(ICarBuilder builder)
    {
        builder.SetModel();
        builder.SetEngine();
        builder.SetTransmission();

        return builder.GetCar();
    }
}

// Exemple d'utilisation
class Program
{
    static void Main()
    {
        CarDirector director = new CarDirector();
        ICarBuilder sportsCarBuilder = new SportsCarBuilder();

        Car sportsCar = director.Construct(sportsCarBuilder);
        sportsCar.DisplayInfo();
    }
}
```


## Prototype

### Présentation

Le design pattern Prototype est un modèle de conception qui permet de créer de nouveaux objets en copiant un objet existant, appelé prototype. Au lieu de créer un nouvel objet à partir de zéro, le prototype sert de modèle, et la copie est effectuée pour produire un nouvel objet. Cela peut être utile lorsque la création d'un objet est coûteuse en termes de ressources et qu'il existe déjà un objet similaire à utiliser comme modèle.

En termes simples :
* Le Prototype permet de créer de nouveaux objets en copiant des prototypes existants.
* Il évite la création d'objets à partir de zéro, en utilisant un objet existant comme modèle.
* Cela peut être utile lorsque la création d'un objet est coûteuse ou complexe.

### Avantages

* Création d'objets complexes : Permet de créer des objets complexes plus efficacement en clonant des instances existantes plutôt qu'en les construisant à partir de zéro.
* Réduction de la duplication de code : Évite la duplication de code liée à la création d'objets en permettant de cloner des prototypes plutôt que de recréer des objets similaires.

* ### Inconvénients

* Surcharge mémoire : Si les objets à cloner sont volumineux, cela peut entraîner une surcharge de la mémoire, car chaque clone occupe de l'espace mémoire distinct.
* Gestion des références : Les objets clonés peuvent partager des références à des objets internes, ce qui peut nécessiter une gestion minutieuse pour éviter des effets indésirables.

### Présentation UML

Dans cet exemple, la classe Person implémente l'interface ICloneable avec une méthode Clone() qui effectue une copie superficielle de l'objet. Le client crée un prototype de personne et le clone pour créer une nouvelle personne.

![image](https://github.com/Enfyyys/DP-Groupe1/assets/90694706/16c0202a-894e-4895-8c6d-f722f2019a68)

### Implémentation en C#

```
// Prototype : Interface définissant la méthode de clonage
interface ICloneable
{
    ICloneable Clone();
}

// ConcretePrototype : Implémente l'interface ICloneable pour cloner une personne
class Person : ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }

    public ICloneable Clone()
    {
        // Utilisation du MemberwiseClone pour créer une copie superficielle
        return (ICloneable)MemberwiseClone();
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

// Client
class Program
{
    static void Main()
    {
        // Création d'un prototype de personne
        Person prototypePerson = new Person { Name = "John Doe", Age = 30 };

        // Clonage du prototype pour créer une nouvelle personne
        Person clonedPerson = (Person)prototypePerson.Clone();

        // Modification de la personne clonée
        clonedPerson.Name = "Jane Doe";

        // Affichage des informations des deux personnes
        Console.WriteLine("Original Person:");
        prototypePerson.DisplayInfo();

        Console.WriteLine("\nCloned Person:");
        clonedPerson.DisplayInfo();
    }
}

```


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

```
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


