using AutoMapper;
using CINEMA.API.Context;
using CINEMA.API.DTO.Genre;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly CinemaDBContext _context;
        private readonly IMapper _mapper;

        public GenreController(CinemaDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllGenres")]
        public async Task<ActionResult<IEnumerable<GenreResponse>>> Get()
        {
            var genres = await _context.Genre.ToListAsync();

            var genreResponse = _mapper.Map<List<GenreResponse>>(genres);
            return Ok(genreResponse);
        }
    }
}
