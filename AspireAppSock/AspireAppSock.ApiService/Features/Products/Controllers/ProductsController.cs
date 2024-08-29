using Microsoft.AspNetCore.Mvc;
using AspireAppSock.ApiService.Domain.Models;
namespace AspireAppSock.ApiService.Features.Products.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _productRepository;

    public ProductsController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetProducts()
    {
        return _productRepository.GetAllProducts();
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = _productRepository.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    [HttpPost]
    public ActionResult AddProduct(Product product)
    {
        _productRepository.AddProduct(product);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(long id, Product product)
    {
        var existingProduct = _productRepository.GetProductById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        _productRepository.UpdateProduct(product);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(long id)
    {
        var product = _productRepository.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        _productRepository.DeleteProduct(id);
        return Ok();
    }
}
