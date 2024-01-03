using Microsoft.EntityFrameworkCore;
using rinha_de_backend_2023.Data.Models;
using rinha_de_backend_2023.Data.Utils;
using rinha_de_backend_2023.Data.Repositories.Interfaces;

namespace rinha_de_backend_2023.Data.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly RinhaDbContext _dbContext;

    public PessoaRepository(RinhaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public  string Insert(Pessoa pessoa)
    {
        _dbContext.Pessoas.Add(pessoa);
        _dbContext.SaveChanges();

        return pessoa.Id;
    }

    public Pessoa? GetById(string id)
    {
        return _dbContext.Pessoas
            .Include(p => p.Technologies)
            .FirstOrDefault(p =>  p.Id == id);
    }
    
    public IList<Pessoa> Get(string term)
    {
        return _dbContext.Pessoas
            .Include(p => p.Technologies)
            .Where(p => p.Searchable.Contains(term))
            .Take(Constants.MAX_NUMBER_OF_REGISTERS_PER_QUERY)
            .ToList();
    }
}