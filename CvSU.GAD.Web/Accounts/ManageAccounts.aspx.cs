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
		private Account CurrentAccount { get; set; }
		private AdminConnector AdminConnector = new AdminConnector();

        public ManageAccounts()
        {
			CurrentAccount = new Account();
			AdminConnector = new AdminConnector();
        }

		protected void Page_Load(object sender, EventArgs e)
		{
			UpdateSession();
			CurrentAccount = GetAccountSession();
			if (CurrentAccount == null)
			{
				Response.Redirect("../index.aspx", true);
			}
			else if (CurrentAccount.Status.ToLower().Equals("new"))
			{
				Response.Redirect("accounts/setup.aspx");
			}

			LoadJSData();
		}

		private void LoadJSData()
		{
			string accountsJSON = JsonConvert.SerializeObject(AdminConnector.GetAccounts(CurrentAccount.AccountID));
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var accountsJSON = {accountsJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}
    }
}