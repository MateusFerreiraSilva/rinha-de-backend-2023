using System.ComponentModel.DataAnnotations.Schema;

namespace rinha_de_backend_2023.Data.Models;

public sealed class Pessoa
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
    public string Apelido { get; set; }
    
    public string Nome { get; set; }

    public string Nascimento { get; set; }

    public IList<Technology>? Technologies { get; set; }

    public string Searchable { get; private set; }

    public Pessoa()
    {
    }

    public Pessoa(string apelido, string nome, string nascimento, IList<Technology>? stack)
    {
        Apelido = apelido;
        Nome = nome;
        Nascimento = nascimento;
        Technologies = stack;
        Searchable = (
            apelido +
            nome +
            string.Join(string.Empty, stack?.ToList().Select(t => t.Nome).ToList() ?? new List<string>())
        ).ToLower();
    }
    
    public Pessoa(string apelido, string nome, string nascimento, IList<string>? stack)
    {
        Apelido = apelido;
        Nome = nome;
        Nascimento = nascimento;
        Technologies = stack?.ToList()
            .Select(t => new Technology { Nome = t })
            .ToList();
        
        Searchable =  (apelido + nome + string.Join(string.Empty, stack ?? new List<string>())).ToLower();
    }
}