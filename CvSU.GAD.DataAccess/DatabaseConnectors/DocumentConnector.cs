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
    public class DocumentConnector : DatabaseConnector
    {
        private DataAccessFactory _dataAccessFactory { get; }

        public DocumentConnector()
        {
            _dataAccessFactory = new DataAccessFactory();
        }

        public string AddDocument(Document newDocument)
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
							context.Documents.Add(newDocument);
							isSaved = context.SaveChanges() > 0;
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
							LogInfo($"New Document {newDocument.Title} is successfully saved.");
						}
						else
						{
							transaction.Rollback();
							LogInfo($"New Document {newDocument.Title} is failed to save.");
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

		public string ApproveDocument(int documentID)
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
							var approvedDocument = context.Documents.FirstOrDefault(d => d.DocumentID == documentID);
							approvedDocument.Status = "Approved";
							isSaved = context.SaveChanges() > 0;
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
						}
						else
						{
							transaction.Rollback();
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

		public string RejectDocument(int documentID)
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
							var rejectedDocument = context.Documents.FirstOrDefault(d => d.DocumentID == documentID);
							rejectedDocument.Status = "Rejected";
							isSaved = context.SaveChanges() > 0;
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
						}
						else
						{
							transaction.Rollback();
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

		public List<Document> GetAccomplishments()
        {
			List<Document> accomplishments = new List<Document>();

            try
            {
				using (CVSUGADDBContext ctx = _dataAccessFactory.GetCVSUGADDBContext())
				{
					accomplishments = ctx.Documents.Include(p => p.Account).Include(p => p.Account.Profiles).Where(p => p.Type == "Accomplishment").ToList();
					accomplishments.ForEach(p => p.DocumentFile = "");
				}
			}
            catch (Exception ex)
            {
				LogException(ex);
				throw ex;
			}

			return accomplishments;
        }

        public List<Document> GetProjects()
        {
            List<Document> projects = new List<Document>();

			try
			{
				using (CVSUGADDBContext ctx = _dataAccessFactory.GetCVSUGADDBContext())
				{
					projects = ctx.Documents.Include(p => p.Account).Include(p => p.Account.Profiles).Where(p => p.Type == "Extension").ToList();
					projects.ForEach(p => p.DocumentFile = "");
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
				throw ex;
			}

			return projects;
        }

		public string GetDocumentFile(int documentID)
        {
			string result = string.Empty;

			try
			{
				using (CVSUGADDBContext ctx = _dataAccessFactory.GetCVSUGADDBContext())
				{
					var project = ctx.Documents.FirstOrDefault(p => p.DocumentID == documentID);
					result = project.DocumentFile;
				}
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return result;
		}
    }
}
