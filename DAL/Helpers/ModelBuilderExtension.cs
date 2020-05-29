using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Helpers
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Florida Hotel",
                    City = "Kyiv",
                    Address = "Shcherbakivskogo Street 52",
                    NutritionTypeId = 1,
                    Description = "Some description",
                    HasParking = false,
                    HasRoomCleaning = false,
                    DistanceToCityCenter = 3.5,
                    Rating = 3
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Goloseevo Hotel",
                    City = "Kyiv",
                    Address = "Goloseevsky Prospect 87",
                    NutritionTypeId = 4,
                    Description = "Some description",
                    HasParking = false,
                    HasRoomCleaning = true,
                    DistanceToCityCenter = 1.5,
                    Rating = 4
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Two Mirrors Design Hotel",
                    City = "Odessa",
                    Address = "Bohdan Khmelnitsky Street 34A",
                    NutritionTypeId = 5,
                    Description = "Some description",
                    HasParking = true,
                    HasRoomCleaning = true,
                    DistanceToCityCenter = 1,
                    Rating = 5
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Cityhotel Apartments",
                    City = "Kharkiv",
                    Address = "Gogolevskaya Street 8",
                    NutritionTypeId = 5,
                    Description = "Some description",
                    HasParking = true,
                    HasRoomCleaning = true,
                    DistanceToCityCenter = 0.6,
                    Rating = 5
                }
            );

            modelBuilder.Entity<RoomType>().HasData(
                new RoomType
                {
                    Id = 1,
                    Name = "Suit",
                    Description = "Superior rooms, mainly consist of 2 rooms - belong to the luxury category.",
                    Capacity = 3
                },
                new RoomType
                {
                    Id = 2,
                    Name = "De Luxe",
                    Description =
                        "Superior rooms which mainly bigger than others. Have all necessary appliances with excellent quality.",
                    Capacity = 4
                },
                new RoomType
                {
                    Id = 3,
                    Name = "Standart",
                    Description = "Standard single rooms with minimum comfort.",
                    Capacity = 2
                },
                new RoomType
                {
                    Id = 4,
                    Name = "Duplex",
                    Description = "Two-story suit room which has three comfortable rooms for living",
                    Capacity = 6
                }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, FirstName = "Sergey", LastName = "Burenko", Rating = 0.0 },
                new Client { Id = 2, FirstName = "Oksana", LastName = "Panatko", Rating = 0.0 },
                new Client { Id = 3, FirstName = "Alexandr", LastName = "Shmatko", Rating = 0.0 },
                new Client { Id = 4, FirstName = "Dmitriy ", LastName = "Kovalenko", Rating = 0.0 },
                new Client { Id = 5, FirstName = "Viktor", LastName = "Tsygankov", Rating = 0.0 },
                new Client { Id = 6, FirstName = "Elena", LastName = "Sinica", Rating = 0.0 },
                new Client { Id = 7, FirstName = "Roman", LastName = "Zaiets", Rating = 0.0 }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, RoomTypeId = 1, HotelId = 1, IsReserved = false, Price = 119.9 },
                new Room { Id = 2, RoomTypeId = 1, HotelId = 1, IsReserved = true, Price = 119.9 },
                new Room { Id = 3, RoomTypeId = 2, HotelId = 1, IsReserved = false, Price = 149.2},
                new Room { Id = 4, RoomTypeId = 3, HotelId = 1, IsReserved = true, Price = 80.5 },
                new Room { Id = 5, RoomTypeId = 3, HotelId = 1, IsReserved = true, Price = 80.5 },
                new Room { Id = 6, RoomTypeId = 3, HotelId = 1, IsReserved = true, Price = 80.5 },

                new Room { Id = 7, RoomTypeId = 1, HotelId = 2, IsReserved = false, Price = 140.2 },
                new Room { Id = 8, RoomTypeId = 1, HotelId = 2, IsReserved = false, Price = 140.2 },
                new Room { Id = 9, RoomTypeId = 1, HotelId = 2, IsReserved = false, Price = 140.2 },
                new Room { Id = 10, RoomTypeId = 1, HotelId = 2, IsReserved = false, Price = 140.2 },
                new Room { Id = 11, RoomTypeId = 2, HotelId = 2, IsReserved = false, Price = 195 },
                new Room { Id = 12, RoomTypeId = 3, HotelId = 2, IsReserved = true, Price = 115},
                new Room { Id = 13, RoomTypeId = 3, HotelId = 2, IsReserved = true, Price = 115 },

                new Room { Id = 14, RoomTypeId = 1, HotelId = 3, IsReserved = false, Price = 321.8 },
                new Room { Id = 15, RoomTypeId = 2, HotelId = 3, IsReserved = false, Price = 472.1 },
                new Room { Id = 16, RoomTypeId = 3, HotelId = 3, IsReserved = false, Price = 240.8 },
                new Room { Id = 17, RoomTypeId = 4, HotelId = 3, IsReserved = false, Price = 670.8},

                new Room { Id = 18, RoomTypeId = 1, HotelId = 4, IsReserved = false, Price = 329 },
                new Room { Id = 19, RoomTypeId = 2, HotelId = 4, IsReserved = false, Price = 502.1 },
                new Room { Id = 20, RoomTypeId = 3, HotelId = 4, IsReserved = false, Price = 251.7 },
                new Room { Id = 21, RoomTypeId = 4, HotelId = 4, IsReserved = false, Price = 694.4}                
            );

            modelBuilder.Entity<Reservation>().HasData(
                 new Reservation
                 {
                     Id = 1,
                     RoomId = 1,
                     ClientId = 1,
                     BookingDate = new DateTime(2020, 06, 01),
                     BookingDateEnd = new DateTime(2020, 06, 10)
                 },
                new Reservation
                {
                    Id = 2,
                    RoomId = 2,
                    ClientId = 3,
                    BookingDate = new DateTime(2020, 05, 28),
                    BookingDateEnd = new DateTime(2020, 06, 5)
                },
                new Reservation
                {
                    Id = 3,
                    RoomId = 10,
                    ClientId = 4,
                    BookingDate = new DateTime(2020, 06, 01),
                    BookingDateEnd = new DateTime(2020, 06, 11)
                },
                 new Reservation
                 {
                     Id = 4,
                     RoomId = 9,
                     ClientId = 2,
                     BookingDate = new DateTime(2020, 06, 01),
                     BookingDateEnd = new DateTime(2020, 06, 11)
                 }
            );

            modelBuilder.Entity<RatingCriteria>().HasData(
                new RatingCriteria
                {
                    Id = 1,
                    HotelId = 1,
                    ClientId = 1,
                    Decency = 10,
                    RoomCleanliness = 9,
                    HotelRulesCompliance = 10,
                    Behavior = 9,
                    Comment = "Well-mannered client. Recomend!"
                },
                new RatingCriteria
                {
                    Id = 2,
                    HotelId = 2,
                    ClientId = 1,
                    Decency = 10,
                    RoomCleanliness = 10,
                    HotelRulesCompliance = 10,
                    Behavior = 10,
                    Comment = "Well-mannered client. Recomend!"
                },
                new RatingCriteria
                {
                    Id = 3,
                    HotelId = 3,
                    ClientId = 3,
                    Decency = 10,
                    RoomCleanliness = 9,
                    HotelRulesCompliance = 10,
                    Behavior = 9,
                    Comment = "Well-mannered client. Recomend!"
                }
            );
            modelBuilder.Entity<NutritionType>().HasData(
               new NutritionType
               {
                   Id = 1,
                   Name = "RO(Room only)",
                   Description = "Has not any nutrition.",
                   IsPaid = false
               },
               new NutritionType
               {
                    Id = 2,
                    Name = "BB(Bed & breakfast)",
                    Description = "Has only breakfast.",
                    IsPaid = true
               },
               new NutritionType
               {
                    Id = 3,
                    Name = "HB(Half board)",
                    Description = "Has breakfast and dinner.",
                    IsPaid = true
               },
               new NutritionType
               {
                    Id = 4,
                    Name = "FB(Full board)",
                    Description = "Has breakfast, lunch and dinner.",
                    IsPaid = true
               },
               new NutritionType
               {
                   Id = 5,
                   Name = "AI(All inclusive)",
                   Description = "Has breakfast, lunch and dinner. All drinks are free. Unlimited servings.",
                   IsPaid = false
               }
            );
        }
    }
}
