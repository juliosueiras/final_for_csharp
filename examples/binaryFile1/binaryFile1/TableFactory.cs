using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace binaryFile1
{
    class TableFactory
    {
        public static DataTable makeTable()
        {
            DataTable table = new DataTable();
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "AccountNumber";
            dc1.DataType = Type.GetType("System.Int32");
            table.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "FirstName";
            dc2.DataType = Type.GetType("System.String");
            table.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn();
            dc3.ColumnName = "LastName";
            dc3.DataType = Type.GetType("System.String");
            table.Columns.Add(dc3);

            DataColumn dc4 = new DataColumn();
            dc4.ColumnName = "Balance";
            dc4.DataType = Type.GetType("System.String");
            table.Columns.Add(dc4);

            return table;        }
    }
}
