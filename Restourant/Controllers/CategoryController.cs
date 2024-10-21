using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restourant.Models;

namespace Restourant.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoryController
{
    private readonly RestourantContext _context;
    public CategoryController(RestourantContext context)
    {
        _context = context;
    }

    [HttpGet("Categoriyalarni ko'rish")]
    public List<Category> GetAll()
    {
        return _context.Categories.ToList();
    }


    [HttpGet("Category Id boyicha qidirish")]
    public string GetById(int id)
    {
        if(!_context.Categories.Any(c => c.Id == id))
        {
            return "Bunday Categoriya topilmadi.";
        }
        Category category = _context.Categories.First(c => c.Id == id);
        return $"{category.Id}.{category.Name}";
    }

    [HttpPost]
    public string Insert(Category category)
    {
        if (category.Id < 1)
        {
            throw new ArgumentException("Category Id 0 yoki undan kichkina bo'la olmaydi.");
        }
        if(_context.Categories.Any(x=>x.Id == category.Id))
        {
            throw new Exception("Id allaqachon bor");
        }
        _context.Categories.Add(category);
        _context.SaveChanges();
        return "qo'shildi";
    }
    
    [HttpPut]
    public Category Update(Category category)
    {
        if(!_context.Categories.Any(x=>x.Id==category.Id))
        {
            throw new Exception("Id topilmadi");
        }
        _context.Categories.Update(category);
        _context.SaveChanges();
        return category;
    }

    [HttpDelete("Id bo'yicha o'chirish")]
    public string Delete(int id)
    {
        if (!_context.Categories.Any(x => x.Id == id))
        {
            throw new Exception("Id topilmadi");
        }
        Category category= _context.Categories.First(x=>x.Id == id);
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return "o'chirildi";
    }


    


}
