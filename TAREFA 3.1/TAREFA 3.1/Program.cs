using TAREFA_3._1.Filmes;

Cinefilo cinefilo = new Cinefilo();

Filme filme1 = new Filme("Shrek", 5400);

filme1.AdicionarElenco("Mike Myers");
filme1.AdicionarElenco("Eddie Murphy");
filme1.AdicionarElenco("Cameron Diaz");
cinefilo.AdicionarFilme(filme1);

Filme filme2 = new Filme("Madagascar", 5160);

filme2.AdicionarElenco("Ben Stiller");
filme2.AdicionarElenco("Chris Rock");
filme2.AdicionarElenco("David Schwimmer");
cinefilo.AdicionarFilme(filme2);

Filme filme3 = new Filme("Dr. Dolittle", 5100);

filme3.AdicionarElenco("Eddie Murphy");
filme3.AdicionarElenco("Ossie Davis");
filme3.AdicionarElenco("Oliver Platt");
cinefilo.AdicionarFilme(filme3);

Filme filme4 = new Filme("Gente Grande", 6120);

filme4.AdicionarElenco("Adam Sandler");
filme4.AdicionarElenco("Kevin James");
filme4.AdicionarElenco("Chris Rock");
cinefilo.AdicionarFilme(filme4);

Filme filme5 = new Filme("Austin Powers - Um Agente Nada Discreto", 5640);

filme5.AdicionarElenco("Mike Myers");
filme5.AdicionarElenco("Elizabeth Hurley");
filme5.AdicionarElenco("Michael York");
cinefilo.AdicionarFilme(filme5);

Artista artista = new Artista ("");

void MenuPrincipal()
{
    Console.Clear();
    Console.WriteLine("Boas vindas ao Organizador de Filmes!\nO que você deseja:\n");
    Console.WriteLine("1- Ver mais sobre os filmes\n2- Ver mais sobre os artistas\n3- Adicionar um novo filme\n4- Adicionar um novo artista\n5- Conectar um filme ao artista\n6- Sair\n");
    Console.WriteLine("Qual opção você deseja?");
    string opcaoEscolhida = Console.ReadLine()!;

    switch (opcaoEscolhida)
    {
        case "1":
            Console.WriteLine("1- Ver mais sobre os filmes");
            cinefilo.MostrarFilme();
            Console.ReadKey();
            MenuPrincipal();
            break;
        case "2":
            Console.WriteLine("2- Ver mais sobre os artistas");
            cinefilo.MostrarArtista();
            Console.ReadKey();
            MenuPrincipal();
            break;
        case "3":
            Console.WriteLine("3- Adicionar um novo filme");
            cinefilo.AdicionarNovoFilme();
            Console.ReadKey();
            MenuPrincipal();
            break;
        case "4":
            Console.WriteLine("4- Adicionar um novo artista");
            cinefilo.AdicionarNovoArtista();
            Console.ReadKey();
            MenuPrincipal();
            break;
        case "5":
            Console.WriteLine("5- Conectar um filme ao artista");
            cinefilo.ConectarNovoFilme();
            Console.ReadKey();
            MenuPrincipal();
            break;
        case "6":
            Console.WriteLine("Tchau! :)");
            break;
        default:
            Console.WriteLine("\nOpção inválida, favor tentar novamente!");
            Console.WriteLine("Pressione qualquer digito para voltar ao menu principal.");
            Console.ReadKey();
            MenuPrincipal();
            break;

    }


}


MenuPrincipal();