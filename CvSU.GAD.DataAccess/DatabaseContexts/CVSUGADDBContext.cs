using CvSU.GAD.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSU.GAD.DataAccess.DatabaseContexts
{
	class CVSUGADDBContext : CVSUGADEntities
	{
		public CVSUGADDBContext()
		{
			Configuration.AutoDetectChangesEnabled = true;
			Configuration.LazyLoadingEnabled = false;
			Configuration.EnsureTransactionsForFunctionsAndCommands = true;
		}
	}
}
