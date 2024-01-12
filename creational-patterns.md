# Patrons de création :

## Fabrique / Factory Method

### Présentation

Fabrique est un patron de conception de création qui définit une interface pour créer des objets dans une classe mère, mais délègue le choix des types d’objets à créer aux sous-classes.

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

        throw new VehiculeCreationException("Impossible de créer une " + typeVehicule);
    }
}

```


## Fabrique absraite / Abstarct Factory

### Présentation

Une fabrique abstraite encapsule un ensemble de fabriques ayant une thématique commune. Le code client crée une instance concrète de la fabrique abstraite, puis utilise son interface générique pour créer des objets concrets de la thématique.

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
