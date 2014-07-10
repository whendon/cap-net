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
        public static IEnumerable<string> GetElements(this string representation)
        {
            var addresses = new List<string>();
            char[] representationChars = representation.ToCharArray();
            const string decisionState = "spaceState";
            const string addCharInSpaceContainingAddress = "addCharInSpaceContainingAddress";
            const string addCharInAddressWithNoSpace = "addCharInAddressWithNoSpace";


            string state = decisionState;
            string partialElement = "";

            for (int i = 0; i < representationChars.Count(); i++)
            {
                char currentChar = representationChars[i];
                switch (state)
                {
                    case decisionState:
                        if (currentChar.IsSpace())
                        {
                            state = addCharInAddressWithNoSpace;
                        }
                        else if (currentChar.IsQuote())
                        {
                            state = addCharInSpaceContainingAddress;
                        }
                        else if (currentChar.IsElementCaracter())
                        {
                            state = addCharInAddressWithNoSpace;
                            partialElement += currentChar;
                        }
                        break;

                    case addCharInAddressWithNoSpace:
                        if (currentChar.IsElementCaracter())
                        {
                            state = addCharInAddressWithNoSpace;
                            partialElement += currentChar;
                            if (i == representationChars.Count() - 1)
                            {
                                addresses.Add(partialElement);
                            }
                        }
                        else if (currentChar.IsSpace())
                        {
                            addresses.Add(partialElement);
                            partialElement = "";
                            state = decisionState;
                        }
                        else if (currentChar.IsQuote())
                        {
                            state = addCharInSpaceContainingAddress;
                        }
                        break;

                    case addCharInSpaceContainingAddress:

                        if (currentChar.IsElementCaracter() || currentChar.IsSpace())
                        {
                            state = addCharInSpaceContainingAddress;
                            partialElement += currentChar;
                            if (i == representationChars.Count() - 1)
                            {
                                addresses.Add(partialElement);
                            }
                        }
                        else if (currentChar.IsQuote())
                        {
                            addresses.Add(partialElement);
                            partialElement = "";
                            state = decisionState;
                        }
                        break;
                }
            }

            return addresses;


        }

        private static bool IsElementCaracter(this char tested)
        {
            return tested.CompareTo('"') != 0 && tested.CompareTo(' ') != 0;
        }

        private static bool IsSpace(this char tested)
        {
            return tested.CompareTo(' ') == 0;
        }

        private static bool IsQuote(this char tested)
        {
            return tested.CompareTo('"') == 0;
        }

    }

}
