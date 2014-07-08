using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class RestrictiveCharacters
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly IEnumerable<char> restrictiveCharacters =
                                               new[] { ',', ':', '>', '<',
                                                       '-', '+', '=', ']', 
                                                       '[', ')', '(', '*', 
                                                       '&', '^', '%', '$', 
                                                       '#', '!' };
    }
}
