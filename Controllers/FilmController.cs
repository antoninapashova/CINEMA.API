using AutoMapper;
using CINEMA.API.Context;
using CINEMA.API.DTO.Film;
using CINEMA.API.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CINEMA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {

        public  CinemaDBContext _context;
        public  IMapper _mapper;

        public FilmController(CinemaDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Return all films in the database
        /// 
        /// </summary>
        /// <returns>All films</returns>
        [HttpGet(Name ="GetAllFilms")]
        public async Task<ActionResult<IEnumerable<FilmResponse>>> Get()
        {
            var films = await _context.Film
                .Include(x => x.genre)
                 .Include(x => x.reservations)
                 .Include(x => x.cinemaRoom)
                .ToListAsync();

            var filmsResponse = _mapper.Map<List<FilmResponse>>(films);
            return Ok(filmsResponse);

        }

        /// <summary>
        /// Gets a film by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Only one film</returns>

        [HttpGet("{id}", Name ="GetFilmByID")]
        public async Task<ActionResult<IEnumerable<FilmResponse>>> Get(int id)
        {
            var film = await _context.Film.
                   Include(x => x.genre)
                 .Include(x => x.reservations)
                 .Include(x => x.cinemaRoom).FirstOrDefaultAsync(x=>x.FilmID == id);
            if (film == null)
            {
                return NotFound();
            }
            var filmResponse = _mapper.Map<FilmResponse>(film);
            return Ok(filmResponse);
        }

        /// <summary>
        /// Send a film to database
        /// </summary>
        /// <param name="filmRequest"></param>
        /// <returns>HTTP status for created book</returns>

        [HttpPost(Name ="addFilm")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Film>> Post(FilmRequest filmRequest)
        {
            var film = _mapper.Map<Film>(filmRequest);
             _context.Film.Add(film);
            await _context.SaveChangesAsync();
            var filmResponse = _mapper.Map<FilmResponse>(film);
            return CreatedAtAction("Get", new { id = filmResponse.FilmID }, filmResponse);
         
        }

        /// <summary>
        /// Update a film
        /// </summary>
        /// <param name="filmId"></param>
        /// <param name="filmRequest"></param>
        /// <returns>Returns updated film</returns>

        [HttpPut("/{filmId}", Name ="updateFilmByID")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FilmResponse>> Put(int filmId, FilmRequest filmRequest)
        {
            var originalFilm = await _context.Film.FindAsync(filmId);
            if (originalFilm == null)
            {
                return NotFound();
            }

            _mapper.Map(filmRequest, originalFilm);
            _context.Entry(originalFilm).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var filmResponse = _mapper.Map<FilmResponse>(originalFilm);
            return Ok(filmResponse);
        }

        /// <summary>
        /// Update only one property from one film 
        /// </summary>
        /// <param name="filmId"></param>
        /// <param name="filmRequestPath"></param>
        /// <returns>Updated film</returns>

        [HttpPatch("/{filmId}")]
        [Consumes("application/json-patch+json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FilmResponse>> Patch(int filmId, [FromBody] JsonPatchDocument<FilmRequest> filmRequestPath)
        {
            var originalFilm = await _context.Film.FindAsync(filmId);
            if (originalFilm == null)
            {
                return NotFound();
            }

            var filmRequest = _mapper.Map<FilmRequest>(originalFilm);
            filmRequestPath.ApplyTo(filmRequest);
            _mapper.Map(filmRequest, originalFilm);
            _context.Entry(originalFilm).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var filmResponse = _mapper.Map<FilmResponse>(originalFilm);
            return Ok(filmResponse);

        }
        /// <summary>
        /// Delete a film by ID
        /// </summary>
        /// <param name="filmId"></param>
        /// <returns>Status OK if the film is deleted or NotFound if there isn`t a film with same id</returns>

        [HttpDelete("{filmId}", Name = "deleteFilm")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int filmId)
        {
            var film = await _context.Film.FindAsync(filmId);
            if (film == null)
            {
                return NotFound();
            }
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
