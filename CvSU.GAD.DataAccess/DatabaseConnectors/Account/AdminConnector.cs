using CvSU.GAD.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CvSU.GAD.DataAccess.DatabaseConnectors.Account
{
	public class AdminConnector : AccountConnector
	{
		public string AddAccount(Models.Account account)
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

		public List<Models.Account> GetAccounts(int accountId)
		{
			List<Models.Account> accounts = null;

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					var adminAccount = context.Accounts
						.FirstOrDefault(a => a.AccountID == accountId && a.Type == _accountTypeAdmin);

					if (adminAccount != null)
					{
						accounts = context.Accounts.Where(a => a.Type != _accountTypeAdmin).ToList();
					}
					else
					{
						_log.Warn($"Unauthozired account id '{accountId}'.");
					}
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

			return accounts;
		}

		public string ArciveAccount(int adminAccountId, int accountId)
		{
			string messageResult = "Failed to archive account";

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isArchied = false;

						try
						{
							var dbAdmin = context.Accounts
								.FirstOrDefault(a => a.AccountID == adminAccountId && a.Type == _accountTypeAdmin);

							if (dbAdmin != null)
							{
								var dbAccount = context.Accounts.FirstOrDefault(a => a.AccountID == accountId);

								if (dbAccount != null)
								{
									dbAccount.Status = _accountStatusArchive;
									isArchied = context.SaveChanges() > 0;
								}
								else
								{
									messageResult = "Account doesn'y exist.";
								}
							}
							else
							{
								messageResult = "Unauthorized.";
							}
						}
						catch (Exception ex)
						{
							LogException(ex);
							messageResult = "Please contact the support. ";
						}

						if (isArchied)
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
				messageResult = "Please contact the support. ";
			}
			catch (Exception ex)
			{
				LogException(ex);
				messageResult = "Please contact the support. ";
			}

			return messageResult;
		}
	}
}
