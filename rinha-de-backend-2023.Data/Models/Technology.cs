using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rinha_de_backend_2023.Data.Utils;

namespace rinha_de_backend_2023.Data.Models;

public class Technology
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(Constants.TECHNOLOGY_NAME_MAX_LEN)]
    public string Nome { get; set; }

    public virtual IList<Pessoa> Pessoas { get; set; }
}