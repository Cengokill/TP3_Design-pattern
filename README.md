# TP3_Design-pattern
# Projet : Gestion de Sauvegarde de Fichiers

## Description
Ce projet implémente un système de sauvegarde de fichiers avec les fonctionnalités suivantes :

- **Enregistrement de fichiers texte** : permet de sauvegarder un fichier avec un contenu donné.
- **Application dynamique de transformations** : possibilité de compresser ou de chiffrer le fichier avant la sauvegarde.
- **Utilisation du pattern Décorateur** : permet d'ajouter des fonctionnalités (compression, chiffrement) de manière flexible sans modifier la structure de base du fichier.
- **Utilisation du pattern Façade** : simplifie l'utilisation du système en offrant une interface unique pour sauvegarder un fichier avec ou sans transformations.

## Structure du Projet
Le projet est structuré en plusieurs composants :

- **Core/** : Contient la classe de base `FichierTexte` qui représente un fichier simple.
- **Decorators/** : Contient les décorateurs `CompressionDecorator` et `ChiffrementDecorator` qui modifient dynamiquement le comportement de `FichierTexte`.
- **Facade/** : Contient `SauvegardeFacade`, qui simplifie l'accès aux fonctionnalités du système en gérant la création et l'application des décorateurs.
- **Program.cs** : Contient un test qui crée un fichier texte, applique les décorateurs dynamiquement et utilise `SauvegardeManager` pour sauvegarder le fichier.

## Installation et Exécution
### Prérequis
- .NET SDK installé (version 8.0 ou supérieure recommandée)
- Un éditeur C# comme Visual Studio ou Jetbrains Rider

### Instructions d'exécution
1. **Cloner le projet** :
   ```sh
   git clone https://github.com/Cengokill/TP3_Design-pattern.git
   cd sauvegarde-fichier
   ```
2. **Compiler et exécuter** :
   ```sh
   dotnet run
   ```
3. **Résultat attendu** :
   - Un fichier `monFichier.txt` sera créé.
   - Si la compression et le chiffrement sont activés, le fichier sera compressé et chiffré avant d'être sauvegardé.
   - La console affichera `La sauvegarde a réussi.` en cas de succès.

## Exemples d'utilisation
Dans `Program.cs`, un test est réalisé :
```csharp
string cheminFichier = "monFichier.txt";
string contenuInitial = "Ceci est le contenu original du fichier.";
SauvegardeManager sauvegarde = new SauvegardeManager();
bool resultat = sauvegarde.SauvegarderFichier(cheminFichier, contenuInitial, false, true);
Console.WriteLine(resultat ? "La sauvegarde a réussi." : "La sauvegarde a échoué.");
```

## Auteurs
- **Killian** - Développeur principal

