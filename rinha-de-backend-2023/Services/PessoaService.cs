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

    public async Task<Pessoa> GetAsync(string id)
    {
        var response = await _pessoaRepository.GetAsync(id);

        return response;
    }

    public async Task<string> PostAsync(PessoaDTO pessoaDto)
    {
        var pessoa = new Pessoa
        {
            Apelido = pessoaDto.Apelido,
            Nome = pessoaDto.Nome,
            Nascimento = pessoaDto.Nascimento
        };
        var insertedEntityId = await _pessoaRepository.InsertAsync(pessoa);
        var path = $"/pessoas/{insertedEntityId}";

        return path;
    }
}