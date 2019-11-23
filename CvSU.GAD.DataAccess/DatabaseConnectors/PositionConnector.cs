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
	public class PositionConnector : DatabaseConnector
	{
		private DataAccessFactory _dataAccessFactory { get; }

		public PositionConnector()
		{
			_dataAccessFactory = new DataAccessFactory();
		}

		public string AddPosition(Position newPosition)
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
							Position dbPosition = context.Positions.FirstOrDefault(p => p.Title == newPosition.Title);

							if (dbPosition == null)
							{
								context.Positions.Add(newPosition);
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								message += "Position already exist in the database. ";
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
							LogInfo($"New Position {newPosition.Title} is successfully saved.");
						}
						else
						{
							transaction.Rollback();
							LogInfo($"New Position {newPosition.Title} is failed to save.");
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

		public List<Position> GetPositions()
		{
			List<Position> positions = new List<Position>();
			try
			{
				using (CVSUGADDBContext ctx = _dataAccessFactory.GetCVSUGADDBContext())
				{
					positions = ctx.Positions.Where(p => p.PositionID != 0).ToList();
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return positions;
		}

		public string ArchivePosition(int positionID, bool isArchive)
		{
			string message = "Failed to save.";
			try
			{
				using (CVSUGADDBContext context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					Position positionToArchive = context.Positions.FirstOrDefault(p => p.PositionID == positionID);

					using (DbContextTransaction transaction = context.Database.BeginTransaction())
					{
						bool isSaved = false;

						try
						{
							if (positionToArchive != null)
							{
								positionToArchive.IsArchived = isArchive;
								isSaved = context.SaveChanges() > 0;
							}
							else
							{
								message = "Position to Archive does not exist.";
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
							LogInfo($"{positionToArchive.Title} is successfully archived.");
						}
						else
						{
							transaction.Rollback();
							LogInfo($"{positionToArchive.Title} is failed to archive.");
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

		public string UpdatePosition(Position position)
		{
			string resultMessage = "Failed to updated. ";

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						bool isUpdated = false;

						try
						{
							var dbPosition = context.Positions.FirstOrDefault(p => p.PositionID == position.PositionID);

							if (dbPosition != null)
							{
								dbPosition.Title = position.Title;
								dbPosition.IsFaculty = position.IsFaculty;
								dbPosition.IsArchived = position.IsArchived;

								isUpdated = context.SaveChanges() > 0;
							}
							else
							{
								resultMessage = "Position doesn't exist on the databaes.";
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
			catch (Exception ex)
			{
				LogException(ex);
				resultMessage = "Please contact the support. ";
			}

			return resultMessage;
		}
	}
}
