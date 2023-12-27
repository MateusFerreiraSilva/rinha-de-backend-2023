using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using rinha_de_backend_2023.Data.Models;
using rinha_de_backend_2023.Models.DTO;
using rinha_de_backend_2023.Services.Interfaces;

namespace rinha_de_backend_2023.Controllers.V1;

[ApiController]
[Route("/pessoas")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessoaService;
    
    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    /// <summary>
    /// Create
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    public async Task<IActionResult> PostAsync([FromBody] PessoaDTO pessoa)
    {
        var response = await _pessoaService.PostAsync(pessoa);

        return Created(response, null);
    }
    
    /// <summary>
    /// Get
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAsync([FromHeader, Required]string id)
    {
        var response = await _pessoaService.GetAsync(id);
        
        return Ok(response);
    }
}