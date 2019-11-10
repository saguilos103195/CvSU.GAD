using CvSU.GAD.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSU.GAD.DataAccess.DatabaseConnectors
{
	public class ProgramConnector : DatabaseConnector
	{
		private DataAccessFactory _dataAccessFactory { get; }

		public ProgramConnector()
		{
			_dataAccessFactory = new DataAccessFactory();
		}

		public string AddProgram(Program program)
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
							context.Programs.Add(program);
							isSaved = context.SaveChanges() > 0;
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

		public List<Program> GetPrograms(int departmentId)
		{
			List<Program> programs = null;

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					programs = context.Programs.Where(p => p.DepartmentID == departmentId).ToList();
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

			return programs;
		}

		public Program GetProgram(int programId)
		{
			Program program = null;

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					program = context.Programs.FirstOrDefault(p => p.ProgramID == programId);
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

			return program;
		}

		public string UpdateProgram(Program program)
		{
			string resultMessage = "Failed to updated.";

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isUpdated = false;

						try
						{
							var dbProgram = context.Programs.FirstOrDefault(p => p.ProgramID == program.ProgramID);

							if (dbProgram != null)
							{
								dbProgram.DepartmentID = program.DepartmentID;
								dbProgram.Alias = program.Alias;
								dbProgram.IsArchived = program.IsArchived;
								dbProgram.Title = program.Title;

								isUpdated = context.SaveChanges() > 0;
							}
							else
							{
								resultMessage = "Program doesn't exist in the database.";
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

						if (isUpdated)
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

		public string ArchiveProgram(int programId, bool isArchive)
		{
			string resultMessage = "Failed to archive.";

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isUpdate = false; 

						try
						{
							var dbProgram = context.Programs.FirstOrDefault(p => p.ProgramID == programId);

							if (dbProgram != null)
							{
								dbProgram.IsArchived = isArchive;
								isUpdate = context.SaveChanges() > 0;
							}
							else
							{
								resultMessage = "Program doesn't exist in the database.";
							}
						}
						catch (Exception ex)
						{
							LogException(ex);
						}

						if (isUpdate)
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
