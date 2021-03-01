using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.WebForms.Content.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.WebForms.Accounts
{
    public partial class CreateAccount : CustomPage
    {
		private AdminConnector AdminConnector { get; }
		private CollegeConnector CollegeConnector { get; }

        public CreateAccount()
        {
			AdminConnector = new AdminConnector();
			CollegeConnector = new CollegeConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
        {
			LoadJSData();
			LoadCollegeSelection();
		}

		private void LoadCollegeSelection()
        {
			var collegesSelectList = CollegeConnector.GetColleges().Select(c => new { ID = c.CollegeID, Name = c.Title, c.Alias }).ToList();

			foreach (var college in collegesSelectList)
            {
				selectCollege.Items.Add(new ListItem { Text = college.Name, Value = college.ID.ToString() });

			}
		}

		private void LoadJSData()
		{
			var collegesSelectList = CollegeConnector.GetColleges().Select(c => new { ID = c.CollegeID, Name = c.Title, c.Alias }).ToList();
			string collegeSelectJSON = JsonConvert.SerializeObject(collegesSelectList);
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var collegeSelectJSON = {collegeSelectJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		protected void CreateBtn_Click(object sender, EventArgs e)
        {
			Account newAccount = new Account
			{
				Username = txtUsername.Value,
				Password = txtPassword.Value,
				Type = selectType.Value,
				CreatedByID = CurrentAccount.AccountID,
			};

			if (newAccount.Type == "Coordinator")
			{
				newAccount.CollegeID = Convert.ToInt32(selectCollege.Value);
			}

			string message = AdminConnector.AddAccount(newAccount);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Account successfully added!", "OK", "/accounts/createaccount.aspx");
				
			}
			else
			{
				ShowErrorModal("Error", message, "OK", "#");
			}
		}
    }
}