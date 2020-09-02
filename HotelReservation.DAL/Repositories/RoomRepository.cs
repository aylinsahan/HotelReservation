using HotelReservation.DAL.Repositories.Interface;
using HotelReservation.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelReservation.DAL.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(DbContext dbContext) : base(dbContext)
        {

        }      
    }
}
