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
        /// <param name="cheminFichier">Chemin complet du fichier.</param>
        /// <param name="contenu">Contenu texte initial du fichier.</param>
        /// <param name="compresser">True pour appliquer la compression, false sinon.</param>
        /// <param name="chiffrer">True pour appliquer le chiffrement, false sinon.</param>
        /// <returns>True si l'enregistrement final a réussi, false sinon.</returns>
        public bool SauvegarderFichier(string cheminFichier, string contenu, bool compresser, bool chiffrer)
        {
            // 1. Crée le fichier de base
            FichierTexte fichier = new FichierTexte(cheminFichier, contenu);

            // 2. Application d'un décorateur en fonction de l'option choisie.
            // Seule l'une des deux transformations (compression ou chiffrement) peut être appliquée.
            FichierTexte fichierDecore = fichier;

            bool EstCompresse = false, EstChiffre = false;
            
            if (compresser){
                fichierDecore = new CompressionDecorator(fichierDecore);
                // 3. Enregistrement du fichier, avec une compression.
                EstCompresse = fichierDecore.Enregistrer();
                if(EstCompresse)
                    Console.WriteLine("Erreur lors de l'enregistrement du fichier compressé.");
            }if (chiffrer){
                fichierDecore = new ChiffrementDecorator(fichierDecore);
                // 3. Enregistrement du fichier, avec un chiffrement.
                EstChiffre = fichierDecore.Enregistrer();
                if(EstChiffre)
                    Console.WriteLine("Erreur lors de l'enregistrement du fichier chiffré.");
            }

            // 3. Vérification des options de transformation.
            // Si l'utilisateur a demandé la compression ou bien le chiffrement (ou)
            if (!(EstCompresse && !EstChiffre) && (compresser || chiffrer))
            {
                return false;
            }

            // 3. Enregistrement du fichier sans transformation.
            if (!fichierDecore.Enregistrer())
            {
                Console.WriteLine("Erreur lors de l'enregistrement du fichier sans transformation.");
                return false;
            }
                
            // 4. Retourne le résultat de l'enregistrement final.
            if(!EstCompresse && !EstChiffre)
            {
                Console.WriteLine("Erreur lors de l'enregistrement du fichier sans transformation.");
                return false;
            }    
            
            
        }
    }
}