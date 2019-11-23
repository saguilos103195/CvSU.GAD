using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.Web.Content.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.Web.Accounts
{
	public partial class Profile : CustomPage
	{
		private Account CurrentAccount { get; set; }
		private AccountConnector AccountConnector { get; }

		public Profile()
		{
			CurrentAccount = new Account();
			AccountConnector = new AccountConnector();
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
		}

		protected void UpdateProfileBtn_Click(object sender, EventArgs e)
		{
			DataAccess.Models.Profile updatedProfile = new DataAccess.Models.Profile
			{
				AccountID = CurrentAccount.AccountID,
				Address = addressTxt.Value,
				Birthdate = DateTime.Parse(bdateTxt.Value),
				CellphoneNumber = cellphoneTxt.Value,
				Designation = designationTxt.Value,
				EmailAddress = emailTxt.Value,
				EngagedFrom = DateTime.Parse(engagedFromTxt.Value),
				EngagedTo = DateTime.Parse(engagedToTxt.Value),
				Firstname = fnameTxt.Value,
				Lastname = lnameTxt.Value,
				Middlename = mnameTxt.Value,
				OfficeAddress = officeAddressTxt.Value,
				Religion = religionTxt.Value,
				TelephoneNumber = telephoneTxt.Value,
				WillTravel = willingChkBox.Checked
			};

			string message = AccountConnector.UpdateProfile(updatedProfile);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Program successfully archived!', 'OK', '#009efb', 'profile.aspx');  </script>";
				
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}
	}
}