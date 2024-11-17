using System;
using System.Data;
using Avalonia.Controls;
using Avalonia.Data;
using DataTableGrid.ViewModels.TableBase;

namespace DataTableGrid.Views;

public class DataTableGridView : ContentControl
{
    readonly ObservableDataTable observableDataTable;
    readonly DataGrid dataGrid;
    public DataTableGridView(DataTable dataTable)
    {
        observableDataTable = new ObservableDataTable(dataTable);
        DataContext = observableDataTable;
        dataGrid = new();
        dataGrid.ItemsSource = observableDataTable;
        BuildDataGridColumns();
        Content = dataGrid;
    }

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
