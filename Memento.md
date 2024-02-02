# Patrons comportementaux :

## Memento

### Présentation
Le memento est un design pattern qui permet de sauvegarder un état à un moment donné. La classe qui gère les propriétés que l'on veut sauvegarder (Originator) a avoir la responsabilité de faire une capture de son état, et de sauvegarder cet état dans une classe (Memento). Ensuite, une classe CareTaker va se charger de gérer tous ces mementos.

### Avantages
* Permet de mettre en place le "retour en arrière" sur un état quelconque. On prendra dans l'exemple suivant le cas d'un escalier que l'on monte (sous forme d'une chaîne de caractères).
* On peut garder l'encapsulation de l'objet que l'on veut sauvegarder

### Inconvénients
* A utiliser avec précaution car cela peut amener à consommer beaucoup de mémoire vive si ce pattern fait trop souvent de sauvegardes.

### Présentation UML
![Design PAttern sauvegarde-Page-5 drawio](https://github.com/Enfyyys/DP-Groupe1/assets/105907677/8c79a615-8046-43ea-be9a-49f8fed4f6c1)


### Implémentation en C#

```C#
// On prendra pour exemple un escalier que l'on grimpe (la chaîne de caractère s'allonge)
var initialState = "_|";

// On définit l'état initial
var originator = new Originator(initialState);
var careTaker = new Caretaker(originator);

careTaker.Backup(); // sauvegarde initiale

originator.GrimpeUneMarche();
originator.GrimpeUneMarche();

careTaker.Backup(); // sauvegarde
careTaker.ShowHistory();

originator.GrimpeUneMarche();
originator.GrimpeUneMarche();
careTaker.Backup(); // sauvegarde
careTaker.ShowHistory();

// Problème : on a fait une bêtise, on revient en arrière
careTaker.Undo();
careTaker.ShowHistory();

class Originator
{
    private string _state;

    public Originator(string state)
    {
        this._state = state;
        Console.WriteLine("Originator: Voilà où j'en suis actuellement : " + state);
    }
    
    public void GrimpeUneMarche()
    {
        Console.WriteLine("Je grimpe une marche");
        _state += " _|";
        Console.WriteLine($"Voici mon avancement dans l'escalier : {_state}");
    }
    
    public IMemento Save()
    {
        return new ConcreteMemento(_state);
    }
    
    public void Restore(IMemento memento)
    {
        _state = memento.GetState();
        Console.WriteLine($"Originator: Je suis redescendu, voici où j'en suis : {_state}");
    }
}

public interface IMemento
{
    string GetState();

    DateTime GetDate();
}

class ConcreteMemento : IMemento
{
    private string _state;

    private DateTime _date;

    public ConcreteMemento(string state)
    {
        _state = state;
        _date = DateTime.Now;
    }
    
    public string GetState()
    {
        return _state;
    }

    public DateTime GetDate()
    {
        return _date;
    }
}

class Caretaker
{
    private List<IMemento> _mementos = new();

    private Originator _originator = null;

    public Caretaker(Originator originator)
    {
        _originator = originator;
    }

    public void Backup()
    {
        Console.WriteLine("\nCaretaker: Sauvegarde de l'avancement dans l'escalier");
        _mementos.Add(_originator.Save());
    }

    public void Undo()
    {
        if (_mementos.Count == 0)
        {
            return;
        }

        var memento = _mementos.Last();
        this._mementos.Remove(memento);

        Console.WriteLine(
            $"Caretaker: On revient à l'état du {memento.GetDate().ToString()}. L'état était : {memento.GetState()} ");

        try
        {
            _originator.Restore(memento);
        }
        catch (Exception)
        {
            Undo();
        }
    }

    public void ShowHistory()
    {
        Console.WriteLine("Caretaker: Voici la liste des sauvegardes :");

        foreach (var memento in _mementos)
        {
            Console.WriteLine($"{memento.GetDate().ToString()} : {memento.GetState()}");
        }
    }
}
```
