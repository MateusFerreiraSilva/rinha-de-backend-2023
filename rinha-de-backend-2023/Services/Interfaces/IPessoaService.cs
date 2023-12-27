using rinha_de_backend_2023.Data.Models;
using rinha_de_backend_2023.Models.DTO;

namespace rinha_de_backend_2023.Services.Interfaces;

public interface IPessoaService
{
    Task<Pessoa> GetAsync(string id);

    Task<string> PostAsync(PessoaDTO pessoaDto);
}