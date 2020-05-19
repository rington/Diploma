using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.DIResolver
{
    public static class DIForBLL
    {
        public static IServiceCollection AddDIForBLL(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IRoomTypeService, RoomTypeService>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IRatingCriteriaService, RatingCriteriaService>();
            services.AddTransient<INutritionTypeService, NutritionTypeService>();
            return services;
        }
    }
}
