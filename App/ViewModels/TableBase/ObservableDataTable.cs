using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

public class ObservableDataTable : IEnumerable<ObservableDataRow>
{
    public ObservableDataRow this[int index] => observableRows[index];
    private readonly DataTable table;
    private readonly List<ObservableDataRow> observableRows = [];

    public ObservableDataTable(DataTable table)
    {
        this.table = table;
        foreach (DataRow row in table.Rows)
        {
            ObservableDataRow observableDataRow = new(row);
            observableRows.Add(observableDataRow);
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public IEnumerator<ObservableDataRow> GetEnumerator()
    {
        foreach (ObservableDataRow row in observableRows)
        {
            yield return row;
        }
    }
    public DataColumnCollection Columns => table.Columns;
}
