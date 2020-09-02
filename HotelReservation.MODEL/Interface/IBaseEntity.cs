using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservation.MODEL.Interface
{
    /// <summary>
    /// Generic type in key id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseEntity<T>
    {
        [Key]
        T Id { get; set; }
    }
}
