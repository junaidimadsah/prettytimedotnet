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
namespace PrettyTime.units
{
    public class Custom : TimeUnit
    {
        #region TimeUnit Members

        public long MillisPerUnit { get; set; }

        public long MaxQuantity { get; set; }

        public string Name { get; set; }

        public string PluralName { get; set; }

        public TimeFormat Format { get; set; }

        #endregion
    }
}