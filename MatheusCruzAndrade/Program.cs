using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatheusCruzAndrade
{
    class Program
    {

        public static string SumDate(long value, int _minute, int _hour, int _day, int _month, int _year)
        {
            int tot_mins = Convert.ToInt32(value);
            int days = tot_mins / 1440;
            int months = days / 30;
            int hours = (tot_mins % 1440) / 60;
            int mins = tot_mins % 60;

            int finalDay = 0, finalMonth = 0, finalYear = 0, finalHour = 0, finalMinute = 0;

            if (mins + _minute > 60)
            {
                _hour += 1;
                finalMinute = (mins + _minute) - 60;
            }
            else
            {
                finalMinute = (mins + _minute);
            }

            if (hours + _hour > 24)
            {
                _day += 1;
                finalHour = (hours + _hour) - 24;
            }
            else
            {
                finalHour = (hours + _hour);
            }

            int[] DaysW31 = new int[] { 1, 3, 5, 7, 8, 10, 12 };
            int[] DaysW30 = new int[] { 4, 6, 9, 11 };

            int quantDays = 0;

            if (DaysW31.Any(x => x.Equals(_month)))
                quantDays = 31;
            else if (DaysW30.Any(x => x.Equals(_month)))
                quantDays = 30;
            else
                quantDays = 28;

            if (days + _day > quantDays)
            {
                _month += 1;
                finalDay = (days + _day) - quantDays;
            }
            else
            {
                finalDay = (days +_day);
            }

            if (months + _month > 12)
            {
                _year += 1;
                finalMonth = (months + _month) - 12;
            }
            else
            {
                finalMonth = (months + _month);
            }

            finalYear = _year;

            string newDate = string.Format("{0}/{1}/{2} {3}:{4}", finalDay, finalMonth, finalYear, finalHour, finalMinute);

            return newDate;
        }

        public static string SubtractDate(long value, int _minute, int _hour, int _day, int _month, int _year)
        {
            int tot_mins = Convert.ToInt32(value);
            int days = tot_mins / 1440;
            int months = days / 30;
            int hours = (tot_mins % 1440) / 60;
            int mins = tot_mins % 60;

            int finalDay = 0, finalMonth = 0, finalYear = 0, finalHour = 0, finalMinute = 0;

            if (mins - _minute >= 0)
            {
                _hour -= 1;
                finalMinute = 60 -(mins - _minute);
            }
            else
            {
                //_hour -= 1;
                finalMinute = Math.Abs((mins - _minute));
            }

            if (hours - _hour >= 0)
            {
                finalHour = 24 - (hours - _hour);
            }
            else
            {
                _day -= 1;
                finalHour = Math.Abs((hours - _hour));
            }

            int[] DaysW31 = new int[] { 1, 3, 5, 7, 8, 10, 12 };
            int[] DaysW30 = new int[] { 4, 6, 9, 11 };

            int quantDays = 0;

            if (DaysW31.Any(x => x.Equals(_month)))
                quantDays = 31;
            else if (DaysW30.Any(x => x.Equals(_month)))
                quantDays = 30;
            else
                quantDays = 28;

            if (days - _day <= 0)
            {
                finalDay = Math.Abs(quantDays - (days - _day));
            }
            else
            {
                _month -= 1;
                finalDay = quantDays - (days - _day);
            }

            if (months - _month <= 0)
            {
                finalMonth = Math.Abs((months - _month));
            }
            else
            {
                _year -= 1;
                finalMonth = 12 - (months - _month);
            }

            finalYear = _year;

            string newDate = string.Format("{0}/{1}/{2} {3}:{4}", finalDay, finalMonth, finalYear, finalHour, finalMinute);

            return newDate;
        }

        public static string WriteDate(string date, char op, long value)
        {
            string[] Words = (date).Split(new char[] { '/', ' ', ':' });

            if (Words.Count().Equals(5))
            {
                int _day, _month, _year, _hour, _minute;

                _day = Convert.ToInt32(Words[0]);
                if (!(_day >= 1 && _day <= 31))
                    return "-3 Dia invalido.";

                _month = Convert.ToInt32(Words[1]);
                if (!(_month >= 1 && _month <= 12))
                    return "-4 Mes invalido.";

                _year = Convert.ToInt32(Words[2]);

                _hour = Convert.ToInt32(Words[3]);
                if (!(_hour >= 1 && _hour <= 24))
                    return "-6 Hora invalida.";

                _minute = Convert.ToInt32(Words[4]);
                if (!(_minute >= 0 && _minute <= 60))
                    return "-7 Minutos invalida.";

                if (op.Equals('+'))
                    return SumDate(value, _minute, _hour, _day, _month, _year);
                else
                    return SubtractDate(value, _minute, _hour, _day, _month, _year);
            }
            else
            {
                return "-2 Data em formato invalido.";
            }


        }

        public static string ChangeDate(string date, char op, long value)
        {
            if (op.Equals('+') || op.Equals('-'))
            {
                return WriteDate(date, op, Math.Abs(value));
            }
            else
            {
                return "-1 Operação invalida.";
            }
        }


        static void Main(string[] args)
        {
            string date = "01/12/2010 23:56";
            int value = 4000;

            string strResult = ChangeDate(date, '+', value);

            //DateTime dt = new DateTime();

            //dt = Convert.ToDateTime(date);

            //dt = dt.AddMinutes(value);

            //dt = dt.Subtract(new TimeSpan(0, value, 0));

            Console.WriteLine(strResult);
            Console.WriteLine(Convert.ToString(dt));

            Console.Read();

        }
    }
}
