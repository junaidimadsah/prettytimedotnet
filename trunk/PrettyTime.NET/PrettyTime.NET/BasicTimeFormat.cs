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

namespace PrettyTime
{
    public class BasicTimeFormat: TimeFormat
    {
        private const string NEGATIVE = "-";
        public const string SIGN = "%s";
        public const string QUANTITY = "%n";
        public const string UNIT = "%u";

        private string pattern = "";
        private string futurePrefix = "";
        private string futureSuffix = "";
        private string pastPrefix = "";
        private string pastSuffix = "";
        private int roundingTolerance = 0;

        public string format(Duration duration)
        {
            string sign = getSign(duration);
            string unit = getGramaticallyCorrectName(duration);
            long quantity = getQuantity(duration);

            string result = applyPattern(sign, unit, quantity);
            result = decorate(sign, result);
            return result;
        }

        private string decorate(string sign, string result)
        {
            if (NEGATIVE.Equals(sign))
            {
                result = pastPrefix + result + pastSuffix;
            }
            else
            {
                result = futurePrefix + result + futureSuffix;
            }
            return result;
        }

        private string applyPattern(string sign, string unit, long quantity)
        {
            string result = pattern.Replace(SIGN, sign);
            result = result.Replace(QUANTITY, quantity.ToString());
            result = result.Replace(UNIT, unit);
            return result;
        }

        private long getQuantity(Duration duration)
        {
            long quantity = Math.Abs(duration.quantity);

            if (duration.delta != 0)
            {
                double threshold = Math
                        .Abs(((double) duration.delta / (double) duration.unit.MillisPerUnit) * 100);
                if (threshold < roundingTolerance)
                {
                    quantity = quantity + 1;
                }
            }
            return quantity;
        }

        private string getGramaticallyCorrectName(Duration d)
        {
            string result = d.unit.Name;
            if ((Math.Abs(d.quantity) == 0) || (Math.Abs(d.quantity) > 1))
            {
                result = d.unit.PluralName;
            }
            return result;
        }

        private string getSign(Duration d)
        {
            if (d.quantity < 0)
            {
                return NEGATIVE;
            }
            return "";
        }

        /*
         * Builder Setters
         */
        public BasicTimeFormat setPattern(string pattern)
        {
            this.pattern = pattern;
            return this;
        }

        public BasicTimeFormat setFuturePrefix(string futurePrefix)
        {
            this.futurePrefix = futurePrefix;
            return this;
        }

        public BasicTimeFormat setFutureSuffix(string futureSuffix)
        {
            this.futureSuffix = futureSuffix;
            return this;
        }

        public BasicTimeFormat setPastPrefix(string pastPrefix)
        {
            this.pastPrefix = pastPrefix;
            return this;
        }

        public BasicTimeFormat setPastSuffix(string pastSuffix)
        {
            this.pastSuffix = pastSuffix;
            return this;
        }

        /**
         * The percentage of the current {@link TimeUnit}.getMillisPerUnit() for
         * which the quantity may be rounded up by one.
         * 
         * @param roundingTolerance
         * @return
         */
        public BasicTimeFormat setRoundingTolerance(int roundingTolerance)
        {
            this.roundingTolerance = roundingTolerance;
            return this;
        }

        /*
         * Normal getters
         */

        public string getPattern()
        {
            return pattern;
        }

        public string getFuturePrefix()
        {
            return futurePrefix;
        }

        public string getFutureSuffix()
        {
            return futureSuffix;
        }

        public string getPastPrefix()
        {
            return pastPrefix;
        }

        public string getPastSuffix()
        {
            return pastSuffix;
        }

        public int getRoundingTolerance()
        {
            return roundingTolerance;
        }
    }
}