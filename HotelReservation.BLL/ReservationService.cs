using HotelReservation.BLL.Interface;
using HotelReservation.DAL.Repositories.Interface;
using HotelReservation.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelReservation.BLL
{
    public class ReservationService : BaseService<IReservationRepository, Reservation>, IReservationService
    {
        private readonly ITempRoomService _tempRoomService;
        public ReservationService(IReservationRepository reservationRepository, ITempRoomService tempRoomService) : base(reservationRepository)
        {
            _tempRoomService = tempRoomService;
        }

        public bool ReservationAdd(Reservation model)
        {
            var id = _tempRoomService.GetAll().FirstOrDefault().Id;
            var data = _tempRoomService.GetById(id);
            model.EntyDate = data.EntyDate;
            model.ReleaseDate = data.ReleaseDate;
            model.NumberOfNight = data.NumberOfNight;
            model.GuestCount = data.GuestCount;
            model.TotalPrice = data.TotalPrice;
            model.Description = data.Description + data.Description2;
            model.CreatedDate = DateTime.Now;
            this.Add(model);     
            return true;
        }
    }
}
