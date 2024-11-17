using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

internal class PeopleTable : DataTable
{
    internal PeopleTable()
    {
        Columns.Add("Name");
        Columns.Add("Age");
        Rows.Add("John Doe", 42);
        Rows.Add("Jane Doe", 39);
        Rows.Add("Sammy Doe", 13);
    }
}
