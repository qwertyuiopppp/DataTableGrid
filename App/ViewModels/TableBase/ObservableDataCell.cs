using System.ComponentModel;
using System.Data;

namespace DataTableGrid.ViewModels.TableBase;

/// <summary>
/// Represents an observable cell in a data table, implementing the INotifyPropertyChanged interface.
/// </summary>
internal class ObservableDataCell : INotifyPropertyChanged
{
    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly DataRow row;
    private readonly DataColumn column;

    /// <summary>
    /// Initializes a new instance of the ObservableDataCell class.
    /// </summary>
    /// <param name="row">The DataRow containing the cell.</param>
    /// <param name="column">The DataColumn representing the cell's column.</param>
    public ObservableDataCell(DataRow row, DataColumn column)
    {
        this.column = column;
        this.row = row;
        row.Table.ColumnChanged += Table_ColumnChanged;
    }

    /// <summary>
    /// Handles the ColumnChanged event of the DataTable.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A DataColumnChangeEventArgs that contains the event data.</param>
    private void Table_ColumnChanged(object sender, DataColumnChangeEventArgs e)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
    }

    /// <summary>
    /// Gets a value indicating whether the cell is read-only.
    /// </summary>
    /// <returns>true if the cell is read-only; otherwise, false.</returns>
    public bool IsReadOnly => column.ReadOnly;

    /// <summary>
    /// Gets or sets the value of the cell.
    /// </summary>
    /// <value>The value of the cell.</value>
    public object? Value
    {
        get => row[column];
        set { if (row[column] != value) row[column] = value; }
    }
}