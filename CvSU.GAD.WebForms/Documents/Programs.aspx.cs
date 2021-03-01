using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.WebForms.Content.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.WebForms.Documents
{
    public partial class Programs : CustomPage
    {
		private ProgramConnector ProgramConnector { get; }
		private DepartmentConnector DepartmentConnector { get; }
		private CollegeConnector CollegeConnector { get; }

		public Programs()
		{
			ProgramConnector = new ProgramConnector();
			DepartmentConnector = new DepartmentConnector();
			CollegeConnector = new CollegeConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadJSData();
			LoadCollegeSelection();
			LoadDepartmentSelect();
		}

		private void LoadDepartmentSelect()
        {
			var departmentSelectList = DepartmentConnector.GetDepartments();

			foreach (var department in departmentSelectList)
			{
				selectDepartmentEdit.Items.Add(new ListItem { Text = department.Title, Value = department.DepartmentID.ToString() });
                selectDepartment.Items.Add(new ListItem { Text = department.Title, Value = department.DepartmentID.ToString() });
			}
		}

		private void LoadCollegeSelection()
		{
			var collegesSelectList = CollegeConnector.GetColleges();

			foreach (var college in collegesSelectList)
			{
                selectCollegeEdit.Items.Add(new ListItem { Text = college.Title, Value = college.CollegeID.ToString() });
                selectCollege.Items.Add(new ListItem { Text = college.Title, Value = college.CollegeID.ToString() });
			}
		}

		private void LoadJSData()
		{
			string departments = JsonConvert.SerializeObject(DepartmentConnector.GetDepartments());
			string colleges = JsonConvert.SerializeObject(CollegeConnector.GetColleges());
			string programsJSON = JsonConvert.SerializeObject(ProgramConnector.GetPrograms());
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var colleges = {colleges}; " + Environment.NewLine +
									$"var departments = {departments}; " + Environment.NewLine +
									$"var programsJSON = {programsJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		protected void ArchiveBtn_Click(object sender, EventArgs e)
		{
			string message = ProgramConnector.ArchiveProgram(int.Parse(selectedID.Value), true);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Program successfully archived!", "OK", "/documents/programs.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

		protected void RetrieveBtn_Click(object sender, EventArgs e)
		{
			string message = ProgramConnector.ArchiveProgram(int.Parse(selectedID.Value), false);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Program successfully retrieved!", "OK", "/documents/programs.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

		protected void EditBtn_Click(object sender, EventArgs e)
		{
            Program updateProgram = new Program
            {
                ProgramID = int.Parse(selectedID.Value),
                Title = txtTitleEdit.Value,
                Alias = txtAliasEdit.Value,
                DepartmentID = int.Parse(selectDepartmentEdit.Value),
                IsArchived = false
            };

            string message = ProgramConnector.UpdateProgram(updateProgram);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Program successfully updated!", "OK", "/documents/programs.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
        }

		protected void CreateBtn_Click(object sender, EventArgs e)
		{
			Program newProgram = new Program();
			newProgram.Title = txtTitle.Value;
			newProgram.Alias = txtAlias.Value;
			newProgram.DepartmentID = int.Parse(selectDepartment.Value);
			string message = ProgramConnector.AddProgram(newProgram);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Program successfully added!", "OK", "/documents/programs.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}
	}
}