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
        private const int betweenAddressesState = 0;
        private const int InSpaceContainingAddress = 1;
        private const int InAddressWithNoSpace = 2;

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
            state = betweenAddressesState;
            partialElement = "";

            for (currentPosition = 0; currentPosition < representationChars.Count(); currentPosition++)
            {
                char currentChar = representationChars[currentPosition];
                switch (state)
                {
                    case betweenAddressesState:
                        BetweenAddressesState(currentChar);
                        break;

                    case InAddressWithNoSpace:
                        InAddressWithNoSpaceState(currentChar);
                        break;

                    case InSpaceContainingAddress:

                        InSpaceContainingAddressState(currentChar);
                        break;
                }
            }

            addresses.RemoveAll(content => content.Equals(""));
            return addresses;
        }

        private static void InSpaceContainingAddressState(char currentChar)
        {
            if (currentChar.IsElementCaracter() || currentChar.IsSpace())
            {
                state = InSpaceContainingAddress;
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
                state = betweenAddressesState;
            }
        }

        private static void InAddressWithNoSpaceState(char currentChar)
        {
            if (currentChar.IsElementCaracter())
            {
                state = InAddressWithNoSpace;
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
                state = betweenAddressesState;
            }
            else if (currentChar.IsQuote())
            {
                state = InSpaceContainingAddress;
            }
        }

        private static void BetweenAddressesState(char currentChar)
        {
            if (currentChar.IsSpace())
            {
                state = InAddressWithNoSpace;
            }
            else if (currentChar.IsQuote())
            {
                state = InSpaceContainingAddress;
            }
            else if (currentChar.IsElementCaracter())
            {
                state = InAddressWithNoSpace;
                partialElement += currentChar;
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
