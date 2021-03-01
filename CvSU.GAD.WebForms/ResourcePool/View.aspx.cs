using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
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
    public partial class View : CustomPage
    {
        private readonly CollegeConnector CollegeConnector;

        private readonly AdminConnector AdminConnector;

        public View()
        {
            CollegeConnector = new CollegeConnector();
            AdminConnector = new AdminConnector();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadJSData();
            LoadCollegeSelection();
        }

        private void LoadCollegeSelection()
        {
            var collegesSelectList = CollegeConnector.GetColleges().Select(c => new { ID = c.CollegeID, Name = c.Title, c.Alias }).ToList();

            foreach (var college in collegesSelectList)
            {
                selectReassignCollege.Items.Add(new ListItem { Text = college.Name, Value = college.ID.ToString() });

            }
        }

        private void LoadJSData()
        {
            try
            {
                string resourcePoolJSON = JsonConvert.SerializeObject(AdminConnector.GetProfiles(CurrentAccount.AccountID), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                string loadJSData = $"<script type=\"text/javascript\">" + Environment.NewLine +
                                        $"var resourcePoolJSON = {resourcePoolJSON}; " + Environment.NewLine +
                                    $"</script>";
                LoadJavaSript("loadJSData", loadJSData);
            }
            catch (Exception ex)
            {
                ShowErrorModal("Error", ex.Message, "OK", "#");
            }
        }

        protected void ReassignBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int collegeID = 0;

                if (!string.IsNullOrEmpty(selectReassignCollege.Value))
                {
                    collegeID = int.Parse(selectReassignCollege.Value);
                }

                string message = AdminConnector.ReassignPersonnel(CurrentAccount.AccountID, int.Parse(selectedID.Value), collegeID);
               
                if (string.IsNullOrEmpty(message))
                {
                    ShowSuccessModal("Success", "Personnel successfully reassigned!", "OK", "/resourcepool/view.aspx");
                }
                else
                {
                    ShowErrorModal("Oops...", message, "OK", "#");
                }
            }
            catch (Exception ex)
            {
                ShowErrorModal("Error", ex.Message, "OK", "/resourcepool/view.aspx");
            }
        }
    }
}