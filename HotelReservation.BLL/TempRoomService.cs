using System;
using HotelReservation.BLL.Interface;
using System.Collections.Generic;
using System.Text;
using HotelReservation.MODEL.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using HotelReservation.DAL;
using HotelReservation.DAL.Repositories.Interface;
using System.Linq;
using HotelReservation.DAL.Repositories;
using HotelReservation.BLL.Helper.Interface;

namespace HotelReservation.BLL
{
    public class TempRoomService : BaseService<ITempRoomRepository, TempRoom>, ITempRoomService
    {
        private readonly IHelperProvider _helperProvider;
        private readonly IRoomPriceCalculationService _roomPriceCalculationService;
        public TempRoomService(ITempRoomRepository tempRoomRepository, IHelperProvider helperProvider, IRoomPriceCalculationService roomPriceCalculationService) 
            : base(tempRoomRepository)
        {
            _helperProvider = helperProvider;
            _roomPriceCalculationService = roomPriceCalculationService;
        }

        public bool CreateTempRoom (TempRoom model)
        {
            this.DeleteAll();
            var weekend = _helperProvider.WeekendCount(model.EntyDate, model.ReleaseDate);
            var weekdays = _helperProvider.WeekdaysCount(model.EntyDate, model.ReleaseDate);
            var extraBedRoom = model.GuestCount / 3;
            var standardRoom = model.GuestCount % 3;
            var data = model;
            data.EntyDate = model.EntyDate;
            data.ReleaseDate = model.ReleaseDate;
            data.GuestCount = model.GuestCount;
            data.WeekendCount = weekend;
            data.WeekdaysCount = weekdays;
            data.NumberOfNight = weekdays + weekend;
            data.StandardRoom = standardRoom;
            data.ExtraBedRoom = extraBedRoom;
            data.Description = standardRoom != 0 ? standardRoom + " Kişilik Standart Oda " : "";
            data.Description2 = extraBedRoom != 0 ? " 3 Kişilik " + extraBedRoom + " Adet Standat Oda Ekstra Yataklı " : "";
            data.TotalPrice = _roomPriceCalculationService.RoomPriceCalculate(model.EntyDate, model.ReleaseDate, model.GuestCount);
            this.Add(data);

            return true;
        }

        public void DeleteAll()
        {
            Repository.DeleteAll();
        }
    }

}

