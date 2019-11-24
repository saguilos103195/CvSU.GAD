using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.Web.Content.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.Web.Documents
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

		}

		private void LoadJSData()
		{
			var departmentsSelectList = DepartmentConnector.GetDepartments().Select(d => new { ID = d.DepartmentID, Name = d.Title, d.Alias, d.CollegeID }).ToList();
			string departmentSelectJSON = JsonConvert.SerializeObject(departmentsSelectList);
			var collegesSelectList = CollegeConnector.GetColleges().Select(c => new { ID = c.CollegeID, Name = c.Title, c.Alias }).ToList();
			string collegeSelectJSON = JsonConvert.SerializeObject(collegesSelectList);
			string programsJSON = JsonConvert.SerializeObject(ProgramConnector.GetPrograms());
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var collegeSelectJSON = {collegeSelectJSON}; " + Environment.NewLine +
									$"var departmentSelectJSON = {departmentSelectJSON}; " + Environment.NewLine +
									$"var programsJSON = {programsJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		protected void ArchiveBtn_Click(object sender, EventArgs e)
		{
			string message = ProgramConnector.ArchiveProgram(int.Parse(selectedID.Value), true);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Program successfully archived!', 'OK', '#009efb', 'programs.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void RetrieveBtn_Click(object sender, EventArgs e)
		{
			string message = ProgramConnector.ArchiveProgram(int.Parse(selectedID.Value), false);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Program successfully retrieved!', 'OK', '#009efb', 'programs.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void EditBtn_Click(object sender, EventArgs e)
		{
			Program updateProgram = new Program
			{
				ProgramID = int.Parse(selectedID.Value),
				Title = editTitleTxt.Value, Alias = editAliasTxt.Value,
				DepartmentID = int.Parse(editSelectedDepartmentTxt.Value),
				IsArchived = false
			};

			string message = ProgramConnector.UpdateProgram(updateProgram);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Department successfully updated!', 'OK', '#009efb', 'programs.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void CreateBtn_Click(object sender, EventArgs e)
		{
			Program newProgram = new Program();
			newProgram.Title = titleTxt.Value;
			newProgram.Alias = aliasTxt.Value;
			newProgram.DepartmentID = int.Parse(selectedDepartmentTxt.Value);
			string message = ProgramConnector.AddProgram(newProgram);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Program successfully added!', 'OK', '#009efb', 'programs.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}
	}
}