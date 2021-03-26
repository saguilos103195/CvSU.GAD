using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.WebForms.Content.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.WebForms.ResourcePool
{
    public partial class Approvals : CustomPage
    {
        private SeminarConnector SeminarConnector { get; set; }
		private DocumentConnector DocumentConnector { get; set; }

        public Approvals()
        {
            SeminarConnector = new SeminarConnector();
			DocumentConnector = new DocumentConnector();

		}

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadJSData();
        }

        private void LoadJSData()
        {
            string seminarsJSON = JsonConvert.SerializeObject(SeminarConnector.GetSeminars(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
			string accomplishmentJSON = JsonConvert.SerializeObject(DocumentConnector.GetAccomplishments(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
			string extensionJSON = JsonConvert.SerializeObject(DocumentConnector.GetProjects(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
                                    $"var seminarsJSON = {seminarsJSON}; " + Environment.NewLine +
									$"var accomplishmentJSON = {accomplishmentJSON}; " + Environment.NewLine +
									$"var extensionJSON = {extensionJSON}; " + Environment.NewLine +
								$"</script>";
            LoadJavaSript("loadJSData", loadJSData);
        }
		protected void RejectBtn_Click(object sender, EventArgs e)
		{
			string message = SeminarConnector.RejectSeminar(int.Parse(selectedID.Value));

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Seminar successfully rejected!", "OK", "/resourcepool/approvals.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

		protected void ApproveBtn_Click(object sender, EventArgs e)
		{
			string message = SeminarConnector.ApproveSeminar(int.Parse(selectedID.Value));

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Seminar successfully approved!", "OK", "/resourcepool/approvals.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

        protected void ApproveExtensionBtn_Click(object sender, EventArgs e)
        {
			string message = DocumentConnector.ApproveDocument(int.Parse(selectedID.Value));

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Extension successfully approved!", "OK", "/resourcepool/approvals.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

        protected void RejectExtensionBtn_Click(object sender, EventArgs e)
        {
			string message = DocumentConnector.RejectDocument(int.Parse(selectedID.Value));

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Extension successfully rejected!", "OK", "/resourcepool/approvals.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

        protected void ApproveAccomplishmentBtn_Click(object sender, EventArgs e)
        {
			string message = DocumentConnector.ApproveDocument(int.Parse(selectedID.Value));

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Accomplishment successfully approved!", "OK", "/resourcepool/approvals.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

        protected void RejectAccomplishmentBtn_Click(object sender, EventArgs e)
        {
			string message = DocumentConnector.RejectDocument(int.Parse(selectedID.Value));

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Accomplishment successfully rejected!", "OK", "/resourcepool/approvals.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}
    }
}