﻿using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
using CvSU.GAD.DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.WebForms.Content.Classes
{
    public class CustomPage : Page
    {
		public DataAccess.Models.Account SessionAccount { get; set; }
		AccountConnector AccountConnector { get; }
		public Account CurrentAccount { get; set; }

		public CustomPage()
		{
			CurrentAccount = new Account();
			AccountConnector = new AccountConnector();
			Load += new EventHandler(Page_Load);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
			if (pageName.ToLower() != "index")
			{
				UpdateSession();
				LoadJSProfile();

				CurrentAccount = GetAccountSession();

				if (CurrentAccount == null && pageName.ToLower() != "index")
				{
					Response.Redirect("/index.aspx", true);
				}
				else if (CurrentAccount.IsNew && pageName.ToLower() != "setup")
				{
					Response.Redirect("/accounts/setup.aspx");
				}
			}
		}

		protected void LoadJavaSript(string key, string script)
		{
			ScriptManager.RegisterStartupScript(this, typeof(Page), key, script, false);
		}

		protected void ShowErrorModal(string title, string message, string buttonText, string link)
        {
            string showError = "<script type=\"text/javascript\"> $(document).ready(function (){ showErrorModal('" + title + "', '" + message + "', '" + buttonText + "', '" + link + "')}); </script>";
            LoadJavaSript("showError", showError);
		}

		protected void ShowSuccessModal(string title, string message, string buttonText, string link)
		{
			string showSuccess = "<script type=\"text/javascript\"> $(document).ready(function (){ showSuccessModal('" + title + "', '" + message + "', '" + buttonText + "', '" + link + "')}); </script>";
			LoadJavaSript("showSuccess", showSuccess);
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

			try
			{
				if (HttpContext.Current.Session["AccountJSON"] != null)
				{
					SessionAccount = JsonConvert.DeserializeObject<Account>(HttpContext.Current.Session["AccountJSON"].ToString(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
				}
			}
			catch (Exception ex)
			{
				//_log.Error(ex);
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

		protected void ClearSession()
		{
			HttpContext.Current.Session["AccountJSON"] = null;
		}
	}
}