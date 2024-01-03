using rinha_de_backend_2023.Data.Models;
using rinha_de_backend_2023.Data.Repositories.Interfaces;
using rinha_de_backend_2023.Models.DTO;
using rinha_de_backend_2023.Services.Interfaces;

namespace rinha_de_backend_2023.Services;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaService(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }
    
    public string Post(PessoaDTO pessoaDto)
    {
        var pessoa = new Pessoa(pessoaDto.Apelido, pessoaDto.Nome, pessoaDto.Nascimento, pessoaDto.Stack);
      
        var insertedEntityId = _pessoaRepository.Insert(pessoa);
        var path = $"/pessoas/{insertedEntityId}";

        return path;
    }

    public PessoaDTO? GetById(string id)
    {
        var response =  _pessoaRepository.GetById(id);

        if (response == null)
        {
            return null;
        }

        return new PessoaDTO
        {
            Apelido = response.Apelido,
            Nome = response.Nome,
            Nascimento = response.Nascimento,
            Stack = response.Technologies?.Select(t => t.Nome).ToList()
        };
    }
    
    public IList<PessoaDTO> Get(string term)
    {
        var response =  _pessoaRepository.Get(term);

        return response.Select(
            p => new PessoaDTO
                {
                    Apelido = p.Apelido,
                    Nome = p.Nome,
                    Nascimento = p.Nascimento,
                    Stack = p.Technologies?.Select(t => t.Nome).ToList()
                }
        ).ToList();
    }
}