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
		private DataAccessFactory DataAccessFactory { get; set; }
		private static Logger _log = LogManager.GetCurrentClassLogger();

		public CollegeConnector()
		{
			DataAccessFactory = new DataAccessFactory();
		}

		public bool AddCollege(College newCollege)
		{
			try
			{
				using (CVSUGADDBContext ctx = DataAccessFactory.GetCVSUGADDBContext())
				{
					using (DbContextTransaction transaction = ctx.Database.BeginTransaction())
					{
						try
						{
							ctx.Colleges.Add(newCollege);
							int isSaved = ctx.SaveChanges();

							if (isSaved > 0)
							{
								transaction.Commit();
								return true;
							}
							else
							{
								transaction.Rollback();
								return false;
							}
							
						}
						catch (DbEntityValidationException ex)
						{
							transaction.Rollback();
							LogDbEntityValidationException(ex);
							return false;
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							LogException(ex);
							return false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
				return false;
			}
		}

		public List<College> GetColleges()
		{
			List<College> colleges = new List<College>();
			try
			{
				using (CVSUGADDBContext ctx = DataAccessFactory.GetCVSUGADDBContext())
				{
					colleges = ctx.Colleges.ToList();
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return colleges;
		}

	}
}
