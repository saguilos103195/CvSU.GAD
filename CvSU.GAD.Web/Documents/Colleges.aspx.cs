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
	public partial class Colleges : CustomPage
	{
		CollegeConnector CollegeConnector { get; set; }

		public Colleges()
		{
			CollegeConnector = new CollegeConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			GetColleges();
			
		}

		private void GetColleges()
		{
			string JSONColleges = JsonConvert.SerializeObject(CollegeConnector.GetColleges());
			string getColleges = "<script type=\"text/javascript\"> var collegesJSON = " + JSONColleges + " </script>";
			ScriptManager.RegisterStartupScript(this, typeof(Page), "getColleges", getColleges, false);
		}

		protected void createBtn_Click(object sender, EventArgs e)
		{
			College newCollege = new College();
			newCollege.Alias = aliasTxt.Value;
			newCollege.IsMain = typeChkBx.Checked;
			newCollege.Title = titleTxt.Value;
			string message = CollegeConnector.AddCollege(newCollege);
			string showAlert = "";
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'College successfully added!', 'OK', '#009efb', 'colleges.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void ArchiveBtn_Click(object sender, EventArgs e)
		{

		}
	}
}