# Patrons de Structure :

## Adaptateur

### Présentation 
<p>L’Adaptateur est un patron de conception structurel qui permet de faire collaborer des objets ayant des interfaces normalement incompatibles. </p>

<p>L’adaptateur fait fonctionner ensemble des classes qui n'auraient pas pu fonctionner sans lui, à cause d'une incompatibilité d'interfaces. Il permet donc de se faire comprendre par son destinataire, il fait office d'intermédiaire. </p>

<p> Cela peut arriver aussi que l'adaptateur ait la fonction d'adapter dans les 2 sens afin que les 2 partie normalement incompatible puissent se comprendre</p>


### Avantages

<p> Tout d'abord il y a le <strong>principe de Responsabilitée</strong>. Cela indique que grâce au code de l'adaptateur on peut découpler l’interface ou le code de conversion des données (soit l'adaptateur), de la logique métier du programme.</p>

<p>il y a aussi le <strong>Principe ouvert / fermé</strong> permettant d'ajouter sans trop de modification de nouveaux type d'adaptateurs.</p>

### Inconvénient

<p>La compléxité du code augmente car cela nécéssite de créer un ensemble d'interface et de nouvelles classes. Parfois il vaut mieux changer le code pour s'adapter au service.</p>


### Présentation UML

<img src='./UML_Adaptateur.jpg'/>

### Implémentation en C#


<p> Pour la situation, on va imaginer qu'on utilise un service pour tracer des formes géométriques et calculer des aires. On a déjà de quoi faire pour tracer des rectangles et calculer leurs aires dans la classe Rectangle. Cependant le service qu'on utilise contient des méthodes qui sont assez similaire aux nôtre. Pour s'adapter et éviter de modifier la classe Rectangle on va faire un Adaptateur pour intégrer le service ayant la classe forme qui possède les méthodes à implémenter. 

Ci dessous l'UML de la situation donné (pour voir le code qui va avec il faut se reporter sur le fichier Adaptateur.cs) </p>

```

 public interface Forme {
    double calculerAire();
    void dessiner();
}

public interface Rectangle {
    double calculerSurface();
    void tracerRectangle();
}


public class Adaptateur implements Forme {
    private Rectangle rectangle;

    public Adaptateur(Rectangle rectangle) {
        this.rectangle = rectangle;
    }

    @Override
    public double calculerAire() {
        return rectangle.calculerSurface();
    }

    @Override
    public void dessiner() {
        rectangle.tracerRectangle();
    }
}
```


## Pont

### Présentation

Le design pattern Bridge est un modèle structurel qui permet de séparer l'abstraction d'une classe de son implémentation, de sorte que les deux puissent évoluer indépendamment. 

### Avantages

Cela permet d'avoir des applications multiplateforme

Avec le principe ouvert / fermé, cela rend facile l'implémentation de nouvelles abstractions et implémentations indépendamment les unes des autres. 

Il est possible de se concentrer sur la logique de haut niveau dans l’abstraction, et sur les détails de la plateforme dans l’implémentation.

### Inconvénient

Cela rajoute une couche supplémentaire d'abstraction et le rend plus difficile à comprendre. Il est souvent plus utile sur les plus gros projets car sur des plus petits ce n'est pas forcément nécéssaire.

Cela peu rajouter beaucoup de classes et d'implémentation dans le code et demande alors une gestion plus complexe.

Avec l'implémentation de classes, cela rend plus difficile la maintenance de celles-ci où il peut être nécessaire de mettre à jour plusieurs classes en même temps.

Pour les développeurs qui ne sont pas familiers avec le pattern Bridge, son utilisation peut nécessiter un apprentissage initial. Il peut être perçu comme moins intuitif que des approches plus simples, ce qui peut entraîner une courbe d'apprentissage.

### Présentation UML

<img src="./UML_Bridge.jpg"/>

### Implémentation en C#

Dans ce contexte, on veux faire des carrés et des cercles qu'on  souhaite afficher avec différentes couleurs. Plutôt que de lier étroitement les formes aux couleurs, elles sont conçus indépendemment afin de pouvoir rajouter facilement de nouvelles classes (formes où couleurs). Ainsi il sera facile d'ajouter au besoin de nouvelles fonctionnalités avec moins d'implémentation et de classes.
```
public interface IColoration
{
    void Colorier();
}

public class ColorationRouge : IColoration
{
    public void Colorier()
    {
        Console.WriteLine("Coloration en Rouge");
    }
}

public class ColorationBleu : IColoration
{
    public void Colorier()
    {
        Console.WriteLine("Coloration en Bleu");
    }
}

public abstract class Forme
{
    protected IColoration Coloration;

    protected Forme(IColoration coloration)
    {
        Coloration = coloration;
    }

    public abstract void Afficher();
}

public class Cercle : Forme
{
    public Cercle(IColoration coloration) : base(coloration)
    {
    }

    public override void Afficher()
    {
        Console.Write("Cercle ");
        Coloration.Colorier();
    }
}

public class Carre : Forme
{
    public Carre(IColoration coloration) : base(coloration)
    {
    }

    public override void Afficher()
    {
        Console.Write("Carré ");
        Coloration.Colorier();
    }
}

class Program
{
    static void Main()
    {
        IColoration colorationRouge = new ColorationRouge();
        IColoration colorationBleu = new ColorationBleu();

        Forme cercle = new Cercle(colorationRouge);
        Forme carre = new Carre(colorationBleu);

        cercle.Afficher(); 
        carre.Afficher();
    }
}

```