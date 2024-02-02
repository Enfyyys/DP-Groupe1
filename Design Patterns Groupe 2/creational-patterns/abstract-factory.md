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

```C#
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