using Microsoft.AspNetCore.Mvc;
using Restourant.Models;

namespace Restourant.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeController
{
    private readonly RestourantContext _context;
    public EmployeeController(RestourantContext context)
    {
        _context = context;
    }
    [HttpGet("Barcha Employeelarni ko'rish")]
    public List<Employee>? GetAll()
    {
        return _context.Employees.ToList();
    }
    [HttpPost]
    public string Insert(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException("Null");
        }
        if(_context.Employees.Any(x=>x.Id==employee.Id)) 
        {
            throw new ArgumentException("Bunday Idga ega foydalanuvchi mavjud");
        }
        if(_context.Employees.Any(x => x.UserName == employee.UserName))
        {
            throw new ArgumentException("Bunday Usernamega ega Employee mavjud");
        }
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return $"{employee.Id}.{employee.UserName}  employee qo'shildi.";
    }
    [HttpPut]
    public string Update(Employee employee)
    {
        if(!_context.Employees.Any(x=>x.Id == employee.Id))
        {
            throw new ArgumentException("Bunday Id lik Employee mavjud emas");
        }
        _context.Employees.Update(employee);
        _context.SaveChanges();
        return "Ozgartirildi";
    }

    [HttpDelete]
    public string Delete(int id)
    {
        if (!_context.Employees.Any(x => x.Id == id))
        {
            throw new ArgumentException("Id topilmadi");
        }
        Employee? employee = _context.Employees.Find(id);
        _context.Employees.Remove(employee);
        return $"{employee.UserName} o'chrildi";
    }
}
