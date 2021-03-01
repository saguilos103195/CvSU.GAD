using CvSU.GAD.DataAccess;
using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.WebForms
{
    public partial class Index : System.Web.UI.Page
    {
		private AccountConnector AccountConnector { get; }

		public Index()
		{
			AccountConnector = new AccountConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void LoginBtn_Click(object sender, EventArgs e)
		{
			Tuple<bool, string> response = AccountConnector.Login(inputUsername.Value, inputPassword.Value);

			DataAccess.Models.Account Account = new DataAccess.Models.Account();

			if (response.Item1)
			{
				Account = JsonConvert.DeserializeObject<DataAccess.Models.Account>(response.Item2);
				HttpContext.Current.Session["AccountJSON"] = JsonConvert.SerializeObject(Account);
				errorMessage.Visible = false;
                Response.Redirect((Account.IsNew ? "accounts/setup.aspx" : "accounts/createaccount.aspx"));

            }
			else
			{
				errorMessage.InnerHtml = response.Item2;
				errorMessage.Visible = true;
			}

			JavaScriptLogger.DisplayLog(this);
			//LoadJavaSript("showAlert", showAlert);
		}
	}
}