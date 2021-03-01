using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.WebForms.Content.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.WebForms.Projects
{
    public partial class View : CustomPage
    {
		private readonly DocumentConnector DocumentConnector;

        public View()
        {
			DocumentConnector = new DocumentConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
        {
			LoadJSData();
		}

		private void LoadJSData()
		{
			List<Document> projects = new List<Document>();

            if (CurrentAccount.Type == "Administrator")
            {
				projects = DocumentConnector.GetProjects();
			}
            else
            {
				projects = DocumentConnector.GetProjects().Where(p => p.CreatedBy == CurrentAccount.AccountID).ToList();
            }

			string projectsJSON = JsonConvert.SerializeObject(projects, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var projectsJSON = {projectsJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		[WebMethod]
		public static string GetBase64DocumentFile(int projectID)
        {
			DocumentConnector projectConnector = new DocumentConnector();
			string base64File = projectConnector.GetDocumentFile(projectID);
			projectConnector = null;

			return base64File;
		}
    }
}