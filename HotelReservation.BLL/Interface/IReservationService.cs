using HotelReservation.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.BLL.Interface
{
    public interface IReservationService : IBaseService<Reservation>
    {
        bool ReservationAdd(Reservation model);
    }
}
