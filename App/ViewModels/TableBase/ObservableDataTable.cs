using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

/// <summary>
/// Represents an observable wrapper around a DataTable, implementing IEnumerable<ObservableDataRow>.
/// </summary>
public class ObservableDataTable : IEnumerable<ObservableDataRow>
{
    /// <summary>
    /// Gets the ObservableDataRow at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the ObservableDataRow to get.</param>
    /// <returns>The ObservableDataRow at the specified index.</returns>
    public ObservableDataRow this[int index] => observableRows[index];

    private readonly DataTable table;
    private readonly List<ObservableDataRow> observableRows = [];

    /// <summary>
    /// Initializes a new instance of the ObservableDataTable class.
    /// </summary>
    /// <param name="table">The DataTable to wrap with observable functionality.</param>
    public ObservableDataTable(DataTable table)
    {
        this.table = table;
        foreach (DataRow row in table.Rows)
        {
            ObservableDataRow observableDataRow = new(row);
            observableRows.Add(observableDataRow);
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the ObservableDataTable.
    /// </summary>
    /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Returns an enumerator that iterates through the ObservableDataTable.
    /// </summary>
    /// <returns>An IEnumerator<ObservableDataRow> that can be used to iterate through the collection.</returns>
    public IEnumerator<ObservableDataRow> GetEnumerator()
    {
        foreach (ObservableDataRow row in observableRows)
        {
            yield return row;
        }
    }

    /// <summary>
    /// Gets the collection of columns for the ObservableDataTable.
    /// </summary>
    /// <returns>A DataColumnCollection containing the columns of the table.</returns>
    public DataColumnCollection Columns => table.Columns;
}