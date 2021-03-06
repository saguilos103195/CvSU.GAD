﻿using CvSU.GAD.DataAccess.DatabaseContexts;
using CvSU.GAD.DataAccess.Models;
using CvSU.GAD.DataAccess.Models.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

		public string UpdateSeminar(Seminar seminar)
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
							var dbSeminar = context.Seminars.FirstOrDefault(s => s.SeminarID == seminar.SeminarID);

							if (dbSeminar != null)
							{
								int count = 0;

								if (dbSeminar.Name != seminar.Name)
								{
									dbSeminar.Name = seminar.Name;
									count++;
								}

								if (dbSeminar.Year != seminar.Year)
								{
									dbSeminar.Year = seminar.Year;
									count++;
								}

								if (count > 0)
								{
									dbSeminar.Status = _seminarPending;
									isSaved = context.SaveChanges() > 0;
								}
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
		 
		public List<SeminarModel> GetSeminars()
		{
			List<SeminarModel> seminars = null;

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					seminars = context.Seminars.Include(s => s.Profile).Select(s => 
					new SeminarModel
					{
						Name = s.Name,
						ProfileName = s.Profile.Firstname + " " + s.Profile.Middlename.Substring(0, 1) + ". " + s.Profile.Lastname,
						SeminarID = s.SeminarID,
						Status = s.Status,
						Year = s.Year
					})
					.ToList();
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return seminars;
		}

		public string ApproveSeminar(int seminarId)
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
							var dbSeminar = context.Seminars.FirstOrDefault(s => s.SeminarID == seminarId);

							if (dbSeminar != null)
							{
								dbSeminar.Status = _seminarApproved;
								isSaved = context.SaveChanges() > 0;
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

		public string RejectSeminar(int seminarId)
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
							var dbSeminar = context.Seminars.FirstOrDefault(s => s.SeminarID == seminarId);

							if (dbSeminar != null)
							{
								dbSeminar.Status = _seminarRejected;
								isSaved = context.SaveChanges() > 0;
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

		public string CancelSeminar(int seminarId)
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
							var dbSeminar = context.Seminars.FirstOrDefault(s => s.SeminarID == seminarId);

							if (dbSeminar != null)
							{
								dbSeminar.Status = _seminarCancelled;
								isSaved = context.SaveChanges() > 0;
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
	}
}
