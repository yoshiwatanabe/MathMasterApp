using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Reflection;
using System.Resources;
using System.IO;
using System.Diagnostics;
using MathMasterLibrary;

namespace MathMasterProgram
{
	/// <summary>
	/// Summary description for ProblemBook.
	/// </summary>
	public interface IProblemBook
	{
		string Name { get; }
		string Description { get; }
		string FolderName { get; }
		int PageCount { get; }
		
		void SavePages(string directory);
	}

	public class AdditionProblemBook01 : IProblemBook
	{
		AdditionProblemGenerator _generator;

		public string Name { get { return "Simple Additions Level 1"; } }
		public string Description { get { return "2 digit by 2 digit addition problems in 100 pages. Problems are randomized for each rows."; } }
		public string FolderName { get { return "AdditionProblemTwoByTwoNumber1"; } }
		public int PageCount { get { return 100; } }
		
		public void SavePages(string directory)
		{
			Debug.Assert(directory != null);
			Debug.Assert(Directory.Exists(directory));

			//
			// First, take care of creating the subfolder.
			//

			Directory.CreateDirectory(Path.Combine(directory, this.FolderName));


			ProblemTable table = _generator.GenerateProblemTable();
			ProblemTable[][] grid = table.Split(9, 9);

			int pageNumber = 0;

			for (int i = 0; i <= 10; i++)
			{
				for (int j = 0; j <= 10; j++)
				{
					ProblemTable currentProblemTable = grid[i][j];
					Save(currentProblemTable, directory, pageNumber, "answer");
					ProblemTable.RemoveAnswers(currentProblemTable);
					Save(currentProblemTable, directory, pageNumber, "problem");
					pageNumber++;
				}
			}
		}

		private void Save(ProblemTable table, string directory, int pageNumber, string prefix)
		{
			string xml = ProblemTable.ToXml(table);

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);

			XmlNode nameNode = doc.CreateElement("Name");
			nameNode.InnerText = this.Name;
			doc.DocumentElement.AppendChild(nameNode);

			XmlNode pageNumberNode = doc.CreateElement("PageNumber");
			pageNumberNode.InnerText = pageNumber.ToString();
			doc.DocumentElement.AppendChild(pageNumberNode);
			
			XmlElement root = doc.DocumentElement;
			XPathNavigator nav = root.CreateNavigator();

			XslTransform xslt = new XslTransform();
			Assembly assembly = Assembly.GetExecutingAssembly();
			Stream stream = assembly.GetManifestResourceStream("MathMasterProgram.StarndardFormat.xslt"); // bad spell!
			
			XmlTextReader xmlReader = new XmlTextReader(stream); 
			xslt.Load(xmlReader, null, null);
			xmlReader.Close();
					
			string subFolderPath = Path.Combine(directory, this.FolderName);
			string pageNumberText = string.Format("{0:000}", pageNumber);
			string fileName = Path.Combine(subFolderPath, prefix + ".page" + pageNumberText + ".html");
			XmlTextWriter xmlWriter = new XmlTextWriter(fileName, null);
			xslt.Transform(nav, null, xmlWriter, null);
			xmlWriter.Close();

		}

		public AdditionProblemBook01()
		{
			AdditionProblemGenerator.Configuration configuration = new AdditionProblemGenerator.Configuration();
			configuration.RandomizationOption = AdditionProblemGenerator.RandomizationOptions.RandomizeWithinRows;
			_generator = new AdditionProblemGenerator(configuration, 2, 2);
		}
	}
}
