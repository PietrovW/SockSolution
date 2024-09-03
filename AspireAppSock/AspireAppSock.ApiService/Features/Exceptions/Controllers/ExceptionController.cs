using AspireAppSock.ApiService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspireAppSock.ApiService.Features.Exceptions.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExceptionController(ILogger<ExceptionController> logger) : ControllerBase
{
    private readonly ILogger<ExceptionController> _logger = logger;
    [HttpGet]
    public ActionResult<List<Product>> GetProducts()
    {
        try
        {
            throw new Exception("Testing exceptions - ML");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unknown error occurred on the Index action of the HomeController");
        }
        return BadRequest();
    }
}
