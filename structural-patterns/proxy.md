## Procuration / Proxy

### Présentation 

Un proxy est une classe se substituant à une autre classe. Par convention et simplicité, le proxy implémente la même interface que la classe à laquelle il se substitue. Un proxy est utilisé principalement pour contrôler l'accès aux méthodes de la classe substituée.

En termes simples :
* Le pattern Proxy introduit un objet intermédiaire qui agit comme un substitut à un autre objet.
* Le proxy peut contrôler l'accès, effectuer des opérations supplémentaires avant ou après l'accès, etc.

### Avantages

* Contrôle d'accès : Le proxy peut restreindre l'accès à l'objet réel.
* Gestion d'objets lourds : Le proxy peut retarder la création ou le chargement d'objets coûteux jusqu'à ce qu'ils soient réellement nécessaires.

### Inconvénient

* Complexité accrue : L'ajout d'une couche de proxy peut introduire de la complexité.

### Présentation UML

Dans cet exemple, le client utilise le Proxy pour accéder au RealSubject. Le Proxy crée l'objet RealSubject uniquement lorsque la méthode Request est appelée, ce qui peut être utile pour économiser des ressources si la création de l'objet réel est coûteuse.

![image](https://github.com/Enfyyys/DP-Groupe1/assets/90694706/94ac6646-903b-45a4-bacc-248533126102)

### Implémentation en C#

```C#
// Interface du sujet
public interface ISubject
{
    void Request();
}

// Implémentation du sujet réel
public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("Traitement effectué par le sujet réel.");
    }
}

// Implémentation du proxy
public class Proxy : ISubject
{
    private RealSubject realSubject;

    public void Request()
    {
        // Création de l'objet réel seulement si nécessaire
        if (realSubject == null)
        {
            realSubject = new RealSubject();
        }

        // Utilisation du sujet réel
        realSubject.Request();
    }
}

class Program
{
    static void Main()
    {
        // Utilisation du proxy pour accéder au sujet
        ISubject proxy = new Proxy();
        proxy.Request();
    }
}

```