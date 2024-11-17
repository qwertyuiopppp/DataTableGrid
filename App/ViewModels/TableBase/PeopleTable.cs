using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

internal class PeopleTable : DataTable
{
    internal PeopleTable()
    {
        Columns.Add("Name");
        Columns.Add("Age");
        Columns.Add("Address");
        Rows.Add("John Doe", 42, "123 Main St");
        Rows.Add("Jane Doe", 39, "456 Elm St");
        Rows.Add("Sammy Doe", 13, "789 Oak St");
    }
}
