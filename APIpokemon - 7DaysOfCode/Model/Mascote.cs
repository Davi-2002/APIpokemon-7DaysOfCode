namespace APIpokemon___7DaysOfCode.Model;

public class Mascote
{
    public string? name { get; set; }
    public int weight { get; set; }
    public int height { get; set; }
    public List<Ability>? abilities { get; set; }

    public void ExibirBichin()
    {

        Console.WriteLine("----------------------------------");
        Console.WriteLine($"nome: {name}");
        Console.WriteLine($"peso: {weight}");
        Console.WriteLine($"altura: {height}");
        Console.WriteLine($"habilidades: ");
        abilities!.ForEach(item => Console.WriteLine(item.ability!.name!.ToUpper()));

        Console.WriteLine("----------------------------------");

    }

}
