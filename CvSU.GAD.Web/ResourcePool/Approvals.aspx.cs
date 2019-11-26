using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.Web.Content.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.Web.ResourcePool
{
	public partial class Approvals : CustomPage
	{
		private SeminarConnector SeminarConnector { get; set; }

		public Approvals()
		{
			SeminarConnector = new SeminarConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadJSData();
		}

		private void LoadJSData()
		{
			string seminarsJSON = JsonConvert.SerializeObject(SeminarConnector.GetSeminars());
			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var seminarsJSON = {seminarsJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		protected void RejectBtn_Click(object sender, EventArgs e)
		{
			string message = SeminarConnector.RejectSeminar(int.Parse(selectedID.Value));
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Seminar successfully rejected!', 'OK', '#009efb', 'approvals.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void ApproveBtn_Click(object sender, EventArgs e)
		{
			string message = SeminarConnector.ApproveSeminar(int.Parse(selectedID.Value));
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Seminar successfully approved!', 'OK', '#009efb', 'approvals.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}
	}
}