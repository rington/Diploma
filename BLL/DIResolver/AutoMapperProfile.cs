using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.DIResolver
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();

            CreateMap<Hotel, HotelDTO>();
            CreateMap<HotelDTO, Hotel>();

            CreateMap<Room, RoomDTO>();
            CreateMap<RoomDTO, Room>();

            CreateMap<RoomType, RoomTypeDTO>();
            CreateMap<RoomTypeDTO, RoomType>();

            CreateMap<Reservation, ReservationDTO>();
            CreateMap<ReservationDTO, Reservation>();

            CreateMap<RatingCriteria, RatingCriteriaDTO>();
            CreateMap<RatingCriteriaDTO, RatingCriteria>();

            CreateMap<NutritionType, NutritionTypeDTO>();
            CreateMap<NutritionTypeDTO, NutritionType>();
        }
    }
}
