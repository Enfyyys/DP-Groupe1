# Patrons de création :

## Fabrique / Factory Method

### Présentation

Fabrique est un patron de conception de création qui définit une interface pour créer des objets dans une classe mère, mais délègue le choix des types d’objets à créer aux sous-classes.

### Avantages

* Noms descriptifs : Les méthodes de fabrication n'ont pas l'obligation d'avoir un nom de constructeur identique au nom de la classe, ce qui perment d'avoir un nom qui décrit mieux leur fonction.
* Encapsulation : Les méthodes de fabrication permettent d'encapsuler la création des objets, en utilisant par exemple un switch sur le type d'un objet au lieu de faire une fonction par type d'objet.

### Présentation UML

![image](https://github.com/Enfyyys/DP-Groupe1/assets/90694706/e9857c25-86a7-4c0c-8715-923a31323382)

### Implémentation en C#

```
public class FabriqueVehicule {

  Vehicule create(String typeVehicule) throws VehiculeCreationException {
    if(typeVehicule.equals("voiture")) {
      return new Voiture();
    } 
    else if(typeVehicule.equals("moto")) {
      return new Moto();
    } 
    throw new VehiculeCreationException("Impossible de créer une " + typeVehicule);
  }
}
```
