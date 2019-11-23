using CvSU.GAD.DataAccess.DatabaseContexts;
using CvSU.GAD.DataAccess.Models;
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
							//Disaggregation dbDisaggregation = context.Disaggregations.FirstOrDefault(d => (
							//((d.
							//PositionID == 0 && d.ProgramID == newDisaggregation.ProgramID) || 
							//(d.ProgramID == 0 && d.PositionID == newDisaggregation.PositionID)) && 
							//d.Semester == newDisaggregation.Semester && d.SchoolYear == newDisaggregation.SchoolYear));

							//if (dbDisaggregation == null)
							//{
							//	context.Disaggregations.Add(newDisaggregation);
							//	isSaved = context.SaveChanges() > 0;
							//}
							//else
							//{
							//	message = "Disaggregation data already exist for this period. ";
							//}

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

		public List<Disaggregation> GetStudentDisaggregation()
		{
			List<Disaggregation> disaggregation = new List<Disaggregation>();

			try
			{
				//using (CVSUGADDBContext ctx = _dataAccessFactory.GetCVSUGADDBContext())
				//{
				//	disaggregation = ctx.Disaggregations.Include(d => d.Program).Where(d => d.PositionID == 0).ToList();
				//}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return disaggregation;
		}

		public List<Disaggregation> GetFacultyDisaggregation()
		{
			List<Disaggregation> disaggregation = new List<Disaggregation>();

			try
			{
				//using (CVSUGADDBContext ctx = _dataAccessFactory.GetCVSUGADDBContext())
				//{
				//	disaggregation = ctx.Disaggregations.Include(d => d.Position).Where(d => d.ProgramID == 0 && d.Position.IsFaculty).ToList();
				//}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return disaggregation;
		}

		public List<Disaggregation> GetNonFacultyDisaggregation()
		{
			List<Disaggregation> disaggregation = new List<Disaggregation>();

			try
			{
				//using (CVSUGADDBContext ctx = _dataAccessFactory.GetCVSUGADDBContext())
				//{
				//	disaggregation = ctx.Disaggregations.Include(d => d.Position).Where(d => d.ProgramID == 0 && !d.Position.IsFaculty).ToList();
				//}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return disaggregation;
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
