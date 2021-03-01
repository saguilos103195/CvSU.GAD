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
			LoadProgramSelect();
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

		private void LoadProgramSelect()
		{
			var programSelectList = ProgramConnector.GetPrograms();

            foreach (var program in programSelectList)
            {
				selectProgram.Items.Add(new ListItem { Text = program.Title, Value = program.ProgramID.ToString() });
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
				disaggregations = DisaggregationConnector.GetStudentDisaggregation();
			}
			else
			{
				disaggregations = DisaggregationConnector.GetStudentDisaggregation().Where(d => d.AccountID == CurrentAccount.AccountID).ToList();
			}

			string programs = JsonConvert.SerializeObject(ProgramConnector.GetPrograms());
			string departments = JsonConvert.SerializeObject(DepartmentConnector.GetDepartments());
			string colleges = JsonConvert.SerializeObject(CollegeConnector.GetColleges());
			string studentSDJSON = JsonConvert.SerializeObject(disaggregations, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var colleges = {colleges}; " + Environment.NewLine +
									$"var departments = {departments}; " + Environment.NewLine +
									$"var programs = {programs}; " + Environment.NewLine +
									$"var studentSDJSON = {studentSDJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		protected void CreateBtn_Click(object sender, EventArgs e)
		{
            DataAccess.Models.Disaggregation newDisaggregation = new DataAccess.Models.Disaggregation
            {
                AccountID = CurrentAccount.AccountID,
                DepartmentID = int.Parse(selectDepartment.Value),
                IsStudent = true,
                ReferenceID = int.Parse(selectProgram.Value),
                MaleQuantity = int.Parse(numMaleQuantity.Value),
                FemaleQuantity = int.Parse(numFemaleQuantity.Value),
                Semester = selectSemester.Value,
                SchoolYear = selectSchoolYear.Value
            };

            string message = DisaggregationConnector.AddDisaggregation(CurrentAccount.AccountID, newDisaggregation);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Data successfully added!", "OK", "/disaggregation/student.aspx");
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
				ShowSuccessModal("Success", "Data successfully deleted!", "OK", "/disaggregation/student.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
        }
	}
}