# Patrons comportementaux :

## Visitor

### Présentation
Lorsque la structure de l’objet est composée de nombreuses classes et que de nouvelles opérations sont souvent nécessaires, il est très laborieux pour les développeurs de devoir implémenter une nouvelle sous-classe pour chaque nouvelle opération. En procédant de la sorte, le système obtenu disposerait de différentes classes de nœud qui seraient non seulement trop compliquées à comprendre mais aussi à entretenir et à modifier. L’instance décisive du Visitor pattern, le visiteur (Visitor), permet d’ajouter de nouvelles fonctionnalités virtuelles à une famille de classes sans avoir à les modifier.

### Avantages
* Respect des règles SOLID et notamment la responsabilité unique des classes et le principe Ouvert/Fermé (Fermé à la modification, ouvert à l'extension des classes)
* On peut parcourir des objets complexes sans apporter de complexité aux classes associées
* 
### Inconvénients
* Pas forcement simple pour le visiteur d'accéder aux attributs privés d'une classe.
* Les visiteurs doivent être mis à jour à chaque fois que les classes Elements sont mises à jour. Ceci apporte une dépendance.

### Présentation UML
![Design PAttern sauvegarde-Page-5 drawio](https://github.com/Enfyyys/DP-Groupe1/assets/105907677/8c79a615-8046-43ea-be9a-49f8fed4f6c1)


### Implémentation en C#

```CS


var chaise = new Chaise();
var table = new Table();

var ebeniste = new Ebeniste();
var menuisier = new Menuisier();

chaise.Accept(ebeniste);
chaise.Accept(menuisier);

table.Accept(menuisier);

public interface IElement
{
    public void Accept(IVisitor visitor);
}

public interface IVisitor
{
    public void Visit(Chaise chaise);
    public void Visit(Table chaise);
}

public class Chaise : IElement
{
    public void Accept(IVisitor visitor)
    {
        Console.WriteLine($"{visitor.GetType()} a le contrôle total sur la chaise !");
        visitor.Visit(this);
    }
}

public class Table : IElement
{
    public void Accept(IVisitor visitor)
    {
        Console.WriteLine($"{visitor.GetType()} a le contrôle total sur la table !");
        visitor.Visit(this);
    }
}

public class Ebeniste : IVisitor
{
    public void Visit(Chaise chaise)
    {
        Console.WriteLine($"L'ébéniste répare la {chaise.GetType()}");
    }

    public void Visit(Table table)
    {
        Console.WriteLine($"L'ébéniste répare la {table.GetType()}");
    }
}

public class Menuisier : IVisitor
{
    public void Visit(Chaise chaise)
    {
        Console.WriteLine($"Le menuisier répare la {chaise.GetType()}");
    }

    public void Visit(Table table)
    {
        Console.WriteLine($"Le menuisier répare la {table.GetType()}");
    }
}

```
