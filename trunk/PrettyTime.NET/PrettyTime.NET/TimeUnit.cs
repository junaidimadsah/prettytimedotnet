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
namespace PrettyTime
{
    public interface TimeUnit
    {
        /**
         * The number of milliseconds represented by each instance of this TimeUnit.
         * Must be a positive number greater than zero.
         * 
         * @return
         */
        long MillisPerUnit { get; }

        /**
         * The maximum quantity of this Unit to be used as a threshold for the next
         * largest Unit (e.g. if one <code>Second</code> represents 1000ms, and
         * <code>Second</code> has a maxQuantity of 5, then if the difference
         * between compared timestamps is larger than 5000ms, PrettyTime will move
         * on to the next smallest TimeUnit for calculation; <code>Minute</code>, by
         * default)
         * <p>
         * millisPerUnit * maxQuantity = maxAllowedMs
         * <p>
         * If maxQuantity is zero, it will be equal to the next highest
         * <code>TimeUnit.getMillisPerUnit() /
         * this.getMillisPerUnit()</code> or infinity if there are no greater
         * TimeUnits
         * 
         * @return
         */
        long MaxQuantity { get; }

        /**
         * The grammatically singular name for this unit of time. (e.g. one
         * "second")
         * 
         * @return
         */
        string Name { get; }

        /**
         * The grammatically plural name for this unit of time. (e.g. many
         * "seconds")
         * 
         * @return
         */
        string PluralName { get; }

        /**
         * The current {@link BasicTimeFormat} for this unit of time.
         * 
         * @return
         */
        TimeFormat Format { get; }
    }
}