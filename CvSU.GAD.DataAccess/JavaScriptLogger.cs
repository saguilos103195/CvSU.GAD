using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace CvSU.GAD.DataAccess
{
    public class JavaScriptLogger
    {
        public static List<string> Logs = new List<string>();

        public static void DisplayLog(Page page)
        {
            string loadLogs = "<script type=\"text/javascript\">" + Environment.NewLine;

            foreach (var item in Logs)
            {
                loadLogs += "console.log('" + item + "');" + Environment.NewLine;
            }

            loadLogs += "</script>";

            ScriptManager.RegisterStartupScript(page, typeof(Page), "loadLogs", loadLogs, false);
        }
    }
}
