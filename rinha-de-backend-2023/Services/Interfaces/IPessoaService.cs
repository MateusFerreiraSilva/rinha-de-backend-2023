using rinha_de_backend_2023.Models.DTO;
using rinha_de_backend_2023.Models.DTO.Requests;
using rinha_de_backend_2023.Models.DTO.Responses;

namespace rinha_de_backend_2023.Services.Interfaces;

public interface IPessoaService
{
    string Post(PessoaRequestDTO pessoaRequestDto);
    
    PessoaResponseDTO? GetById(string id);
    
    IList<PessoaResponseDTO> Get(string term);
}