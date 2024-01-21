using rinha_de_backend_2023.Data.Models;
using rinha_de_backend_2023.Data.Repositories.Interfaces;
using rinha_de_backend_2023.Models.DTO.Requests;
using rinha_de_backend_2023.Models.DTO.Responses;
using rinha_de_backend_2023.Services.Interfaces;

namespace rinha_de_backend_2023.Services;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IContagemPessoasService _contagemPessoasService;
    
    public PessoaService(IPessoaRepository pessoaRepository, IContagemPessoasService contagemPessoasService)
    {
        _pessoaRepository = pessoaRepository;
        _contagemPessoasService = contagemPessoasService;
    }
    
    public string Post(PessoaRequestDTO pessoaRequestDto)
    {
        if (!pessoaRequestDto.IsStackValid())
        {
            return string.Empty;
        }

        var pessoa = new Pessoa(pessoaRequestDto.Apelido, pessoaRequestDto.Nome, pessoaRequestDto.Nascimento, pessoaRequestDto?.Stack);
      
        var insertedEntityId = _pessoaRepository.Insert(pessoa);

        if (insertedEntityId.Equals(string.Empty))
        {
            return string.Empty;
        }

        _contagemPessoasService.RegisterSuccessfulInsert();
        
        var path = $"/pessoas/{insertedEntityId}";

        return path;
    }

    public PessoaResponseDTO? GetById(string id)
    {
        var response =  _pessoaRepository.GetById(id);

        if (response == null)
        {
            return null;
        }

        return new PessoaResponseDTO
        {
            Id = response.Id,
            Apelido = response.Apelido,
            Nome = response.Nome,
            Nascimento = response.Nascimento,
            Stack = response.Stack
        };
    }
    
    public IList<PessoaResponseDTO> Get(string term)
    {
        var response =  _pessoaRepository.Get(term);

        return response.Select(
            p => new PessoaResponseDTO
                {
                    Id = p.Id,
                    Apelido = p.Apelido,
                    Nome = p.Nome,
                    Nascimento = p.Nascimento,
                    Stack = p.Stack
                }
        ).ToList();
    }
}