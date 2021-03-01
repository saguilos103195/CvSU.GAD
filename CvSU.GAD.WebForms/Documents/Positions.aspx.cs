using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.WebForms.Content.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.WebForms.Documents
{
    public partial class Positions : CustomPage
    {
		private PositionConnector PositionConnector { get; }

		public Positions()
		{
			PositionConnector = new PositionConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadJSData();
		}

		private void LoadJSData()
		{
			string positionsJSON = JsonConvert.SerializeObject(PositionConnector.GetPositions());
			string loadJSData = "<script type=\"text/javascript\"> var positionsJSON = " + positionsJSON + " </script>";
			LoadJavaSript("loadJSData", loadJSData);
		}

		protected void CreateBtn_Click(object sender, EventArgs e)
		{
			Position newPosition = new Position();
			newPosition.Title = txtTitle.Value;
			newPosition.IsFaculty = checkBoxFaculty.Checked;
			string message = PositionConnector.AddPosition(newPosition);
			
			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Position successfully added!", "OK", "/documents/positions.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

		protected void ArchiveBtn_Click(object sender, EventArgs e)
		{
			string message = PositionConnector.ArchivePosition(int.Parse(selectedID.Value), true);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Position successfully archived!", "OK", "/documents/positions.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

		protected void RetrieveBtn_Click(object sender, EventArgs e)
		{
			string message = PositionConnector.ArchivePosition(int.Parse(selectedID.Value), false);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Position successfully retrieved!", "OK", "/documents/positions.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

		protected void EditBtn_Click(object sender, EventArgs e)
		{
			Position updatePosition = new Position { PositionID = int.Parse(selectedID.Value), Title = txtTitleEdit.Value, IsArchived = false, IsFaculty = checkBoxFacultyEdit.Checked };

			string message = PositionConnector.UpdatePosition(updatePosition);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Position successfully updated!", "OK", "/documents/positions.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}
	}
}