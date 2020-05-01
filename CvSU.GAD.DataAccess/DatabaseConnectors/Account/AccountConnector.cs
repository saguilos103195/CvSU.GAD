using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using CvSU.GAD.DataAccess.Models;
using Newtonsoft.Json;
using CvSU.GAD.DataAccess.DatabaseContexts;

namespace CvSU.GAD.DataAccess.DatabaseConnectors.Account
{
	public class AccountConnector : DatabaseConnector
	{
		internal DataAccessFactory _dataAccessFactory;
		public string _accountTypeAdmin { get; }
		public string _accountTypeCoordinator { get; }

		public AccountConnector()
		{
			_dataAccessFactory = new DataAccessFactory();
			_accountTypeAdmin = "Administrator";
			_accountTypeCoordinator = "Coordinator";
		}

		public Tuple<bool, string> Login(string username, string password)
		{
			string messageResult = "Failed to login invalid username and password.";
			Models.Account dbAccount = new Models.Account();

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					dbAccount = context.Accounts
						.FirstOrDefault(a => a.Username == username && a.Password == password && !a.IsArchived);

					if (dbAccount != null)
					{
						messageResult = string.Empty;
					}
				}
			}
			catch (DbEntityValidationException ex)
			{
				LogDbEntityValidationException(ex);
				messageResult = "Please contact support.";
			}
			catch (Exception ex)
			{
				LogException(ex);
				messageResult = "Please contact support.";
			}

			return Tuple.Create(messageResult == "", messageResult == "" ? 
				JsonConvert.SerializeObject(dbAccount, 
				new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }) 
				: messageResult);
		}

		public string UpdatePassword(int accountId, string newPassword)
		{
			string messageResult = "Failed to update.";
			
			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isSaved = false;

						try
						{
							Models.Account dbAccount = context.Accounts.FirstOrDefault(a => a.AccountID == accountId);

							if (dbAccount != null)
							{
								dbAccount.Password = newPassword;
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								messageResult = "Account doesn't exist.";
							}
						}
						catch (Exception ex)
						{
							LogException(ex);
							messageResult = "Please contact support.";
						}

						if (isSaved)
						{
							transaction.Commit();
							messageResult = string.Empty;
						}
						else
						{
							transaction.Rollback();
						}
					}
				}
			}
			catch (DbEntityValidationException ex)
			{
				LogDbEntityValidationException(ex);
				messageResult = "Please contact support.";
			}
			catch (Exception ex)
			{
				LogException(ex);
				messageResult = "Please contact support.";
			}

			return messageResult;
		}

		public string UpdateProfilePicture(int accountID, string base64)
		{
			string messageResult = "Failed to update.";

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isUpdated = false;

						try
						{
							var dbProfile = context.Profiles.FirstOrDefault(p => p.AccountID == accountID);

							if (dbProfile != null)
							{
								dbProfile.Image = base64;
								isUpdated = context.SaveChanges() > 0;
							}
						}
						catch (DbEntityValidationException ex)
						{
							LogDbEntityValidationException(ex);
							messageResult = "Please contact support.";
						}
						catch (Exception ex)
						{
							LogException(ex);
							messageResult = "Please contact support.";
						}

						if (isUpdated)
						{
							transaction.Commit();
							messageResult = string.Empty;
						}
						else
						{
							transaction.Rollback();
						}
					}
				}
			}
			catch (Exception ex)
			{
				_log.Error(ex);
			}

			return messageResult;
		}

		public string UpdateAccount(Models.Account account)
		{
			string messageResult = "Failed to update.";

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isUpdated = false;

						try
						{
							var dbAccount = context.Accounts.FirstOrDefault(a => a.AccountID == account.AccountID);

							if (dbAccount != null)
							{
								dbAccount.CollegeID = account.CollegeID;
								dbAccount.Type = account.Type;
								isUpdated = context.SaveChanges() > 0;
							}
						}
						catch (DbEntityValidationException ex)
						{
							LogDbEntityValidationException(ex);
							messageResult = "Please contact support.";
						}
						catch (Exception ex)
						{
							LogException(ex);
							messageResult = "Please contact support.";
						}

						if (isUpdated)
						{
							transaction.Commit();
							messageResult = string.Empty;
						}
						else
						{
							transaction.Rollback();
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return messageResult;
		}

		public Profile GetProfile(int accountId)
		{
			Profile profile = null;

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					profile = context.Profiles.Include(p => p.Educations).Include(s => s.Seminars).FirstOrDefault(p => p.AccountID == accountId);
				}
			}
			catch (DbEntityValidationException ex)
			{
				LogDbEntityValidationException(ex);
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return profile;
		}

		public string AddProfile(Profile profile)
		{
			string resultMessage = "Failed to save.";

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isSaved = false;

						try
						{
							Models.Account dbAccount = context.Accounts.Include(a => a.Profiles).FirstOrDefault(a => a.AccountID == profile.AccountID);

							if (dbAccount.Profiles.Count < 1)
							{
								context.Profiles.Add(profile);
								dbAccount.IsNew = false;
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								resultMessage = "Account has already registered.";
							}
						}
						catch (Exception ex)
						{
							LogException(ex);
							resultMessage = "Please contact the support. ";
						}

						if (isSaved)
						{
							transaction.Commit();
							resultMessage = string.Empty;
						}
						else
						{
							transaction.Rollback();
						}
					}
				}
			}
			catch (DbEntityValidationException ex)
			{
				LogDbEntityValidationException(ex);
				resultMessage = "Please contact the support. ";
			}
			catch (Exception ex)
			{
				LogException(ex);
				resultMessage = "Please contact the support. ";
			}

			return resultMessage;
		}

		public string GetAccount(int accountId)
		{
			string resultMessage = string.Empty;

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					Models.Account dbAccount = context.Accounts.FirstOrDefault(a => a.AccountID == accountId);

					if (dbAccount != null)
					{
						resultMessage = JsonConvert.SerializeObject(dbAccount, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}
			return resultMessage;
		}


        public string UpdateProfile(Profile profile)
        {
            string resultMessage = string.Empty;

            try
            {
                using (var context = _dataAccessFactory.GetCVSUGADDBContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        bool isUpdated = false;

                        try
                        {
                            Profile dbProfile = context.Profiles.FirstOrDefault(p => p.AccountID == profile.AccountID);

                            if (dbProfile != null)
                            {
                                int numberOfChanges = 0;

                                if (dbProfile.Address != profile.Address)
                                {
                                    dbProfile.Address = profile.Address;
                                    numberOfChanges++;
                                }

                                if (dbProfile.Birthdate != profile.Birthdate)
                                {
                                    dbProfile.Birthdate = profile.Birthdate;
                                    numberOfChanges++;
                                }

                                if (dbProfile.CellphoneNumber != profile.CellphoneNumber)
                                {
                                    dbProfile.CellphoneNumber = profile.CellphoneNumber;
                                    numberOfChanges++;
                                }

                                if (dbProfile.Designation != profile.Designation)
                                {
                                    dbProfile.Designation = profile.Designation;
                                    numberOfChanges++;
                                }

                                if (dbProfile.EmailAddress != profile.EmailAddress)
                                {
                                    dbProfile.EmailAddress = profile.EmailAddress;
                                    numberOfChanges++;
                                }

                                if (dbProfile.Firstname != profile.Firstname)
                                {
                                    dbProfile.Firstname = profile.Firstname;
                                    numberOfChanges++;
                                }

                                if (dbProfile.Lastname != profile.Lastname)
                                {
                                    dbProfile.Lastname = profile.Lastname;
                                    numberOfChanges++;
                                }

                                if (dbProfile.Middlename != profile.Middlename)
                                {
                                    dbProfile.Middlename = profile.Middlename;
                                    numberOfChanges++;
                                }

                                if (dbProfile.OfficeAddress != profile.OfficeAddress)
                                {
                                    dbProfile.OfficeAddress = profile.OfficeAddress;
                                    numberOfChanges++;
                                }

                                if (dbProfile.Religion != profile.Religion)
                                {
                                    dbProfile.Religion = profile.Religion;
                                    numberOfChanges++;
                                }

                                if (dbProfile.TelephoneNumber != profile.TelephoneNumber)
                                {
                                    dbProfile.TelephoneNumber = profile.TelephoneNumber;
                                    numberOfChanges++;
                                }

                                if (dbProfile.WillTravel != profile.WillTravel)
                                {
                                    dbProfile.WillTravel = profile.WillTravel;
                                    numberOfChanges++;
                                }

                                if (numberOfChanges > 0)
                                {
                                    isUpdated = context.SaveChanges() > 0;
                                }
                                else
                                {
                                    resultMessage = "No changes found.";
                                }
                            }
                            else
                            {
                                resultMessage = "Profile doesn't exist in the database.";
                            }
                        }
                        catch (Exception ex)
                        {
                            LogException(ex);
                            resultMessage = "Please contact the support. ";
                        }

                        if (isUpdated)
                        {
                            transaction.Commit();
                            LogInfo($"Account '{profile.AccountID}' is successfully updated.");
                        }
                        else
                        {
                            transaction.Rollback();
                            LogWarn($"Account '{profile.AccountID}' failed to updated.");
                            resultMessage = "Failed to update. ";
                        }
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                LogDbEntityValidationException(ex);
                resultMessage = "Please contact the support. ";
            }
            catch (Exception ex)
            {
                LogException(ex);
                resultMessage = "Please contact the support. ";
            }

            return resultMessage;
        }

		public string AddEducation(Education education)
		{
			string resultMessage = "Failed to approve the seminar. ";

			try
			{
				using (CVSUGADDBContext context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isSaved = false;

						try
						{
							var dbProfile = context.Profiles.FirstOrDefault(p => p.ProfileID == education.ProfileID);

							if (dbProfile != null)
							{
								context.Educations.Add(education);
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								resultMessage += "Profile doesn't exist in the database.";
							}
						}
						catch (DbEntityValidationException ex)
						{
							transaction.Rollback();
							LogDbEntityValidationException(ex);
							resultMessage += "Please contact the support. ";
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							LogException(ex);
							resultMessage += "Please contact the support. ";
						}

						if (isSaved)
						{
							transaction.Commit();
							resultMessage = string.Empty;
						}
						else
						{
							transaction.Rollback();
							resultMessage += "Please contact the support. ";
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
				resultMessage += "Please contact the support. ";
			}

			return resultMessage;
		}

		public string UpdateEducation(Education education)
        {
            string resultMessage = string.Empty;

            try
            {
                if (education != null)
                {
                    using (var context = _dataAccessFactory.GetCVSUGADDBContext())
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            bool isUpdated = false;

                            try
                            {
                                Education dbEducation = context.Educations.FirstOrDefault(p => p.EducationID == education.EducationID);

                                if (dbEducation != null)
                                {
                                    int numberOfChanges = 0;

                                    if (dbEducation.Course != education.Course)
                                    {
                                        dbEducation.Course = education.Course;
                                        numberOfChanges++;
                                    }

                                    if (dbEducation.DateFrom != education.DateFrom)
                                    {
                                        dbEducation.DateFrom = education.DateFrom;
                                        numberOfChanges++;
                                    }

                                    if (dbEducation.DateTo != education.DateTo)
                                    {
                                        dbEducation.DateTo = education.DateTo;
                                        numberOfChanges++;
                                    }

                                    if (dbEducation.EducationalLevel != education.EducationalLevel)
                                    {
                                        dbEducation.EducationalLevel = education.EducationalLevel;
                                        numberOfChanges++;
                                    }

                                    if (dbEducation.SchoolName != education.SchoolName)
                                    {
                                        dbEducation.SchoolName = education.SchoolName;
                                        numberOfChanges++;
                                    }

                                    if (numberOfChanges > 0)
                                    {
                                        isUpdated = context.SaveChanges() > 0;
                                    }
                                    else
                                    {
                                        resultMessage = "No changes found.";
                                    }
                                }
                                else
                                {
                                    resultMessage = "Profile doesn't exist in the database.";
                                }
                            }
                            catch (Exception ex)
                            {
                                LogException(ex);
                                resultMessage = "Please contact the support. ";
                            }

                            if (isUpdated)
                            {
                                transaction.Commit();
                                LogInfo($"Account '{education.EducationID}' is successfully updated.");
                            }
                            else
                            {
                                transaction.Rollback();
                                LogWarn($"Account '{education.EducationID}' failed to updated.");
                                resultMessage = "Failed to update. ";
                            }
                        }
                    }
                }
                else
                {
                    resultMessage = "Invalid education";
                }
            }
            catch (DbEntityValidationException ex)
            {
                LogDbEntityValidationException(ex);
                resultMessage = "Please contact the support. ";
            }
            catch (Exception ex)
            {
                LogException(ex);
                resultMessage = "Please contact the support. ";
            }

            return resultMessage;
        }
    }
}
