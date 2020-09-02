using HotelReservation.DAL.Repositories.Interface;
using HotelReservation.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelReservation.DAL.Repositories
{
    public class TempRoomRepository : BaseRepository<TempRoom>, ITempRoomRepository
    {
        public TempRoomRepository(DbContext dbContext) : base(dbContext)
        {

        }

      
    }
}
