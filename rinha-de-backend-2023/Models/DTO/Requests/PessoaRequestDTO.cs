namespace rinha_de_backend_2023.Models.DTO.Requests;

public class PessoaRequestDTO
{
    public string Apelido { get; set; }
    
    public string Nome { get; set; }

    public string Nascimento { get; set; }

    public IList<string>? Stack { get; set; }
}