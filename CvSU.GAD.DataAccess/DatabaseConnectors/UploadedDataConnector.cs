using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSU.GAD.DataAccess.DatabaseConnectors
{
    public class UploadedDataConnector
    {
        private DataAccessFactory _dataAccessFactory { get; }
        public UploadedDataConnector()
        {
            _dataAccessFactory = new DataAccessFactory();
        }

        public bool SaveDataInformation(string fileLocation, int accountId)
        {
            try
            {
                using (var context = _dataAccessFactory.GetCVSUGADDBContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        



                    }
                }







                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        


        }


    }
}
