using Microsoft.AspNetCore.Mvc;
using Restourant.Models;

namespace Restourant.Controllers;
[ApiController]
[Route("[controller]")]

public class UserController
{
    private readonly RestourantContext _context;


    public UserController(RestourantContext context)
    {
        _context = context;
    }
    [HttpGet("Userlarni hamasini ko'rish")]
    public IEnumerable<User> GetAllUsers()
    {
        var list = _context.Users.ToList();
        return list;
    }


    [HttpGet("Userni Idsi bo'yicha qidirish")]
    public User? GetUser(int id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);
        return user;
    }


    [HttpPost("User qo'shish")]
    public int InsertUser(User user)
    {
        if (user == null)
        {
            throw new Exception("User xusiyatlari null");
        }
        if (_context.Users.Any(x => x.Id == user.Id))
        {
            throw new Exception("User Id allaqachon mavjud");
        }
        if (user.PhoneNumber.Length != 13)
        {
            throw new Exception("User telefon raqamida xatolik bor");
        }
        if (_context.Users.Any(x => x.Username == user.Username))
        {
            throw new Exception("Bunday Username allaqachon mavjud");
        }
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.Id;
    }


    [HttpPut("User Ma'lumotlarini yangilash")]
    public string UpdateUser(User user)
    {
        if (user == null)
        {
            throw new Exception("User xusiyatlari null");
        }
        if (!_context.Users.Any(x => x.Id == user.Id))
        {
            throw new Exception(" Yangilanayotgan User Id  mavjud emas ");
        }
        if (user.PhoneNumber.Length != 13)
        {
            throw new Exception(" Yangilanayotgan User telefon raqamida xatolik bor");
        }
        if (_context.Users.Any(x => x.Username == user.Username))
        {
            throw new Exception("Bunday Username allaqachon mavjud");
        }

        _context.Users.Update(user);
        _context.SaveChanges();
        return $"{user.Id} lik User malumotlari Yangilandi";
    }

    [HttpDelete("Userni Idsi bo'yicha o'chirish")]
    public string DeleteUser(int id)
    {
        if (id <= 1)
        {
            throw new Exception("User Id nol yoki undan kichik");
        }
        if (!_context.Users.Any(x => x.Id == id))
        {
            throw new Exception("Kiritilgan Id lik User yoq");
        }
        var user = _context.Users.Find(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
        return $"{id} lik user o'chirildi";
    }
}
