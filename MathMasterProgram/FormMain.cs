using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Reflection;
using System.Resources;
using System.IO;
using MathMasterLibrary;


namespace MathMasterProgram
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox _textBox;
		private System.Windows.Forms.MainMenu _mainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.ListView _listView;
		private System.Windows.Forms.ColumnHeader _columnHeaderName;
		private System.Windows.Forms.ColumnHeader _columnHeaderPages;
		private System.Windows.Forms.ColumnHeader _columnHeaderSubFolder;
		private System.Windows.Forms.Button _buttonGenerate;
		private System.Windows.Forms.ToolTip _toolTip;
		private System.Windows.Forms.Label _labelDescription;
		private System.ComponentModel.IContainer components;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			#region Test ProblemTable XML serialization.
//			ProblemRow row1 = new ProblemRow();
//			row1.Cells = new ProblemCell[] {
//											   new ProblemCell("a", "b"),
//											   new ProblemCell("c", "d")};
//
//			ProblemRow row2 = new ProblemRow();
//			row2.Cells = new ProblemCell[] {
//											   new ProblemCell("a0", "b0"),
//											   new ProblemCell("c0", "d0")};
//
//			ProblemTable table = new ProblemTable();
//			table.Rows = new ProblemRow[] {row1, row2};
//
//			XmlSerializer serializer = new XmlSerializer(typeof(ProblemTable));
//			StringBuilder builder = new StringBuilder();
//			StringWriter strWriter = new StringWriter(builder);
//			serializer.Serialize(strWriter, table);
//			string s = builder.ToString();
			#endregion

//			AdditionProblemGenerator.Configuration configuration = new AdditionProblemGenerator.Configuration();
//			configuration.RandomizationOption = AdditionProblemGenerator.RandomizationOptions.RandomizeAll;
//			AdditionProblemGenerator gen = new AdditionProblemGenerator(configuration, 2, 2);
//
//			ProblemTable table = gen.GenerateProblemTable();
//			ProblemTable[][] grid = table.Split(9, 9);
//
//
//			string xml = ProblemTable.ToXml(grid[10][10]);
//			this._textBox.Text = xml;
//
//			XmlDocument doc = new XmlDocument();
//			doc.LoadXml(xml);
//			
//			XmlElement root = doc.DocumentElement;
//			XPathNavigator nav = root.CreateNavigator();
//
//			XslTransform xslt = new XslTransform();
//			Assembly assembly = Assembly.GetExecutingAssembly();
//			Stream stream = assembly.GetManifestResourceStream("MathMasterProgram.StarndardFormat.xslt"); // bad spell!
//			
//			XmlTextReader xmlReader = new XmlTextReader(stream); 
//			try
//			{
//				xslt.Load(xmlReader, null, null);
//			}
//			catch (Exception e)
//			{
//				string s = e.Message;
//			}
//			XmlTextWriter xmlWriter = new XmlTextWriter("C:\\JunkXml.html", null);
//			xslt.Transform(nav, null, xmlWriter, null);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this._textBox = new System.Windows.Forms.TextBox();
			this._mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this._listView = new System.Windows.Forms.ListView();
			this._columnHeaderName = new System.Windows.Forms.ColumnHeader();
			this._columnHeaderPages = new System.Windows.Forms.ColumnHeader();
			this._columnHeaderSubFolder = new System.Windows.Forms.ColumnHeader();
			this._buttonGenerate = new System.Windows.Forms.Button();
			this._toolTip = new System.Windows.Forms.ToolTip(this.components);
			this._labelDescription = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _textBox
			// 
			this._textBox.Location = new System.Drawing.Point(120, 328);
			this._textBox.Multiline = true;
			this._textBox.Name = "_textBox";
			this._textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this._textBox.Size = new System.Drawing.Size(440, 144);
			this._textBox.TabIndex = 2;
			this._textBox.Text = "textBox1";
			// 
			// _mainMenu
			// 
			this._mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2});
			this.menuItem1.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Exit";
			// 
			// _listView
			// 
			this._listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this._columnHeaderName,
																						this._columnHeaderSubFolder,
																						this._columnHeaderPages});
			this._listView.FullRowSelect = true;
			this._listView.Location = new System.Drawing.Point(8, 40);
			this._listView.MultiSelect = false;
			this._listView.Name = "_listView";
			this._listView.Size = new System.Drawing.Size(480, 224);
			this._listView.TabIndex = 3;
			this._listView.View = System.Windows.Forms.View.Details;
			this._listView.SelectedIndexChanged += new System.EventHandler(this._listView_SelectedIndexChanged);
			// 
			// _columnHeaderName
			// 
			this._columnHeaderName.Text = "Name";
			this._columnHeaderName.Width = 176;
			// 
			// _columnHeaderPages
			// 
			this._columnHeaderPages.Text = "Pages";
			this._columnHeaderPages.Width = 63;
			// 
			// _columnHeaderSubFolder
			// 
			this._columnHeaderSubFolder.Text = "Sub Folder";
			this._columnHeaderSubFolder.Width = 200;
			// 
			// _buttonGenerate
			// 
			this._buttonGenerate.Location = new System.Drawing.Point(544, 216);
			this._buttonGenerate.Name = "_buttonGenerate";
			this._buttonGenerate.Size = new System.Drawing.Size(144, 23);
			this._buttonGenerate.TabIndex = 4;
			this._buttonGenerate.Text = "Generate";
			this._buttonGenerate.Click += new System.EventHandler(this._buttonGenerate_Click);
			// 
			// _labelDescription
			// 
			this._labelDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._labelDescription.Location = new System.Drawing.Point(504, 64);
			this._labelDescription.Name = "_labelDescription";
			this._labelDescription.Size = new System.Drawing.Size(224, 136);
			this._labelDescription.TabIndex = 5;
			this._labelDescription.Text = "label1";
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(744, 504);
			this.Controls.Add(this._labelDescription);
			this.Controls.Add(this._buttonGenerate);
			this.Controls.Add(this._listView);
			this.Controls.Add(this._textBox);
			this.Menu = this._mainMenu;
			this.Name = "FormMain";
			this.Text = "FormMain";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

		private void FormMain_Load(object sender, System.EventArgs e)
		{
			AdditionProblemBook01 book01 = new AdditionProblemBook01();

			ListViewItem item01 = new ListViewItem(new string[] {book01.Name, book01.FolderName, book01.PageCount.ToString()});
			item01.Tag = book01;
			_listView.Items.Add(item01);
		}

		private void _listView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (_listView.SelectedItems.Count == 1)
			{
				IProblemBook book = _listView.SelectedItems[0].Tag as IProblemBook;
				_labelDescription.Text = book.Description;
			}	
		}

		private void _buttonGenerate_Click(object sender, System.EventArgs e)
		{
			if (_listView.SelectedItems.Count == 1)
			{
				IProblemBook book = _listView.SelectedItems[0].Tag as IProblemBook;
				string directory = Directory.GetCurrentDirectory();

				this.Cursor = Cursors.WaitCursor;
				book.SavePages(directory);
				this.Cursor = Cursors.Default;
			}		
		}
	}
}
