using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

public class ObservableDataRowCollection : IEnumerable<ObservableDataRow>
{
    public ObservableDataRow this[int index] => observableRows[index];
    private readonly DataTable table;
    private readonly List<ObservableDataRow> observableRows = new();
    //private readonly Func<DataRow, T> rowFactory;

    public ObservableDataRowCollection(DataTable table)
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
}
