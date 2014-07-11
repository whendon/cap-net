using System;

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
            var splitCoordinate = stringRepresentation.Split(',');
            this.X = double.Parse(splitCoordinate[0]);
            this.Y = double.Parse(splitCoordinate[1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        public double X
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public double Y
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
            return string.Format("{0},{1}", this.X, this.Y);
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
            var p = (Coordinate)obj;
            return (X == p.X && Y == p.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
