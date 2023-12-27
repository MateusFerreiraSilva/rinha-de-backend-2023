using rinha_de_backend_2023.Data.Models;

namespace rinha_de_backend_2023.Data.Repositories.Interfaces;

public interface IPessoaRepository
{
    public Task<Pessoa> GetAsync(string id);
    
    public Task<string> InsertAsync(Pessoa pessoa);
}