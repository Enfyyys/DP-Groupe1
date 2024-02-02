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