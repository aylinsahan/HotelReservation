using HotelReservation.DAL.Repositories.Interface;
using HotelReservation.MODEL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DAL.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
