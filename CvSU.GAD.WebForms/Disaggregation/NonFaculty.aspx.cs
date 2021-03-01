using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.Models.Helper;
using CvSU.GAD.WebForms.Content.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.WebForms.Disaggregation
{
    public partial class NonFaculty : CustomPage
    {
		private CollegeConnector CollegeConnector { get; }
		private DepartmentConnector DepartmentConnector { get; }
		private PositionConnector PositionConnector { get; }
		private DisaggregationConnector DisaggregationConnector { get; }

		public NonFaculty()
		{
			CollegeConnector = new CollegeConnector();
			DepartmentConnector = new DepartmentConnector();
			PositionConnector = new PositionConnector();
			DisaggregationConnector = new DisaggregationConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadJSData();
			LoadPositionSelect();
			LoadDepartmentSelect();
			LoadCollegeSelection();
			LoadSchoolYearSelect();
		}

		private void LoadSchoolYearSelect()
		{
			int currentYear = DateTime.Now.Year;
			for (int start = currentYear; start > currentYear - 20; start--)
			{
				var end = start + 1;
				selectSchoolYear.Items.Add(new ListItem { Text = start + "-" + end, Value = start + "-" + end });
			}
		}

		private void LoadPositionSelect()
		{
			var positionSelectList = PositionConnector.GetPositions().Where(p => !p.IsFaculty).ToList();

			foreach (var position in positionSelectList)
			{
				selectPosition.Items.Add(new ListItem { Text = position.Title, Value = position.PositionID.ToString() });
			}
		}

		private void LoadDepartmentSelect()
		{
			var departmentSelectList = DepartmentConnector.GetDepartments();

			foreach (var department in departmentSelectList)
			{
				selectDepartment.Items.Add(new ListItem { Text = department.Title, Value = department.DepartmentID.ToString() });
			}
		}

		private void LoadCollegeSelection()
		{
			var collegesSelectList = CollegeConnector.GetColleges();

			foreach (var college in collegesSelectList)
			{
				selectCollege.Items.Add(new ListItem { Text = college.Title, Value = college.CollegeID.ToString() });
			}
		}

		private void LoadJSData()
		{
			List<DisaggregationModel> disaggregations = new List<DisaggregationModel>();

			if (CurrentAccount.Type == "Administrator")
			{
				disaggregations = DisaggregationConnector.GetNonFacultyDisaggregation();
			}
			else
			{
				disaggregations = DisaggregationConnector.GetNonFacultyDisaggregation().Where(d => d.AccountID == CurrentAccount.AccountID).ToList();
			}

			string departments = JsonConvert.SerializeObject(DepartmentConnector.GetDepartments());
			string colleges = JsonConvert.SerializeObject(CollegeConnector.GetColleges());
			string employeeSDJSON = JsonConvert.SerializeObject(disaggregations, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var colleges = {colleges}; " + Environment.NewLine +
									$"var departments = {departments}; " + Environment.NewLine +
									$"var employeeSDJSON = {employeeSDJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		protected void CreateBtn_Click(object sender, EventArgs e)
		{
			DataAccess.Models.Disaggregation newDisaggregation = new DataAccess.Models.Disaggregation
			{
				AccountID = CurrentAccount.AccountID,
				DepartmentID = int.Parse(selectDepartment.Value),
				IsStudent = false,
				ReferenceID = int.Parse(selectPosition.Value),
				MaleQuantity = int.Parse(numMaleQuantity.Value),
				FemaleQuantity = int.Parse(numFemaleQuantity.Value),
				Semester = selectSemester.Value,
				SchoolYear = selectSchoolYear.Value
			};

			string message = DisaggregationConnector.AddDisaggregation(CurrentAccount.AccountID, newDisaggregation);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Data successfully added!", "OK", "/disaggregation/nonfaculty.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

		protected void DeleteBtn_Click(object sender, EventArgs e)
		{
			string message = DisaggregationConnector.DeleteDisaggregation(int.Parse(selectedID.Value));

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Data successfully deleted!", "OK", "/disaggregation/nonfaculty.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}
	}
}