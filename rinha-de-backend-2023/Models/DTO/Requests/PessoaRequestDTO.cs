namespace rinha_de_backend_2023.Models.DTO.Requests;

public class PessoaRequestDTO
{
    public string Apelido { get; set; }
    
    public string Nome { get; set; }

    public DateOnly Nascimento { get; set; }

    public IList<string>? Stack { get; set; }

    public bool IsStackValid()
    {
        return Stack?.DefaultIfEmpty() == null ||
               Stack.All(s => s != null && s.Length >= Data.Utils.Constants.STR_FIELD_MIN_LEN && s.Length <= Data.Utils.Constants.TECHNOLOGY_NAME_MAX_LEN);
    }
}