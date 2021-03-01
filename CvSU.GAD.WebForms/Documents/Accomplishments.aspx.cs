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

namespace CvSU.GAD.WebForms.Documents
{
    public partial class Accomplishments : CustomPage
    {
		private readonly DocumentConnector DocumentConnector;

        public Accomplishments()
        {
			DocumentConnector = new DocumentConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
        {
			LoadJSData();
		}

		private void LoadJSData()
		{
			List<Document> reports = new List<Document>();

			if (CurrentAccount.Type == "Administrator")
			{
				reports = DocumentConnector.GetAccomplishments();
			}
			else
			{
				reports = DocumentConnector.GetAccomplishments().Where(d => d.CreatedBy == CurrentAccount.AccountID).ToList();
			}

			string reportsJSON = JsonConvert.SerializeObject(reports, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

			string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
									$"var reportsJSON = {reportsJSON}; " + Environment.NewLine +
								$"</script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		[WebMethod]
		public static string GetBase64DocumentFile(int documentID)
		{
			DocumentConnector documentConnector = new DocumentConnector();
			string base64File = documentConnector.GetDocumentFile(documentID);
			documentConnector = null;

			return base64File;
		}

		protected void CreateBtn_Click(object sender, EventArgs e)
        {
			try
			{
				if (fileDocument.PostedFile.InputStream.Length != 0)
				{
					Stream uploadFileStream = fileDocument.PostedFile.InputStream;
					BinaryReader uploadBinaryReader = new BinaryReader(uploadFileStream);
					byte[] uploadBytes = uploadBinaryReader.ReadBytes((int)uploadFileStream.Length);
					string uploadBase64 = Convert.ToBase64String(uploadBytes, 0, uploadBytes.Length);

					Document newAccomplishment = new Document
					{
						Title = txtTitle.Value,
						Type = "Accomplishment",
						DocumentName = fileDocument.PostedFile.FileName,
						DocumentMimeType = fileDocument.PostedFile.ContentType,
						DocumentFile = uploadBase64,
						CreatedBy = CurrentAccount.AccountID
					};

					string message = DocumentConnector.AddDocument(newAccomplishment);

					if (string.IsNullOrEmpty(message))
					{
						ShowSuccessModal("Success", "Report successfully created!", "OK", "/documents/accomplishments.aspx");

					}
					else
					{
						ShowErrorModal("Error", message, "OK", "#");
					}

				}
				else
				{
					ShowErrorModal("Oops...", "Please choose document", "OK", "#");
				}
			}
			catch (Exception ex)
			{
				ShowErrorModal("Error", ex.Message, "OK", "#");
			}
		}
    }
}