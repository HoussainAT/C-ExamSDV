using System.Text.Json;

namespace ProjetCSharp;

public class DeleteExpo
{
    // Suppression d'une exposition
    public void SuppExpo()
    {
        string filename = @"/Users/houssain/Library/CloudStorage/OneDrive-SUPDEVINCI/B2/CSharp/ProjetCSharp/data.json";
        List<CreateExpo> expositions = new List<CreateExpo>();

        if (File.Exists(filename))
        {
            string fichierExistant = File.ReadAllText(filename);
            expositions = JsonSerializer.Deserialize<List<CreateExpo>>(fichierExistant) ?? new List<CreateExpo>();

            if (expositions.Any())
            {
                Console.WriteLine("Expositions existantes :");
                for (int i = 0; i < expositions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {expositions[i].NomExpo} (Visiteurs: {expositions[i].NombresVisiteurs})");
                }
                Console.WriteLine("Entrez le numéro de l'exposition à supprimer:");
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= expositions.Count)
                {
                    var expoASupprimer = expositions[index - 1];
                    expositions.RemoveAt(index - 1);

                    string jsonString = JsonSerializer.Serialize(expositions);
                    File.WriteAllText(filename, jsonString);

                    Console.WriteLine($"Exposition '{expoASupprimer.NomExpo}' supprimée avec succès.");
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un numéro valide.");
                }
            }
            else
            {
                Console.WriteLine("Aucune exposition trouvée.");
            }
        }
    }
}
