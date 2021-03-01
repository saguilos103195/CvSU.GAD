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

	}
}