using Microsoft.AspNetCore.Mvc;
using Restourant.Models;
using System.Reflection.Metadata.Ecma335;

namespace Restourant.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController
{
    private readonly RestourantContext _context;
    public ProductController(RestourantContext context)
    {
        _context = context;
    }
    [HttpGet]
    public List<Product> GetAllProduct()
    {
       return _context.Products.ToList();
    }
    [HttpPost]
    public string PostProduct(Product product)
    {
        if(product == null)
        {
            throw new ArgumentNullException("Null");
        }
        if(_context.Products.Any(x=>x.Id == product.Id))
        {
            throw new Exception("Id mavjud");
        }
        if (product.Price < 0)
        {
            throw new Exception("Narx manfiy");
        }
        if(!_context.Categories.Any(x=>x.Id == product.CategoryId))
        {
            throw new Exception("Bunday Category Id yoq");
        }
        _context.Products.Add(product);
        _context.SaveChanges();
        return "qo'shildi";
    }
}
