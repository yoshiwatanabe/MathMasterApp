using System;

namespace MathMasterLibrary
{
	/// <summary>
	/// Utility class to provide integer values in string representation.
	/// </summary>
	public class IntegerValueSet
	{
		/// <summary>
		/// 
		/// </summary>
		readonly string[][] _dimentionalValues;

		/// <summary>
		/// Rethrns the string representations of integer values for the
		/// specified dimention.
		/// </summary>
		/// <param name="dimension"></param>
		/// <returns></returns>
		public string[] GetDimentionalValues(int dimension)
		{
			if (dimension >= _dimentionalValues.Length)
			{
				throw new ArgumentOutOfRangeException("dimension", dimension,
					"The number of dimentions in the object is " + _dimentionalValues.Length);
			}

			return _dimentionalValues[dimension];
		}

		/// <summary>
		/// Initializes the object such that it can provide a contiguous sequential integer
		/// values ranging from zero to the max value - 1 for each dimention. Each the range of
		/// values for each dimention is expressed as number of digits.
		/// </summary>
		/// <param name="dimentionDigits">The number of parameters specifies the number of dimentions. The value in 
		/// each dimention is the number of digits in that dimention and used to specify the max value for the
		/// range of integer values where the start value is zero.</param>
		public IntegerValueSet(params int[] dimentionDigits)
		{
			_dimentionalValues = new string[dimentionDigits.Length][];

			int dimention = 0;
			foreach (int digit in dimentionDigits)
			{
				int size = (int)Math.Pow(10, digit);
				string[] values = new string[size-1];

				for (int i = 0; i != values.Length; i++)
				{
					values[i] = (i+1).ToString();
				}

				_dimentionalValues[dimention++] = values;

			}
		}
	}
}
