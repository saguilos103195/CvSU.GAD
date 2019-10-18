using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSU.GAD.DataAccess.DatabaseConnectors
{
	public class DatabaseConnector
	{
		private static Logger _log = LogManager.GetCurrentClassLogger();

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
	}
}
