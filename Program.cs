using ProjetSauvegardeFichiers.Facade;

namespace ProjetSauvegardeFichiers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Définition du chemin et du contenu initial du fichier texte
            string cheminFichier = "monFichier.txt";
            string contenuInitial = "Ceci est le contenu original du fichier.";

            // Création de l'instance de la façade de sauvegarde
            // La façade orchestre la création du fichier texte et l'application des décorateurs.
            SauvegardeManager sauvegarde = new SauvegardeManager();

            // Lancement de la sauvegarde avec application de la compression et du chiffrement.
            // Les deux décorateurs sont appliqués dans l'ordre : compression puis chiffrement.
            bool resultat = sauvegarde.SauvegarderFichier(cheminFichier, contenuInitial, true, true);

            // Affichage du résultat de la sauvegarde
            Console.WriteLine(resultat ? "La sauvegarde a réussi." : "La sauvegarde a échoué.");
        }
    }
}