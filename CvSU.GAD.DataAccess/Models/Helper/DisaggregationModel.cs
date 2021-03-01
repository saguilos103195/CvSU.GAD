using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSU.GAD.DataAccess.Models.Helper
{
	public class DisaggregationModel
	{
		public int DisaggregationID { get; set; }
		public int AccountID { get; set; }
		public string PositionTitle { get; set; }
		public string ProgramTitle { get; set; }
		public string Department { get; set; }
		public int MaleQuantity { get; set; }
		public int FemaleQuantity { get; set; }
		public string Semester { get; set; }
		public string SchoolYear { get; set; }
	}
}
