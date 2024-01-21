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
    public string Apelido { get; set; }
    
    [Required]
    [MaxLength(Constants.NAME_MAX_LEN)]
    public string Nome { get; set; }
    
    [Required]
    public DateOnly Nascimento { get; set; }
    
    public List<string> Stack { get; set; }

    public string Searchable { get; private set; }

    public Pessoa()
    {
    }

    public Pessoa(string apelido, string nome, DateOnly nascimento, IList<string>? stack)
    {
        Apelido = apelido;
        Nome = nome;
        Nascimento = nascimento;
        Stack = stack?.ToList() ?? new List<string>();
        Searchable = (
            apelido.RemoveAllWhiteSpaces() +
            nome.RemoveAllWhiteSpaces() +
            string.Join(string.Empty, stack?.Select(s => s.RemoveAllWhiteSpaces()) ?? new List<string>())
        ).ToLower();
    }
}