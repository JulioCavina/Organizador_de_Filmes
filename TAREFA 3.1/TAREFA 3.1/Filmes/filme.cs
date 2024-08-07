using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace TAREFA_3._1.Filmes;


class Filme
{
    public Filme(string titulo, int duracao)
    {
        Titulo = titulo;
        Duracao = duracao;
        listaElenco = new List<Artista>();
    }

    public void AdicionarElenco(string nomeArtista)
    {
        Artista artista;
        if (Cinefilo.listaArtistas.ContainsKey(nomeArtista))
        {
            artista = Cinefilo.listaArtistas[nomeArtista];
        }
        else
        {
            artista = new Artista(nomeArtista);
            Cinefilo.listaArtistas[nomeArtista] = artista;
        }
        artista.AdicionarFilme(Titulo);
        if (!listaElenco.Any(a => a.Nome == nomeArtista))
        {
            listaElenco.Add(artista);
        }
    }

    public string Titulo { get; }
    
    public int Duracao { get; }


    public List<Artista> listaElenco { get; }


    public void MostrarFilme()
    {
        Console.Clear();
        Console.WriteLine("1- Ver mais sobre os filmes:\n");

        if (listaElenco.Count != 0)
        {
            Console.WriteLine("O filme " + Titulo + " tem " + Duracao + " segundos e foi estrelado por:");
            foreach (Artista item in listaElenco) { Console.WriteLine($"° {item.Nome}"); }
        }
        else
        {
            Console.WriteLine("O filme " + Titulo + " tem " + Duracao + " segundos.");
        } 
         
    }

}














class Cinefilo
{

    public List<Filme> listaFilme = new List<Filme>();
    public static Dictionary<string,Artista> listaArtistas = new Dictionary<string,Artista>();

    public void AdicionarFilme(Filme filme)
    {
        listaFilme.Add(filme);

    }

    public void AdicionarNovoArtista()
    {
        
        Console.Clear();
        Console.WriteLine("3- Adicionar um novo artista:\n");
        Console.WriteLine("Qual é o nome do artista?\n");
        string nomeArtista = Console.ReadLine()!;
        Artista artista = new Artista(nomeArtista);
        int artistaCheck = 0;
        foreach (var item in listaArtistas.Values)
        {
            if (item.Nome == artista.Nome)
            {
                artistaCheck++;
            }
        }
        if (artistaCheck == 1)
        {
            Console.WriteLine($"\nO artista {artista.Nome} já está adicionado no programa.\nPressione qualquer tecla para retornar ao menu principal!");
        }
        else
        {
            Console.WriteLine("Digite o ID (número) do filme que o artista participou:\n");
            int contador = 1;
            int indexFilmes;
            foreach (var filme in listaFilme)
            {
                Console.WriteLine($"{contador}. {filme.Titulo}");
                contador++;
            }
            Console.WriteLine($"{contador}. Cancelar (Retorne ao menu principal)\n");
            Console.WriteLine();
            string opcaoEscolhida = Console.ReadLine()!;

            if (int.TryParse(opcaoEscolhida, out indexFilmes) && indexFilmes > 0 && indexFilmes <= listaFilme.Count)
            {
                Filme filme = listaFilme[indexFilmes - 1];
                artista.AdicionarFilme(filme.Titulo);
                listaArtistas[nomeArtista] = artista;
                filme.AdicionarElenco(nomeArtista);

                Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal!");

            }
            else if (contador == indexFilmes)
            {
                Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal!");
            }
            else
            {
                Console.WriteLine("\nFilme não encontrado, pressione qualquer tecla para retornar ao menu principal!");
            }
        }
    }

    public void ConectarNovoFilme()
    {
        Console.Clear();
        Console.WriteLine("5- Conectar um filme ao artista:\n");
        Console.WriteLine("Qual é o filme que deseja conectar?\n");
        int contador = 1;
        int indexFilmes;
        int indexArtistas;
        foreach (var filme in listaFilme)
        {
            Console.WriteLine($"{contador}. {filme.Titulo}");
            contador++;
        }
        Console.WriteLine();
        string opcaoEscolhida = Console.ReadLine()!;

        if (int.TryParse(opcaoEscolhida, out indexFilmes) && indexFilmes > 0 && indexFilmes <= listaFilme.Count)
        {
            Filme filmeEscolhido = listaFilme[indexFilmes-1];
            contador = 1;
            Console.WriteLine("\nQual é o artista que deseja conectar?\n");
            foreach (var artista in listaArtistas.Values)
            {
                Console.WriteLine($"{contador}. {artista.Nome}");
                contador++;
            } 
            Console.WriteLine();
            string opcaoEscolhida2 = Console.ReadLine()!;

            if (int.TryParse(opcaoEscolhida2, out indexArtistas) && indexArtistas > 0 && indexArtistas <= listaArtistas.Values.Count)
            {

                var listaValores = listaArtistas.Values.ToList();
                filmeEscolhido.AdicionarElenco(listaValores[indexArtistas - 1].Nome);


                Console.WriteLine($"\nO(a) artista {listaValores[indexArtistas-1].Nome} foi conectado ao filme {filmeEscolhido.Titulo}.\nPressione qualquer tecla para retornar ao menu principal!");

            }
            else
            {
                Console.WriteLine("\nArtista não encontrado, pressione qualquer tecla para retornar ao menu principal!");
            }
        }
        else
        {
            Console.WriteLine("\nFilme não encontrado, pressione qualquer tecla para retornar ao menu principal!");
        }

    }


    public void AdicionarNovoFilme()
    {
        Console.Clear();
        Console.WriteLine("3- Adicionar um novo filme:\n");
        Console.WriteLine("Qual é o Título do filme?\n");
        string titulo = Console.ReadLine()!;
        Console.WriteLine("\nQual é a duração do filme (em segundos)?\n");
        string segundos = Console.ReadLine()!;
        int segundosInt;
        if (int.TryParse(segundos, out segundosInt) && segundosInt > 0 )
        {
            Filme filme = new Filme(titulo, segundosInt);
            listaFilme.Add (filme);
            Console.WriteLine($"\nFilme {filme.Titulo} adicionado!\nPressione qualquer tecla para retornar ao menu principal!");

        }
        else
        {
            Console.WriteLine("Valor não valido! Pressione qualquer tecla para retornar ao menu principal!");
        }

    }




    public void MostrarFilme()
    {
        Console.Clear();
        Console.WriteLine("1- Ver mais sobre os filmes:\n");
        Console.WriteLine("Digite o ID (número) do filme que você deseja ver:\n");
        int contador = 0;
        int indexFilmes;
        foreach (var filme in listaFilme) 
        { 
            Console.WriteLine($"{contador+1}. {filme.Titulo}");
            contador++;
        }
        Console.WriteLine();
        string opcaoEscolhida = Console.ReadLine()!;

        if (int.TryParse(opcaoEscolhida,out indexFilmes)&&indexFilmes>0&&indexFilmes<=listaFilme.Count)
        {
            listaFilme[indexFilmes - 1].MostrarFilme();
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal!");
            
        }
        else
        {
            Console.WriteLine("Filme não encontrado, pressione qualquer tecla para retornar ao menu principal!");
            
        }


    }

    public void MostrarArtista()
    {
        Console.Clear();

        Console.WriteLine("1- Ver mais sobre os artistas:\n");
        Console.WriteLine("Digite o ID (número) do artista que você deseja ver:\n");
        int contador = 0;
        int indexArtista;
        foreach (var artista in listaArtistas.Values)
        {
            Console.WriteLine($"{contador + 1}. {artista.Nome}");
            contador++;
        }
        Console.WriteLine();
        string opcaoEscolhida = Console.ReadLine()!;

        if (int.TryParse(opcaoEscolhida, out indexArtista) && indexArtista > 0 && indexArtista <= listaArtistas.Count)
        {
            var artistasList = new List<Artista>(listaArtistas.Values);
            artistasList[indexArtista - 1].MostrarFilmes();
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal!");

        }
        else
        {
            Console.WriteLine("Artista não encontrado, pressione qualquer tecla para retornar ao menu principal!");

        }
    }



}
