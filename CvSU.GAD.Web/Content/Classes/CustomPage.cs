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
		protected void LoadJavaSript(string key, string script)
		{
			ScriptManager.RegisterStartupScript(this, typeof(Page), key, script, false);
		}
		
		protected DataAccess.Models.Account GetAccountSession()
		{
			DataAccess.Models.Account sessionAccount = null;

			if (HttpContext.Current.Session["AccountJSON"] != null)
			{
				sessionAccount = JsonConvert.DeserializeObject<DataAccess.Models.Account>(HttpContext.Current.Session["AccountJSON"].ToString());
			}

			return sessionAccount;
		}
	}
}