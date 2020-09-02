using HotelReservation.MODEL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.MODEL.Entities
{
    public class TempRoom : BaseEntity<int>
    {
        public DateTime EntyDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfNight { get; set; }
        public int WeekendCount { get; set; }
        public int WeekdaysCount { get; set; }
        public int GuestCount { get; set; }
        public string RoomType { get; set; }
        public decimal RoomPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ExtraBedPrice { get; set; }
        public decimal WeekendPrice { get; set; }
        public decimal SinglePrice { get; set; }
        public int StandardRoom { get; set; }
        public int SingleRoom { get; set; }
        public int ExtraBedRoom { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }

    }
}
