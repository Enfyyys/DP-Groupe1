# Patrons de création :

## Itérateur
![Design PAttern sauvegarde-Page-3 drawio](https://github.com/Enfyyys/DP-Groupe1/assets/105907677/08e21cb3-8fd6-4b75-9a6a-802d77489391)


### Présentation

Par défaut, la plupart des langages de programmation incluent des interfaces permettant d'itérer sur les collections d'objets. En C#, on peut itérer facilement sur les collections implémentant ICollection par exemple (List).
Cependant, le pattern Itérator permet de pousser cette possibilité à des types de collection particuliers, ou non conventionnels, en conservant les mêmes méthodes, et permet donc d'abstraire les algorithmes qui vont itérer dans les collections.

### Avantages

* Permet de respecter le principe de responsabilité unique (une classe doit avoir une seule responsabilité)
* On peut itérer une même collection avec plusieurs itérateurs, car instance a son propre pointeur.

### Inconvénients
* Inutile pour les collections courantes (List, Array...)
* Certaines collections spécialisées sont parfois plus efficace qu'un itérateur.

### Présentation UML



### Implémentation en C#

```C#
var stamps = new StampCollection();
stamps.CreateIterator();

public class Stamp
{
    public decimal Value { get; set; } = 1;

    public string Color { get; set; } = String.Empty;
}

public interface IIterator<out T>
{
    public T GetNext();
    public T GetActual();
    public void Reset();
}

public interface IObjectCollection<out T>
{
    public IIterator<T> CreateIterator();
}

public class StampIterator : IIterator<Stamp>
{
    public Stamp GetNext()
    {
        // Logic to get the next Stamp
        return new Stamp();
    }

    public Stamp GetActual()
    {
        // Get the actual Stamp
        return new Stamp();
    }

    public void Reset()
    {
        // Reset the cursor
    }
}

// Concrete collection
public class StampCollection : IObjectCollection<Stamp>
{
    public IIterator<Stamp> CreateIterator()
    {
        return new StampIterator();
    }
}
```
