using Microsoft.AspNetCore.Mvc;
using rinha_de_backend_2023.Services.Interfaces;

namespace rinha_de_backend_2023.Controllers.V1;

[ApiController]
[Route("/contagem-pessoas")]
public class ContagemPessoasController : ControllerBase
{
    private readonly IContagemPessoasService _contagemPessoasService;
    
    public ContagemPessoasController(IContagemPessoasService contagemPessoasService)
    {
        _contagemPessoasService = contagemPessoasService;
    }
    
    /// <summary>
    /// Returns the number of success on the insert
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    public string Get()
    {
        return _contagemPessoasService.CountSuccessfulInserts();
    }
}