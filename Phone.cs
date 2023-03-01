using System;

namespace IronChallenge
{
	public class Phone
	{
        /// <summary>
		/// This multi-dimensional array represents the keypad. 
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
		

		public static string OldPhonePad(string input)
		{
			return string.Empty;
		}
	}
}
