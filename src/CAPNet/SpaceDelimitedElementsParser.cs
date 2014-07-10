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
    public static class SpaceDelimitedElementsParser
    {
        private const int BETWEEN_ELEMENTS = 0;
        private const int IN_SPACE_CONTAINING_ELEMENTS = 2;
        private const int IN_ELEMENTS_WITH_NO_SPACE = 1;
    
        private static int state;
        private static string partialElement;
        private static int currentPosition;
        private static char[] representationChars;
        private static List<string> addresses;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="representation"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetElements(this string representation)
        {
            addresses = new List<string>();
            representationChars = representation.ToCharArray();
            partialElement = "";

            state = BETWEEN_ELEMENTS;

            for (currentPosition = 0; currentPosition < representationChars.Count(); currentPosition++)
            {
                char currentChar = representationChars[currentPosition];
                switch (state)
                {
                    case BETWEEN_ELEMENTS:
                        BetweenAddressesState(currentChar);
                        break;

                    case IN_ELEMENTS_WITH_NO_SPACE:
                        InAddressWithNoSpaceState(currentChar);
                        break;

                    case IN_SPACE_CONTAINING_ELEMENTS:

                        InSpaceContainingAddressState(currentChar);
                        break;
                }
            }

            return addresses;
        }

        private static void InSpaceContainingAddressState(char currentChar)
        {
            if (currentChar.IsElementCaracter() || currentChar.IsSpace())
            {
                state = IN_SPACE_CONTAINING_ELEMENTS;
                partialElement += currentChar;
                if (currentPosition == representationChars.Count() - 1)
                {
                    addresses.Add(partialElement);
                }
            }
            else if (currentChar.IsQuote())
            {
                addresses.Add(partialElement);
                partialElement = "";
                state = BETWEEN_ELEMENTS;
            }
        }

        private static void InAddressWithNoSpaceState(char currentChar)
        {
            if (currentChar.IsElementCaracter())
            {
                state = IN_ELEMENTS_WITH_NO_SPACE;
                partialElement += currentChar;
                if (currentPosition == representationChars.Count() - 1)
                {
                    addresses.Add(partialElement);
                }
            }
            else if (currentChar.IsSpace())
            {
                addresses.Add(partialElement);
                partialElement = "";
                state = BETWEEN_ELEMENTS;
            }
            
        }

        private static void BetweenAddressesState(char currentChar)
        {
            if (currentChar.IsSpace())
            {
                state = BETWEEN_ELEMENTS;
            }
            else if (currentChar.IsQuote())
            {
                state = IN_SPACE_CONTAINING_ELEMENTS;
            }
            else if (currentChar.IsElementCaracter())
            {
                state = IN_ELEMENTS_WITH_NO_SPACE;
                partialElement += currentChar;
                if (currentPosition == representationChars.Count() - 1)
                {
                    addresses.Add(partialElement);
                }
            }
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
