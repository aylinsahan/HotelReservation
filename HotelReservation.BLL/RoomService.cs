using HotelReservation.BLL.Interface;
using HotelReservation.DAL.Repositories.Interface;
using HotelReservation.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HotelReservation.BLL
{
    public class RoomService : BaseService<IRoomRepository, Room>, IRoomService
    {
        public RoomService(IRoomRepository roomRepository) : base(roomRepository)
        {

        }
       
    }
}

