/*
 * PrettyTime.NET is an OpenSource .NET time comparison library for creating human
 * readable time. This is a modified version of PrettyTime, created by Lincoln 
 * Baxter, III from OcpSoft. PrettyTime can be found at 
 * <http://code.google.com/p/prettytime/>.
 * 
 * PrettyTime.NET - Copyright (C) 2009 - Adam Yeager <adam.yeager@gmail.com>
 * PrettyTime - Copyright (C) 2009 - Lincoln Baxter, III <lincoln@ocpsoft.com>
 * 
 * This program is free software: you can redistribute it and/or modify it under
 * the terms of the GNU Lesser General Public License as published by the Free
 * Software Foundation, either version 3 of the License, or (at your option) any
 * later version.
 * 
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
 * details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program. If not, see the file COPYING.LESSER3 or visit the
 * GNU website at <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using PrettyTime.units;

namespace PrettyTime
{
    public class PrettyTime: IDisposable
    {
        public DateTime reference { get; set; }
        private List<TimeUnit> units;

        /**
         * Default constructor
         */
        public PrettyTime()
        {
            startUnits();
            this.reference = DateTime.Now;
        }

        /**
         * Constructor accepting a Date timestamp to represent the point of
         * reference for comparison. This may be changed by the user, after
         * construction.
         * <p>
         * See {@code PrettyTime.setReference(Date timestamp)}.
         * 
         * @param reference
         */
        public PrettyTime(DateTime reference)
        {
            startUnits();
            this.reference = reference;
        }

        /**
         * Calculate the approximate duration between the referenceDate and date
         * 
         * @param date
         * @return
         */
        public Duration approximateDuration(DateTime then)
        {
            TimeSpan ts = then - reference;
            long difference = Convert.ToInt64(Math.Floor(ts.TotalMilliseconds));
            return calculateDuration(difference);
        }

        private Duration calculateDuration(long difference)
        {
            long absoluteDifference = Math.Abs(difference);

            Duration result = new Duration();

            for (int i = 0; i < units.Count; i++)
            {
                TimeUnit unit = units[i];
                long millisPerUnit = Math.Abs(unit.MillisPerUnit);
                long quantity = Math.Abs(unit.MaxQuantity);

                bool isLastUnit = (i == units.Count - 1);

                if ((quantity == 0) && !isLastUnit)
                {
                    quantity = units[i + 1].MillisPerUnit / unit.MillisPerUnit;
                }

                // does our unit encompass the time duration?
                if ((millisPerUnit * quantity > absoluteDifference) || isLastUnit)
                {
                    result.unit = unit;
                    if (millisPerUnit > absoluteDifference)
                    {
                        // we are rounding up: get 1 or -1 for past or future
                        result.quantity = getSign(difference, absoluteDifference);
                    }
                    else
                    {
                        result.quantity = difference / millisPerUnit;
                    }

                    result.delta = difference - result.quantity * millisPerUnit;
                    break;
                }

            }

            return result;
        }

        private long getSign(long difference, long absoluteDifference)
        {
            if (difference < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        /**
         * Calculate to the precision of the smallest provided {@link TimeUnit}, the
         * exact duration represented by the difference between the reference
         * timestamp, and {@code then}
         * <p>
         * <b>Note</b>: Precision may be lost if no supplied {@link TimeUnit} is
         * granular enough to represent one millisecond
         * 
         * @param then
         *            The date to be compared against the reference timestamp, or
         *            <i>now</i> if no reference timestamp was provided
         * @return A sorted {@link List} of {@link Duration} objects, from largest
         *         to smallest. Each element in the list represents the approximate
         *         duration (number of times) that {@link TimeUnit} to fit into the
         *         previous element's delta. The first element is the largest
         *         {@link TimeUnit} to fit within the total difference between
         *         compared dates.
         */
        public List<Duration> calculatePreciseDuration(DateTime then)
        {
            List<Duration> result = new List<Duration>();
            TimeSpan ts = then - reference;
            //long difference = Convert.ToInt64(Math.Floor(ts.TotalMilliseconds));
            long difference = Convert.ToInt64(ts.TotalMilliseconds);
            Duration duration = calculateDuration(difference);
            result.Add(duration);
            while (duration.delta > 0)
            {
                duration = calculateDuration(duration.delta);
                if (duration.unit is TimeUnit)
                {
                    result.Add(duration);
                }
            }
            return result;
        }

        /**
         * Format the given {@link Duration} object, using the {@link TimeFormat}
         * specified by the {@link TimeUnit} contained within
         * 
         * @param duration
         *            the {@link Duration} to be formatted
         * @return A formatted string representing {@code duration}
         */
        private string format(Duration duration)
        {
            TimeFormat format = duration.unit.Format;
            return format.format(duration);
        }

        /**
         * Format the given {@link Date} object. This method applies the {@code
         * PrettyTime.approximateDuration(date)} method to perform its calculation
         * 
         * @param duration
         *            the {@link Date} to be formatted
         * @return A formatted string representing {@code then}
         */
        public string format(DateTime Date)
        {
            Duration d = approximateDuration(Date);
            return format(d);
        }

        public string format(string Date)
        {
            Duration d = approximateDuration(Convert.ToDateTime(Date));
            return format(d);
        }

        /**
         * Get a {@link List} of the current configured {@link TimeUnit}s in this
         * instance.
         * 
         * @return
         */
        public List<TimeUnit> getUnits()
        {
            return units;
        }

        /**
         * Set the current configured {@link TimeUnit}s to be used in calculations
         * 
         * @return
         */
        public void setUnits(List<TimeUnit> units)
        {
            this.units = units;
        }

        public void setUnits(params TimeUnit[] units)
        {
            this.units = units.ToList<TimeUnit>();
        }

        private void startUnits()
        {
            this.units = new List<TimeUnit>();
            this.units.Add(new JustNow());
            this.units.Add(new Minute());
            this.units.Add(new Hour());
            this.units.Add(new Day());
            this.units.Add(new Week());
            this.units.Add(new Month());
            this.units.Add(new Year());
        }

        #region IDisposable Members
        //Implement IDisposable.
        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Free other state (managed objects).
            }
            // Free your own state (unmanaged objects).
            // Set large fields to null.
        }

        ~PrettyTime()
        {
          Dispose (false);
        }
        #endregion
    }
}