using rinha_de_backend_2023.Models;

namespace rinha_de_backend_2023.Services.Interfaces;

public interface IPessoaService
{
    Task<Pessoa> PostAsync(Pessoa pessoa);
    
    Task<Pessoa> GetAsync(string id);
}