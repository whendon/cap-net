using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public static class RestrictedCharacters
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly IEnumerable<char> restrictedCharacters =
                                               new[] { ' ', ',', '<', '&' };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool DoesNotContainsRestrictedChars(this string str)
        {
            return !restrictedCharacters.Any(wrongChar => str.Contains(wrongChar.ToString()));
        }
    }
}
