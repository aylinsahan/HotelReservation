using HotelReservation.MODEL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservation.MODEL.Entities
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get ; set; }
    }
}
