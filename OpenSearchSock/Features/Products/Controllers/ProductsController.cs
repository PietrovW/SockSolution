using Microsoft.AspNetCore.Mvc;
using OpenSearchSock.Domain.Models;
using OpenSearchSock.Common.Interfaces;
namespace OpenSearchSock.Features.Products.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductRepository productRepository) : ControllerBase
{
    private readonly IProductRepository _productRepository = productRepository;

    [HttpGet]
    public ActionResult<List<Product>> GetProducts()
    {
        return _productRepository.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(long id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    [HttpPost]
    public ActionResult AddProduct(Product product)
    {
        _productRepository.Add(product);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(long id, Product product)
    {
        var existingProduct = _productRepository.GetById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        _productRepository.Update(product);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(long id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        _productRepository.Delete(product);
        return Ok();
    }
}



