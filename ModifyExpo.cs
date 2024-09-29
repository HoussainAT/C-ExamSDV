namespace ProjetCSharp;

using System.Text.Json;

public class ModifyExpo
{
    // Propriétés
    public string? NomExpo { get; set; }
    public int? NombresVisiteurs { get; set; }

    //Modification d'un
    public void ModExpo()
    {
        string filename = @"/Users/houssain/Library/CloudStorage/OneDrive-SUPDEVINCI/B2/CSharp/ProjetCSharp/data.json";
        string jsonString = File.ReadAllText(filename);

        List<ModifyExpo>? expositions = JsonSerializer.Deserialize<List<ModifyExpo>>(jsonString);

        for (int i = 0; i < expositions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Nom de l'exposition: {expositions[i].NomExpo}");
            Console.WriteLine($"   Nombre de visiteurs: {expositions[i].NombresVisiteurs}");
        }

        Console.WriteLine("Choisissez l'exposition à modifier (numéro):");
        int expoChoix = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Que voulez-vous modifier?");
        Console.WriteLine("1. Nom de l'exposition");
        Console.WriteLine("2. Nombre de visiteurs");
        int choix = int.Parse(Console.ReadLine());

        switch (choix)
        {
            case 1:
                Console.WriteLine("Entrez le nouveau nom de l'exposition:");
                expositions[expoChoix].NomExpo = Console.ReadLine();
                break;

            case 2:
                Console.WriteLine("Entrez le nouveau nombre de visiteurs:");
                expositions[expoChoix].NombresVisiteurs = int.Parse(Console.ReadLine());
                break;

            default:
                Console.WriteLine("Choix invalide.");
                return;
        }

        jsonString = JsonSerializer.Serialize(expositions, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, jsonString);

        Console.WriteLine("Les modifications ont été enregistrées.");
    }
}
