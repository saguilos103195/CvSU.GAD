using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.WebForms.Content.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.WebForms.Projects
{
    public partial class Apply : CustomPage
    {
		private readonly DocumentConnector ProjectConnector;

        public Apply()
        {
			ProjectConnector = new DocumentConnector();
		}

        protected void Page_Load(object sender, EventArgs e)
        {

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

					Document newProject = new Document
					{
						Title = txtTitle.Value,
						Type = "Extension",
						DocumentName = fileDocument.PostedFile.FileName,
						DocumentMimeType = fileDocument.PostedFile.ContentType,
						DocumentFile = uploadBase64,
						CreatedBy = CurrentAccount.AccountID,
						Status = "Pending"
					};

					string message = ProjectConnector.AddDocument(newProject);

					if (string.IsNullOrEmpty(message))
					{
						ShowSuccessModal("Success", "Project successfully created!", "OK", "/projects/apply.aspx");

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