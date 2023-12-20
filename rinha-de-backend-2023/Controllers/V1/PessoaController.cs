using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using rinha_de_backend_2023.Models;
using rinha_de_backend_2023.Services.Interfaces;

namespace rinha_de_backend_2023.Controllers.V1;

[ApiController]
public class PessoaController : ControllerBase
{
    private IPessoaService _pessoaService;

    PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    /// <summary>
    /// Create
    /// </summary>
    [HttpPost]
    [Route("/pessoas")]
    public async Task<IActionResult> PostAsync([Required]Pessoa pessoa)
    {
        var response = _pessoaService.PostAsync(pessoa);
        
        return Created($"/pessoas/{response.Id}", response);
    }
    
    /// <summary>
    /// Get
    /// </summary>
    [HttpGet]
    [Route("/pessoas/{id}")]
    public async Task<IActionResult> GetAsync([Required]string id)
    {
        var response = _pessoaService.GetAsync(id);
        
        return Ok(response);
    }
}