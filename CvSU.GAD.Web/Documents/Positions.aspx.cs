using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.Web.Content.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.Web.Documents
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
			newPosition.Title = titleTxt.Value;
			newPosition.IsFaculty = typeChkBx.Checked;
			string message = PositionConnector.AddPosition(newPosition);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Position successfully added!', 'OK', '#009efb', 'positions.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void ArchiveBtn_Click(object sender, EventArgs e)
		{
			string message = PositionConnector.ArchivePosition(int.Parse(selectedID.Value), true);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Position successfully archived!', 'OK', '#009efb', 'positions.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void RetrieveBtn_Click(object sender, EventArgs e)
		{
			string message = PositionConnector.ArchivePosition(int.Parse(selectedID.Value), false);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Position successfully retrieved!', 'OK', '#009efb', 'positions.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void EditBtn_Click(object sender, EventArgs e)
		{
			Position updatePosition = new Position { PositionID = int.Parse(selectedID.Value), Title = editTitleTxt.Value, IsArchived = false, IsFaculty = editTypeChkBx.Checked };

			string message = PositionConnector.UpdatePosition(updatePosition);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Position successfully updated!', 'OK', '#009efb', 'positions.aspx');  </script>";
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}
	}
}