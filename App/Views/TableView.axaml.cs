using System.Data;
using Avalonia.Controls;
using Avalonia.Data;
using DataTableGrid.ViewModels.TableBase;

namespace DataTableGrid.Views;

/// <summary>
/// Provides methods for launching and managing TableView instances.
/// </summary>
public static class TableViewLauncher
{
    /// <summary>
    /// Initializes and displays multiple TableView windows with different data sources.
    /// </summary>
    /// <remarks>
    /// This method creates four windows:
    /// - Two windows sharing an ObservableDataTable source.
    /// - Two windows using a PeopleTable source.
    /// Each window is initialized with a unique title for identification.
    /// </remarks>
    public static void Run()
    {
        PeopleTable peopleTable = new();
        ObservableDataTable peopleList = new(peopleTable);//, row => new ObservableDataRow(row));
        Window window1 = new TableView(peopleList) { Title = "Please edit the data (View1)" };
        Window window2 = new TableView(peopleList) { Title = "Please edit the data (View2)" };
        Window window3 = new TableView(peopleTable) { Title = "Dynamically created Win 1" };
        Window window4 = new TableView(peopleTable) { Title = "Dynamically created Win 2" };
    }
}

internal partial class TableView : Window
{
    /// <summary>
    /// Initializes a new instance of the TableView class using a DataTable as the data source.
    /// </summary>
    /// <param name="people">The DataTable containing the people data to be displayed.</param>
    internal TableView(DataTable people)
    {
        InitializeComponent();
        DataTableGridView dataTableGridView = new DataTableGridView(people);
        Content = dataTableGridView;
        Width = 375; Height = 350;
        Show();
    }

    /// <summary>
    /// Initializes a new instance of the TableView class using an ObservableDataTable as the data source.
    /// </summary>
    /// <param name="people">The ObservableDataTable containing the people data to be displayed.</param>
    internal TableView(ObservableDataTable people)
    {
        InitializeComponent();
        Grid grid = new();
        grid.RowDefinitions = new RowDefinitions("*, 10");


        DataGrid dataGrid = SetupGrid(people);
        grid.Children.Add(dataGrid);

        // grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });   
        // TextBlock info = new() { Text = GetInfo(), Margin = new Thickness(5) };
        // grid.Children.Add(info);
        // Grid.SetRow(info, 2);


        Content = grid;
        Width = 375; Height = 350;
        Show();

    }

    /// <summary>
    /// Sets up and configures a DataGrid for displaying people data.
    /// </summary>
    /// <param name="people">The ObservableDataTable containing the people data to be displayed in the DataGrid.</param>
    /// <returns>A configured DataGrid object ready for display.</returns>
    private DataGrid SetupGrid(ObservableDataTable people)
    {
        DataGrid dataGrid = new()
        {
            ItemsSource = people,
            DataContext = people,
            AutoGenerateColumns = false,
        };

        dataGrid.Columns.Add(new DataGridTextColumn
        {
            Header = "Name",
            Binding = new Binding("[0].Value"),
            IsReadOnly = false,
        });
        dataGrid.Columns.Add(new DataGridTextColumn
        {
            Header = "Age",
            Binding = new Binding("[1].Value"),
            IsReadOnly = false,
        });
        Grid.SetRow(dataGrid, 0);
        return dataGrid;
    }

    /// <summary>
    /// Generates an informational string about the TableView and its functionality.
    /// </summary>
    /// <returns>A string containing detailed information about the TableView's features and behavior.</returns>
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