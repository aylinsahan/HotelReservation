using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.BLL.Helper.Interface
{
    public interface IHelperProvider
    {
        int WeekdaysCount(DateTime entryDate, DateTime releaseDate);
        int WeekendCount(DateTime entryDate, DateTime releaseDate);
    }
}
