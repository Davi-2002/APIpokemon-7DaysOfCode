using APIpokemon___7DaysOfCode.Model;

namespace APIpokemon___7DaysOfCode.Controller;

public static class Cuidar
{
    public static void VerMascotes()
    {
        if (!string.IsNullOrEmpty(Nomes.mascote))
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"O que gostaria de fazer {Nomes.nome}?\n");
                Console.WriteLine($"1 - Saber como meu {Nomes.mascote} está" +
                                 $"\n2 - Alimentar {Nomes.mascote}" +
                                 $"\n3 - Brincar com {Nomes.mascote}" +
                                 $"\n4 - Botar {Nomes.mascote} para dormir" +
                                 $"\n5 - Renomear {Nomes.mascote}" +
                                 "\n6 - Voltar\n");
                try
                {
                    int escolha = int.Parse(Console.ReadLine()!);

                    switch (escolha)
                    {
                        case 1:
                            Saber();
                            break;

                        case 2:
                            Alimentar();
                            break;

                        case 3:
                            Brincar();
                            break;

                        case 4:
                            Dormir();
                            break;

                        case 5:
                            Renomear();
                            break;

                        case 6:
                            Console.Clear();
                            return;

                        default:
                            Console.WriteLine("\nNão existe esta opção! tente digitar 1, 2, 3, 4 ou 5.");
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
            Console.Clear();
            Console.WriteLine("Adote um Pokémon primeiro!");
            Thread.Sleep(2000);
        }
    }

    private static void Renomear()
    {
        Console.Clear();
        Console.WriteLine("Qual nome você deseja?");
        Console.Write("Novo nome: ");
        Nomes.mascote = Console.ReadLine();
    }

    private static void Dormir()
    {
        Console.Clear();
        Console.WriteLine($"{Nomes.mascote} está roncando mais que um trator fora da garantia!");

        if (Status.fome < 10)
        {
            Status.fome ++;
        }

        if (Status.humor > 0)
        {
            Status.humor--;
        }

        for (int i = 0; i < 5 && Status.sono > 0; i++)
        {
            Status.sono -= 1;
        }
        //Status.sono -= 5;


        Thread.Sleep(3000);
    }

    private static void Brincar()
    {
        Console.Clear();
        Console.WriteLine($"Você jogou um fut com seu querido {Nomes.mascote}, ele parece ser ruim de bola!");

        if (Status.fome < 10)
        {
            Status.fome++;
        }

        if (Status.humor < 10)
        {
            Status.humor++;
        }

        if (Status.sono < 10)
        {
            Status.sono++;
        }

        // MESMA FUNÇÃO, PORÉM SEM VERIFICAR SE ESTÁ DENTRO DE 0 E 10
        /*
        Status.fome++;
        Status.humor++;
        Status.sono++;
        */

        Thread.Sleep(3000);
    }

    private static void Alimentar()
    {
        Console.Clear();
        Console.WriteLine($"{Nomes.mascote} comeu um belo churras bem passado!");

        if (Status.fome > 0)
        {
            Status.fome--;
        }

        if (Status.humor > 0)
        {
            Status.humor--;
        }

        if (Status.sono < 10)
        {
            Status.sono ++;
        }

        Thread.Sleep(3000);
    }

    private static void Saber()
    {
        Console.Clear();
        Console.WriteLine("<====================>");
        Console.WriteLine($"|Nome:  | {Nomes.mascote}");
        MostrarStatus("|FOME:  |",Status.fome);
        MostrarStatus("|FELIZ: |",Status.humor);
        MostrarStatus("|SONO:  |",Status.sono);
        Console.WriteLine("<====================>");

        Console.Write("\nAperte qualquer tecla para voltar!");
        Console.ReadKey();
    }

    private static void MostrarStatus(string nome,int status)
    {
        Console.Write($"{nome} [");
        for (int i = 1; i <= status; i++)
        {
            Console.Write("|");
        }
        Console.WriteLine("]");
    }
}
