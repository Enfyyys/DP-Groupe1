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
