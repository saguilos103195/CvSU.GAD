using CvSU.GAD.DataAccess.DatabaseContexts;
using CvSU.GAD.DataAccess.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSU.GAD.DataAccess.DatabaseConnectors
{
	public class DatabaseConnector
	{
		protected static Logger _log = LogManager.GetCurrentClassLogger();

		private DataAccessFactory _dataAccessFactory { get; set; }

		public void InitializeDefaultValues()
		{
			_dataAccessFactory = new DataAccessFactory();

			try
			{
				using (CVSUGADDBContext context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (DbContextTransaction transaction = context.Database.BeginTransaction())
					{
						bool isSaved = false;

						try
						{
							College unmappedCollege = context.Colleges.FirstOrDefault(c => c.CollegeID == 0);

							if (unmappedCollege == null)
							{
								context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[College] ON");
								context.Colleges.Add(new College { CollegeID = 0, Title = "UNMAPPED", Alias = "UNMAPPED", IsArchived = false, IsMain = false });
								isSaved = context.SaveChanges() > 0;
								context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[College] OFF");
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

						if (isSaved)
						{
							transaction.Commit();
							LogInfo($"Unmapped College successfully saved.");
						}
						else
						{
							transaction.Rollback();
							LogInfo($"Unmapped College failed to save.");
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}
		}

		public void LogDbEntityValidationException(DbEntityValidationException ex)
		{
			_log.Error(ex);

			foreach (DbEntityValidationResult result in ex.EntityValidationErrors)
			{
				foreach (DbValidationError error in result.ValidationErrors)
				{
					_log.Error(error.ErrorMessage);
				}
			}
		}

		public void LogException(Exception ex)
		{
			_log.Error(ex);
			Exception innerException = ex.InnerException;

			while (innerException != null)
			{
				_log.Error(innerException);
				innerException = innerException.InnerException;
			}
		}

		public void LogInfo(string info)
		{
			_log.Info(info);
		}
	}
}
