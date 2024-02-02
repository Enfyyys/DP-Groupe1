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