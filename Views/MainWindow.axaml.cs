using Avalonia.Controls;
using DataTableGrid.Models;
using DataTableGrid.ViewModels;

namespace DataTableGrid.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        Width = 400;
        Height=600;
        //DataContext = this;
        InitializeComponent();
        People people = new People();  
        ListSource.DataContext = people;
        DataTableGridViewModel dataTableGridViewModel = new DataTableGridViewModel(people.PeopleTable); 
        TableSource.DataContext = dataTableGridViewModel;
        //var items = dataTableGridViewModel.GetRows();
//        TableSource.ItemsSource = items;
    }
}

