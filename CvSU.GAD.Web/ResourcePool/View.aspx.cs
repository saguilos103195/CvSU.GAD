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
	public partial class View : CustomPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//LoadJSData();
		}

		//private void LoadJSData()
		//{
		//	string seminarsJSON = JsonConvert.SerializeObject(SeminarConnector.GetSeminars());
		//	string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
		//							$"var seminarsJSON = {seminarsJSON}; " + Environment.NewLine +
		//						$"</script>";
		//	LoadJavaSript("loadJSData", loadJSData);
		//}
	}
}