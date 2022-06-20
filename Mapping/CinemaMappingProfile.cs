using AutoMapper;
using CINEMA.API.DTO.CinemaRoom;
using CINEMA.API.DTO.Film;
using CINEMA.API.DTO.Genre;
using CINEMA.API.DTO.Reservation;
using CINEMA.API.DTO.Role;
using CINEMA.API.DTO.User;
using CINEMA.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.Mapping
{
    public class CinemaMappingProfile : Profile
    {
        public CinemaMappingProfile()
        {

           CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, UserRequest>().ReverseMap();
            CreateMap<Film, FilmResponse>().ReverseMap();
            CreateMap<Film, FilmRequest>().ReverseMap();
            CreateMap<FilmRequest, Film>().ReverseMap();
            CreateMap<Reservation, ReservationResponse>().ReverseMap();
            CreateMap<Reservation, ReservationRequest>().ReverseMap();
            CreateMap<CinemaRoom, CinemaRoomResponse>().ReverseMap();
            CreateMap<UserRole, UserRoleResponse>().ReverseMap();
            CreateMap<Genre, GenreResponse>().ReverseMap();
            CreateMap<CinemaRoom, CinemaRoomResponse>().ReverseMap();
            CreateMap<UserRole, UserRoleRequest>().ReverseMap();
        }
    }
}
