## Command

### Présentation

Le design pattern Command permet de solutionner les problèmes liés aux dépendances entre les paramètres et l'exécution d'une tâche. Un bon exemple est la commande dans un restaurant. Bien qu'étant une action, une commande peut être réalisée par plusieurs serveurs différents ayant chacun leur manière de prendre la commande (tout retenir de tête, marquer sur un papier). Lors du repas, le client peut faire plusieurs commandes (d'abord l'entrée, puis le plat ... ou tout commander d'un coup). Si l'on cumule toutes les possibilités, l'implémentation d'un repas complet avec toutes les possibilités devient très complexe. Le pattern Command va encapsuler la notion d'execution dans une classe, et dissocier la partie action (command) des propriétés (qui peuvent être transportées avec l'action). Notons qu'une commande ne réalise pas forcement la tâche (c'est le rôle de la couche métier), mais donne toutes les informations nécessaires et déclenche l'execution ("le serveur prend la commande et la transmet en cuisine).

### Avantages

* Ajouter ce pattern prend sens lorsqu'il y a trop de couplage entre l'IHM et la couche métier. Il permet notamment de découpler l'action d'un bouton de la tâche qu'il réalise et d'apporter de nouvelles tâches sans détruire ce qui est déjà en place.

### Inconvénients

* Amène de la complexité au code et diminue sa lisibilité, ce qui peut être un frein sur de petits projets.

### Présentation UML

![chainOfResponsibility](https://github.com/Enfyyys/DP-Groupe1/assets/105907677/c612f508-3c82-4e14-9a8f-9d5dcbf336b3)


### Implémentation en C#

```C#
var customer = new Customer();
var starter = new StarterCommand();

customer.AddCommmand(starter);


public interface ICommand
{
    public void Ask();
}

public class StarterCommand : ICommand
{
    public void Ask()
    {
        Console.WriteLine("Customer wants its Starter !");
        Waiter.TakeStarterIntoAccount();
    }
}

public class MainCourseCommand : ICommand
{
    public void Ask()
    {
        Console.WriteLine("Customer wants its Main Course !");
        Waiter.TakeMainCourseIntoAccount();
    }
}

public class DessertCommand : ICommand
{
    public void Ask()
    {
        Console.WriteLine("Customer wants its Dessert !"); 
        Waiter.TakeDessertIntoAccount();
    }
}

public class Customer
{
    private List<ICommand> _commands = new();

    public void AddCommmand(ICommand command)
    {
        _commands.Add(command);
        command.Ask();
    }
}

public static class Waiter
{
    public static void TakeStarterIntoAccount()
    {
        Console.WriteLine("Chef will prepare the Starter");
    }

    public static void TakeMainCourseIntoAccount()
    {
        Console.WriteLine("Chef will prepare the Main Course");
    }

    public static void TakeDessertIntoAccount()
    {
        Console.WriteLine("Chef will prepare the Dessert");
    }
}
```
