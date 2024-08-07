namespace TAREFA_3._1.Filmes;

class Artista
{

    public Artista(string nome)
    {
        Nome = nome;
        filmesParticipados = new List<string>();
    }


    public string Nome { get; }
    public List<string> filmesParticipados { get; }

    public void AdicionarFilme(string filme)
    {
        if (!filmesParticipados.Contains(filme))
        {
            filmesParticipados.Add(filme);
        }
    }


    public void MostrarFilmes()
    {
        Console.WriteLine($"\nArtista: {Nome}");
        Console.WriteLine("Filmes que participou:\n");
        foreach (var filme in filmesParticipados)
        {
            Console.WriteLine($"° {filme}");
        }
    }
}