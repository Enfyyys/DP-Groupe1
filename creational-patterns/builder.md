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

```C#
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