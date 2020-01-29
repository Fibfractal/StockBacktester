using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GraphProject
{
    public class ImportFromSql : IImportData
    {
        private List<IDataPoint> _dataPoints;

        public ImportFromSql()
        {
            _dataPoints = new List<IDataPoint>();
        }

        public List<IDataPoint> ImportData()
        {
            return _dataPoints;
        }
    }
}
