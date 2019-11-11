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
	public partial class CreateAccount : CustomPage
	{
        AdminConnector AdminConnector { get; }

        public CreateAccount()
		{
            AdminConnector = new AdminConnector();
        }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void CreateBtn_Click(object sender, EventArgs e)
		{
			Account newAccount = new Account { Username = usernameTxt.Value, Password = passwordTxt.Value, Status = AdminConnector._accountStatusNew, Type = accountTypeSel.Value };
			string message = AdminConnector.AddAccount(newAccount);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Account successfully added!', 'OK', '#009efb', 'createaccount.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}
	}
}