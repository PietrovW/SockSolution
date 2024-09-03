using AspireAppSock.ApiService.Common.Interfaces;
using AspireAppSock.ApiService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspireAppSock.ApiService.Features.Customers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    [HttpGet]
    public ActionResult<List<Customer>> GetProducts()
    {
        return _customerRepository.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetProduct(long id)
    {
        var product = _customerRepository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    [HttpPost]
    public ActionResult AddProduct(Customer product)
    {
        _customerRepository.Add(product);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(long id, Customer product)
    {
        var existingProduct = _customerRepository.GetById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        _customerRepository.Update(product);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(long id)
    {
        var product = _customerRepository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        _customerRepository.Delete(product);
        return Ok();
    }
}