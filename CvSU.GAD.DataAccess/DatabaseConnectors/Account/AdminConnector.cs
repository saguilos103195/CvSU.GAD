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
								resultMessage = $"Username {account.Username} already exist.";
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


		public string ArchiveAccount(int accountId)
		{
			string resultMessage = "Failed to archive.";

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isArchived = false;

						try
						{
							var dbAccount = context.Accounts.FirstOrDefault(a => a.AccountID == accountId);

							if (dbAccount != null)
							{
								dbAccount.IsArchived = true;
								isArchived = context.SaveChanges() > 0;
							}
							else
							{
								resultMessage = "Account doesn't exist in the database.";
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

						if (isArchived)
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
			catch (Exception ex)
			{
				LogException(ex);
			}

			return resultMessage;
		}

		public List<Models.Account> GetAccounts(int accountId)
		{
			List<Models.Account> accounts = new List<Models.Account>();

			try
			{
				Models.Account adminAccount = new Models.Account();
				List<Models.Account> allAccounts = new List<Models.Account>();
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					adminAccount = context.Accounts
						.FirstOrDefault(a => a.AccountID == accountId && a.Type == _accountTypeAdmin);

					allAccounts = context.Accounts.Where(a => a.Type == "Administrator").ToList();
					accounts.AddRange(context.Accounts.Where(a => a.Type == "Coordinator").ToList());
				}

				if (adminAccount != null && allAccounts.Count != 0)
				{
					accounts.AddRange(GetCreatedAccounts(adminAccount.AccountID, allAccounts));
				}
				else
				{
					_log.Warn($"Unauthozired account id '{accountId}'.");
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

		public List<Models.Account> GetCreatedAccounts(int accountID, List<Models.Account> allAccounts)
		{
			List<Models.Account> accounts = new List<Models.Account>();

			try
			{
				allAccounts.Remove(allAccounts.FirstOrDefault(a => a.AccountID == accountID));

				List<Models.Account> filteredAccount = allAccounts.Where(a => a.CreatedByID == accountID).ToList();

				foreach (Models.Account account in filteredAccount)
				{
					accounts.Add(account);
					accounts.AddRange(GetCreatedAccounts(account.AccountID, allAccounts));
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
