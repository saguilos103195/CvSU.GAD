using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using CvSU.GAD.DataAccess.Models;

namespace CvSU.GAD.DataAccess.DatabaseConnectors.Account
{
	public abstract class AccountConnector : DatabaseConnector
	{
		internal DataAccessFactory _dataAccessFactory;
		public string _accountStatusNew { get; }
		public string _accountStatusActive { get; }
		public string _accountStatusArchive { get; }
		public string _accountTypeAdmin { get; }
		public string _accountTypeCoordinator { get; }

		public AccountConnector()
		{
			_dataAccessFactory = new DataAccessFactory();
			_accountStatusNew = "New";
			_accountStatusActive = "Active";
			_accountStatusActive = "Archive";
			_accountTypeAdmin = "Admin";
			_accountTypeCoordinator = "Coordinator";
		}

		public string Login(string username, string password)
		{
			string messageResult = "Failed to login invalid username and password.";

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					var dbAccount = context.Accounts
						.FirstOrDefault(a => a.Username == username && a.Password == password && a.Status != _accountStatusArchive);

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

			return messageResult;
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
							var dbAccount = context.Accounts.FirstOrDefault(a => a.AccountID == accountId);

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

		public Profile GetProfile(int accountId)
		{
			Profile profile = null;

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					profile = context.Profiles.Include(p => p.Educations).FirstOrDefault(p => p.AccountID == accountId);
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
	}
}
