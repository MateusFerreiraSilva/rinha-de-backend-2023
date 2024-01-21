using Microsoft.EntityFrameworkCore;
using Npgsql;
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
    
    public string Insert(Pessoa pessoa)
    {
        try
        {
            _dbContext.Pessoas.Add(pessoa);
            _dbContext.SaveChanges();

            return pessoa.Id;
        }
        catch (DbUpdateException exception) when (exception.InnerException is NpgsqlException sqlException)
        {
            switch (sqlException.SqlState)
            {
                case Constants.CONSTRAINT_VIOLATION_CODE:
                case Constants.UNIQUE_CONSTRAINT_VIOLATION_CODE:
                case Constants.LENGTH_CONSTRAINT_VIOLATION_CODE:
                    return string.Empty;
                default:
                    Console.Write("Ah muleke");
                    throw;
            }
        }
        catch (Exception ex)
        {
            Console.Write("ahh carai");
            Console.Write(ex);
            throw;
        }
    }

    public Pessoa? GetById(string id)
    {
        return _dbContext.Pessoas
            .FirstOrDefault(p =>  p.Id == id);
    }
    
    public IList<Pessoa> Get(string term)
    {
        return _dbContext.Pessoas
            .Where(p => p.Searchable.Contains(term.ToLower().RemoveAllWhiteSpaces()))
            .Take(Constants.MAX_NUMBER_OF_REGISTERS_PER_QUERY)
            .ToList();
    }
}