using System;

namespace MathMasterLibrary
{
	/// <summary>
	/// Summary description for IProblemGenerator.
	/// </summary>
	public interface IProblemGenerator
	{
		/// <summary>
		/// 
		/// </summary>
		ProblemCategories Category { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		ProblemTable GenerateProblemTable();
	}
}
