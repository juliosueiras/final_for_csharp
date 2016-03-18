using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GroupProject
{
    class TableFactory
    {
        public static DataTable makeTable()
        {

            DataTable table = new DataTable();

            table.Columns.Add(NewColumn("SkillID", "System.Int32"));
            table.Columns.Add(NewColumn("SkillName", "System.String"));
            table.Columns.Add(NewColumn("SkillLevel", "System.String"));
            table.Columns.Add(NewColumn("YearsExperience", "System.Int32"));
            table.Columns.Add(NewColumn("Description", "System.String"));

            return table;
        }

        public static DataColumn NewColumn(String name, String type) {

            DataColumn dc = new DataColumn();
            dc.ColumnName = name;
            dc.DataType = Type.GetType(type);
            return dc;

        }
    }
}
