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
    public partial class Departments : CustomPage
    {
		private DepartmentConnector DepartmentConnector { get; }
		private CollegeConnector CollegeConnector { get; }

		public Departments()
		{
			DepartmentConnector = new DepartmentConnector();
			CollegeConnector = new CollegeConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadJSData();
			LoadCollegeSelection();
		}

		private void LoadJSData()
		{
			string collegesJSON = JsonConvert.SerializeObject(CollegeConnector.GetColleges());
			string departmentsJSON = JsonConvert.SerializeObject(DepartmentConnector.GetDepartments());
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var collegesJSON = {collegesJSON}; " + Environment.NewLine +
									$"var departmentsJSON = {departmentsJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
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

		protected void CreateBtn_Click(object sender, EventArgs e)
		{
			Department newDepartment = new Department();
			newDepartment.Title = txtTitle.Value;
			newDepartment.Alias = txtAlias.Value;
			newDepartment.IsArchived = false;
			newDepartment.CollegeID = int.Parse(selectCollege.Value);
			string message = DepartmentConnector.AddDepartment(newDepartment);
			
			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Department successfully added!", "OK", "/documents/departments.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

        protected void ArchiveBtn_Click(object sender, EventArgs e)
        {
			string message = DepartmentConnector.ArchiveDepartment(int.Parse(selectedID.Value), true);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Department successfully archived!", "OK", "/documents/departments.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

        protected void RetrieveBtn_Click(object sender, EventArgs e)
        {
			string message = DepartmentConnector.ArchiveDepartment(int.Parse(selectedID.Value), false);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Department successfully retrieved!", "OK", "/documents/departments.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

        protected void EditBtn_Click(object sender, EventArgs e)
        {
			Department updateDepartment = new Department { DepartmentID = int.Parse(selectedID.Value), Title = txtTitleEdit.Value, Alias = txtAliasEdit.Value, CollegeID = int.Parse(selectCollegeEdit.Value), IsArchived = false };

			string message = DepartmentConnector.UpdateDepartment(updateDepartment);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Department successfully updated!", "OK", "/documents/departments.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}
    }
}