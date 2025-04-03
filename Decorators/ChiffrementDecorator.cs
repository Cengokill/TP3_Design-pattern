using System;
using System.Text;
using ProjetSauvegardeFichiers.Core;

namespace ProjetSauvegardeFichiers.Decorators
{
    /// <summary>
    /// Décorateur concret qui ajoute une fonctionnalité de chiffrement à un fichier.
    /// Implémente le pattern Decorator en héritant de FichierTexte.
    /// </summary>
    public class ChiffrementDecorator : FichierTexte
    {
        private readonly FichierTexte Fichier;

        /// <summary>
        /// Initialise une nouvelle instance du décorateur de chiffrement.
        /// </summary>
        /// <param name="fichier">Le fichier à décorer.</param>
        public ChiffrementDecorator(FichierTexte fichier) : base(fichier.NomFichier, fichier.Contenu)
            => Fichier = fichier;

        /// <summary>
        /// Enregistre le fichier après avoir chiffré son contenu.
        /// Le contenu chiffré est stocké dans l'objet décoré, puis l'enregistrement est délégué pour permettre la chainabilité.
        /// </summary>
        public override bool Enregistrer(string extension = ".txt")
        {
            try
            {
                // 1. Récupérer le contenu original
                string contenuOriginal = Fichier.Contenu;

                // 2. Chiffrer le contenu
                string contenuChiffre = Chiffrer(contenuOriginal);

                // 3. Mettre à jour le contenu chiffré dans l'objet décoré.
                Fichier.Contenu = contenuChiffre;
                Console.WriteLine("Le contenu a été chiffré et mis à jour dans l'objet décoré.");

                // 4. Déléguer l'enregistrement à l'objet décoré pour la chainabilité.
                return Fichier.Enregistrer();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chiffrement du fichier : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Méthode de chiffrement simple qui inverse la chaîne de caractères.
        /// </summary>
        /// <param name="input">La chaîne à chiffrer.</param>
        /// <returns>La chaîne chiffrée.</returns>
        private string Chiffrer(string input)
        {
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
