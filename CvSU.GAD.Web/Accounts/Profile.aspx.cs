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
	}
}