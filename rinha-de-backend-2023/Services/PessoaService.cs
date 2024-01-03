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

    public async Task<PessoaDTO> GetAsync(string id)
    {
        var response = await _pessoaRepository.GetAsync(id);

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

    public async Task<string> PostAsync(PessoaDTO pessoaDto)
    {
        var pessoa = new Pessoa
        {
            Apelido = pessoaDto.Apelido,
            Nome = pessoaDto.Nome,
            Nascimento = pessoaDto.Nascimento,
            Technologies = pessoaDto.Stack?.ToList()
                .Select(t => new Technology { Nome = t })
                .ToList()
        };
      
        var insertedEntityId = await _pessoaRepository.InsertAsync(pessoa);
        var path = $"/pessoas/{insertedEntityId}";

        return path;
    }
}