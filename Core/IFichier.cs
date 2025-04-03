namespace ProjetSauvegardeFichiers.Core
{
    /// <summary>
    /// Interface définissant les opérations de base pour un fichier
    /// Cette interface est utilisée comme composant de base pour le pattern Decorator
    /// </summary>
    public interface IFichier
    {
        /// <summary>
        /// Obtient le chemin complet du fichier incluant son nom
        /// </summary>
        string NomFichier { get; }

        /// <summary>
        /// Obtient ou définit le contenu du fichier
        /// </summary>
        string Contenu { get; set; }

        /// <summary>
        /// Enregistre le fichier sur le système
        /// </summary>
        /// <returns>True si l'enregistrement a réussi, False sinon</returns>
        bool Enregistrer(string extension);
    }
}