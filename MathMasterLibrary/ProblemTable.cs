using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace MathMasterLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class ProblemCell
	{
		/// <summary>
		/// 
		/// </summary>
		public string ValueOne;

		/// <summary>
		/// 
		/// </summary>
		public string ValueTwo;

		/// <summary>
		/// 
		/// </summary>
		public string Operator;

		/// <summary>
		/// 
		/// </summary>
		public string AnswerValue;

		/// <summary>
		/// 
		/// </summary>
		public ProblemCell()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="valueOne"></param>
		/// <param name="valueTwo"></param>
		/// <param name="op"></param>
		/// <param name="answerValue"></param>
		public ProblemCell(string valueOne, string valueTwo, string op, string answerValue)
		{
			ValueOne = valueOne;
			ValueTwo = valueTwo;
			Operator = op;
			AnswerValue = answerValue;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class ProblemRow
	{
		/// <summary>
		/// 
		/// </summary>
		[XmlArray()]
		public ProblemCell[] Cells;

		/// <summary>
		/// 
		/// </summary>
		public ProblemRow()
		{
		}
	}

	/// <summary>
	/// Summary description for ProblemTable.
	/// </summary>
	public class ProblemTable
	{
		/// <summary>
		/// 
		/// </summary>
		[XmlArray()]
		public ProblemRow[] Rows;

		/// <summary>
		/// 
		/// </summary>
		public ProblemTable()
		{
	
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public static string ToXml(ProblemTable table)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ProblemTable));
			StringBuilder builder = new StringBuilder();
			using (StringWriter strWriter = new StringWriter(builder))
			{
				serializer.Serialize(strWriter, table);
				return builder.ToString();
			}
		}

		public static void RemoveAnswers(ProblemTable table)
		{
			foreach(ProblemRow row in table.Rows)
			{
				foreach(ProblemCell cell in row.Cells)
				{
					cell.AnswerValue = " ";
				}
			}
		}

		/// <summary>
		/// Splits the single ProblemTable instance into multiple tables in two-dimentional array.
		/// Each ProblemTable instance in the two-dimentional array would have the specified 
		/// height and width. The input height and width values must divide the table without any remainder.
		/// </summary>
		/// <param name="width">Widht value. It must divide the table without any remainder.</param>
		/// <param name="height">Height value. It must divide the table without any remander.</param>
		/// <returns>Two-dimentional array containing ProblemTable instances.</returns>
		public ProblemTable[][] Split(int width, int height)
		{
			int virticalUniCount = Rows.Length / height;
			Debug.Assert(Rows.Length % height == 0);

			int horizontalUnitCount = Rows[0].Cells.Length / width;
			Debug.Assert(Rows[0].Cells.Length % width == 0);

			ProblemTable[][] retTables = new ProblemTable[virticalUniCount][];			
			
			for (int i = 0; i != virticalUniCount; i++)
			{
				ProblemTable tempTable = new ProblemTable();
				tempTable.Rows = new ProblemRow[height];
				for (int j = 0; j != height; j++)
				{
					tempTable.Rows[j] = Rows[i * height + j];
				}

				retTables[i] = new ProblemTable[horizontalUnitCount];

				for (int k = 0; k != horizontalUnitCount; k++)
				{
					retTables[i][k] = new ProblemTable();
					ProblemTable unitTable = retTables[i][k];
					unitTable.Rows = new ProblemRow[height];
					for (int p = 0; p != height; p++)
					{
						ProblemCell[] cells = new ProblemCell[width];
						for (int q = 0; q != width; q++)
						{
							cells[q] = tempTable.Rows[p].Cells[k * width + q];
						}

						unitTable.Rows[p] = new ProblemRow();
						unitTable.Rows[p].Cells = cells;
					}
				}
			}

			return retTables;

		}
	}
}
