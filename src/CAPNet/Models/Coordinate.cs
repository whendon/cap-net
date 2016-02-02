using System;
using System.Globalization;

namespace CAPNet.Models
{
    /// <summary>
    ///  [WGS 84] coordinate pair 
    /// </summary>
    public sealed class Coordinate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringRepresentation"></param>
        public Coordinate(string stringRepresentation)
        {
            if (stringRepresentation == null) { throw new ArgumentNullException(nameof(stringRepresentation)); }
            var splitCoordinate = stringRepresentation.Split(',');
            this.Latitude = decimal.Parse(splitCoordinate[0], CultureInfo.InvariantCulture);
            this.Longitude = decimal.Parse(splitCoordinate[1], CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public Coordinate(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Latitude
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Longitude
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0},{1}",
                Latitude,
                Longitude);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Coordinate p = (Coordinate)obj;
            return (this.Latitude == p.Latitude && this.Longitude == p.Longitude);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }
    }
}
