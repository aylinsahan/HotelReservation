using HotelReservation.MODEL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservation.MODEL.Entities
{
    public class Reservation : BaseEntity<int>
    {
        [Required]
        public DateTime EntyDate { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public int NumberOfNight { get; set; }
        [Required]
        public int GuestCount { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
