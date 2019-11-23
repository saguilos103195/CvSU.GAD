using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
using CvSU.GAD.DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CvSU.GAD.Web.Content.Classes
{
	public class CustomPage : Page
	{
		DataAccess.Models.Account SessionAccount { get; set; }
		AccountConnector AccountConnector { get; }

		public CustomPage()
		{
			AccountConnector = new AccountConnector();
		}

		protected void LoadJavaSript(string key, string script)
		{
			ScriptManager.RegisterStartupScript(this, typeof(Page), key, script, false);
		}

		protected void UpdateSession()
		{
			if (HttpContext.Current.Session["AccountJSON"] != null)
			{
				Account sessionAccount = JsonConvert.DeserializeObject<Account>(HttpContext.Current.Session["AccountJSON"].ToString());
				HttpContext.Current.Session["AccountJSON"] = AccountConnector.GetAccount(sessionAccount.AccountID);
			}
		}
		
		protected DataAccess.Models.Account GetAccountSession()
		{
			SessionAccount = null;

			if (HttpContext.Current.Session["AccountJSON"] != null)
			{
				SessionAccount = JsonConvert.DeserializeObject<Account>(HttpContext.Current.Session["AccountJSON"].ToString());
			}

			return SessionAccount;
		}

		protected void LoadJSProfile()
		{
			GetAccountSession();
			
			if (SessionAccount != null)
			{
				Profile profile = AccountConnector.GetProfile(SessionAccount.AccountID);
				string loadProfile = $"<script type=\"text/javascript\"> var profileJSON = {JsonConvert.SerializeObject(profile, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}; </script>";
				LoadJavaSript("loadProfile", loadProfile);
			}
			
		}
	}
}