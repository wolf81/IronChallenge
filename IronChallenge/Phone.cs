using System;
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

            var charIndex = -1;
            var lastKeyIndex = -1;
            var output = "";

            foreach (var c in input)
            {
                // number: add letter from keypad array to output string
                if (int.TryParse(c.ToString(), out int keyIndex))
                {
                    // if last key was not set, set to current key and
                    // reset character index
                    if (lastKeyIndex == -1)
                    {
                        lastKeyIndex = keyIndex;
                        charIndex = -1;
                    }

                    if (keyIndex == lastKeyIndex)
                    {
                        // loop through the characters for current key, when at
                        // last character, return to first in array
                        charIndex = (charIndex + 1) % Keys[lastKeyIndex].Length;
                    }
                    else
                    {
                        // the key has changed, so update output string, key
                        // index & char index
                        output = output + Keys[lastKeyIndex][charIndex];
                        lastKeyIndex = keyIndex;
                        charIndex = 0;
                    }
                }
                // space: reset key index, e.g. '4 44' => 'GH'
                else if (c.Equals(' '))
                {
                    output = output + Keys[lastKeyIndex][charIndex];
                    lastKeyIndex = -1;
                }
                // hash: append current char to result & terminate
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
                        // first append newest character if we didn't press
                        // backspace previously
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
