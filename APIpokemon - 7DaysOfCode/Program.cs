using RestSharp;
using System.Text.Json;

Exibir.Menu();

public static class Exibir
{
    private static string? nome;
    private static string? pokemon;
    private static string[] pokemonsValidos = { "umbreon", "espeon", "vaporeon" };

    public static void Menu()
    {
        Console.WriteLine(" ______   ______     __  __     ______     __    __     ______     __   __    \r\n/\\  == \\ /\\  __ \\   /\\ \\/ /    /\\  ___\\   /\\ \"-./  \\   /\\  __ \\   /\\ \"-.\\ \\   \r\n\\ \\  _-/ \\ \\ \\/\\ \\  \\ \\  _\"-.  \\ \\  __\\   \\ \\ \\-./\\ \\  \\ \\ \\/\\ \\  \\ \\ \\-.  \\  \r\n \\ \\_\\    \\ \\_____\\  \\ \\_\\ \\_\\  \\ \\_____\\  \\ \\_\\ \\ \\_\\  \\ \\_____\\  \\ \\_\\\\\"\\_\\ \r\n  \\/_/     \\/_____/   \\/_/\\/_/   \\/_____/   \\/_/  \\/_/   \\/_____/   \\/_/ \\/_/ \r\n                                                                              ");
        Console.WriteLine("\nSeja bem vindo! qual é o seu nome?");
        nome = Console.ReadLine()!;
        
        if (!string.IsNullOrEmpty(nome))
        {
            Console.WriteLine($"\nPrazer {nome}! espero que esteja bem ^^");
            Thread.Sleep(2000);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"o que gostaria de fazer agora {nome}?");
                Console.WriteLine("1 - Adotar um Pokémon" +
                                 "\n2 - Ver seus Pokémons" +
                                 "\n3 - Sair");
                try
                {
                    int escolha = int.Parse(Console.ReadLine()!);

                    switch (escolha)
                    {
                        case 1:
                            Adotar();
                            break;

                        case 2:
                            VerMascotes();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("\naté mais! :)");
                            return;

                        default:
                            Console.WriteLine("\nnão existe esta opção! tente digitar 1, 2 ou 3.");
                            Thread.Sleep(3000);
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nacho que você se esqueceu de escolher uma opção! vamos tentar denovo...");
                    Thread.Sleep(3000);
                }
            }
        }
        else
        {
            Console.WriteLine("você não colocou seu nome :(");
        }
        
    }

    private static void Adotar()
    {
        Console.Clear();
        Console.Write($"Escolha um desses pokémons {nome}:" +
                 "\n\n************" +
                   "\n* umbreon  *" +
                   "\n* espeon   *" +
                   "\n* vaporeon *" +
                   "\n************" +
                 "\n\ndigite o nome do pokémon: ");

        pokemon = Console.ReadLine()!.ToLower();

        if (pokemonsValidos.Contains(pokemon))
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"o que gostaria de fazer agora {nome}?");
                Console.WriteLine($"1 - Saber mais sobre {pokemon}" +
                                $"\n2 - Adotar {pokemon}" +
                                 "\n3 - Voltar");
                try
                {
                    int escolha = int.Parse(Console.ReadLine()!);

                    switch (escolha)
                    {
                        case 1:
                            SaberMais();
                            break;

                        case 2:
                            AdoçãoPokemon();
                            return;

                        case 3:
                            Console.Clear();
                            return;

                        default:
                            Console.WriteLine("\nnão existe esta opção! tente digitar 1, 2 ou 3.");
                            Thread.Sleep(3000);
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nacho que você se esqueceu de escolher uma opção! vamos tentar denovo...");
                    Thread.Sleep(3000);
                }
            }
 
        }
        else
        {
            Console.WriteLine("\nvocê não pode escolher esse pokémon ou ele não existe");
            Thread.Sleep(3000);
        }
    }

    private static void VerMascotes()
    {
        Console.Clear();
        Console.WriteLine("ainda não implementado");
        Thread.Sleep(2000);
    }
        
    private static void SaberMais()
    {
        Console.Clear();
        
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

        Console.Write("\naperte qualquer tecla para voltar!");
        Console.ReadKey();
    }

    private static void AdoçãoPokemon()
    {
        Console.Clear();
        Console.WriteLine($"Boa {nome}! o {pokemon} agora é seu! cuide bem dele!");

        switch(pokemon)
        {
            case "espeon":
                Console.WriteLine(@"                                                
        %                                       
       +-                                       
       =--+                                     
       ##---#                                   
       @##=--=*                                 
        %##===---+                       +-:=   
        ###=::::::-=-----=+#%  %*     =-::-=*   
  #=-===++*-------=----------==*    +--+        
   ****+*+---+======*####***#%     *-=+===-===  
         +=-===-:*+=*#####%       *-====++====  
          *====+====--=           -:=%          
            #*+====+=-:-         #--            
             #+=====*=-:=         --            
             +=------* *#         =-%           
             =--------=           =-#           
             ----------=*         -:%           
             -::---------=+      *-=            
             %-:-==:--------=+   =-=            
              =--=+--:::::-----*--+             
              *--=-::::::--------*              
              *--=-------------+=               
              -=++==--------====*               
             *+*#*+============+                
                      %%%@                      
                                                ");
                break;
            case "umbreon":
                Console.WriteLine(@"                                                
                         +++#                   
                          ++--+--               
                           #+-..-+#             
                             --++++#            
                               #++++#           
                                 +++++#         
     ++#                 ###  #-----...-#       
      +---++       ++-...------------...+#      
      #------..- +-----..----+++---.+-----#     
       +-----. .--   ##+.-+   --------++++      
        ++--.  .--++          +-----++++        
         -.....----+#        #----++++          
           #+++++++++------++--------+          
               ##++++----------------+          
                #+--------------------          
                ++--------------------#         
                +++++-....-+++++--..--          
               #+++++..-..+ #++++..-.#          
              +-+++++-..-#  ##+++-..+           
              +--++-+++#    #+++++-+            
              #--++-+#       +++#-++            
               --++-+         #+++++            
               ++++--+#         +++++#          
                    +--+           ++#          
                                                ");
                break;
            case "vaporeon":
                Console.WriteLine(@"                                                  
                    #                             
                    ##                @%          
                    %#%            #*=-+          
                     ##%        %#+=:::+          
                   #-=#=:::=+#%#*=::-=*           
                 -:.-**#****=**=---::             
     %****##%##%=.:++-+*+---+*-==-::*             
      #-::..:-=+***-------=*#+=----:%             
        *+-----====#@*+---=*+==----:=             
           =:.-=======--+++====::-+               
            #:..:-:====+***=++:::+*               
             #:*:...-====++=--:-=*                
                +-:.:.:-------:-+                 
                ##+-:::-::--=+*                   
               %#+-----=-=+++#                    
          %###**+---------=++#                    
      @%#*++=------------+++++       +====+#      
      #*=-----------=----++++* %%%%=--------=#    
    %**=------------==-=*####*++++*+=------+#     
    %#+--+=-------=+*###+=====*% *----+##@        
    %*+-----===+++#**====++*#    #------*         
    *=**+*++*##*++=====++*+*%     *======%        
    *---=====----====++++*+*       #+====+        
     #+-------=====+# *+++=+%         *+==%       
        #*++=++**#     *+##%            %#        
                                                  ");
                break;
            default:
                break;
        }

        Console.Write("\naperte qualquer tecla para voltar ao menu!");
        Console.ReadKey();
    }
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
    public abilityName? ability { get; set; }

    public class abilityName
    {
        public string? name { get; set; }
    }
}