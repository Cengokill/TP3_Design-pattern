namespace ProjetSauvegardeFichiers;

public static class Configuration
{
    public static string CheminFichier { get; private set; }
    public static string Separateur { get; private set; }

    static Configuration()
    {
        CheminFichier = "";
        Separateur = Path.DirectorySeparatorChar.ToString();
    }
}