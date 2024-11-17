using System.Collections;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Media;
using DataTableGrid.ViewModels.TableBase;

namespace DataTableGrid.Views;

public static class TableViewLauncher
{
    public static void Run()
    {
        PeopleTable peopleTable = new();
        ObservableDataRowCollection<ObservableDataRow> peopleList = new(peopleTable, row => new ObservableDataRow(row));
        Window window1 = new TableView(peopleList) { Title = "Please edit the data (View1)" };
        Window window2 = new TableView(peopleList) { Title = "Please edit the data (View2)" };
    }

}

internal partial class TableView : Window
{
    internal TableView(ObservableDataRowCollection<ObservableDataRow> people)
    {
        InitializeComponent();
        Grid grid = new();
        grid.RowDefinitions = new RowDefinitions("*, 10, Auto");


        DataGrid dataGrid = SetupGrid(people);
        grid.Children.Add(dataGrid);

        TextBlock info = new() { Text = GetInfo(), Margin = new Thickness(5) };
        grid.Children.Add(info);
        Grid.SetRow(info, 2);


        Content = grid;
        Width = 375; Height = 350;
        Show();

    }
    private DataGrid SetupGrid(ObservableDataRowCollection<ObservableDataRow> people)
    {
        DataGrid dataGrid = new()
        {
            ItemsSource = people,
            AutoGenerateColumns = false,
        };
        //Two way binding works as expected for the following two bindings 
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") });
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Age", Binding = new Binding("Age") });

        //For the following two bindings, the texboxes updates the underlying data source, but the texboxes do not respond to Property changed events.
        //In addition, I have to set IsReadOnly to false to enable editing.
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("[0]"), IsReadOnly = false, Foreground = Brushes.Red });
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Age", Binding = new Binding("[1]"), IsReadOnly = false, Foreground = Brushes.Red });
        Grid.SetRow(dataGrid, 0);
        return dataGrid;
    }

    private string GetInfo()
    {
        string s = "";
        s += "This is one view of a DataTable in a Grid.\n ";
        s += "There is a twin view that shares the same DataTable.\n";
        s += "If you edit any of the cells, the corresponding \n";
        s += "black cell in the other view will also be updated.\n";
        s += "However, red the cells do not respond to\n";
        s += "PropertyChanged events.\n";
        s += "The red cells use index bindings, I.e \"[0]\" and \"[1]\".\n";
        s += "The black cells use named bindings,\n";
        s += "I.e., \"Name\" and \"Age\".\n";
        s += "Please check TableView.axaml.cs and\nObservableDataRow.cs\n";
        return s;
    }
}
