using System.Globalization;

namespace Domain.Common
{
    public class DateTimeToPersianDateTimeConverter
    {
        private readonly string _separator;
        private readonly bool _includeHourMinute;

        public DateTimeToPersianDateTimeConverter(string separator = "/", bool includeHourMinute = true)
        {
            _separator = separator;
            _includeHourMinute = includeHourMinute;
        }

        public string toShamsiDateTime(DateTime? prmVal)
        {
            if (prmVal == null)
                return "";
            DateTime info = prmVal ?? DateTime.Now;
            var year = info.Year;
            var month = info.Month;
            var day = info.Day;
            var persianCalendar = new PersianCalendar();
            var pYear = persianCalendar.GetYear(new DateTime(year, month, day, new GregorianCalendar()));
            var pMonth = persianCalendar.GetMonth(new DateTime(year, month, day, new GregorianCalendar()));
            var pDay = persianCalendar.GetDayOfMonth(new DateTime(year, month, day, new GregorianCalendar()));
            return _includeHourMinute ?
                string.Format("{0}{1}{2}{1}{3} {4}:{5}", pYear, _separator, pMonth.ToString("00", CultureInfo.InvariantCulture), pDay.ToString("00", CultureInfo.InvariantCulture), info.Hour.ToString("00"), info.Minute.ToString("00"))
                : string.Format("{0}{1}{2}{1}{3}", pYear, _separator, pMonth.ToString("00", CultureInfo.InvariantCulture), pDay.ToString("00", CultureInfo.InvariantCulture));
        }

        public DateTime getFirstDayOfLastMonth()
        {
            DateTime info = DateTime.Now;
            var year = info.Year;
            var month = info.Month;
            var day = info.Day;
            var persianCalendar = new PersianCalendar();
            var pYear = persianCalendar.GetYear(new DateTime(year, month, day, new GregorianCalendar()));
            var pMonth = persianCalendar.GetMonth(new DateTime(year, month, day, new GregorianCalendar()));
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(pYear, pMonth - 1, 1, pc);
            return dt;
        }

        public DateTime getLastDayOfLastMonth()
        {
            DateTime info = DateTime.Now;
            var year = info.Year;
            var month = info.Month;
            var day = info.Day;
            var persianCalendar = new PersianCalendar();
            var pYear = persianCalendar.GetYear(new DateTime(year, month, day, new GregorianCalendar()));
            var pMonth = persianCalendar.GetMonth(new DateTime(year, month, day, new GregorianCalendar()));
            var pDay = 0;

            pMonth = pMonth - 1;

            if (pMonth == 12)
                pDay = 29;
            if (pMonth >= 1 && pMonth <= 6)
                pDay = 31;
            if (pMonth >= 7 && pMonth < 12)
                pDay = 30;

            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(pYear, pMonth, pDay, pc);
            return dt;
        }

        //Get Current Shamsi year in Miladi date
        public Tuple<DateTime, DateTime> getCurrentYear()
        {
            DateTime info = DateTime.Now;
            var year = info.Year;
            var month = info.Month;
            var day = info.Day;
            var persianCalendar = new PersianCalendar();
            var pYear = persianCalendar.GetYear(new DateTime(year, month, day, new GregorianCalendar()));
            var pMonth = persianCalendar.GetMonth(new DateTime(year, month, day, new GregorianCalendar()));
            var pDay = 0;

            if (pMonth == 12)
                pDay = 29;
            if (pMonth >= 1 && pMonth <= 6)
                pDay = 31;
            if (pMonth >= 7 && pMonth < 12)
                pDay = 30;

            PersianCalendar pc = new PersianCalendar();

            DateTime startYearDate = new DateTime(pYear, 1, 1, pc);
            DateTime endYearDate = new DateTime(pYear, pMonth, pDay, pc);

            var result = new Tuple<DateTime, DateTime>(startYearDate, endYearDate);
            return result;
        }

        //Get Last Two Shamsi year in Miladi date
        public Tuple<DateTime, DateTime> getLastTwoYear()
        {
            DateTime info = DateTime.Now;
            var year = info.Year;
            var month = info.Month;
            var day = info.Day;
            var persianCalendar = new PersianCalendar();
            var pYear = persianCalendar.GetYear(new DateTime(year, month, day, new GregorianCalendar()));
            var pMonth = persianCalendar.GetMonth(new DateTime(year, month, day, new GregorianCalendar()));
            var pDay = 0;

            if (pMonth == 12)
                pDay = 29;
            if (pMonth >= 1 && pMonth <= 6)
                pDay = 31;
            if (pMonth >= 7 && pMonth < 12)
                pDay = 30;

            PersianCalendar pc = new PersianCalendar();

            DateTime startYearDate = new DateTime(pYear - 1, 1, 1, pc);
            DateTime endYearDate = new DateTime(pYear, pMonth, pDay, pc);

            var result = new Tuple<DateTime, DateTime>(startYearDate, endYearDate);
            return result;
        }


        //Get Last Shamsi month in Miladi date
        public Tuple<DateTime, DateTime> getLastMonth()
        {
            DateTime info = DateTime.Now;
            var year = info.Year;
            var month = info.Month - 1;
            var day = info.Day;
            var persianCalendar = new PersianCalendar();
            var pYear = persianCalendar.GetYear(new DateTime(year, month, day, new GregorianCalendar()));
            var pMonth = persianCalendar.GetMonth(new DateTime(year, month, day, new GregorianCalendar()));

            var pDay = 0;

            if (pMonth == 12)
                pDay = 29;
            if (pMonth >= 1 && pMonth <= 6)
                pDay = 31;
            if (pMonth >= 7 && pMonth < 12)
                pDay = 30;

            PersianCalendar pc = new PersianCalendar();

            DateTime startMonthDate = new DateTime(pYear, pMonth, 1, pc);
            DateTime endMonthDate = new DateTime(pYear, pMonth, pDay, pc);

            var result = new Tuple<DateTime, DateTime>(startMonthDate, endMonthDate);
            return result;
        }

        //Get Current Shamsi month in Miladi date
        public Tuple<DateTime, DateTime> getMiladiMonth(int pYear, int pMonth)
        {
            var pDay = 0;

            if (pMonth == 12)
                pDay = 29;
            if (pMonth >= 1 && pMonth <= 6)
                pDay = 31;
            if (pMonth >= 7 && pMonth < 12)
                pDay = 30;

            PersianCalendar pc = new PersianCalendar();

            DateTime startMonthDate = new DateTime(pYear, pMonth, 1, pc);
            DateTime endMonthDate = new DateTime(pYear, pMonth, pDay, pc);

            var result = new Tuple<DateTime, DateTime>(startMonthDate, endMonthDate);
            return result;
        }
        public int getShamsiYear(DateTime? prmVal)
        {
            if (prmVal == null)
                return 0;
            DateTime info = prmVal ?? DateTime.Now;
            var year = info.Year;
            var month = info.Month;
            var day = info.Day;
            var persianCalendar = new PersianCalendar();
            var pYear = persianCalendar.GetYear(new DateTime(year, month, day, new GregorianCalendar()));
            return pYear;
        }

        public int getShamsiMonth(DateTime? prmVal)
        {
            if (prmVal == null)
                return 0;
            DateTime info = prmVal ?? DateTime.Now;
            var year = info.Year;
            var month = info.Month;
            var day = info.Day;
            var persianCalendar = new PersianCalendar();
            var pMonth = persianCalendar.GetMonth(new DateTime(year, month, day, new GregorianCalendar()));
            return pMonth;
        }
    }
}
