using DAL.Entities;
using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Room> Rooms { get; }
        IRepository<Hotel> Hotels { get; }
        IRepository<RoomType> RoomTypes { get; }
        IRepository<NutritionType> NutritionTypes { get; }
        IRepository<Client> Clients { get; }
        IRepository<RatingCriteria> RatingCriterias { get; }
        IReservationRepository Reservations { get; }
        void Save();
    }
}
