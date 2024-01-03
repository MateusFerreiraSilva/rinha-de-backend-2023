using System.ComponentModel.DataAnnotations.Schema;

namespace rinha_de_backend_2023.Data.Models;

public class Technology
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
    public string Nome { get; set; }

    public virtual IList<Pessoa> Pessoas { get; set; }
}