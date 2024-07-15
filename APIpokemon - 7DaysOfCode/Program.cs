using RestSharp;
using System.Text.Json;

Console.Write("Escolha um desses pokémons para poder cuidar:" +
  "\n\n************" +
    "\n* umbreon  *" +
    "\n* espeon   *" +
    "\n* vaporeon *" +
    "\n************" +
    "\n\nagora digite o nome do pokémon que você decidiu ter: ");

string pokemon = Console.ReadLine()!;

if (pokemon.Equals("umbreon") || pokemon.Equals("espeon") || pokemon.Equals("vaporeon"))
{
    var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemon}");
    var request = new RestRequest("", Method.Get);
    var response = client.Execute(request);

    if (response.StatusCode == System.Net.HttpStatusCode.OK)
    {
        var bichano = JsonSerializer.Deserialize<Mascote>(response.Content!);
        bichano!.ExibirBichin();

        // Console.WriteLine(response.Content);
        // Console.WriteLine();
    }
    else
    {
        Console.WriteLine(response.ErrorMessage);
        Console.WriteLine();
    }

    Console.ReadKey();
}
else
{
    Console.WriteLine("\nvocê não pode escolher esse pokémon ou ele não existe\n");
}

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

public class Ability
{
    public abilityName? ability {  get; set; }

    public class abilityName
    {
        public string? name { get; set; }
    }
}