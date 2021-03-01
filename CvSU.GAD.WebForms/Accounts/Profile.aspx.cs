using CvSU.GAD.DataAccess.DatabaseConnectors;
using CvSU.GAD.DataAccess.DatabaseConnectors.Account;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.WebForms.Content.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CvSU.GAD.WebForms.Accounts
{
    public partial class Profile : CustomPage
    {
		private AccountConnector AccountConnector { get; }
		private SeminarConnector SeminarConnector { get; }
		private int profileID = 0;
		private int OrientationKey = 0x0112;

		public Profile()
		{
			AccountConnector = new AccountConnector();
			SeminarConnector = new SeminarConnector();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!Page.IsPostBack)
            {
				LoadProfile();
			}

			profileID = AccountConnector.GetProfile(SessionAccount.AccountID).ProfileID;
		}

		private void LoadProfile()
        {
			DataAccess.Models.Profile profile = AccountConnector.GetProfile(SessionAccount.AccountID);

			var middleInitial = string.Empty;

            if (profile.Middlename.Length > 0)
            {
				middleInitial = profile.Middlename.Substring(0, 1) + ".";
			}

			displayName.InnerHtml = profile.Firstname + " " + middleInitial + " " + profile.Lastname;
			displayPosition.InnerHtml = SessionAccount.Type;
			displayGender.InnerHtml = profile.Gender;
			displayContact.InnerHtml = profile.CellphoneNumber;
			displayAddress.InnerHtml = profile.Address;
			displayEmail.InnerHtml = profile.EmailAddress;
			profilePicture.Src = (profile.Image != null ? "data:image/png;base64," + profile.Image : profile.Gender == "Male" ? "/Content/Images/male.png" : "/Content/Images/female.png");
			//profilePicture.Src = @"data:image/png;base64," + profile.Image;

			txtFirstName.Value = profile.Firstname;
			txtMiddleName.Value = profile.Middlename;
			txtLastName.Value = profile.Lastname;
			txtBirthdate.Value = profile.Birthdate.ToString("yyyy-MM-dd");
            txtEmailAddress.Value = profile.EmailAddress;
			txtCellphone.Value = profile.CellphoneNumber;
			txtTelephone.Value = profile.TelephoneNumber;
			txtReligion.Value = profile.Religion;
			txtDesignation.Value = profile.Designation;
			txtPermanentAddress.Value = profile.Address;
			txtOfficeAddress.Value = profile.OfficeAddress;
			txtEngagedFrom.Value = profile.EngagedFrom.ToString("yyyy-MM-dd");
			txtEngagedTo.Value = profile.EngagedTo.ToString("yyyy-MM-dd");
			checkBoxWillTravel.Checked = profile.WillTravel;
		}

		protected void UpdateProfileBtn_Click(object sender, EventArgs e)
		{
            DataAccess.Models.Profile updatedProfile = new DataAccess.Models.Profile
            {
                AccountID = CurrentAccount.AccountID,
                Address = txtPermanentAddress.Value,
                Birthdate = DateTime.ParseExact(txtBirthdate.Value, "yyyy-MM-dd", null),
                CellphoneNumber = txtCellphone.Value,
                Designation = txtDesignation.Value,
                EmailAddress = txtEmailAddress.Value,
                EngagedFrom = DateTime.ParseExact(txtEngagedFrom.Value, "yyyy-MM-dd", null),
                EngagedTo = DateTime.ParseExact(txtEngagedTo.Value, "yyyy-MM-dd", null),
                Firstname = txtFirstName.Value,
                Lastname = txtLastName.Value,
                Middlename = txtMiddleName.Value,
                OfficeAddress = txtOfficeAddress.Value,
                Religion = txtReligion.Value,
                TelephoneNumber = txtTelephone.Value,
                WillTravel = checkBoxWillTravel.Checked
            };

            string message = AccountConnector.UpdateProfile(updatedProfile);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Profile successfully updated!", "OK", "/accounts/profile.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
        }

		protected void AddEducBtn_Click(object sender, EventArgs e)
		{
			Education newEducation = new Education
            {
                ProfileID = profileID,
                Course = txtSchoolCourse.Value,
                DateFrom = DateTime.ParseExact(txtSchoolDateFrom.Value, "yyyy-MM-dd", null),
                DateTo = DateTime.ParseExact(txtSchoolDateTo.Value, "yyyy-MM-dd", null),
                EducationalLevel = selectSchoolType.Value,
                SchoolName = txtSchoolName.Value

            };

            string message = AccountConnector.AddEducation(newEducation);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Education successfully added!", "OK", "/accounts/profile.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
        }

		protected void EditEducBtn_Click(object sender, EventArgs e)
		{
            Education updatedEducation = new Education
            {
                EducationID = int.Parse(selectedID.Value),
                Course = txtSchoolCourse.Value,
                DateFrom = DateTime.ParseExact(txtSchoolDateFrom.Value, "yyyy-MM-dd", null),
                DateTo = DateTime.ParseExact(txtSchoolDateTo.Value, "yyyy-MM-dd", null),
                EducationalLevel = selectSchoolType.Value,
                SchoolName = txtSchoolName.Value

            };

            string message = AccountConnector.UpdateEducation(updatedEducation);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Education successfully updated!", "OK", "/accounts/profile.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
        }

		protected void AddSeminarBtn_Click(object sender, EventArgs e)
		{
            Seminar newSeminar = new Seminar
            {
                Name = txtSeminarName.Value,
                ProfileID = profileID,
                Year = txtSeminarYear.Value
            };

            string message = SeminarConnector.AddSeminar(newSeminar);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Seminar successfully added!", "OK", "/accounts/profile.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}


		protected void EditSeminarBtn_Click(object sender, EventArgs e)
		{
            Seminar updatedSeminar = new Seminar
            {
                SeminarID = int.Parse(selectedID.Value),
                Name = txtSeminarName.Value,
                Year = txtSeminarYear.Value
            };

            string message = SeminarConnector.UpdateSeminar(updatedSeminar);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Seminar successfully updated!", "OK", "/accounts/profile.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
		}

		protected void UpdatePasswordBtn_Click(object sender, EventArgs e)
		{
            string message = AccountConnector.UpdatePassword(profileID, txtPassword.Value);

			if (string.IsNullOrEmpty(message))
			{
				ShowSuccessModal("Success", "Password successfully updated!", "OK", "/accounts/profile.aspx");
			}
			else
			{
				ShowErrorModal("Oops...", message, "OK", "#");
			}
        }

		protected void UploadProfilePicBtn_Click(object sender, EventArgs e)
		{
            try
            {
				if (fileProfilePic.PostedFile.InputStream.Length != 0)
				{
					Stream uploadFileStream = fileProfilePic.PostedFile.InputStream;
					var img = System.Drawing.Image.FromStream(uploadFileStream);
					img = PadImage(img);
                    using (var resizedImage = ResizeImage(img, 200, 200))
                    {
						MemoryStream stream = new MemoryStream();
						resizedImage.Save(stream, ImageFormat.Bmp);
						byte[] imageBytes = stream.ToArray();
						string base64String = Convert.ToBase64String(imageBytes);

                        string message = AccountConnector.UpdateProfilePicture(CurrentAccount.AccountID, base64String);

                        if (string.IsNullOrEmpty(message))
                        {
                            ShowSuccessModal("Success", "Profile picture successfully updated!", "OK", "/accounts/profile.aspx");
                        }
                        else
                        {
                            ShowErrorModal("Oops...", message, "OK", "#");
                        }
                    }
				}
				else
				{
					ShowErrorModal("Oops...", "Please choose image", "OK", "#");
				}
			}
            catch (Exception ex)
            {
				ShowErrorModal("Error", ex.Message, "OK", "#");
			}
        }

		public Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighSpeed;
				graphics.InterpolationMode = InterpolationMode.Default;
				graphics.SmoothingMode = SmoothingMode.HighSpeed;
				graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

				using (var wrapMode = new ImageAttributes())
				{
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}

		public System.Drawing.Image PadImage(System.Drawing.Image originalImage)
		{
			if (originalImage.PropertyIdList.Contains(OrientationKey))
			{
				var orientation = (int)originalImage.GetPropertyItem(OrientationKey).Value[0];
				switch (orientation)
				{
					case 0x0112:
					case 1:
						break;
					case 2:
						originalImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
						break;
					case 3:
						originalImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
						break;
					case 4:
						originalImage.RotateFlip(RotateFlipType.Rotate180FlipX);
						break;
					case 5:
						originalImage.RotateFlip(RotateFlipType.Rotate90FlipX);
						break;
					case 6:
						originalImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
						break;
					case 7:
						originalImage.RotateFlip(RotateFlipType.Rotate270FlipX);
						break;
					case 8:
						originalImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
						break;
					default:
						throw new NotImplementedException("An orientation of " + orientation + " isn't implemented.");
				}
			}

			int largestDimension = Math.Max(originalImage.Height, originalImage.Width);
			Size squareSize = new Size(largestDimension, largestDimension);
			Bitmap squareImage = new Bitmap(squareSize.Width, squareSize.Height);
			using (Graphics graphics = Graphics.FromImage(squareImage))
			{
				graphics.FillRectangle(Brushes.White, 0, 0, squareSize.Width, squareSize.Height);
				graphics.CompositingQuality = CompositingQuality.HighSpeed;
				graphics.InterpolationMode = InterpolationMode.Default;
				graphics.SmoothingMode = SmoothingMode.HighSpeed;

				
				graphics.DrawImage(originalImage, (squareSize.Width / 2) - (originalImage.Width / 2), (squareSize.Height / 2) - (originalImage.Height / 2), originalImage.Width, originalImage.Height);
			}
			return squareImage;
		}
	}
}