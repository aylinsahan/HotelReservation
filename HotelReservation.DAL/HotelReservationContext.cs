using HotelReservation.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.DAL
{
    public class HotelReservationContext : DbContext
    {
        public HotelReservationContext()
        {

        }
        public HotelReservationContext(DbContextOptions opt) : base(opt)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    RoomType = "Standart Oda",
                    RoomPrice = 100,
                    ExtraBedPriceRatio = 20,
                    WeekendPriceRatio = 30,
                    SingleRoomRatio = 30
                }
            );
        }

        

        public DbSet<Room> Room { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<TempRoom> TempRoom { get; set; }


    }
}
