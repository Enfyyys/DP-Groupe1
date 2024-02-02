## Chaine de responsabilité

### Présentation

La chaîne de responsabilité répond à une problématique métier dans laquelle une requete doit être traitée différemment selon son contenu et devra passer successivement par différents process. Un exemple concret peut être le tunnel de vente. Une commande doit d'abord être validée, puis payée et enfin envoyée. Si la méthode de transport change (transporteur, changement de dépôt logistique), ou si une nouvelle plateforme bancaire est ajoutée, le code peut rapidement devenir complexe. L'idée est donc de créer des objets appelés "handler" qui accederont à la resource et qui ne connaitront que le handler suivant. Ainsi, chaque handler qui reçoit la resource (validation, paiement...) pourra la manipuler et la passer (ou non) au prochain handler, jusqu'à obtenir le résultat (envoi du colis). 

### Avantages

* Ajouter un traitement dans la chaîne consiste à créer une classe qui va contenir le handler et définir le handler suivant (on les "connecte").
* A l'inverse, supprimer un handler se fera aussi simplement.
* On s'assure qu'une resource passera par un premier traitement avant un autre traitement (on ne paye pas tant qu'une commande n'est pas validée).

### Inconvénients
* Ajoute de la complexité qui diminue la lisibilité du code ou le debugage du code.
* Il peut arriver de perdre un maillon dans la chaîne si la définition des maillons n'est pas correctement réalisée.

### Présentation UML
![chainOfResponsibility](https://github.com/Enfyyys/DP-Groupe1/assets/105907677/c612f508-3c82-4e14-9a8f-9d5dcbf336b3)


### Implémentation en C#

```C#
var order = new List<string>();
Console.WriteLine(order.Count);

var validation = new ValidationHandler();
var payment = new PaymentHandler();
var shipping = new ShippingHandler();

validation.SetNext(payment);
payment.SetNext(shipping);

var result = validation.Handle(order);

Console.WriteLine(result.Count);

public interface ISalesFunnelHandler
{
    public void SetNext(ISalesFunnelHandler nextHandler);

    public List<string> Handle(List<string> order);
}

public abstract class BaseSalesFunnelHandler : ISalesFunnelHandler
{
    protected ISalesFunnelHandler? _nextHandler;

    public void SetNext(ISalesFunnelHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract List<string> Handle(List<string> order);
}

public class ValidationHandler : BaseSalesFunnelHandler
{
    public override List<string> Handle(List<string> order)
    {
        order.Add("Valide");
        if (_nextHandler is not null)
        {
            return _nextHandler.Handle(order);
        };
        return order;
    }
}

public class PaymentHandler : BaseSalesFunnelHandler
{
    public override List<string> Handle(List<string> order)
    {
        order.Add("Payed");
        if (_nextHandler is not null)
        {
            return _nextHandler.Handle(order);
        };
        return order;
    }
}

public class ShippingHandler : BaseSalesFunnelHandler
{
    public override List<string> Handle(List<string> order)
    {
        order.Add("Shipped");
        if (_nextHandler is not null)
        {
            return _nextHandler.Handle(order);
        };
        return order;
    }
}
```
