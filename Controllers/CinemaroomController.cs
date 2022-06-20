using AutoMapper;
using CINEMA.API.Context;
using CINEMA.API.DTO.CinemaRoom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CINEMA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaroomController : ControllerBase
    {
        private readonly CinemaDBContext _context;
        private readonly IMapper _mapper;

        public CinemaroomController(CinemaDBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet(Name = "GetAllRooms")]
       
        public async Task<ActionResult<IEnumerable<CinemaRoomResponse>>> Get()
        {
            var cinemaRooms = await _context.CinemaRoom.ToListAsync();

            var cinemaRoomResponse = _mapper.Map<List<CinemaRoomResponse>>(cinemaRooms);
            return Ok(cinemaRoomResponse);
        }
    }
}
