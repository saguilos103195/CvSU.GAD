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
		}

		private void LoadJSData()
		{
			var collegesSelectList = CollegeConnector.GetColleges().Select(c => new { ID = c.CollegeID, Name = c.Title, c.Alias }).ToList();
			string collegeSelectJSON = JsonConvert.SerializeObject(collegesSelectList);
			string departmentsJSON = JsonConvert.SerializeObject(DepartmentConnector.GetDepartments());
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine + 
									$"var collegeSelectJSON = {collegeSelectJSON}; " + Environment.NewLine  +
									$"var departmentsJSON = {departmentsJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		protected void ArchiveBtn_Click(object sender, EventArgs e)
		{
			string message = DepartmentConnector.ArchiveDepartment(int.Parse(selectedID.Value), true);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Department successfully archived!', 'OK', '#009efb', '/documents/departments.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void CreateBtn_Click(object sender, EventArgs e)
		{
			Department newDepartment = new Department();
			newDepartment.Title = titleTxt.Value;
			newDepartment.Alias = aliasTxt.Value;
			newDepartment.IsArchived = false;
			newDepartment.CollegeID = int.Parse(selectedCollegeTxt.Value);
			string message = DepartmentConnector.AddDepartment(newDepartment);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Department successfully added!', 'OK', '#009efb', '/documents/departments.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void RetrieveBtn_Click(object sender, EventArgs e)
		{
			string message = DepartmentConnector.ArchiveDepartment(int.Parse(selectedID.Value), false);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Department successfully retrieved!', 'OK', '#009efb', '/documents/departments.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void EditBtn_Click(object sender, EventArgs e)
		{
			Department updateDepartment = new Department { DepartmentID = int.Parse(selectedID.Value), Title = editTitleTxt.Value, Alias = editAliasTxt.Value, CollegeID = int.Parse(editSelectedCollegeTxt.Value), IsArchived = false };

			string message = DepartmentConnector.UpdateDepartment(updateDepartment);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Department successfully updated!', 'OK', '#009efb', '/documents/departments.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}
	}
}