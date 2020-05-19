using DAL.DBContext;
using System;

namespace TestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new HotelContext();

            foreach (var item in db.Hotels)
            {
                Console.WriteLine("ID: " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("City: " + item.City);
                Console.WriteLine("Address: " + item.Address);
                Console.WriteLine("Rating: " + item.Rating);
                Console.WriteLine();
            }
        }
    }
}
