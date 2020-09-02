using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.MODEL.Entities
{
    public class Room : BaseEntity<int>
    {
        public string RoomType { get; set; }
        public decimal RoomPrice { get; set; }
        public decimal ExtraBedPriceRatio { get; set; }
        public decimal WeekendPriceRatio { get; set; }
        public decimal SingleRoomRatio { get; set; }

    }

}
