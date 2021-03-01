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
    public partial class Colleges : CustomPage
    {
        private CollegeConnector CollegeConnector { get; }

        public Colleges()
        {
            CollegeConnector = new CollegeConnector();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadJSData();
        }

        private void LoadJSData()
        {
            string collegesJSON = JsonConvert.SerializeObject(CollegeConnector.GetColleges());
            string loadJSData = "<script type=\"text/javascript\"> var collegesJSON = " + collegesJSON + " </script>";
            LoadJavaSript("loadJSData", loadJSData);
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            College newCollege = new College();
            newCollege.Alias = txtAlias.Value;
            newCollege.IsMain = checkBoxMain.Checked;
            newCollege.Title = txtTitle.Value;
            string message = CollegeConnector.AddCollege(newCollege);
            if (string.IsNullOrEmpty(message))
            {
                ShowSuccessModal("Success", "College successfully added!", "OK", "/documents/colleges.aspx");
            }
            else
            {
                ShowErrorModal("Oops...", message, "OK", "#");
            }
        }

        protected void ArchiveBtn_Click(object sender, EventArgs e)
        {
            string message = CollegeConnector.ArchiveCollege(int.Parse(selectedID.Value));

            if (string.IsNullOrEmpty(message))
            {
                ShowSuccessModal("Success", "College successfully archived!", "OK", "/documents/colleges.aspx");
            }
            else
            {
                ShowErrorModal("Oops...", message, "OK", "#");
            }
        }

        protected void RetrieveBtn_Click(object sender, EventArgs e)
        {
            string message = CollegeConnector.RetrieveCollege(int.Parse(selectedID.Value));

            if (string.IsNullOrEmpty(message))
            {
                ShowSuccessModal("Success", "College successfully retrieved!", "OK", "/documents/colleges.aspx");
            }
            else
            {
                ShowErrorModal("Oops...", message, "OK", "#");
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            College updateCollege = new College { CollegeID = int.Parse(selectedID.Value), Title = txtTitleEdit.Value, Alias = txtAliasEdit.Value, IsArchived = false, IsMain = checkBoxMainEdit.Checked };

            string message = CollegeConnector.UpdateCollege(updateCollege);

            if (string.IsNullOrEmpty(message))
            {
                ShowSuccessModal("Success", "College successfully updated!", "OK", "/documents/colleges.aspx");
            }
            else
            {
                ShowErrorModal("Oops...", message, "OK", "#");
            }
        }
    }
}