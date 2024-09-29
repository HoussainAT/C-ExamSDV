using ProjetCSharp;

Console.WriteLine("|-----------------|");
Console.WriteLine("|---ADMIN MUSÉE---|");
Console.WriteLine("|-----------------|");
Console.WriteLine("1 - Créer une exposition");
Console.WriteLine("2 - Modifier une exposition");
Console.WriteLine("3 - Supprimer une exposition");
Console.WriteLine("4 - Quitter l'application");


int? choix = int.Parse(Console.ReadLine());
switch (choix)
{
    case 1:
        CreateExpo newExpo = new CreateExpo();
        newExpo.InterConsole();
        newExpo.CreerJson();
        break;
    case 2:
        ModifyExpo modExpo = new ModifyExpo();
        modExpo.ModExpo();
        break;
    case 3:
        DeleteExpo deleteExpo = new DeleteExpo();
        deleteExpo.SuppExpo();
        break;
    case 4:
        Console.WriteLine("L'application va se couper");
        break;
    default:
        Console.WriteLine("Choisissez entre 1 et 4");
        break;
}