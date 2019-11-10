using CvSU.GAD.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CvSU.GAD.DataAccess.DatabaseConnectors
{
	public class AccountConnector : DatabaseConnector
	{
		private DataAccessFactory _dataAccessFactory { get; }
		private string _accountStatusNew { get; }
		private string _accountStatusActive { get; }
		private string _accountStatusArchive { get; }

		public AccountConnector()
		{
			_dataAccessFactory = new DataAccessFactory();
			_accountStatusNew = "New";
			_accountStatusActive = "Active";
			_accountStatusActive = "Archive";
		}

		public string AddAccount(Account account)
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
							var dbAccount = context.Accounts.FirstOrDefault(a => a.Username == account.Username);

							if (dbAccount == null)
							{
								context.Accounts.Add(account);
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								resultMessage = $"Username '{account.Username}' is already exist.";
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

		public string AddPropfile(Profile profile)
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
							var dbProfile = context.Profiles.Include(p => p.Account)
								.FirstOrDefault(a => a.AccountID == profile.AccountID);

							if (dbProfile == null)
							{
								dbProfile.Account.Status = _accountStatusActive;
								context.Profiles.Add(profile);
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


	}
}
