using System;
using System.Diagnostics;
using System.Collections;

namespace MathMasterLibrary
{
	/// <summary>
	/// Summary description for OneByOneAdditionGenerator.
	/// </summary>
	public class AdditionProblemGenerator : IProblemGenerator
	{
		public enum RandomizationOptions
		{
			RandomizeWithinRows,
			RandomizeAll,
		}		
		
		public class Configuration
		{
			public RandomizationOptions RandomizationOption;
		}

		public Configuration ConfigurationSettings;

		int[] _dimentionDigits;
		public ProblemCategories Category { get { return ProblemCategories.Addition; } }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ProblemTable GenerateProblemTable()
		{
			int firstDimScale = (int)Math.Pow(10, _dimentionDigits[0]) -1;
			int secondDimScale = (int)Math.Pow(10,  _dimentionDigits[1]) -1;

			IntegerValueSet dimentionValueSet = new IntegerValueSet(_dimentionDigits[0], _dimentionDigits[1]);
			string[] firstDimValues = dimentionValueSet.GetDimentionalValues(0); //gen.GetFirstDimensionValues();
			string[] secondDimValues = dimentionValueSet.GetDimentionalValues(1);//gen.GetSecondDimensionValues();
 
			ProblemTable table = new ProblemTable();
			table.Rows = new ProblemRow[firstDimScale];

			for (int i = 0; i != firstDimValues.Length; i++)
			{
				string firstDimValue = firstDimValues[i];
			
				table.Rows[i] =  new ProblemRow();
				table.Rows[i].Cells = new ProblemCell[secondDimScale];
				
				for (int j = 0; j != secondDimValues.Length; j++)
				{
					string secondDimValue = secondDimValues[j];
					int valOne = int.Parse(firstDimValue);
					int valTwo = int.Parse(secondDimValue);
					int answer = valOne + valTwo;
					string op = "+";
				
					table.Rows[i].Cells[j] = new ProblemCell(firstDimValue, secondDimValue, op, answer.ToString());
				}
			}

			switch (ConfigurationSettings.RandomizationOption)
			{
				case RandomizationOptions.RandomizeAll:
					RandamizeAll(table);
					break;

				case RandomizationOptions.RandomizeWithinRows:
					RandamizeWithintRows(table);
					break;

				default:
					break;
			}

			return table;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		private ProblemTable RandamizeWithintRows(ProblemTable table)
		{
			Random rand = new Random();
			foreach (ProblemRow row in table.Rows)
			{
				ArrayList sourceCells = new ArrayList(row.Cells);
				ArrayList tempCells = new ArrayList();

				while (sourceCells.Count != 0)
				{
					int randomPos = rand.Next(sourceCells.Count);
					tempCells.Add(sourceCells[randomPos]);
					sourceCells.RemoveAt(randomPos);
				}

				row.Cells = tempCells.ToArray(typeof(ProblemCell)) as ProblemCell[];
			}

			return table;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		private ProblemTable RandamizeAll(ProblemTable table)
		{
			ArrayList all = new ArrayList();
			Random rand = new Random();

			foreach (ProblemRow row in table.Rows)
			{
				all.AddRange(row.Cells);
			}

			for (int i = 0; i != table.Rows.Length; i++)
			{
				ProblemRow row = table.Rows[i];
				for (int j = 0; j != row.Cells.Length; j++)
				{
					int randomPos = rand.Next(all.Count);
					row.Cells[j] = all[randomPos] as ProblemCell;
					all.RemoveAt(randomPos);
				}
			}

			return table;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dimentionDigits"></param>
		public AdditionProblemGenerator(params int[] dimentionDigits)
		{
			_dimentionDigits = dimentionDigits;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="configurationSettings"></param>
		/// <param name="dimentionDigits"></param>
		public AdditionProblemGenerator(Configuration configurationSettings, params int[] dimentionDigits)
		{
			ConfigurationSettings = configurationSettings;
			_dimentionDigits = dimentionDigits;
		}

	}
}
