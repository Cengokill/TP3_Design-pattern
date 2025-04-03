using System;
using System.IO.Compression;
using System.Text;
using ProjetSauvegardeFichiers.Core;

namespace ProjetSauvegardeFichiers.Decorators;

/// <summary>
/// Décorateur concret qui ajoute une fonctionnalité de compression à un fichier
/// Implémente le pattern Decorator
/// </summary>
public class CompressionDecorator : FichierTexte
{
    protected FichierTexte Fichier;

    /// <summary>
    /// Initialise une nouvelle instance du décorateur de compression
    /// </summary>
    /// <param name="fichier">Le fichier à décorer</param>
    public CompressionDecorator(FichierTexte fichier) : base(fichier.CheminFichier, fichier.Contenu) => Fichier = fichier;
    
    public string CheminFichier => Fichier.CheminFichier;
    
    public string Contenu
    {
        get => Fichier.Contenu;
        set => Fichier.Contenu = value;
    }

    /// <summary>
    /// Enregistre le fichier, en le compressant au préalable.
    /// </summary>
    /// <param name="cheminFichier">Le chemin où enregistrer le fichier compressé.</param>
    public override bool Enregistrer()
    {
        try
        {
            // 1. Compresser le contenu en mémoire
            byte[] compressedData;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (GZipStream compressionStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(Contenu);
                    compressionStream.Write(bytes, 0, bytes.Length);
                }
                compressedData = memoryStream.ToArray();
            }

            // 2. Mettre à jour le contenu compressé dans l'objet décoré.
            Fichier.Contenu = Convert.ToBase64String(compressedData);
            Console.WriteLine("Le contenu a été compressé et mis à jour dans l'objet décoré.");

            // 3. Déléguer l'enregistrement à l'objet décoré pour la chainabilité.
            return Fichier.Enregistrer();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la compression du fichier : {ex.Message}");
            return false;
        }
    }
}