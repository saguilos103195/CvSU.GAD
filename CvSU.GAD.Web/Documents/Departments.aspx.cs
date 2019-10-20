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
	public partial class Departments : CustomPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			CollegeConnector collegeConnector = new CollegeConnector();
			List<College> dbColleges = collegeConnector.GetColleges();
			Dictionary<int, string> collegeList = new Dictionary<int, string>() {  };
			var collegesSelectList = collegeConnector.GetColleges().Select(c => new { ID = c.CollegeID, Name = c.Title }).ToList();
			string collegeSelectJSON = JsonConvert.SerializeObject(collegesSelectList);
			string loadJsonObjects = $"<script type=\"text/javascript\">var jsonColleges = {collegeSelectJSON}; </script>";
			LoadJavaSript("loadJsonObjects", loadJsonObjects);

		}

		protected void ArchiveBtn_Click(object sender, EventArgs e)
		{

		}

		protected void CreateBtn_Click(object sender, EventArgs e)
		{

		}
	}
}