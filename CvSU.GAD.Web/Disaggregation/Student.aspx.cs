﻿using CvSU.GAD.DataAccess.DatabaseConnectors;
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
	public partial class Student : CustomPage
	{
		private CollegeConnector CollegeConnector { get; }
		private DepartmentConnector DepartmentConnector { get; }
		private ProgramConnector ProgramConnector { get; }
		private DisaggregationConnector DisaggregationConnector { get; }

		public Student()
		{
			CollegeConnector = new CollegeConnector();
			DepartmentConnector = new DepartmentConnector();
			ProgramConnector = new ProgramConnector();
			DisaggregationConnector = new DisaggregationConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadJSData();
		}

		private void LoadJSData()
		{
			var programsSelectList = ProgramConnector.GetPrograms().Select(d => new { ID = d.ProgramID, Name = d.Title, d.Alias, d.DepartmentID }).ToList();
			string programSelectJSON = JsonConvert.SerializeObject(programsSelectList);
			var departmentsSelectList = DepartmentConnector.GetDepartments().Select(d => new { ID = d.DepartmentID, Name = d.Title, d.Alias, d.CollegeID }).ToList();
			string departmentSelectJSON = JsonConvert.SerializeObject(departmentsSelectList);
			var collegesSelectList = CollegeConnector.GetColleges().Select(c => new { ID = c.CollegeID, Name = c.Title, c.Alias }).ToList();
			string collegeSelectJSON = JsonConvert.SerializeObject(collegesSelectList);
			string studentSDJSON = JsonConvert.SerializeObject(DisaggregationConnector.GetStudentDisaggregation(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var collegeSelectJSON = {collegeSelectJSON}; " + Environment.NewLine +
									$"var departmentSelectJSON = {departmentSelectJSON}; " + Environment.NewLine +
									$"var programSelectJSON = {programSelectJSON}; " + Environment.NewLine +
									$"var studentSDJSON = {studentSDJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		protected void CreateBtn_Click(object sender, EventArgs e)
		{
			DataAccess.Models.Disaggregation newDisaggregation = new DataAccess.Models.Disaggregation
			{
				AccountID = CurrentAccount.AccountID,
				DepartmentID = int.Parse(selectedDepartmentTxt.Value),
				IsStudent = true,
				ReferenceID = int.Parse(selectedProgramTxt.Value),
				MaleQuantity = int.Parse(maleQTxt.Value),
				FemaleQuantity = int.Parse(femaleQTxt.Value),
				Semester = semesterSel.Value,
				SchoolYear = schoolYearTxt.Value
			};

			string message = DisaggregationConnector.AddDisaggregation(CurrentAccount.AccountID, newDisaggregation);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Data successfully added!', 'OK', '#009efb', '/disaggregation/student.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void DeleteBtn_Click(object sender, EventArgs e)
		{
			string message = DisaggregationConnector.DeleteDisaggregation(int.Parse(selectedID.Value));
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Data successfully deleted!', 'OK', '#009efb', '/disaggregation/student.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}
	}
}