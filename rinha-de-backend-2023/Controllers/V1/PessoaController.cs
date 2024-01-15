using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using rinha_de_backend_2023.Models.DTO.Requests;
using rinha_de_backend_2023.Models.DTO.Responses;
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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] PessoaRequestDTO pessoaRequest)
    {
        var response = _pessoaService.Post(pessoaRequest);

        if (response.Equals(string.Empty))
        {
            return UnprocessableEntity();
        }

        return Created(response, null);
    }
    
    /// <summary>
    /// Get with id
    /// </summary>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(string id)
    {
        var response = _pessoaService.GetById(id);
        
        return response == null ? NotFound() : Ok(response);
    }
    
    /// <summary>
    /// Get with specific term
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Get([FromQuery(Name="t"), Required] string term)
    {
        var response = _pessoaService.Get(term);
        
        return Ok(response);
    }
}