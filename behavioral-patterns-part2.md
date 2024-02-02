## Etat (State)

### Présentation

Le DP Etat, permet de travailler avec des état avec les objets.
Un objet a donc un état defini dans un objet.

### Avantage

- Principe de responsabilité unique
- Ajoutez de nouveaux états sans modifier les classes état ou le contexte existants.
- Simplifiez le code du contexte en éliminant les gros blocs conditionnels.

### Inconvénient

- Trop complexe pour des automate simple.

### UML

![Etat_UML](https://github.com/Enfyyys/DP-Groupe1/assets/103527909/5f7740eb-c8e3-47c9-aa01-397ada169127)

### Exemple C#

```C#

class Plante
    {
        private Etat etat;

        public Plante()
        {
            this.etat = new En_vie(this);
        }

        public void changer_etat(Etat etat)
        {
            this.etat = etat;
        }
    }

    abstract class Etat
    {
        public Plante plant;

        public Etat(Plante plant)
        {
            this.plant = plant;
        }

        public abstract void Arroser();//Lance la lecture de la video

        public abstract void Photosynthese();//Met la video en pause

        public abstract void Transformation_engrais();//Arrete la lecture de la video

        public abstract void Enleve_les_racine();

    }

    class En_vie : Etat
    {

        public En_vie(Plante plant): base(plant)
        {
           
        }

        public override void Arroser()
        {
            Console.WriteLine("Plante arrosé");//arrose la plante
        }

        public override void Photosynthese()
        {
            Console.WriteLine("photosynthese possible");//Fait de la photosynthese
        }

        public override void Enleve_les_racine()
        {
            plant.changer_etat(new Morte(plant)); //Change l'etat de la plante
        }

        public override void Transformation_engrais()
        {
            plant.changer_etat(new Engrais(plant));//Change l'etat de la plante
        }
    }

    class Morte : Etat
    {
        public Morte(Plante plant) : base(plant)
        {

        }

        public override void Arroser()
        {
            //Fonction impossible a faire dans l'etat actuel
        }

        public override void Photosynthese()
        {
            //Fonction impossible a faire dans l'etat actuel
        }

        public override void Transformation_engrais()
        {
            plant.changer_etat(new Engrais(plant));//Change l'etat de la plante
        }

        public override void Enleve_les_racine()
        {
            //Fonction impossible a faire dans l'etat actuel
        }
    }

    class Engrais : Etat
    {

        public Engrais(Plante plant) : base(plant)
        {

        }

        public override void Arroser()
        {
            //Fonction impossible a faire dans l'etat actuel
        }

        public override void Photosynthese()
        {
            //Fonction impossible a faire dans l'etat actuel
        }
        public override void Transformation_engrais()
        {
            //Fonction impossible a faire dans l'etat actuel
        }

        public override void Enleve_les_racine()
        {
            //Fonction impossible a faire dans l'etat actuel
        }
    }

```

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

## Stratégie (Strategy)

### Présentation

Le design patterns Stratégie permet de définir une famille d’algorithmes, de les mettre dans des classes séparées et de rendre leurs objets interchangeables.

### Avantage

- On peut permuter l’algorithme utilisé à l’intérieur d’un objet à l’exécution.
- On peut séparer les détails de l’implémentation d’un algorithme et le code qui l’utilise.
- On peut ajouter de nouvelles stratégies sans avoir à modifier le contexte.

### Inconvénient

### UML

![UML_Strategy](https://github.com/Enfyyys/DP-Groupe1/assets/103527909/5bd83704-b492-4b61-964e-641af4b4b23e)

### Exemple C#

```C#
using System;

public class Program
{
    public interface Compression
    {
        void CompressFolder(string compressedArchiveFileName);
    }

    public class CompressionContext
    {
        private Compression Compression;

        public CompressionContext(Compression Compression)
        {
            this.Compression = Compression;
        }

        public void SetStrategy(Compression Compression)
        {
            this.Compression = Compression;
        }

        public void CreateArchive(string compressedArchiveFileName)
        {
            Compression.CompressFolder(compressedArchiveFileName);
        }
    }

    public class RarCompression : Compression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine(
                "Le dossier est compresser en utilisant Rar '"
                    + compressedArchiveFileName
                    + ".rar' est créer"
            );
        }
    }

    public class TarCompression : Compression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine(
                "Le dossier est compresser en utilisant Rar '"
                    + compressedArchiveFileName
                    + ".tar' est créer"
            );
        }
    }

    public class ZipCompression : Compression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine(
                "Le dossier est compresser en utilisant Rar '"
                    + compressedArchiveFileName
                    + ".zip' est créer"
            );
        }
    }

    public static void Main()
    {
        ///On change la stratégie en zip
        CompressionContext ctx = new CompressionContext(new ZipCompression());
        ctx.CreateArchive("DotNetDesignPattern");
        // On change pour la stratégie en Rarr
        ctx.SetStrategy(new RarCompression());
        ctx.CreateArchive("DotNetDesignPattern");
        // On change pour la stratégie en Tar
        ctx.SetStrategy(new TarCompression());
        ctx.CreateArchive("DotNetDesignPattern");
        Console.Read();
    }
}
```


## Patron de méthode ( Méthode socle, Template Method)

### Présentation

Le design patterns Patron de méthode permet de mettre le squelette d’un algorithme dans la classe mère, mais laisse les sous-classes redéfinir certaines étapes de l’algorithme sans changer sa structure.

### Avantage

- On permet aux clients de redéfinir certaines parties d’un grand algorithme. Elles sont ainsi moins affectées par les modifications apportées aux autres parties de l’algorithme.
- On peut remonter le code dupliqué dans la classe mère.

### Inconvénient

### UML

![UML_Patron_de_Methode](https://github.com/Enfyyys/DP-Groupe1/assets/103527909/f7b92e6b-a7dc-4497-a181-4964b3863bb8)

### Exemple C#

```C#
using System;

public class Program
{
    
	abstract class Construire_maison
    {
		public void Construire()
        {
			this.Faire_les_fondations();
			this.Poser_le_sol();
			this.monter_les_murs();
			this.Posez_le_toit();
        }
		
        protected virtual void Faire_les_fondations()
        {
            Console.WriteLine("Fondation posée");
        }
		protected virtual void Poser_le_sol()
        {
            Console.WriteLine("Sol posée");
        }
		protected virtual void monter_les_murs()
        {
            Console.WriteLine("Mur monté");
        }
		protected virtual void Posez_le_toit()
        {
            Console.WriteLine("Toit posée");
        }
    }
	
	class Construire_un_immeuble : Construire_maison
	{
		protected override void monter_les_murs()
        {
            Console.WriteLine("Mur monté");
        }
		protected override void Posez_le_toit()
        {
            Console.WriteLine("Toit posée");
        }
	}
	
	class Construire_un_bunker : Construire_maison
	{
		protected override void monter_les_murs()
        {
            Console.WriteLine("Mur monté");
        }
		protected override void Posez_le_toit()
        {
            Console.WriteLine("Toit posée");
        }
		protected override void Faire_les_fondations()
        {
            Console.WriteLine("Fondation posée");
        }
	}

    class Client{
		public void Construire(Construire_maison construire_maison){
			construire_maison.Construire();
		}
	}
	
    public static void Main()
    {
        var client = new Client();
		client.Construire(new Construire_un_immeuble());
		client.Construire(new Construire_un_bunker());
    }
}

```
