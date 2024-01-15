using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rinha_de_backend_2023.Data.Utils;

namespace rinha_de_backend_2023.Data.Models;

public sealed class Pessoa
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(Constants.NICKNAME_MAX_LEN)]
    // TO DO add index GIN or GiST, trigram
    public string Apelido { get; set; }
    
    [Required]
    [MaxLength(Constants.NAME_MAX_LEN)]
    public string Nome { get; set; }
    
    [Required]
    [RegularExpression(@"^(19|20)\d{2}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])$")]
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
        
        Searchable =  (
            apelido.RemoveAllWhiteSpaces() +
            nome.RemoveAllWhiteSpaces() +
            string.Join(string.Empty, stack ?? new List<string>()).RemoveAllWhiteSpaces()
        ).ToLower();
    }
}