using rinha_de_backend_2023.Models.DTO;

namespace rinha_de_backend_2023.Services.Interfaces;

public interface IPessoaService
{
    Task<PessoaDTO> GetAsync(string id);

    Task<string> PostAsync(PessoaDTO pessoaDto);
}