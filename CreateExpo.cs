using System.Text.Json;

namespace ProjetCSharp;

public class CreateExpo
{
    // Propriété
    public string? NomExpo { get; set; }
    public int NombresVisiteurs { get; set; }

    // Intéraction Console
    public void InterConsole()
    {
        Console.WriteLine("Entrez votre nom expo:");
        NomExpo = Console.ReadLine();
        Console.WriteLine("Entrez le nombre visiteurs:");
        NombresVisiteurs = int.Parse(Console.ReadLine());
    }
    //Création d'un JSON + ajout des données
    public void CreerJson()
    {
        string fileName = @"/Users/houssain/Library/CloudStorage/OneDrive-SUPDEVINCI/B2/CSharp/ProjetCSharp/data.json";
        List<CreateExpo> expositions;
        if (File.Exists(fileName))
        {
            string existingJson = File.ReadAllText(fileName);
            if (string.IsNullOrWhiteSpace(existingJson))
            {
                expositions = new List<CreateExpo>();
            }
            else
            {
                expositions = JsonSerializer.Deserialize<List<CreateExpo>>(existingJson) ?? new List<CreateExpo>();
            }
        }
        else
        {
            expositions = new List<CreateExpo>();
        }

        var createExpo = new CreateExpo()
        {
            NombresVisiteurs = NombresVisiteurs,
            NomExpo = NomExpo
        };

        expositions.Add(createExpo);

        string jsonString = JsonSerializer.Serialize(expositions);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("Nouvelle exposition ajoutée avec succès.");
    }
}