using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Styling;
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
        //Window window2 = new TableView(peopleList) { Title = "Please edit the data (View2)" };
        //Window window3 = new TableView(peopleTable) { Title = "Dynamically created Win 1" };
        //Window window4 = new TableView(peopleTable) { Title = "Dynamically created Win 2" };
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
        
        
         MenuItems =
        [
            new MenuItemViewModel
            {
                Header = "Theme",
                Items =
                [
                    new MenuItemViewModel
                    {
                        Header = "Auto",
                        //Command = FollowSystemThemeCommand
                    },
                    new MenuItemViewModel
                    {
                        Header = "Aquatic",
                        //Command = SelectThemeCommand,
                        //CommandParameter = SemiTheme.Aquatic
                    },
                    new MenuItemViewModel
                    {
                        Header = "Desert",
                        //Command = SelectThemeCommand,
                        //CommandParameter = SemiTheme.Desert
                    },
                    new MenuItemViewModel
                    {
                        Header = "Dusk",
                        //Command = SelectThemeCommand,
                        //CommandParameter = SemiTheme.Dusk
                    },
                    new MenuItemViewModel
                    {
                        Header = "NightSky",
                        //Command = SelectThemeCommand,
                        //CommandParameter = SemiTheme.NightSky
                    },
                ]
            },
            new MenuItemViewModel
            {
                Header = "Locale",
                Items =
                [
                    new MenuItemViewModel
                    {
                        Header = "简体中文",
                        //Command = SelectLocaleCommand,
                        //CommandParameter = new CultureInfo("zh-cn")
                    },
                    new MenuItemViewModel
                    {
                        Header = "English",
                        //Command = SelectLocaleCommand,
                        //CommandParameter = new CultureInfo("en-us")
                    },
                    new MenuItemViewModel
                    {
                        Header = "日本語",
                        //Command = SelectLocaleCommand,
                        //CommandParameter = new CultureInfo("ja-jp")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Українська",
                        //Command = SelectLocaleCommand,
                        //CommandParameter = new CultureInfo("uk-ua")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Русский",
                        //Command = SelectLocaleCommand,
                        //CommandParameter = new CultureInfo("ru-ru")
                    },
                    new MenuItemViewModel
                    {
                        Header = "繁體中文",
                        //Command = SelectLocaleCommand,
                        //CommandParameter = new CultureInfo("zh-tw")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Deutsch",
                        //Command = SelectLocaleCommand,
                        //CommandParameter = new CultureInfo("de-de")
                    },
                ]
            }
        ];
        
        
        
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

    public ObservableCollection<string> Address { get; set; } = new()
    {
        "1", "2", "3", "4", "5", "6", "7", "8", "9"
    };

    public IReadOnlyList<MenuItemViewModel> MenuItems { get; }
    
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
        dataGrid.Columns.Add(new DataGridTemplateColumn()
        {
            Header = "addr",
            CellTemplate = new FuncDataTemplate<ObservableDataRow>((row,_) =>
            {
                var combobox = new ComboBox()
                {
                    ItemsSource = Address,
                    Width = 100,
                    Height = 30
                };
    
                // 绑定到当前行的第 3 个单元格（索引 2）的值
                combobox.Bind(ComboBox.SelectedItemProperty, 
                    new Binding("[2].Value") { 
                        Source = row,  // 明确指定绑定源为当前行
                        Mode = BindingMode.TwoWay 
                    });

                var stackPanel = new StackPanel()
                {
                    Children = { combobox }
                };
                return stackPanel;
            }),
            IsReadOnly = false,
        });
        
        
        dataGrid.Columns.Add(new DataGridTemplateColumn()
        {
            Header = "bumen",
            CellTemplate = new FuncDataTemplate<ObservableDataRow>((row,_) =>
            {
                var textBlock = new TextBlock()
                {
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                };
                textBlock.Bind(TextBlock.TextProperty, new Binding("[3].Value")
                {
                    Source = row,
                    Mode = BindingMode.TwoWay
                });

                var menuFlyout = new MenuFlyout()
                {
                    ItemsSource = MenuItems
                };

                var button = new Button()
                {
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                    Margin =  new Thickness(0, 0, 8, 0),
                    Content = "编辑",
                    Flyout =  menuFlyout,
                    Styles =
                    {
                        new Style(s => s.OfType<MenuItem>())
                        {
                            Setters =
                            {
                                new Setter(MenuItem.HeaderProperty, new Binding("Header")),
                                new Setter(MenuItem.ItemsSourceProperty, new Binding("Items")),
                                new Setter(MenuItem.CommandProperty, new Binding("Command")),
                                new Setter(MenuItem.CommandParameterProperty, new Binding("CommandParameter"))
                            }
                        }
                    }
                };
                

                var grid = new Grid()
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Children =
                    {
                        textBlock,
                        button
                    }
                };
                
                
                return grid;
            }),
            IsReadOnly = false,
        });
        
        Grid.SetRow(dataGrid, 0);

        Task.Run(async () =>
        {
            while (true)
            {
                
                await Task.Delay(1000);
                var a  = (ObservableDataCell)people[0][2];
                Console.WriteLine(a?.Value?.ToString());
            }
        });
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

public class MenuItemViewModel
{
    public string? Header { get; set; }
    public ICommand? Command { get; set; }
    public object? CommandParameter { get; set; }
    public IList<MenuItemViewModel>? Items { get; set; }
}