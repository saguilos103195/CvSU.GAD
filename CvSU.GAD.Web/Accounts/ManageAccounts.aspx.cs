using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
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
        AdminConnector AdminConnector = new AdminConnector();

        public ManageAccounts()
        {
            AdminConnector = new AdminConnector();
        }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

        private void GetAccounts()
        {
            string JSONAccounts = JsonConvert.SerializeObject(AdminConnector.GetAccounts(1));
            string getAccounts = "<script type=\"text/javascript\"> var accountsJSON = " + JSONAccounts + " </script>";
            LoadJavaSript("getAccounts", getAccounts);
        }
    }
}