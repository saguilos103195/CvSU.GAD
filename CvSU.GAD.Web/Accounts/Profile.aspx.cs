using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.Web.Content.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.Web.Accounts
{
	public partial class Profile : CustomPage
	{
		private Account CurrentAccount { get; set; }
		private AccountConnector AccountConnector { get; }
		private SeminarConnector SeminarConnector { get; }

		public Profile()
		{
			CurrentAccount = new Account();
			AccountConnector = new AccountConnector();
			SeminarConnector = new SeminarConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			UpdateSession();
			CurrentAccount = GetAccountSession();
			if (CurrentAccount == null)
			{
				Response.Redirect("../index.aspx", true);
			}
			else if (CurrentAccount.Status.ToLower().Equals("new"))
			{
				Response.Redirect("accounts/setup.aspx");
			}

			LoadJSProfile();
		}

		protected void UpdateProfileBtn_Click(object sender, EventArgs e)
		{
			DataAccess.Models.Profile updatedProfile = new DataAccess.Models.Profile
			{
				AccountID = CurrentAccount.AccountID,
				Address = addressTxt.Value,
				Birthdate = DateTime.ParseExact(bdateTxt.Value, "dd/MM/yyyy", null),
				CellphoneNumber = cellphoneTxt.Value,
				Designation = designationTxt.Value,
				EmailAddress = emailTxt.Value,
				EngagedFrom = DateTime.ParseExact(engagedFromTxt.Value, "dd/MM/yyyy", null),
				EngagedTo = DateTime.ParseExact(engagedToTxt.Value, "dd/MM/yyyy", null),
				Firstname = fnameTxt.Value,
				Lastname = lnameTxt.Value,
				Middlename = mnameTxt.Value,
				OfficeAddress = officeAddressTxt.Value,
				Religion = religionTxt.Value,
				TelephoneNumber = telephoneTxt.Value,
				WillTravel = willingChkBox.Checked
			};

			string message = AccountConnector.UpdateProfile(updatedProfile);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Profile successfully updated!', 'OK', '#009efb', 'profile.aspx');  </script>";
				
			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void AddEducBtn_Click(object sender, EventArgs e)
		{
			Education newEducation = new Education
			{
				ProfileID = int.Parse(profileID.Value),
				Course = educCourseTxt.Value,
				DateFrom = DateTime.ParseExact(educDateFromTxt.Value, "dd/MM/yyyy", null),
				DateTo = DateTime.ParseExact(educDateToTxt.Value, "dd/MM/yyyy", null),
				EducationalLevel = educTypeSel.Value,
				SchoolName = educSchoolNameTxt.Value

			};

			string message = AccountConnector.AddEducation(newEducation);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Education successfully added!', 'OK', '#009efb', 'profile.aspx');  </script>";

			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void UpdateEducBtn_Click(object sender, EventArgs e)
		{
			Education updatedEducation = new Education
			{
				EducationID = int.Parse(selectedID.Value),
				Course = educCourseTxt.Value,
				DateFrom = DateTime.ParseExact(educDateFromTxt.Value, "dd/MM/yyyy", null),
				DateTo = DateTime.ParseExact(educDateToTxt.Value, "dd/MM/yyyy", null),
				EducationalLevel = educTypeSel.Value,
				SchoolName = educSchoolNameTxt.Value

			};

			string message = AccountConnector.UpdateEducation(updatedEducation);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Education successfully updated!', 'OK', '#009efb', 'profile.aspx');  </script>";

			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void AddSeminarBtn_Click(object sender, EventArgs e)
		{
			Seminar newSeminar = new Seminar
			{
				Name = seminarNameTxt.Value,
				ProfileID = int.Parse(profileID.Value),
				Year = seminarYearTxt.Value
			};

			string message = SeminarConnector.AddSeminar(newSeminar);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Seminar successfully added!', 'OK', '#009efb', 'profile.aspx');  </script>";

			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}


		protected void UpdateSeminarBtn_Click(object sender, EventArgs e)
		{
			Seminar updatedSeminar = new Seminar
			{
				SeminarID = int.Parse(selectedID.Value),
				Name = seminarNameTxt.Value,
				Year = seminarYearTxt.Value
			};

			string message = SeminarConnector.UpdateSeminar(updatedSeminar);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Seminar successfully updated!', 'OK', '#009efb', 'profile.aspx');  </script>";

			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void UpdatePasswordBtn_Click(object sender, EventArgs e)
		{
			string message = AccountConnector.UpdatePassword(int.Parse(profileID.Value), passwordTxt.Value);
			string showAlert;
			if (string.IsNullOrEmpty(message))
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Password successfully updated!', 'OK', '#009efb', 'profile.aspx');  </script>";

			}
			else
			{
				showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
			}
			LoadJavaSript("showAlert", showAlert);
		}

		protected void UpdateProfilePicBtn_Click(object sender, EventArgs e)
		{
			if (ProfilePicFile.HasFile)
			{
				Stream uploadFileStream = ProfilePicFile.PostedFile.InputStream;
				BinaryReader uploadBinaryReader = new BinaryReader(uploadFileStream);
				byte[] uploadBytes = uploadBinaryReader.ReadBytes((int)uploadFileStream.Length);
				string uploadBase64 = Convert.ToBase64String(uploadBytes, 0, uploadBytes.Length);
				string showAlert = "";
				string guid = Guid.NewGuid().ToString();
				if (new FileManager().Upload(uploadBase64, "pic-" + guid + ".jpg"))
				{
					string message = AccountConnector.UpdateProfilePicture(CurrentAccount.AccountID, "../Content/Images/Uploads/pic-" + guid + ".jpg");

					if (string.IsNullOrEmpty(message))
					{
						showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-check-circle', '#51d487', 'Success', 'Profile picture successfully updated!', 'OK', '#009efb', 'profile.aspx');  </script>";

					}
					else
					{
						showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', '" + message + "', 'OK', '#009efb', '#');  </script>";
					}
				}
				else
				{
					showAlert = "<script type=\"text/javascript\"> toggleMasterAlert('far fa-times-circle', '#f27474', 'Oops...', 'Upload Failed. Try Again.', 'OK', '#009efb', '#');  </script>";
				}
				LoadJavaSript("showAlert", showAlert);
			}
		}
	}
}