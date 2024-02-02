## Prototype

### Présentation

Le design pattern Prototype est un modèle de conception qui permet de créer de nouveaux objets en copiant un objet existant, appelé prototype. Au lieu de créer un nouvel objet à partir de zéro, le prototype sert de modèle, et la copie est effectuée pour produire un nouvel objet. Cela peut être utile lorsque la création d'un objet est coûteuse en termes de ressources et qu'il existe déjà un objet similaire à utiliser comme modèle.

En termes simples :
* Le Prototype permet de créer de nouveaux objets en copiant des prototypes existants.
* Il évite la création d'objets à partir de zéro, en utilisant un objet existant comme modèle.
* Cela peut être utile lorsque la création d'un objet est coûteuse ou complexe.

### Avantages

* Création d'objets complexes : Permet de créer des objets complexes plus efficacement en clonant des instances existantes plutôt qu'en les construisant à partir de zéro.
* Réduction de la duplication de code : Évite la duplication de code liée à la création d'objets en permettant de cloner des prototypes plutôt que de recréer des objets similaires.

* ### Inconvénients

* Surcharge mémoire : Si les objets à cloner sont volumineux, cela peut entraîner une surcharge de la mémoire, car chaque clone occupe de l'espace mémoire distinct.
* Gestion des références : Les objets clonés peuvent partager des références à des objets internes, ce qui peut nécessiter une gestion minutieuse pour éviter des effets indésirables.

### Présentation UML

Dans cet exemple, la classe Person implémente l'interface ICloneable avec une méthode Clone() qui effectue une copie superficielle de l'objet. Le client crée un prototype de personne et le clone pour créer une nouvelle personne.

![image](https://github.com/Enfyyys/DP-Groupe1/assets/90694706/16c0202a-894e-4895-8c6d-f722f2019a68)

### Implémentation en C#

```C#
// Prototype : Interface définissant la méthode de clonage
interface ICloneable
{
    ICloneable Clone();
}

// ConcretePrototype : Implémente l'interface ICloneable pour cloner une personne
class Person : ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }

    public ICloneable Clone()
    {
        // Utilisation du MemberwiseClone pour créer une copie superficielle
        return (ICloneable)MemberwiseClone();
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

// Client
class Program
{
    static void Main()
    {
        // Création d'un prototype de personne
        Person prototypePerson = new Person { Name = "John Doe", Age = 30 };

        // Clonage du prototype pour créer une nouvelle personne
        Person clonedPerson = (Person)prototypePerson.Clone();

        // Modification de la personne clonée
        clonedPerson.Name = "Jane Doe";

        // Affichage des informations des deux personnes
        Console.WriteLine("Original Person:");
        prototypePerson.DisplayInfo();

        Console.WriteLine("\nCloned Person:");
        clonedPerson.DisplayInfo();
    }
}

```