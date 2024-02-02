## Poids mouche / Flyweight

### Présentation 

Le design pattern Flyweight est un modèle de conception structurelle qui vise à minimiser l'utilisation de la mémoire et à améliorer les performances en partageant autant que possible les données entre plusieurs objets similaires. Il est particulièrement utile lorsque le programme nécessite un grand nombre d'objets identiques, et la réduction de la redondance des données contribue à optimiser les ressources.

En termes simples :
* Le pattern Flyweight divise les objets en deux parties distinctes : l'état intrinsèque (partagé et immuable) et l'état extrinsèque (spécifique à chaque instance).
* L'état intrinsèque est partagé entre plusieurs objets pour économiser de la mémoire.
* L'état extrinsèque est géré individuellement pour chaque instance.

### Avantages

* Économie de mémoire : Réduction significative de l'utilisation de la mémoire en partageant l'état intrinsèque entre plusieurs objets.
* Performances améliorées : Moins d'objets à manipuler conduisent à une amélioration des performances, en particulier dans le cas de nombreuses instances similaires.

### Inconvénient

* Complexité accrue : L'implémentation du pattern peut ajouter de la complexité au code, notamment lors de la gestion de l'état intrinsèque partagé.

### Présentation UML

Dans cet exemple, 'Car' est l'implémentation concrète du poids mouche et 'CarFlyweightFactory' est la fabrique de poids mouche qui gère la création et la récupération des objets poids mouchee. L'idée est de partager les instances d'objets similaires pour économiser de la mémoire. Ce sera plus visible sur l'implémentation en C#.

![image](https://github.com/Enfyyys/DP-Groupe1/assets/90694706/6d3b4bd1-81b7-4b5e-ac33-7dd76bc08b01)

### Implémentation en C#

```C#
// Interface pour le poids mouche
interface ICarFlyweight
{
    void Drive(int speed);
}

// Implémentation concrète du poids mouche
class Car : ICarFlyweight
{
    public string Model { get; private set; }

    public Car(string model)
    {
        Model = model;
    }

    public void Drive(int speed)
    {
        Console.WriteLine($"{Model} is driving at {speed} km/h.");
    }
}

// Fabrique de poids mouche
class CarFlyweightFactory
{
    private Dictionary<string, ICarFlyweight> flyweights = new Dictionary<string, ICarFlyweight>();

    public ICarFlyweight GetCarFlyweight(string model)
    {
        if (!flyweights.ContainsKey(model))
        {
            flyweights[model] = new Car(model);
        }

        return flyweights[model];
    }
}

// Client
class Program
{
    static void Main()
    {
        CarFlyweightFactory flyweightFactory = new CarFlyweightFactory();

        // Utilisation du poids mouche
        ICarFlyweight car1 = flyweightFactory.GetCarFlyweight("Toyota");
        car1.Drive(120);

        ICarFlyweight car2 = flyweightFactory.GetCarFlyweight("Toyota");
        car2.Drive(100);

        // Les objets "Toyota" sont partagés, démontrant le design pattern du poids mouche.
    }
}

```