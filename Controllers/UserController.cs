using AutoMapper;
using CINEMA.API.Context;
using CINEMA.API.DTO.User;
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
    public class UserController : ControllerBase
    {
        private readonly CinemaDBContext _context;
        private readonly IMapper _mapper;

        public UserController(CinemaDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all users from the databse
        /// </summary>
        /// <returns>All users</returns>
        [HttpGet(Name = "GetAllUsers")]
        [Route("/getAllUsers")]
        public async Task<ActionResult<IEnumerable<UserResponse>>> Get()
        {
            var users = await _context.User
                .Include(x => x.reservations)
                .Include(x => x.role).ToListAsync();

            var usersResponse = _mapper.Map<List<UserResponse>>(users);
            return Ok(usersResponse);
        }
        /// <summary>
        /// Get one user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Only one user if exists</returns>
        [HttpGet("{id}", Name = "GetUserByID")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserResponse>>> Get(int id)
        {
            var user = await _context.User.Include(x => x.reservations).
                ThenInclude(x=>x.film).ThenInclude(x=>x.cinemaRoom)
                .FirstOrDefaultAsync(x=>x.UserID==id);

            if (user == null)
            {
                return NotFound();
            }
            var response = _mapper.Map<UserResponse>(user);

            return Ok(response);
        }

        /// <summary>
        /// Send a user to databse
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddUser")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<User>> Post(UserRequest userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            var userResponse = _mapper.Map<UserResponse>(user);

            return CreatedAtAction("Get", new { id = userResponse.UserID }, userResponse);
        }
        /// <summary>
        /// Update a user by ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userRequest"></param>
        /// <returns>Updated user or Not Found if the user doesn`r exist in the databse </returns>

        [HttpPut("{userId}", Name = "UpdateUserByID")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserResponse>> Put(int userId, UserRequest userRequest)
        {
            var originalUser = await _context.Film.FindAsync(userId);
            if (originalUser == null)
            {
                return NotFound();
            }

            _mapper.Map(userRequest, originalUser);
            _context.Entry(originalUser).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var userResponse = _mapper.Map<UserResponse>(originalUser);
            return Ok(userResponse);
        }

        /// <summary>
        /// Update the value of only one property of the user entity 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userRequestPath"></param>
        /// <returns>Return updated user or Not Found if the user doesn`t exist in the database</returns>

        [HttpPatch("{userId}")]
        [Consumes("application/json-patch+json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserResponse>> Patch(int userId, [FromBody] JsonPatchDocument<UserRequest> userRequestPath)
        {
            var originalUser = await _context.User.FindAsync(userId);
            if (originalUser == null)
            {
                return NotFound();
            }

            var userRequest = _mapper.Map<UserRequest>(originalUser);
            userRequestPath.ApplyTo(userRequest);
            _mapper.Map(userRequest, originalUser);
            _context.Entry(originalUser).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var userResponse = _mapper.Map<UserResponse>(originalUser);
            return Ok(userResponse);

        }
        /// <summary>
        /// Delete user by ID, if the user exists in the database
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns OK if the operation is successfull, or NotFound, if user with same id doesn`t exist</returns>

        [HttpDelete("{userId}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int userId)
        {
            var user = await _context.User.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

       
    }
}
