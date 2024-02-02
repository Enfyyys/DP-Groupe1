## Observateur (Observer)

###  Présentation

Le design patterns Observer, permet d'inscrire un objet à un autre objet pour qu'il reçoive une "notification" pour signaler un modification de l'objet.

###  Avantage

- C'est facile d'ajouter de nouvelles classes souscripteur sans avoir à modifier le code du diffuseur.

###  Inconvénient

- Les souscripteurs sont avertis dans un ordre aléatoire.

###  UML

![Design PAttern sauvegarde-Page-6 drawio(2)](https://github.com/Enfyyys/DP-Groupe1/assets/105907677/f1ed9ef1-6139-4a1c-ba0e-b471c7d29432)

###  Exemple C#

```C#
var jeanluc = new JeanLuc();
var marcel = new Marcel();

var sortieJurassikPark = new SortieJurassikPark();

sortieJurassikPark.Attach(jeanluc);
sortieJurassikPark.Attach(marcel);

sortieJurassikPark.Notify();

public interface IPersonne
{
    void Update(ISortieFilm sortieFilm);
}

public interface ISortieFilm
{
    void Attach(IPersonne personne);
    void Detach(IPersonne personne);
    
    void Notify();
}

public class SortieJurassikPark : ISortieFilm
{
    
    public int State { get; set; } = -0;
    
    private List<IPersonne> _observers = new();

    // The subscription management methods.
    public void Attach(IPersonne personne)
    {
        Console.WriteLine($"{personne.GetType()} est inscrit pour la date de sortie !");
        _observers.Add(personne);
    }

    public void Detach(IPersonne personne)
    {
        _observers.Remove(personne);
    }
    
    public void Notify()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Jurassik Park est sorti dans tous les cinémas !");

        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
}

class JeanLuc : IPersonne
{
    public void Update(ISortieFilm sortieFilm)
    {
        Console.WriteLine("Jean-Luc : J'ai hâte de voir la scène avec la chèvre !");
    }
}

class Marcel : IPersonne
{
    public void Update(ISortieFilm sortieFilm)
    {
        Console.WriteLine("Marcel : Whopopo il était temps !");
    }
}
```