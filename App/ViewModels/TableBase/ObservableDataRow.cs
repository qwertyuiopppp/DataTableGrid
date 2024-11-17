using System;
using System.Collections.Generic;
using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

public class ObservableDataRow
{
    private List<ObservableDataCell> rowCells = new();
    public ObservableDataRow(DataRow row)
    {
        foreach (DataColumn column in row.Table.Columns)
        {
            ObservableDataCell cell = new ObservableDataCell(row, column);
            rowCells.Add(cell);
        }
    }
    public object? this[int index] => rowCells[index];
}