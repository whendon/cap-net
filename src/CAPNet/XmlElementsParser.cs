using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public static class XmlElementsParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="representation"></param>
        /// <returns></returns>
        public static List<string> GetElements(this string representation)
        {
            representation = representation.Trim();
            var spaceContainingElements = GetSpaceContainingElements(representation);
            string spaceContainingElementsMarked = representation.MarkElements(spaceContainingElements);
            var elementsWithNoSpace = spaceContainingElementsMarked.Split(' ');
            var addresses = FillSpaceContainingElements(spaceContainingElements, elementsWithNoSpace);

            return addresses;
        }

        private static string MarkElements(this string representation, IEnumerable<string> spaceContainingElements)
        {
            foreach (var element in spaceContainingElements)
                representation = representation.Replace(element.ToString(), "\"\"");

            return representation;
        }

        private static IEnumerable<string> GetSpaceContainingElements(string representation)
        {
            string pattern = "\"[\\w ]*\"";
            Regex regexObject = new Regex(pattern);
            var spaceContainingElements = from Match match in regexObject.Matches(representation)
                                          select match.Value;

            return spaceContainingElements;
        }

        private static List<string> FillSpaceContainingElements(IEnumerable<string> spaceContainingElements, IEnumerable<string> elementsWithNoSpace)
        {

            var addresses = elementsWithNoSpace.ToList();

            int indexOfSpaceContainingElement = 0;
            for (int index = 0; index < addresses.Count(); index++)
            {
                var currentAddress = addresses.ElementAt(index);
                if (currentAddress.Equals("\"\""))
                {
                    addresses[index] = spaceContainingElements.ElementAt(indexOfSpaceContainingElement).Replace("\"", "");
                    indexOfSpaceContainingElement++;
                }
            }

            return addresses;
        }
    }
}
