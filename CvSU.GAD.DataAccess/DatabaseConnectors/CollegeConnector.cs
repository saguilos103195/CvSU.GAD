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
	public class CollegeConnector : DatabaseConnector
	{
		private DataAccessFactory _dataAccessFactory { get; }

		public CollegeConnector()
		{
			_dataAccessFactory = new DataAccessFactory();
		}

		public string AddCollege(College newCollege)
		{
			string message = "Failed to save.";

			try
			{
				using (CVSUGADDBContext context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (DbContextTransaction transaction = context.Database.BeginTransaction())
					{
						bool isSaved = false;

						try
						{
							College dbCollege = context.Colleges.FirstOrDefault(d => d.Title == newCollege.Title);

							if (dbCollege == null)
							{
								context.Colleges.Add(newCollege);
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								message += "College already exist in the database. ";
							}
							
						}
						catch (DbEntityValidationException ex)
						{
							transaction.Rollback();
							LogDbEntityValidationException(ex);
							message = "Please contact the support. ";
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							LogException(ex);
							message = "Please contact the support. ";
						}

						if (isSaved)
						{
							transaction.Commit();
							message = string.Empty;
							LogInfo($"New College {newCollege.Title} is successfully saved.");
						}
						else
						{
							transaction.Rollback();
							LogInfo($"New College {newCollege.Title} is failed to save.");
							message = "Please contact the support. ";
						}

					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
				message = "Please contact the support. ";
			}

			return message;
		}

		public List<College> GetColleges()
		{
			List<College> colleges = new List<College>();
			try
			{
				using (CVSUGADDBContext ctx = _dataAccessFactory.GetCVSUGADDBContext())
				{
					colleges = ctx.Colleges.Where(c => c.CollegeID != 0).ToList();
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return colleges;
		}

		public string ArchiveCollege(int collegeID)
		{
			string message = "Failed to save.";
			try
			{
				using (CVSUGADDBContext context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					College collegeToArchive = context.Colleges.FirstOrDefault(c => c.CollegeID == collegeID);

					using (DbContextTransaction transaction = context.Database.BeginTransaction())
					{
						bool isSaved = false;

						try
						{
							if (collegeToArchive != null)
							{
								collegeToArchive.IsArchived = true;
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								message = "College to Archive does not exist.";
							}
						}
						catch (DbEntityValidationException ex)
						{
							transaction.Rollback();
							LogDbEntityValidationException(ex);
							message = "Please contact the support. ";
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							LogException(ex);
							message = "Please contact the support. ";
						}

						if (isSaved)
						{
							transaction.Commit();
							message = string.Empty;
							LogInfo($"{collegeToArchive.Title} is successfully archived.");
						}
						else
						{
							transaction.Rollback();
							LogInfo($"{collegeToArchive.Title} is failed to archive.");
							message = "Please contact the support. ";
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
				message = "Please contact the support. ";
			}

			return message;
		}

		public string RetrieveCollege(int collegeID)
		{
			string message = "Failed to save.";
			try
			{
				using (CVSUGADDBContext context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					College collegeToArchive = context.Colleges.FirstOrDefault(c => c.CollegeID == collegeID);

					using (DbContextTransaction transaction = context.Database.BeginTransaction())
					{
						bool isSaved = false;

						try
						{
							if (collegeToArchive != null)
							{
								collegeToArchive.IsArchived = false;
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								message = "College to Retrieve does not exist.";
							}
						}
						catch (DbEntityValidationException ex)
						{
							transaction.Rollback();
							LogDbEntityValidationException(ex);
							message = "Please contact the support. ";
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							LogException(ex);
							message = "Please contact the support. ";
						}

						if (isSaved)
						{
							transaction.Commit();
							message = string.Empty;
							LogInfo($"{collegeToArchive.Title} is successfully retrieved.");
						}
						else
						{
							transaction.Rollback();
							LogInfo($"{collegeToArchive.Title} is failed to retrieve.");
							message = "Please contact the support. ";
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
				message = "Please contact the support. ";
			}

			return message;
		}

		public string UpdateCollege(College updatedCollege)
		{
			string message = "Failed to save.";
			try
			{
				using (CVSUGADDBContext context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					College college = context.Colleges.FirstOrDefault(c => c.CollegeID == updatedCollege.CollegeID);

					using (DbContextTransaction transaction = context.Database.BeginTransaction())
					{
						bool isSaved = false;

						try
						{
							if (college != null)
							{
								college.Title = updatedCollege.Title;
								college.Alias = updatedCollege.Alias;
								college.IsMain = updatedCollege.IsMain;
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								message = "College to Update does not exist.";
							}
						}
						catch (DbEntityValidationException ex)
						{
							transaction.Rollback();
							LogDbEntityValidationException(ex);
							message = "Please contact the support. ";
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							LogException(ex);
							message = "Please contact the support. ";
						}

						if (isSaved)
						{
							transaction.Commit();
							message = string.Empty;
							LogInfo($"{updatedCollege.Title} is successfully retrieved.");
						}
						else
						{
							transaction.Rollback();
							LogInfo($"{updatedCollege.Title} is failed to retrieve.");
							message = "Please contact the support. ";
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
				message = "Please contact the support. ";
			}

			return message;
		}

	}
}
