using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        
        //Metodo che restituisce una lista di utenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()//l'ActionResult mi da la possibilità di far restituire alla chiamata anche risposte standard come BadRequest o NotFound.
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }


        //Metodo ceh restituisce un singolo utente tramite l'id
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //Il metodo Find() deve avere come parametro una primary key
            return await _context.Users.FindAsync(id);
            
        }
    }
}