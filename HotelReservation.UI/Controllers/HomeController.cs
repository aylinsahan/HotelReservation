using HotelReservation.BLL.Helper.Interface;
using HotelReservation.BLL.Interface;
using HotelReservation.DAL.Repositories.Interface;
using HotelReservation.MODEL.Entities;
using HotelReservation.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Diagnostics;
using System.Linq;

namespace HotelReservation.UI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITempRoomService _tempRoomServices;
        private readonly IRoomPriceCalculationService _roomPriceCalculationService;
        private readonly IReservationService _reservationService;
        private readonly IHelperProvider _helperProvider;

        public HomeController(ITempRoomService tempRoomServices, IRoomPriceCalculationService roomPriceCalculationService, IReservationService reservationService, IHelperProvider helperProvider)
        {
            _tempRoomServices = tempRoomServices;
            _roomPriceCalculationService = roomPriceCalculationService;
            _reservationService = reservationService;
            _helperProvider = helperProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RoomSearch(TempRoom model)
        {
            var result = false;
            result = _tempRoomServices.CreateTempRoom(model);

            return result == true ? RedirectToAction("GetRoom") : RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetRoom()
        {
            var data = _tempRoomServices.GetAll().FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult ReservationAdd(Reservation model)
        {
            var result = false;
            result = _reservationService.ReservationAdd(model);
            TempData["ReservationResult"] = result;
            return RedirectToAction("GetRoom");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
