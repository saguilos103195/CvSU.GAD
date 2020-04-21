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
								account.IsArchived = false;
								account.IsNew = true;
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

		public List<Models.Account> GetAllAccounts(int accountId)
		{
			List<Models.Account> accounts = new List<Models.Account>();

			try
			{
				Models.Account adminAccount = new Models.Account();

				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					adminAccount = context.Accounts
						.FirstOrDefault(a => a.AccountID == accountId && a.Type == _accountTypeAdmin);

					if (adminAccount != null)
					{
						accounts = context.Accounts.ToList();
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

		public List<Models.Account> GetAccessedAccounts(int accountId)
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

		private List<Models.Account> GetCreatedAccounts(int accountID, List<Models.Account> allAccounts)
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

		public string ArchiveAccount(int adminAccountId, int accountId)
		{
			string messageResult = "Failed to archive account";

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isArchived = false;

						try
						{
							var dbAdmin = context.Accounts
								.FirstOrDefault(a => a.AccountID == adminAccountId && a.Type == _accountTypeAdmin);

							if (dbAdmin != null)
							{
								var dbAccount = context.Accounts.FirstOrDefault(a => a.AccountID == accountId);

								if (dbAccount != null)
								{
									if (!dbAccount.IsArchived)
									{
										dbAccount.IsArchived = true;
										isArchived = context.SaveChanges() > 0;
									}
									else
									{
										messageResult = "Account is already archived.";
									}

								}
								else
								{
									messageResult = "Account doesn't exist.";
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

						if (isArchived)
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

		public string RetrieveAccount(int adminAccountId, int accountId)
		{
			string messageResult = "Failed to archive account";

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isArchived = false;

						try
						{
							var dbAdmin = context.Accounts
								.FirstOrDefault(a => a.AccountID == adminAccountId && a.Type == _accountTypeAdmin);

							if (dbAdmin != null)
							{
								var dbAccount = context.Accounts.FirstOrDefault(a => a.AccountID == accountId);

								if (dbAccount != null)
								{
									if (dbAccount.IsArchived)
									{
										dbAccount.IsArchived = false;
										isArchived = context.SaveChanges() > 0;
									}
									else
									{
										messageResult = "Account is active.";
									}

								}
								else
								{
									messageResult = "Account doesn't exist.";
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

						if (isArchived)
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
