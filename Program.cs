using ProjetSauvegardeFichiers.Facade;

namespace ProjetSauvegardeFichiers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user for the file name
            Console.WriteLine("Entrez le nom du fichier :");
            string cheminFichier = Console.ReadLine() ?? "monFichier"; // Default to "monFichier.txt" if input is null

            // Prompt the user for the file content
            Console.WriteLine("Entrez le contenu du fichier :");
            string contenuInitial = Console.ReadLine() ?? "Contenu par défaut"; // Default to "Contenu par défaut" if input is null

            // Ask the user if they want to apply compression
            Console.WriteLine("Voulez-vous appliquer la compression ? (o/n) :");
            bool appliquerCompression = Console.ReadLine()?.Trim().ToLower() == "o";

            // Ask the user if they want to apply encryption
            Console.WriteLine("Voulez-vous appliquer le chiffrement ? (o/n) :");
            bool appliquerChiffrement = Console.ReadLine()?.Trim().ToLower() == "o";

            // Création de l'instance de la façade de sauvegarde
            SauvegardeManager sauvegarde = new();

            // Lancement de la sauvegarde avec les options choisies
            bool resultat = sauvegarde.SauvegarderFichier(cheminFichier, contenuInitial, appliquerCompression, appliquerChiffrement);

            // Affichage du résultat de la sauvegarde
            Console.WriteLine(resultat ? "La sauvegarde a réussi." : "La sauvegarde a échoué.");
        }
    }
}