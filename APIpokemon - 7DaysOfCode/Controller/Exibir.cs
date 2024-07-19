using RestSharp;
using System.Text.Json;
using APIpokemon___7DaysOfCode.Model;
using APIpokemon___7DaysOfCode.Controller;


public static class Exibir
{
    public static void Menu()
    {
        Console.WriteLine(" ______   ______     __  __     ______     __    __     ______     __   __    \r\n/\\  == \\ /\\  __ \\   /\\ \\/ /    /\\  ___\\   /\\ \"-./  \\   /\\  __ \\   /\\ \"-.\\ \\   \r\n\\ \\  _-/ \\ \\ \\/\\ \\  \\ \\  _\"-.  \\ \\  __\\   \\ \\ \\-./\\ \\  \\ \\ \\/\\ \\  \\ \\ \\-.  \\  \r\n \\ \\_\\    \\ \\_____\\  \\ \\_\\ \\_\\  \\ \\_____\\  \\ \\_\\ \\ \\_\\  \\ \\_____\\  \\ \\_\\\\\"\\_\\ \r\n  \\/_/     \\/_____/   \\/_/\\/_/   \\/_____/   \\/_/  \\/_/   \\/_____/   \\/_/ \\/_/ \r\n                                                                              ");
        Console.WriteLine("\nSeja bem vindo! Qual é o seu nome?");
        Nomes.nome = Console.ReadLine()!;

        if (!string.IsNullOrEmpty(Nomes.nome))
        {
            Console.WriteLine($"\nPrazer {Nomes.nome}! Espero que esteja bem ^^");
            Thread.Sleep(2000);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"O que gostaria de fazer agora {Nomes.nome}?\n");
                Console.WriteLine("1 - Adotar um Pokémon" +
                                 "\n2 - Ver seu Pokémon" +
                                 "\n3 - Sair\n");
                try
                {
                    int escolha = int.Parse(Console.ReadLine()!);

                    switch (escolha)
                    {
                        case 1:
                            Adotar();
                            break;

                        case 2:
                            Cuidar.VerMascotes();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("\nAté mais! :)");
                            return;

                        default:
                            Console.WriteLine("\nNão existe esta opção! Tente digitar 1, 2 ou 3.");
                            Thread.Sleep(3000);
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nAcho que você se esqueceu de escolher uma opção! Vamos tentar denovo...");
                    Thread.Sleep(3000);
                }
            }
        }
        else
        {
            Console.WriteLine("Você não colocou seu nome :(");
        }

    }

    private static void Adotar()
    {
        Console.Clear();
        Console.Write($"Escolha um desses pokémons {Nomes.nome}:" +
                 "\n\n************" +
                   "\n* umbreon  *" +
                   "\n* espeon   *" +
                   "\n* vaporeon *" +
                   "\n************" +
                 "\n\nDigite o nome do pokémon: ");

        Nomes.pokemon = Console.ReadLine()!.ToLower();

        if (Nomes.pokemonsValidos.Contains(Nomes.pokemon))
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"o que gostaria de fazer agora {Nomes.nome}?\n");
                Console.WriteLine($"1 - Saber mais sobre {Nomes.pokemon}" +
                                $"\n2 - Adotar {Nomes.pokemon}" +
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
            Console.WriteLine("\nVocê não pode escolher esse pokémon ou ele não existe");
            Thread.Sleep(3000);
        }
    }
       
    private static void SaberMais()
    {
        Console.Clear();

        var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{Nomes.pokemon}");
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

        Console.Write("\nAperte qualquer tecla para voltar!");
        Console.ReadKey();
    }

    private static void AdoçãoPokemon()
    {
        Console.Clear();
        Console.WriteLine($"Boa {Nomes.nome}! o {Nomes.pokemon} agora é seu! Cuide bem dele!");

        switch (Nomes.pokemon)
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
        #*++=++**#     *+##%            %#        ");
                break;
            default:
                break;
        }

        Nomes.mascote = Nomes.pokemon;

        Random random = new Random();
        Status.fome = random.Next(11);

        Status.humor = random.Next(11);

        Status.sono = random.Next(11);


        Console.Write("\nAperte qualquer tecla para voltar ao menu!");
        Console.ReadKey();
    }
}
