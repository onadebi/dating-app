using System.Collections;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable>> GetUsers()
    {
        List<AppUser> users = await _context.AppUsers.ToListAsync();
        if (users == null || users.Count == 0) return NotFound();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        AppUser? user = await _context.AppUsers.FindAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

}
