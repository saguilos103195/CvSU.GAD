using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.Web.Content.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.Web.Accounts
{
	public partial class ManageAccounts : CustomPage
	{
		private AdminConnector AdminConnector { get; set; }
		private CollegeConnector CollegeConnector { get; set; }

		public ManageAccounts()
        {
			AdminConnector = new AdminConnector();
			CollegeConnector = new CollegeConnector();
        }

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadJSData();
		}

		private void LoadJSData()
		{
			string allAccountsJSON = JsonConvert.SerializeObject(AdminConnector.GetAllAccounts(CurrentAccount.AccountID), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
			string accessedAccountsJSON = JsonConvert.SerializeObject(AdminConnector.GetAccessedAccounts(CurrentAccount.AccountID), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
			string collegesJSON = JsonConvert.SerializeObject(CollegeConnector.GetColleges());
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var allAccountsJSON = {allAccountsJSON}; " + Environment.NewLine +
									$"var accessedAccountsJSON = {accessedAccountsJSON}; " + Environment.NewLine +
									$"var collegesJSON = {collegesJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		protected void ArchiveBtn_Click(object sender, EventArgs e)
		{
			string message = AdminConnector.ArchiveAccount(CurrentAccount.AccountID, int.Parse(selectedID.Value));
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Account successfully archived!', 'OK', '#009efb', 'manageaccounts.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void RetrieveBtn_Click(object sender, EventArgs e)
		{
			string message = AdminConnector.RetrieveAccount(CurrentAccount.AccountID, int.Parse(selectedID.Value));
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Account successfully retrieved!', 'OK', '#009efb', 'manageaccounts.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}
	}
}