using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.Web.Content.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.Web.Accounts
{
	public partial class Setup : CustomPage
	{
		private AccountConnector AccountConnector { get; }

		public Setup()
		{
			AccountConnector = new AccountConnector();
		}

        protected void Page_Load(object sender, EventArgs e)
        {
			
        }

		protected void CreateProfileBtn_Click(object sender, EventArgs e)
		{
			DataAccess.Models.Profile newProfile = new DataAccess.Models.Profile();
			newProfile.AccountID = CurrentAccount.AccountID;
			newProfile.Firstname = fnameTxt.Value;
			newProfile.Middlename = mnameTxt.Value;
			newProfile.Lastname = lnameTxt.Value;
			newProfile.Gender = genderSel.Value;
			newProfile.Birthdate = DateTime.ParseExact(birthDateTxt.Value, "dd/MM/yyyy", null);
			newProfile.Address = addressTxt.Value;
			newProfile.EmailAddress = emailTxt.Value;
			newProfile.CellphoneNumber = cellphoneTxt.Value;
			newProfile.TelephoneNumber = telephoneTxt.Value;
			newProfile.Religion = religionTxt.Value;
			newProfile.Designation = designationTxt.Value;
			newProfile.OfficeAddress = officeAddressTxt.Value;
			newProfile.EngagedFrom = DateTime.ParseExact(engageFromTxt.Value, "dd/MM/yyyy", null);
			newProfile.EngagedTo = DateTime.ParseExact(engageToTxt.Value, "dd/MM/yyyy", null);
			newProfile.WillTravel = willingChkBox.Checked;
			newProfile.Educations = JsonConvert.DeserializeObject<List<Education>>(educListTxt.Value, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" } );
			
			string message = AccountConnector.AddProfile(newProfile);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Account Setup Complete!', 'OK', '#009efb', '../accounts/profile.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}
	}
}