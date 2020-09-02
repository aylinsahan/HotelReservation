using HotelReservation.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelReservation.BLL.Interface
{
    public interface ITempRoomService : IBaseService<TempRoom>
    {
        void DeleteAll();
        bool CreateTempRoom (TempRoom model);
    }
}
