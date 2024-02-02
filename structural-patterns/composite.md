## Composite

### Présentation 

Composite est un patron de conception structurel qui permet d’agencer les objets dans des arborescences afin de pouvoir traiter celles-ci comme des objets individuels. Et permet de concevoir une structure arborescente, par exemple une représentation d'un dossier, ses sous-dossiers et leurs fichiers.

### Avantages

Il permet de traiter à la fois les objets individuels et les compositions d'objets de manière uniforme, ce qui facilite la manipulation des structures arborescentes.

Le design pattern Composite permet d'ajouter de nouveaux types d'objets sans changer le code client existant. Cela rend le système plus flexible et extensible.

 Les composants peuvent être réutilisés à différents niveaux de la hiérarchie, ce qui favorise la réutilisation du code.

 ### Inconvénient

 Dans certains cas, l'utilisation du design pattern Composite peut entraîner une perte de performance en raison de la manipulation d'une structure arborescente plutôt que d'une structure plate.

 La mise en œuvre du design pattern Composite peut introduire une certaine complexité, surtout si la hiérarchie est profonde et complexe.

  Une structure hiérarchique complexe peut rendre la compréhension du code plus difficile pour les développeurs qui n'ont pas été impliqués dans la conception initiale.

  ### Présention UML

![image](https://github.com/Enfyyys/DP-Groupe1/assets/144044265/6440df2d-01cb-4b36-bc5a-500a54b9e18a)

  ### Implémentation en C#

  
Considérons un scénario simple où on doit modéliser une entreprise avec des employés. Chaque employé peut être soit un individu unique, soit un groupe d'employés. On utilisera le design pattern Composite pour représenter cette structure hiérarchique

```C#

public interface IEmploye
{
    string Nom { get; }
    double Salaire { get; }
}

public class EmployeIndividuel : IEmploye
{
    public string Nom { get; }
    public double Salaire { get; }

    public EmployeIndividuel(string nom, double salaire)
    {
        Nom = nom;
        Salaire = salaire;
    }
}

public class GroupeEmployes : IEmploye
{
    private List<IEmploye> membres = new List<IEmploye>();

    public string Nom { get; }
    public double Salaire
    {
        get
        {
            double totalSalaire = 0;
            foreach (var membre in membres)
            {
                totalSalaire += membre.Salaire;
            }
            return totalSalaire;
        }
    }

    public GroupeEmployes(string nom)
    {
        Nom = nom;
    }

    public void AjouterMembre(IEmploye employe)
    {
        membres.Add(employe);
    }

    public void AfficherStructure(int niveau = 0)
    {
        Console.WriteLine(new string('-', niveau) + $"Groupe: {Nom}, Salaire total: {Salaire}");
        foreach (var membre in membres)
        {
            membre.AfficherStructure(niveau + 2);
        }
    }
}

```