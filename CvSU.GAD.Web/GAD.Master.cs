using CvSU.GAD.DataAccess.DatabaseConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.Web
{
	public partial class GAD : System.Web.UI.MasterPage
	{
		DatabaseConnector DatabaseConnector { get; }

		public GAD()
		{
			DatabaseConnector = new DatabaseConnector();
		}

		protected void Page_Init(object sender, EventArgs e)
		{
			Page.PreLoad += Master_Page_PreLoad;
		}

		protected void Master_Page_PreLoad(object sender, EventArgs e)
		{
			//DatabaseConnector.InitializeDefaultValues();
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}