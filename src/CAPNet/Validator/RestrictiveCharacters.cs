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
        public static readonly ICollection<string> restrictiveCharacters =
                                               new[] { ",", ":", ">", "<",
                                                       "-", "+", "=", "]", 
                                                       "[", ")", "(", "*", 
                                                       "&", "^", "%", "$", 
                                                       "#", "!" };
    }
}
