using System;
using System.ComponentModel;
using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

public class CellViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private DataRow row;
    private DataColumn column;
    public CellViewModel(DataRow row, DataColumn column)
    {
        this.column = column;
        this.row = row;
        row.Table.ColumnChanged += Table_ColumnChanged;
    }

    private void Table_ColumnChanged(object sender, DataColumnChangeEventArgs e)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
    }

    public bool IsReadOnly => false;
    public object? Value
    {
        get
        {
            var v = row[column];
            return v;
        }
        set
        {
            if (row[column] == value) return; // No change, no need to notify
            row[column] = value;
        }
    }


}
