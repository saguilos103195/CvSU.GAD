using CvSU.GAD.DataAccess.DatabaseContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSU.GAD.DataAccess
{
	internal class DataAccessFactory
	{
		public CVSUGADDBContext GetCVSUGADDBContext()
		{
			return new CVSUGADDBContext();
		}
	}
}
