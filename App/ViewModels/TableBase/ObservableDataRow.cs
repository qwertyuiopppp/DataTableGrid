using System;
using System.Collections.Generic;
using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

public class ObservableDataRow
{
    private DataRow? row;
    private List<CellViewModel> rowCells = new List<CellViewModel>();
    public ObservableDataRow(DataRow row)
    {
        this.row = row;
        foreach (DataColumn column in row.Table.Columns)
        {
            CellViewModel cell = new CellViewModel(row, column);
            rowCells.Add(cell);
        }
    }
    public object? this[int index]
    {
        get => rowCells[index];
        private set => rowCells[index] = value as CellViewModel ?? throw new NullReferenceException("CellViewModel is null.");
    }
}