using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataTableGrid.ViewModels;

public class DataTableGridViewModel
{
    private readonly DataTable _table;
    public DataTableGridViewModel(DataTable table)
    {
        _table = table;
    }
    public DataRowWrapper GetRow(int rowIndex)
    {
        var items1 = _table.Rows.Cast<DataRow>();
        var items2 = items1.Select(row => new DataRowWrapper(row));
        var items3 = items2.ToList();

        return new DataRowWrapper(_table.Rows[rowIndex]);
    }

    
    public List<DataRowWrapper> GetRows()
    {
        List<DataRowWrapper> items = _table.Rows.Cast<DataRow>()
            .Select(row => new DataRowWrapper(row))
            .ToList();
        return items;
    }

    public List<DataRowWrapper> Rows => GetRows();
}

