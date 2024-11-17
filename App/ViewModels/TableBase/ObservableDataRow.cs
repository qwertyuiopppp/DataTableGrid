using System.Collections.Generic;
using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

/// <summary>
/// Represents an observable row of data, wrapping a DataRow with ObservableDataCell objects.
/// </summary>
public class ObservableDataRow
{
    private List<ObservableDataCell> rowCells = new();

    /// <summary>
    /// Initializes a new instance of the ObservableDataRow class.
    /// </summary>
    /// <param name="row">The DataRow to be wrapped by this ObservableDataRow.</param>
    public ObservableDataRow(DataRow row)
    {
        foreach (DataColumn column in row.Table.Columns)
        {
            ObservableDataCell cell = new ObservableDataCell(row, column);
            rowCells.Add(cell);
        }
    }

    /// <summary>
    /// Gets the ObservableDataCell at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the cell to retrieve.</param>
    /// <returns>The ObservableDataCell at the specified index, or null if the index is out of range.</returns>
    public object? this[int index] => rowCells[index];
}