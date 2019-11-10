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
		CollegeConnector CollegeConnector { get; }

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
			LoadJavaSript("getColleges", getColleges);
		}

		protected void createBtn_Click(object sender, EventArgs e)
		{
			College newCollege = new College();
			newCollege.Alias = aliasTxt.Value;
			newCollege.IsMain = typeChkBx.Checked;
			newCollege.Title = titleTxt.Value;
			string message = CollegeConnector.AddCollege(newCollege);
			string showAlert;
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
			string message = CollegeConnector.ArchiveCollege(int.Parse(selectedID.Value));
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'College successfully archived!', 'OK', '#009efb', 'colleges.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void RetrieveBtn_Click(object sender, EventArgs e)
		{
			string message = CollegeConnector.RetrieveCollege(int.Parse(selectedID.Value));
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'College successfully retrieved!', 'OK', '#009efb', 'colleges.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void EditBtn_Click(object sender, EventArgs e)
		{
			College updateCollege = new College { CollegeID = int.Parse(selectedID.Value), Title = editTitleTxt.Value, Alias = editAliasTxt.Value, IsArchived = false, IsMain = editTypeChkBx.Checked };

			string message = CollegeConnector.UpdateCollege(updateCollege);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'College successfully updated!', 'OK', '#009efb', 'colleges.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}
	}
}