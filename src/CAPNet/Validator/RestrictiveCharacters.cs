using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
