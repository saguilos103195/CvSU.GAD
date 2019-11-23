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

namespace CvSU.GAD.Web.Disaggregation
{
	public partial class Faculty : CustomPage
	{
		private CollegeConnector CollegeConnector { get; }
		private DepartmentConnector DepartmentConnector { get; }
		private PositionConnector PositionConnector { get; }
		private DisaggregationConnector DisaggregationConnector { get; }
		private Account CurrentAccount { get; set; }

		public Faculty()
		{
			CollegeConnector = new CollegeConnector();
			DepartmentConnector = new DepartmentConnector();
			PositionConnector = new PositionConnector();
			DisaggregationConnector = new DisaggregationConnector();
			CurrentAccount = new Account();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			CurrentAccount = GetAccountSession();
			if (CurrentAccount == null)
			{
				Response.Redirect("../index.aspx", true);
			}
			else if (CurrentAccount.Status.ToLower().Equals("new"))
			{
				Response.Redirect("accounts/setup.aspx");
			}
			LoadJSProfile();
			LoadJSData();
		}

		private void LoadJSData()
		{
			var positionsSelectList = PositionConnector.GetPositions().Where(p => p.IsFaculty).Select(d => new { ID = d.PositionID, Name = d.Title }).ToList();
			string positionSelectJSON = JsonConvert.SerializeObject(positionsSelectList);
			var departmentsSelectList = DepartmentConnector.GetDepartments().Select(d => new { ID = d.DepartmentID, Name = d.Title, d.Alias, d.CollegeID }).ToList();
			string departmentSelectJSON = JsonConvert.SerializeObject(departmentsSelectList);
			var collegesSelectList = CollegeConnector.GetColleges().Select(c => new { ID = c.CollegeID, Name = c.Title, c.Alias }).ToList();
			string collegeSelectJSON = JsonConvert.SerializeObject(collegesSelectList);
			string facultySDJSON = JsonConvert.SerializeObject(DisaggregationConnector.GetFacultyDisaggregation(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var collegeSelectJSON = {collegeSelectJSON}; " + Environment.NewLine +
									$"var departmentSelectJSON = {departmentSelectJSON}; " + Environment.NewLine +
									$"var positionSelectJSON = {positionSelectJSON}; " + Environment.NewLine +
									$"var facultySDJSON = {facultySDJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		protected void DeleteBtn_Click(object sender, EventArgs e)
		{
			string message = DisaggregationConnector.DeleteDisaggregation(int.Parse(selectedID.Value));
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Data successfully deleted!', 'OK', '#009efb', 'faculty.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void CreateBtn_Click(object sender, EventArgs e)
		{
			DataAccess.Models.Disaggregation newDisaggregation = new DataAccess.Models.Disaggregation
			{
				//AccountID = CurrentAccount.AccountID,
				//DepartmentID = int.Parse(selectedDepartmentTxt.Value),
				//PositionID = int.Parse(selectedPositionTxt.Value),
				//ProgramID = 0,
				//MaleQuantity = int.Parse(maleQTxt.Value),
				//FemaleQuantity = int.Parse(femaleQTxt.Value),
				//Semester = semesterSel.Value,
				//SchoolYear = schoolYearTxt.Value
			};

			string message = DisaggregationConnector.AddDisaggregation(newDisaggregation);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Data successfully added!', 'OK', '#009efb', 'faculty.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}
	}
}