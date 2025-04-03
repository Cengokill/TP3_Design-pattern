using ProjetSauvegardeFichiers.Core;
using ProjetSauvegardeFichiers.Decorators;

namespace ProjetSauvegardeFichiers.Facade
{
    /// <summary>
    /// Façade qui encapsule la logique de sauvegarde d'un fichier texte,
    /// en gérant la compression et/ou le chiffrement si nécessaire.
    /// </summary>
    public class SauvegardeManager
    {
        /// <summary>
        /// Sauvegarde un fichier texte en appliquant éventuellement la compression et/ou le chiffrement,
        /// puis en enregistrant le résultat.
        /// </summary>
        /// <param name="nomFichier">Nom du fichier.</param>
        /// <param name="contenu">Contenu texte initial du fichier.</param>
        /// <param name="compresser">True pour appliquer la compression, false sinon.</param>
        /// <param name="chiffrer">True pour appliquer le chiffrement, false sinon.</param>
        /// <returns>True si l'enregistrement final a réussi, false sinon.</returns>
        public bool SauvegarderFichier(string nomFichier, string contenu, bool compresser, bool chiffrer)
        {
            // 1. Crée le fichier de base
            FichierTexte fichier = new(nomFichier, contenu);

            // 2. Application des décorateurs en fonction des options choisies
            FichierTexte fichierDecore = fichier;

            if (compresser)
            {
                fichierDecore = new CompressionDecorator(fichierDecore);
            }

            if (chiffrer)
            {
                fichierDecore = new ChiffrementDecorator(fichierDecore);
            }

            // 3. Enregistrement du fichier décoré (avec les transformations appliquées une seule fois)
            if (!fichierDecore.Enregistrer())
            {
                Console.WriteLine("Erreur lors de l'enregistrement du fichier.");
                return false;
            }

            return true;
        }
    }
}