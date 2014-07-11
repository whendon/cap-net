namespace CAPNet.Models
{
    /// <summary>
    /// The paired values of a point and radius delineating the affected area of the alert message
    /// </summary>
    public class Circle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringRepresentation">The circular area is represented by a central point given as a [WGS 84] coordinate pair followed by a space character and a radius value in kilometers.</param>
        public Circle(string stringRepresentation)
        {
            var circleCenterAndRadius = stringRepresentation.Split(' ');
            this.Center = new Coordinate(circleCenterAndRadius[0]);
            this.Radius = double.Parse(circleCenterAndRadius[1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="radius"></param>
        public Circle(Coordinate coordinate, double radius)
        {
            this.Center = coordinate;
            this.Radius = radius;
        }

        /// <summary>
        /// radius value in kilometers
        /// </summary>
        public double Radius 
        {
            get; 
            private set; 
        }

        /// <summary>
        /// [WGS 84] coordinate pair 
        /// </summary>
        public Coordinate Center 
        { 
            get; 
            private set; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>central point given as a [WGS 84] coordinate pair followed by a space character and a radius value in kilometers</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", Center, Radius);
        }

    }
}
