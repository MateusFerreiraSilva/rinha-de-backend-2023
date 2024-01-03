using rinha_de_backend_2023.Data.Models;

namespace rinha_de_backend_2023.Data.Repositories.Interfaces;

public interface IPessoaRepository
{
    public string Insert(Pessoa pessoa);

    public Pessoa? GetById(string id);
    
    public IList<Pessoa> Get(string term);
}