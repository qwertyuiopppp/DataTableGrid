using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

internal class PeopleTable : DataTable
{
    internal PeopleTable()
    {
        Columns.Add("Name");
        Columns.Add("Age");
        Columns.Add("Address");
        Columns.Add("bumen");
        Rows.Add("John Doe", 42, "123 Main St","部门1");
        Rows.Add("Jane Doe", 39, "456 Elm St","部门2");
        Rows.Add("Sammy Doe", 13, "789 Oak St","部门3");
    }
}
