using HotelReservation.BLL.Helper.Interface;
using HotelReservation.BLL.Interface;
using HotelReservation.DAL.Repositories.Interface;
using HotelReservation.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservation.BLL
{
    public class RoomPriceCalculationService : IRoomPriceCalculationService
    {
        private readonly IRoomService _roomService;
        private readonly IHelperProvider _helperProvider;
        public RoomPriceCalculationService(IRoomService roomService, IHelperProvider helperProvider)
        {
            _roomService = roomService;
            _helperProvider = helperProvider;
        }

        public decimal RatioCalculation(decimal price, decimal ratio)
        {
            var result = (price * ratio) / 100;
            return result;
        }

        public decimal RoomPriceCalculate(DateTime entryDate, DateTime releaseDate, int guestCount)
        {
            var weekend = _helperProvider.WeekendCount(entryDate, releaseDate);
            var weekdays = _helperProvider.WeekdaysCount(entryDate, releaseDate);
            var room = _roomService.GetAll().FirstOrDefault(); // 

            decimal totalPrice = 0, weekdaysPrice, weekendPrice;

            var extrabedRoom = guestCount / 3; // kaç tane ekstra yataklı oda 
            var standardRoom = guestCount % 3; // standart oda kaç kişilik
            weekdaysPrice = room.RoomPrice;
            weekendPrice = room.RoomPrice + RatioCalculation(room.RoomPrice, room.WeekendPriceRatio);

            if (extrabedRoom != 0)
            {
                var extraBedPrice = RatioCalculation(room.RoomPrice, room.ExtraBedPriceRatio);

                totalPrice += (((weekdaysPrice + extraBedPrice) * extrabedRoom) * weekdays);
                totalPrice += (((weekendPrice + extraBedPrice) * extrabedRoom) * weekend);

            }
            if (standardRoom != 0)
            {
                var singlePrice = RatioCalculation(room.RoomPrice, room.SingleRoomRatio);

                if (standardRoom == 1)
                {
                    totalPrice += ((weekdaysPrice - singlePrice) * weekdays);
                    totalPrice += ((weekendPrice - singlePrice) * weekend);
                }
                else
                {
                    totalPrice += (weekdaysPrice * weekdays);
                    totalPrice += (weekendPrice * weekend);
                }
            }
            return totalPrice;

        }
    }
}
