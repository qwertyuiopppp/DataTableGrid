using System.ComponentModel;
using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

internal class ObservableDataCell : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly DataRow row;
    private readonly DataColumn column;
    public ObservableDataCell(DataRow row, DataColumn column)
    {
        this.column = column;
        this.row = row;
        row.Table.ColumnChanged += Table_ColumnChanged;
    }
    private void Table_ColumnChanged(object sender, DataColumnChangeEventArgs e)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
    }
    public bool IsReadOnly => column.ReadOnly;
    public object? Value
    {
        get => row[column];
        set { if (row[column] != value) row[column] = value; }
    }
}