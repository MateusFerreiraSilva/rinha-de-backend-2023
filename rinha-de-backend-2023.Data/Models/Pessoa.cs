using System.ComponentModel.DataAnnotations.Schema;

namespace rinha_de_backend_2023.Data.Models;

public class Pessoa
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
    public string Apelido { get; set; }
    
    public string Nome { get; set; }

    public string Nascimento { get; set; }

    public virtual IList<Technology>? Technologies { get; set; }

    // public string Searchable { get; set; } = Apelido + Nome + string.Join(string.Empty, Technologies);
}