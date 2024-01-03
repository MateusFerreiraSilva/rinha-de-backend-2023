using rinha_de_backend_2023.Models.DTO;

namespace rinha_de_backend_2023.Services.Interfaces;

public interface IPessoaService
{
    string Post(PessoaDTO pessoaDto);
    
    PessoaDTO? GetById(string id);
    
    IList<PessoaDTO> Get(string term);
}