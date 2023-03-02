﻿using System;
using System.Text.RegularExpressions;

namespace IronChallenge
{
    public class Phone
    {
        /// <summary>
        /// Only allow numbers 0 to 9, hash '#', asterisk '*' and space ' '. 
        /// </summary>
        private static readonly Regex ValidChars = new Regex("^[0-9#\\* ]*$");

        /// <summary>
        /// This multi-dimensional array represents the keypad. The first
        /// dimension represents the index of the key. For each dimension we add
        /// a list of associated characters.
        /// </summary>
        static readonly char[][] Keys = {
            new char[] { ' ' },					// 0
		    new char[] { '&', '\'', '(' },		// 1
		    new char[] { 'A', 'B', 'C' },		// 2
		    new char[] { 'D', 'E', 'F' },		// 3
            new char[] { 'G', 'H', 'I' },		// 4
            new char[] { 'J', 'K', 'L' },		// 5
            new char[] { 'M', 'N', 'O' },		// 6
            new char[] { 'P', 'Q', 'R', 'S' },	// 7
            new char[] { 'T', 'U', 'V' },		// 8
            new char[] { 'W', 'X', 'Y', 'Z' },	// 9
    };

        /// <summary>
        /// Convert keypad input to a string.
        /// </summary>
        /// <param name="input">An input string containing numbers, asterisk, hash and/or space.</param>
        /// <returns>An output string based on the numbers pressed on keypad.</returns>
        /// <exception cref="FormatException">A format exception is thrown if input string is not in expected format.</exception>
        public static string OldPhonePad(string input)
        {
            if (input.Equals(string.Empty))
            {
                throw new FormatException("Input string required");
            }

            if (!ValidChars.IsMatch(input))
            {
                throw new FormatException("Input string contains invalid characters");
            }

            if (input.Last().Equals('#') == false)
            {
                throw new FormatException("Input string should be terminated by a hash (#)");
            }

            // the index of the character for the current active key
            var charIndex = -1;
            // the index of the key that was pressed last time, so we can
            // check repeat presses
            var lastKeyIndex = -1;
            // the output string
            var output = "";

            foreach (var c in input)
            {
                // number: add letter from keypad array to output string
                if (int.TryParse(c.ToString(), out int keyIndex))
                {
                    // initialize last key index with current key index if
                    // not set
                    if (lastKeyIndex == -1)
                    {
                        lastKeyIndex = keyIndex;
                        charIndex = -1;
                    }

                    if (keyIndex == lastKeyIndex)
                    {
                        // loop to next character for current active key
                        charIndex = (charIndex + 1) % Keys[lastKeyIndex].Length;
                    }
                    else
                    {
                        // if different key is pressed, update key index and
                        // reset character index
                        output = output + Keys[lastKeyIndex][charIndex];
                        lastKeyIndex = keyIndex;
                        charIndex = 0;
                    }
                }
                // space: update result & reset key index, e.g. '4 44' => 'GH'
                else if (c.Equals(' '))
                {
                    output = output + Keys[lastKeyIndex][charIndex];
                    lastKeyIndex = -1;
                }
                // hash: update result & terminate
                else if (c.Equals('#'))
                {
                    if (lastKeyIndex != -1)
                    {
                        output = output + Keys[lastKeyIndex][charIndex];
                    }
                    break;
                }
                // backspace: remove last character
                else if (c.Equals('*'))
                {
                    if (lastKeyIndex != -1)
                    {
                        // previous input not backspace: update result
                        output = output + Keys[lastKeyIndex][charIndex];
                    }

                    if (output.Length > 1)
                    {
                        // remove last character & reset key index for next
                        // iteration
                        output = output.Substring(0, output.Length - 1);
                        lastKeyIndex = -1;
                    }
                }
            }

            return output;
        }
    }
}
