using Microsoft.AspNetCore.Mvc;
using Restourant.Models;

namespace Restourant.Controllers;
[ApiController]
[Route("[controller]")]
public class AdressController
{
    private readonly RestourantContext _context;
    public AdressController(RestourantContext context)
    {
        _context=context;
    }
    [HttpGet("Adresslarni ko'rish")]
    public List<Adress> Get()
    {
        return _context.Adresses.ToList();
    }

    [HttpPost]
    public string Insert(Adress adress)
    {
        if(_context.Adresses.Any(x=>x.Id==adress.Id))
        {
            throw new Exception("Bunday Id ega Addres mavjud");
        }
        _context.Adresses.Add(adress);
        _context.SaveChanges();
        return $"{adress.Id} ega bolgan adress qo'shildi";
    }

    [HttpPut]
    public string Update(Adress adress)
    {
        if (!_context.Adresses.Any(x => x.Id == adress.Id))
        {
            throw new Exception("Bunday Idga ega Adres mavjud emas");
        }
        _context.Adresses.Update(adress);
        return "Yangilandi";
    }


    [HttpDelete("Id boyicha o'chirish")]
    public  string Delete(Adress adress)
    {
        if (!_context.Adresses.Any(x=>x.Id==adress.Id))
        {
            throw new Exception("Adres topilmadi");
        }
        _context.Adresses.Remove(adress);
        _context.SaveChanges();
        return $"{adress.Id} ega Adres o'chirildi";
    }


}
