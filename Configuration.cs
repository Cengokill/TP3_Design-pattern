namespace ProjetSauvegardeFichiers;

public static class Configuration
{
    public static string CheminFichier { get; private set; }
    public static string Separateur { get; private set; }

    static Configuration()
    {
        Separateur = Path.DirectorySeparatorChar.ToString();
        CheminFichier = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"..{Separateur}..{Separateur}..{Separateur}my_files");
    }
}