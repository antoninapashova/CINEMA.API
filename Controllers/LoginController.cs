using AutoMapper;
using CINEMA.API.Context;
using CINEMA.API.DTO.User;
using CINEMA.API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly CinemaDBContext _context;
        private readonly IMapper _mapper;

        public LoginController(CinemaDBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet("/{email}/{password}")]
        [Consumes("application/json")]
        public async Task<ActionResult<UserResponse>> UserDetailsLogin(
         [FromQuery] string email, [FromQuery] string password)
        {
            User login = await _context.User.
                Where(x => x.email==email && x.password==password).Include(x => x.role)
                .SingleOrDefaultAsync();
            if (login == null)
            {
                 return NotFound(email);
            }
            var response = _mapper.Map<UserResponse>(login);
            return Ok(response);
        }
    }
}
