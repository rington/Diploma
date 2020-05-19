using DAL.DBContext;
using DAL.Entities;
using DAL.Interfaces;
using System;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelContext _db;
        private ClientRepository _clientRepository;
        private HotelRepository _hotelRepository;
        private RoomRepository _roomRepository;
        private RoomTypeRepository _roomTypeRepository;
        private ReservationRepository _reservationRepository;
        private RatingCriteriaRepository _ratingCriteriaRepository;
        private NutritionTypeRepository _nutritionTypeRepository;
        private bool _disposed;

        public UnitOfWork()
        {
            _db = new HotelContext();
        }
        public IRepository<Hotel> Hotels => _hotelRepository ?? (_hotelRepository = new HotelRepository(_db));

        public IRepository<Room> Rooms => _roomRepository ?? (_roomRepository = new RoomRepository(_db));

        public IRepository<RoomType> RoomTypes => _roomTypeRepository ?? (_roomTypeRepository = new RoomTypeRepository(_db));
        public IRepository<NutritionType> NutritionTypes => _nutritionTypeRepository ?? (_nutritionTypeRepository = new NutritionTypeRepository(_db));
        public IRepository<Client> Clients => _clientRepository ?? (_clientRepository = new ClientRepository(_db));
        public IRepository<RatingCriteria> RatingCriterias => _ratingCriteriaRepository ?? (_ratingCriteriaRepository = new RatingCriteriaRepository(_db));

        public IReservationRepository Reservations => _reservationRepository ?? (_reservationRepository = new ReservationRepository(_db));
        public void Save()
        {
            _db.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
