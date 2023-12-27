using Microsoft.EntityFrameworkCore;
using rinha_de_backend_2023.Data.Models;
using rinha_de_backend_2023.Data.Repositories.Interfaces;

namespace rinha_de_backend_2023.Data.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly RinhaDbContext _dbContext;

    public PessoaRepository(RinhaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Pessoa> GetAsync(string id)
    {
        return await _dbContext.Pessoas.FirstAsync(p =>  p.Id == id);
    }

    public async Task<string> InsertAsync(Pessoa pessoa)
    {
        await _dbContext.Pessoas.AddAsync(pessoa);
        await _dbContext.SaveChangesAsync();

        return pessoa.Id;
    }
}