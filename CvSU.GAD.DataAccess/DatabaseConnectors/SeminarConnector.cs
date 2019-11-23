using CvSU.GAD.DataAccess.DatabaseContexts;
using CvSU.GAD.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSU.GAD.DataAccess.DatabaseConnectors
{
	public class SeminarConnector : DatabaseConnector
	{
		private DataAccessFactory _dataAccessFactory { get; }
		private string _seminarPending { get; }
		private string _seminarApproved { get; }
		private string _seminarCancelled { get; }
		private string _seminarRejected { get; }

		public SeminarConnector()
		{
			_dataAccessFactory = new DataAccessFactory();
			_seminarPending = "Pending";
			_seminarApproved = "Approved";
			_seminarRejected = "Rejected";
			_seminarCancelled = "Cancelled";
		}

		public string AddSeminar(Seminar seminar)
		{
			string resultMessage = "Failed to add new seminar. ";

			try
			{
				using (CVSUGADDBContext context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isSaved = false;

						try
						{
							seminar.Status = _seminarPending;
							context.Seminars.Add(seminar);
							isSaved = context.SaveChanges() > 0;
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

		public string AddSeminar(Seminar seminar)
		{
			string resultMessage = "Failed to add new seminar. ";

			try
			{
				using (CVSUGADDBContext context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isSaved = false;

						try
						{
							context.Seminars.Add(seminar);
							isSaved = context.SaveChanges() > 0;
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
	}
}
