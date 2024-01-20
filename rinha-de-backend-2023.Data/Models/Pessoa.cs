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

    // TO DO Add something like  [MaxLength(Constants.TECHNOLOGY_NAME_MAX_LEN)] for each item
    public string Stack { get; set; }

    public string Searchable { get; private set; }

    public Pessoa()
    {
    }

    public Pessoa(string apelido, string nome, string nascimento, string stack)
    {
        Apelido = apelido;
        Nome = nome;
        Nascimento = nascimento;
        Stack = stack;
        Searchable = (
            apelido.RemoveAllWhiteSpaces() +
            nome.RemoveAllWhiteSpaces() +
            stack.RemoveAllSemicolons().RemoveAllWhiteSpaces()
        ).ToLower();
    }
}