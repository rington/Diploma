using API.Models;
using AutoMapper;
using BLL.DTOs;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClientDTO, ClientView>();
            CreateMap<ClientView, ClientDTO>();

            CreateMap<HotelDTO, HotelView>();
            CreateMap<HotelView, HotelDTO>();

            CreateMap<RoomDTO,RoomView>();
            CreateMap<RoomView, RoomDTO>();

            CreateMap<RoomTypeDTO, RoomTypeView>();
            CreateMap<RoomTypeView, RoomTypeDTO>();

            CreateMap<ReservationDTO, ReservationView>();
            CreateMap<ReservationView, ReservationDTO>();

            CreateMap<RatingCriteriaDTO, RatingCriteriaView>();
            CreateMap<RatingCriteriaView, RatingCriteriaDTO>();

            CreateMap<NutritionTypeDTO, NutritionTypeView>();
            CreateMap<NutritionTypeView, NutritionTypeDTO>();
        }
    }
}
