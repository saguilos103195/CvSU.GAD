using CvSU.GAD.DataAccess.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CvSU.GAD.DataAccess.DatabaseContexts;
using System.Data.Entity.Validation;

namespace CvSU.GAD.DataAccess.DatabaseConnectors
{
	public class DepartmentConnector : DatabaseConnector
	{
		private DataAccessFactory _dataAccessFactory { get; }

		public DepartmentConnector()
		{
			_dataAccessFactory = new DataAccessFactory();
		}

		public string AddDepartment(Department newDepartment)
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
							var dbCollege = context.Colleges.Include(c => c.Departments).FirstOrDefault(c => c.CollegeID == newDepartment.CollegeID);

							if (dbCollege != null)
							{
								Department dbDepartment = dbCollege.Departments.FirstOrDefault(d => d.Title == newDepartment.Title);

								if (dbDepartment == null)
								{
									context.Departments.Add(newDepartment);
									isSaved = context.SaveChanges() > 0;
								}
								else
								{
									message = "Department on this college already exist in the database. ";
								}
							}
							else
							{
								message = "College doesn't exist in the database. ";
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
							message = "Please contact the support. ";
							LogException(ex);
						}

						if (isSaved)
						{
							transaction.Commit();
							message = string.Empty;
							LogInfo($"New Department {newDepartment.Title} is successfully saved.");
						}
						else
						{
							transaction.Rollback();
							LogInfo($"New Department {newDepartment.Title} is failed to save.");
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

		public List<Department> GetDepartments()
		{
			List<Department> departments = null;

			try
			{
				using (var context = _dataAccessFactory.GetCVSUGADDBContext())
				{
					departments = context.Departments.ToList();
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return departments;
		}
	}
}
