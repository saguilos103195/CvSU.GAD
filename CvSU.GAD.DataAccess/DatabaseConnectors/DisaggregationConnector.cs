using CvSU.GAD.DataAccess.DatabaseContexts;
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
	public class DisaggregationConnector : DatabaseConnector
	{
		private DataAccessFactory _dataAccessFactory { get; }

		public DisaggregationConnector()
		{
			_dataAccessFactory = new DataAccessFactory();
		}

		public string AddDisaggregation(Disaggregation newDisaggregation)
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
							var dbDisaggregation = context.Disaggregations
								.FirstOrDefault(d => d.IsStudent == newDisaggregation.IsStudent 
									&& d.ReferenceID == newDisaggregation.ReferenceID 
									&& d.SchoolYear == newDisaggregation.SchoolYear
									&& d.Semester == newDisaggregation.Semester);

							if (dbDisaggregation == null)
							{
								context.Disaggregations.Add(newDisaggregation);
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								message = "Disaggregation data already exist for this period. ";
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
							LogInfo($"Disaggregation successfully saved.");
						}
						else
						{
							transaction.Rollback();
							LogInfo($"Disaggregation failed to save.");
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

		public List<DisaggregationModel> GetStudentDisaggregation()
		{
			List<DisaggregationModel> disaggregations = new List<DisaggregationModel>();

			try
			{
				List<Disaggregation> dbDisaggregations = null;

				using (CVSUGADDBContext ctx = _dataAccessFactory.GetCVSUGADDBContext())
				{
					dbDisaggregations = ctx.Disaggregations.Include(d => d.Department.Programs).Where(d => d.IsStudent).ToList();

					if (dbDisaggregations != null && dbDisaggregations.Count > 0)
					{
						foreach (var dbDisaggregation in dbDisaggregations)
						{
							var dbProgram = ctx.Programs.FirstOrDefault(p => p.ProgramID == dbDisaggregation.ReferenceID);

							if (dbProgram != null)
							{
								disaggregations.Add(new DisaggregationModel
								{
									DisaggregationID = dbDisaggregation.DisaggregationID,
									Department = dbDisaggregation.Department.Alias,
									FemaleQuantity = dbDisaggregation.FemaleQuantity,
									MaleQuantity = dbDisaggregation.MaleQuantity,
									ProgramTitle = dbProgram.Title,
									SchoolYear = dbDisaggregation.SchoolYear,
									Semester = dbDisaggregation.Semester
								});
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return disaggregations;
		}

		public List<DisaggregationModel> GetFacultyDisaggregation()
		{
			List<DisaggregationModel> disaggregations = null;

			try
			{
				using (CVSUGADDBContext ctx = _dataAccessFactory.GetCVSUGADDBContext())
				{
					//disaggregation = ctx.Disaggregations.Include(d => d.Position).Where(d.Position.IsFaculty).ToList();
					var dbDisaggregations = ctx.Disaggregations.Include(d => d.Department).Where(d => d.IsStudent == false).ToList();

					if (dbDisaggregations != null && dbDisaggregations.Count > 0)
					{
						disaggregations = new List<DisaggregationModel>();

						foreach (var dbDisaggregation in dbDisaggregations)
						{
							var dbPosition = ctx.Positions.FirstOrDefault(p => p.PositionID == dbDisaggregation.ReferenceID);

							if (dbPosition != null)
							{
								if (dbPosition.IsFaculty)
								{
									disaggregations.Add(new DisaggregationModel
									{
										Department = dbDisaggregation.Department.Title,
										FemaleQuantity = dbDisaggregation.FemaleQuantity,
										MaleQuantity = dbDisaggregation.MaleQuantity,
										PositionTitle = dbPosition.Title,
										Semester = dbDisaggregation.Semester,
										SchoolYear = dbDisaggregation.SchoolYear
									});
								}
								else
								{

								}
							}
							else
							{
								Log($"Disaggregation id '{dbDisaggregation.DisaggregationID}' Position id '{dbDisaggregation.ReferenceID}' doesn't exist in the database.");
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return disaggregations;
		}

		public List<DisaggregationModel> GetNonFacultyDisaggregation()
		{
			List<DisaggregationModel> disaggregations = null;

			try
			{
				using (CVSUGADDBContext ctx = _dataAccessFactory.GetCVSUGADDBContext())
				{
					var dbDisaggregations = ctx.Disaggregations.Include(d => d.Department).Where(d => d.IsStudent == false).ToList();

					if (dbDisaggregations != null && dbDisaggregations.Count > 0)
					{
						disaggregations = new List<DisaggregationModel>();

						foreach (var dbDisaggregation in dbDisaggregations)
						{
							var dbPosition = ctx.Positions.FirstOrDefault(p => p.PositionID == dbDisaggregation.ReferenceID);

							if (dbPosition != null)
							{
								if (!dbPosition.IsFaculty)
								{
									disaggregations.Add(new DisaggregationModel
									{
										Department = dbDisaggregation.Department.Title,
										FemaleQuantity = dbDisaggregation.FemaleQuantity,
										MaleQuantity = dbDisaggregation.MaleQuantity,
										PositionTitle = dbPosition.Title,
										Semester = dbDisaggregation.Semester,
										SchoolYear = dbDisaggregation.SchoolYear
									});
								}
								else
								{

								}
							}
							else
							{
								Log($"Disaggregation id '{dbDisaggregation.DisaggregationID}' Position id '{dbDisaggregation.ReferenceID}' doesn't exist in the database.");
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return disaggregations;
		}

		public string DeleteDisaggregation(int disaggregationID)
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
							Disaggregation dbDisaggregation = context.Disaggregations.FirstOrDefault(d => d.DisaggregationID == disaggregationID);

							if (dbDisaggregation != null)
							{
								context.Disaggregations.Remove(dbDisaggregation);
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								message += "Disaggregation data doesn't exist. ";
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
							LogInfo($"Disaggregation successfully deleted.");
						}
						else
						{
							transaction.Rollback();
							LogInfo($"Disaggregation failed to delete.");
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
