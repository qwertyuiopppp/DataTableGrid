using System;
using System.Data;
using Avalonia.Controls;
using Avalonia.Data;
using DataTableGrid.ViewModels.TableBase;

namespace DataTableGrid.Views;

/// <summary>
/// Represents a custom control for displaying and editing data in a grid format.
/// </summary>
public class DataTableGridView : ContentControl
{
    readonly ObservableDataTable observableDataTable;
    readonly DataGrid dataGrid;

    /// <summary>
    /// Initializes a new instance of the DataTableGridView class.
    /// </summary>
    /// <param name="dataTable">The DataTable containing the data to be displayed in the grid.</param>
    public DataTableGridView(DataTable dataTable)
    {
        observableDataTable = new ObservableDataTable(dataTable);
        DataContext = observableDataTable;
        dataGrid = new();
        dataGrid.ItemsSource = observableDataTable;
        BuildDataGridColumns();
        Content = dataGrid;
    }

    /// <summary>
    /// Builds and populates the columns of the DataGrid based on the structure of the ObservableDataTable.
    /// </summary>
    private void BuildDataGridColumns()
    {
        dataGrid.Columns.Clear();
        foreach (DataColumn column in observableDataTable.Columns)
        {
            DataGridTextColumn textColumn = new()
            {
                Header = column.Caption ?? column.ColumnName,
                Binding = new Binding($"[{column.Ordinal}].Value"),
                IsReadOnly = false,
            };
            dataGrid.Columns.Add(textColumn);
        }
    }
}