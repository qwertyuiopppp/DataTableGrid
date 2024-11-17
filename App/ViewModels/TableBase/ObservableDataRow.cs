using System;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;

namespace DataTableGrid.ViewModels.TableBase;

public class ObservableDataRow : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private DataRow? row;
    public DataRow Row
    {
        get => row ?? throw new NoNullAllowedException("row is null");
        private set => row = value;
    }
    // When binding DataGrid cells directly to this indexed property, the DataGrid does not respond to ProprtyChanged Events
    // In addition I need to set IsReadOnly to false explicitly to enable editing
    public object this[int index]
    {
        get => Row[index]; // called by DataGrid during setup
        set => Row[index] = value;
    }

    //When binding DataGrid cells to thiese two named properties, the DataGrid responds correctly to PropertyChanged Events
    //In addition, the DataGrid, calls IList.IsReadonly and sets IsReadOnly automatically
    public string Name
    {
        get => Row[0].ToString() ?? "No Name"; // called by DataGrid during setup
        set => Row[0] = value;
    }
    public string Age
    {
        get => Row[1].ToString() ?? "-1"; // called by DataGrid during setup
        set => Row[1] = value;
    }
    #region called during setup before connecting to ItemsSource
    public ObservableDataRow()
    {
        throw new NotImplementedException("You must call the constructor with a DataRow as a parameter.");
    }
    public ObservableDataRow(DataRow row)
    {
        this.row = row;
        row.Table.ColumnChanged += Table_ColumnChanged;
    }
    #endregion
    #region NotUsedByDataGrid
    private void Table_ColumnChanged(object sender, DataColumnChangeEventArgs e)
    {
        if (e.Row == row && e.Column != null) // e.Column is null when the row is deleted
        {
            string columnName = e.Column.ColumnName;
            int ordinal = e.Column.Ordinal;
            OnPropertyChanged($"{columnName}");
            OnPropertyChanged($"[{columnName}]");
            OnPropertyChanged($"[{ordinal}]");
        }
    }
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public bool IsReadOnly => false;
    #endregion

}