using System;
using System.IO;

namespace ProjetSauvegardeFichiers.Core
{
    /// <summary>
    /// Classe concrète représentant un fichier texte simple
    /// Implémente l'interface IFichier et sert de composant de base pour le pattern Decorator
    /// </summary>
    public class FichierTexte : IFichier
    {
        public string CheminFichier { get; private set; }
        public string Contenu { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe FichierTexte
        /// </summary>
        /// <param name="nom">Nom du fichier</param>
        /// <param name="contenu">Contenu du fichier</param>
        public FichierTexte(string cheminFichier, string contenu)
        {
            CheminFichier = cheminFichier;
            Contenu = contenu;
        }

        /// <summary>
        /// Enregistre le contenu du fichier texte dans un fichier spécifié.
        /// </summary>
        /// <param name="cheminFichier">Le chemin complet du fichier où enregistrer le contenu.</param>
        public virtual bool Enregistrer()  // virtual pour permettre l'override par les décorateurs
        {
            try
            {
                // Écrit le contenu dans le fichier.
                using (StreamWriter sw = new StreamWriter(CheminFichier))
                {
                    sw.Write(Contenu);
                }
                Console.WriteLine($"Fichier texte enregistré avec succès à : {CheminFichier}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'enregistrement du fichier texte : {ex.Message}");
                return false;
            }
        }
    }
}