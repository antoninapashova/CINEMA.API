using AutoMapper;
using CINEMA.API.Context;
using CINEMA.API.DTO.Reservation;
using CINEMA.API.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
    public class ReservationController : ControllerBase
    {
        private readonly CinemaDBContext _context;
        private readonly IMapper _mapper;

        public ReservationController(CinemaDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /// <summary>
        /// Return all reservations in the database
        /// </summary>
        /// <returns>All films</returns>

        [HttpGet(Name ="getAllReservations")]
        public async Task<ActionResult<IEnumerable<Reservation>>> Get()
        {
            //x => x.Collection.Select(y => y.Property)
            var reservations = await _context.Reservations
                //.Include(x => x.user)
                //.Include(x => x.film).ThenInclude(x=>x.cinemaRoom)
                    .ToListAsync();
            var reservationResponse = _mapper.Map<List<ReservationResponse>>(reservations);
            return Ok(reservationResponse);
        }

        /// <summary>
        /// Gets a reservation by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Only one reservation if exists</returns>

        [HttpGet("{id}", Name = "GetReservationByID")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Reservation>>> Get(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            var reservationResponse = _mapper.Map<ReservationResponse>(reservation);
            return Ok(reservationResponse);
        }


        [HttpGet("getUserReservations/{userId}", Name = "GetReservationByUser")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ReservationResponse>>> GetReservationByUser(int userId)
        {
            var reservation = await _context.Reservations.FindAsync(userId);
                //Include(x=>x.film).ThenInclude(x=>x.cinemaRoom).
                 //FirstOrDefaultAsync(x => x.userID == userId);
            if (reservation == null)
            {
                return NotFound();
            }
            var reservationResponse = _mapper.Map<ReservationResponse>(reservation);
            return Ok(reservationResponse);
        }

        /// <summary>
        /// Send a reservation to database
        /// </summary>
        /// 
        /// <returns>HTTP status for created reservation</returns>
        [HttpPost(Name = "addReservation")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Reservation>> Post(ReservationRequest reservationRequest)
        {
            var reservation = _mapper.Map<Reservation>(reservationRequest);
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            var reservationResponse = _mapper.Map<ReservationResponse>(reservation);


            return CreatedAtAction("Get", new { id = reservation.ReservationID }, reservationResponse);
        }

        /// <summary>
        /// Update a reservation
        /// </summary>
        /// <param name="reservationId"></param>
        /// <param name="reservationRequest"></param>
        /// <returns>Returns updated reservation</returns>
        [HttpPut("{reservationId}", Name = "updateReservation")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReservationResponse>> Put(int reservationId, ReservationRequest reservationRequest)
        {
            var originalReservation = await _context.Film.FindAsync(reservationId);
            if (originalReservation == null)
            {
                return NotFound();
            }

            _mapper.Map(reservationRequest, originalReservation);
            _context.Entry(originalReservation).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var reservationResponse = _mapper.Map<ReservationResponse>(originalReservation);
            return Ok(reservationResponse);
        }

        /// <summary>
        /// Update only one property from one reservation
        /// </summary>
        /// <param name="reservationId"></param>
        /// <param name="reservationRequestPath"></param>
        /// <returns>Updated reservation</returns>

        [HttpPatch("{reservationId}")]
        [Consumes("application/json-patch+json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReservationResponse>> Patch(int reservationId, [FromBody] JsonPatchDocument<ReservationRequest> reservationRequestPath)
        {
            var originalReservation = await _context.Reservations.FindAsync(reservationId);
            if (originalReservation == null)
            {
                return NotFound();
            }

            var reservationRequest = _mapper.Map<ReservationRequest>(originalReservation);
            reservationRequestPath.ApplyTo(reservationRequest);
            _mapper.Map(reservationRequest, originalReservation);
            _context.Entry(originalReservation).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var reservationResponse = _mapper.Map<ReservationResponse>(originalReservation);
            return Ok(reservationResponse);

        }
        /// <summary>
        /// Dekete reservation by ID
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns>Status OK if the film is deleted or NotFound if there isn`t a film with same id</returns>
        [HttpDelete("{reservationId}", Name = "deleteReservationByID")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation == null)
            {
                return NotFound();
            }
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
