using PublicHoliday;
using TollFeeCalculator.Vehicles;

namespace TollFeeCalculator
{
    public static class TollCalculator
    {

        /**
         * Calculate the total toll fee for one day for a certain vehicle
         *
         * @param vehicle - the vehicle
         * @param dates - date and time of all passes on one day
         * @return - the total toll fee for that day
         */

        public static int GetDailyTollFee(IVehicle vehicle, DateTime[] passes)
        {
            DateTime intervalStart = passes[0];
            int tempFee = GetPassageCost(vehicle, intervalStart);
            int totalFee = 0;
            
            foreach (DateTime pass in passes)
            {
                int nextFee = GetPassageCost(vehicle, pass);

                double minutes = (pass - intervalStart).TotalMinutes; //Get total minutes of a timespan

                if (minutes > 0 && minutes <= 60)
                {
                    totalFee -= tempFee; //Removes last added value in case there's a higher within the 1 hour interval
                    totalFee += tempFee = Math.Max(tempFee, nextFee); //Adds highest value in interval to total
                }
                else
                {
                    intervalStart = pass; //Set up new 1 hour interval
                    tempFee = nextFee; //Set up min cost for new interval
                    totalFee += nextFee; //Add to total
                }
            }
            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }



        /**
         * Calculate the toll fee for one pass for a certain vehicle
         *
         * @param vehicle - the vehicle
         * @param dates - date and time of the pass
         * @return - the toll fee for that pass
         */

        public static int GetPassageCost(IVehicle vehicle, DateTime date)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

            int hour = date.Hour;
            int minute = date.Minute;

            if (hour == 6 && minute <= 29) return 9;
            else if (hour == 6) return 16;

            else if (hour == 7) return 22;

            else if (hour == 8 && minute <= 29) return 16;
            else if (hour >= 8 && hour <= 14) return 9;

            else if (hour == 15 && minute <= 29) return 16;
            else if (hour == 15 || hour == 16) return 22;

            else if (hour == 17) return 16;

            else if (hour == 18 && minute <= 29) return 9;

            else return 0;
        }



        /**
         * Checks if vehicle doesn't need to pay toll
         *
         * @param vehicle - the vehicle
         * @return - True if no toll needed
         */

        private static bool IsTollFreeVehicle(IVehicle vehicle) => vehicle.IsTollFree;




        /**
         * Checks if it is a toll free day using third party package
         *
         * @param dates - date and time of the pass
         * @return - True if  no toll is needed
         */
        private static readonly SwedenPublicHoliday holidayCalendar = new SwedenPublicHoliday();
        private static Boolean IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (month == 7) return true; //Check if July

            else if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true; //Check if weekend

            else if (holidayCalendar.IsPublicHoliday(date) || holidayCalendar.IsPublicHoliday(date.AddDays(1))) return true; //Check if public holiday or day before

            else return false;
        }


    }

}