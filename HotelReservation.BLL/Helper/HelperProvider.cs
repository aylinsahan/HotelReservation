using HotelReservation.BLL.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservation.BLL.Helper
{
    public class HelperProvider: IHelperProvider
    {
        public int WeekdaysCount(DateTime entryDate, DateTime releaseDate)
        {
            var _entryDate = entryDate;
            var _releaseDate = releaseDate;
            var _dayCount = (releaseDate - entryDate).Days;
            var _dayOfWeek = new[] { DayOfWeek.Friday, DayOfWeek.Saturday };
            var _weekendCount = Enumerable.Range(0, _dayCount).Select(p => entryDate.AddDays(p)).Where(p => _dayOfWeek.Contains(p.DayOfWeek)).Count();
            var _weekdaysCount = _dayCount - _weekendCount;
            return _weekdaysCount;
        }

        public int WeekendCount(DateTime entryDate, DateTime releaseDate)
        {
            var _entryDate = entryDate;
            var _releaseDate = releaseDate;
            var _dayCount = (releaseDate - entryDate).Days;
            var _dayOfWeek = new[] { DayOfWeek.Friday, DayOfWeek.Saturday };
            var _weekendCount = Enumerable.Range(0, _dayCount).Select(p => entryDate.AddDays(p)).Where(p => _dayOfWeek.Contains(p.DayOfWeek)).Count();
            return _weekendCount;
        }
    }
}
