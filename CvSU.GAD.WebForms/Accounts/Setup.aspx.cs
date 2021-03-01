using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.WebForms.Content.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.WebForms.Accounts
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

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
			DataAccess.Models.Profile newProfile = new DataAccess.Models.Profile();
			newProfile.AccountID = CurrentAccount.AccountID;
			newProfile.Firstname = txtFirstName.Value;
			newProfile.Middlename = txtMiddleName.Value;
			newProfile.Lastname = txtLastName.Value;
			newProfile.Gender = selectGender.Value;
			newProfile.Birthdate = DateTime.ParseExact(txtBirthdate.Value, "yyyy-MM-dd", null);
			newProfile.Address = txtPermanentAddress.Value;
			newProfile.EmailAddress = txtEmailAddress.Value;
			newProfile.CellphoneNumber = txtCellphoneNumber.Value;
			newProfile.TelephoneNumber = txtTelephoneNumber.Value;
			newProfile.Religion = txtReligion.Value;
			newProfile.Designation = txtDesignation.Value;
			newProfile.OfficeAddress = txtOfficeAddress.Value;
			newProfile.EngagedFrom = DateTime.ParseExact(txtEngagementFrom.Value, "yyyy-MM-dd", null);
			newProfile.EngagedTo = DateTime.ParseExact(txtEngagementTo.Value, "yyyy-MM-dd", null);
			newProfile.WillTravel = checkBoxWillTravel.Checked;
			newProfile.Educations = JsonConvert.DeserializeObject<List<Education>>(educListJson.Value, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });

            string message = AccountConnector.AddProfile(newProfile);

            if (string.IsNullOrEmpty(message))
            {
                ShowSuccessModal("Success", "Account Setup Complete!", "OK", "/accounts/profile.aspx");
            }
            else
            {
                ShowErrorModal("Oops...", message, "OK", "#");
            }
        }
    }
}