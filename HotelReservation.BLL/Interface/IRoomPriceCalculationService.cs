using HotelReservation.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.BLL.Interface
{
  public  interface IRoomPriceCalculationService
    {

        decimal RoomPriceCalculate(DateTime entryDate, DateTime releaseDate, int guestCount);
        decimal RatioCalculation(decimal price, decimal ratio);
    }
}
