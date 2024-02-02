## Décorateur

### Présentation 
Décorateur est un patron de conception structurel qui permet d’affecter dynamiquement de nouveaux comportements à des objets en les plaçant dans des emballeurs qui implémentent ces comportements.

### Avantages

Le décorateur permet d'ajouter de nouvelles fonctionnalités à un objet existant sans modifier sa structure de base. Cela rend le code plus flexible et plus facile à étendre.

Le décorateur favorise la composition d'objets plutôt que l'héritage de classes. Cela évite les problèmes liés à une hiérarchie de classes trop profonde et facilite la réutilisation du code.

### Inconvénient

L'utilisation du décorateur peut entraîner une augmentation de la complexité du code, car de multiples couches de décorateurs peuvent être empilées. Cela peut rendre la compréhension du code plus difficile.

Lorsque de nombreuses fonctionnalités sont ajoutées au moyen de décorateurs, cela peut conduire à la création d'un grand nombre de petites classes, ce qui peut être difficile à gérer.

### Présentation UML

![image](https://github.com/Enfyyys/DP-Groupe1/assets/144044265/dc030808-88a1-4671-923d-4e8b70b944a9)

### Implémentation en C#

On développe un système de gestion de café, avec différentes options de boissons. On a une classe de base, *CafeSimple*, qui représente une boisson de base. Ensuite, on a des décorateurs qui ajoutent des extras à la boisson, tels que le lait, le sucre, ou encore la vanille.

```C#

public abstract class Cafe
{
    public abstract string Description { get; }
    public abstract double Cout();
}

public class CafeSimple : Cafe
{
    public override string Description => "Café simple";

    public override double Cout()
    {
        return 1.0; 
    }
}

public abstract class DecorateurCafe : Cafe
{
    protected Cafe cafe;

    public DecorateurCafe(Cafe cafe)
    {
        this.cafe = cafe;
    }
}

public class Lait : DecorateurCafe
{
    public Lait(Cafe cafe) : base(cafe) { }

    public override string Description => cafe.Description + ", Lait";

    public override double Cout()
    {
        return cafe.Cout() + 0.5; // Coût du lait
    }
}

public class Sucre : DecorateurCafe
{
    public Sucre(Cafe cafe) : base(cafe) { }

    public override string Description => cafe.Description + ", Sucre";

    public override double Cout()
    {
        return cafe.Cout() + 0.2; // Coût du sucre
    }
}

```