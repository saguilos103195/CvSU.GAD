using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
using CvSU.GAD.Web.Content.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.Web
{
	public partial class Index : CustomPage
	{
		private AccountConnector AccountConnector { get; }

		public Index()
		{
			AccountConnector = new AccountConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
		{

            FIleManager p = new FIleManager();

            p.Upload("", "");

        }

		protected void LoginBtn_Click(object sender, EventArgs e)
		{
			Tuple<bool, string> response = AccountConnector.Login(usernameTxt.Value, passwordTxt.Value);

			DataAccess.Models.Account Account = new DataAccess.Models.Account();
			string showAlert;
			if (response.Item1)
			{
				Account = JsonConvert.DeserializeObject<DataAccess.Models.Account>(response.Item2);
				HttpContext.Current.Session["AccountJSON"] = JsonConvert.SerializeObject(Account);
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Account Login Verified!', 'OK', '#009efb', '" + (Account.Status.ToLower() == "new" ? "accounts/setup.aspx" : "accounts/profile.aspx") + "');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + response.Item2 + "', 'OK', '#009efb', '#');  </script>";
			}

			LoadJavaSript("showAlert", showAlert);
		}
	}
}