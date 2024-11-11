﻿using System.Collections.Generic;
using System.Text;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public static class SpaceDelimitedElementsParser
    {
        private enum States
        {
            BETWEEN_ELEMENTS = 0,
            IN_SPACE_CONTAINING_ELEMENTS = 1,
            IN_ELEMENTS_WITH_NO_SPACE = 2
        }
        private static States currentState;
        private static StringBuilder partialElement;
        private static int currentPosition;
        private static List<string> elements;
        private static string representation;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Multiple space-delimited elements MAY be included.
        /// Elements including whitespace MUST be enclosed in double-quotes.</param>
        /// <returns>Elements in a IEnumerable&lt;string></returns>
        public static IEnumerable<string> GetSpaceDelimitedElements(this string value)
        {
            representation = value;
            elements = new List<string>();
            partialElement = new StringBuilder();
            currentState = States.BETWEEN_ELEMENTS;

            for (currentPosition = 0; currentPosition < representation.Length; currentPosition++)
            {
                char currentChar = representation[currentPosition];
                switch (currentState)
                {
                    case States.BETWEEN_ELEMENTS:
                        BetweenElementsState(currentChar);
                        break;

                    case States.IN_ELEMENTS_WITH_NO_SPACE:
                        InAddressWithNoSpaceState(currentChar);
                        break;

                    case States.IN_SPACE_CONTAINING_ELEMENTS:
                        InSpaceContainingAddressState(currentChar);
                        break;
                    default:
                        throw new SpaceDelimitedElementsParserException($"Invalid parser state: {currentState}");
                }
            }

            return elements;
        }

        private static void InSpaceContainingAddressState(char currentChar)
        {
            if (currentChar.IsElementCharacterOrSpace())
            {
                partialElement.Append(currentChar);
                if (currentPosition == representation.Length - 1)
                {
                    elements.Add(partialElement.ToString());
                }
            }
            else if (currentChar.IsQuote())
            {
                elements.Add(partialElement.ToString());
                partialElement.Clear();
                currentState = States.BETWEEN_ELEMENTS;
            }
        }

        private static void InAddressWithNoSpaceState(char currentChar)
        {
            if (currentChar.IsElementCharacter())
            {
                partialElement.Append(currentChar);
                if (currentPosition == representation.Length - 1)
                {
                    elements.Add(partialElement.ToString());
                }
            }
            else if (currentChar.IsSpace())
            {
                elements.Add(partialElement.ToString());
                partialElement.Clear();
                currentState = States.BETWEEN_ELEMENTS;
            }

        }

        private static void BetweenElementsState(char currentChar)
        {
            if (currentChar.IsQuote())
            {
                currentState = States.IN_SPACE_CONTAINING_ELEMENTS;
            }
            else if (currentChar.IsElementCharacter())
            {
                currentState = States.IN_ELEMENTS_WITH_NO_SPACE;
                partialElement.Append(currentChar);
                if (currentPosition == representation.Length - 1)
                {
                    elements.Add(partialElement.ToString());
                }
            }
        }

        private static bool IsElementCharacter(this char tested)
        {
            return !tested.IsQuote() && !tested.IsSpace();
        }

        private static bool IsSpace(this char tested)
        {
            return tested == ' ';
        }

        private static bool IsQuote(this char tested)
        {
            return tested == '"';
        }

        private static bool IsElementCharacterOrSpace(this char tested)
        {
            return tested.IsElementCharacter() || tested.IsSpace();
        }
    }

}
