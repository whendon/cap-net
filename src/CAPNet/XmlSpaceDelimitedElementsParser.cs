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
    public static class XmlSpaceDelimitedElementsParser
    {

        private const string decisionState = "spaceState";
        private const string addCharInSpaceContainingAddress = "addCharInSpaceContainingAddress";
        private const string addCharInAddressWithNoSpace = "addCharInAddressWithNoSpace";

        private static string state;
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
            state = decisionState;
            partialElement = "";

            for (currentPosition = 0; currentPosition < representationChars.Count(); currentPosition++)
            {
                char currentChar = representationChars[currentPosition];
                switch (state)
                {
                    case decisionState:
                        DecisionState(currentChar);
                        break;

                    case addCharInAddressWithNoSpace:
                        AddCharInAddressWithNoSpaceState(currentChar);
                        break;

                    case addCharInSpaceContainingAddress:

                        AddCharInSpaceContainingAddressState(currentChar);
                        break;
                }
            }

            return addresses;
        }

        private static void AddCharInSpaceContainingAddressState(char currentChar)
        {
            if (currentChar.IsElementCaracter() || currentChar.IsSpace())
            {
                state = addCharInSpaceContainingAddress;
                partialElement += currentChar;
                if (currentPosition== representationChars.Count() - 1)
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
        }

        private static void AddCharInAddressWithNoSpaceState(char currentChar)
        {
            if (currentChar.IsElementCaracter())
            {
                state = addCharInAddressWithNoSpace;
                partialElement += currentChar;
                if (currentPosition== representationChars.Count() - 1)
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
        }

        private static void DecisionState(char currentChar)
        {
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
