using System;
using System.Diagnostics;

namespace IronChallenge
{
	public class Phone
	{
        /// <summary>
		/// This multi-dimensional array represents the keypad. The first
		/// dimension represents the index of the key. For each dimension we add
		/// a list of associated characters.
		/// </summary>
        readonly char[][] keypad = {
			new char[] { '_' },					// 0
			new char[] { '&', '\'', '(' },		// 1
			new char[] { 'A', 'B', 'C' },		// 2
			new char[] { 'D', 'E', 'F' },		// 3
            new char[] { 'G', 'H', 'I' },		// 4
            new char[] { 'J', 'K', 'L' },		// 5
            new char[] { 'M', 'N', 'O' },		// 6
            new char[] { 'P', 'Q', 'R', 'S' },	// 7
            new char[] { 'T', 'U', 'V' },		// 8
            new char[] { 'W', 'X', 'Y', 'Z' },	// 9
			new char[] { '*', '\b' },			// 10 - on keypad left-hand of 9
			new char[] { '►', '#' },			// 11 - on keypad right-hand of 9
        };

		private int _keyIndex;
		private int _charIndex;
		
		public static string OldPhonePad(string input)
		{
			if (input.Equals(string.Empty))
			{
				throw new FormatException("Input string required");
			}

			if (input.Last().Equals('#') == false)
			{
				throw new FormatException("Input string should be terminated by a hash (#)");
			}

			foreach (var c in input)
			{
				Console.WriteLine('c');
			}

			return string.Empty;
		}
	}
}
