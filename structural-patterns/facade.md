## Facade 

### Présentation

Le design pattern "Décoration" (Decorator) est un motif de conception structurelle qui permet d'attacher de nouvelles fonctionnalités à des objets existants de manière dynamique et transparente, sans affecter la structure de base de ces objets

### Avantage

Flexibilité : Permet d'ajouter de nouvelles fonctionnalités de manière dynamique.
Modularité : Chaque fonctionnalité peut être encapsulée dans un décorateur distinct.
Ouvert pour l'extension, fermé pour la modification : Les fonctionnalités existantes ne sont pas modifiées.

### Inconvénient

Complexité accrue : L'utilisation excessive de décorateurs peut rendre le code plus difficile à comprendre.
Risque de surcharge : L'ajout de trop de couches de décorateurs peut entraîner des performances réduites

### Présentation UML

![image](https://github.com/Enfyyys/DP-Groupe1/assets/144044265/03bf3ba5-fd6a-4d2d-b604-fed1ceb58dd0)

### Code C#

nous avons un café qui propose différentes boissons (café, thé, chocolat chaud) avec des options de décoration telles que le lait, la crème, le sucre, etc. Nous voulons pouvoir ajouter ces options de décoration de manière flexible à nos boissons sans avoir à créer une classe distincte pour chaque combinaison possible de boissons et de décoration

```C#

using System;

interface IBreuvage
{
    string Description();
    double Cout();
}

class BreuvageSimple : IBreuvage
{
    public string Description()
    {
        return "Breuvage simple";
    }

    public double Cout()
    {
        return 1.0;
    }
}

abstract class DecorateurBreuvage : IBreuvage
{
    protected IBreuvage breuvage;

    public DecorateurBreuvage(IBreuvage breuvage)
    {
        this.breuvage = breuvage;
    }

    public virtual string Description()
    {
        return breuvage.Description();
    }

    public virtual double Cout()
    {
        return breuvage.Cout();
    }
}

class LaitDecorateur : DecorateurBreuvage
{
    public LaitDecorateur(IBreuvage breuvage) : base(breuvage) { }

    public override string Description()
    {
        return base.Description() + ", avec du lait";
    }

    public override double Cout()
    {
        return base.Cout() + 0.5; }
}

class SucreDecorateur : DecorateurBreuvage
{
    public SucreDecorateur(IBreuvage breuvage) : base(breuvage) { }

    public override string Description()
    {
        return base.Description() + ", avec du sucre";
    }

    public override double Cout()
    {
        return base.Cout() + 0.2;
    }
}
//code pour voir comment les utilisers
class Program
{
    static void Main(string[] args)
    {
        IBreuvage cafeSimple = new BreuvageSimple();
        Console.WriteLine("Café simple : " + cafeSimple.Description() + ", Coût : $" + cafeSimple.Cout());

        IBreuvage cafeAuLait = new LaitDecorateur(cafeSimple);
        Console.WriteLine("Café avec Lait : " + cafeAuLait.Description() + ", Coût : $" + cafeAuLait.Cout());

        IBreuvage cafeAuLaitAuSucre = new SucreDecorateur(cafeAuLait);
        Console.WriteLine("Café avec Lait et Sucre : " + cafeAuLaitAuSucre.Description() + ", Coût : $" + cafeAuLaitAuSucre.Cout());
    }
}

```