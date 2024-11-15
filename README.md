# DataTableGrid

DataTableGrid is a C# project that demonstrates the implementation of a DataGrid control using Avalonia UI, bound to an observable collection of data rows. This project showcases different binding approaches and their effects on the DataGrid's behavior.

## Project Overview

The DataTableGrid project consists of the following main components:

1. `ObservableDataRow`: A class that wraps a DataRow and implements INotifyPropertyChanged for reactive updates.
2. `ObservableDataRowCollection`: A generic collection that manages ObservableDataRow instances.
3. `PeopleTable`: A custom DataTable for storing people's information.
4. `TableView`: An Avalonia Window that displays the DataGrid and demonstrates different binding scenarios.

## Key Features

- Binding DataGrid columns to named properties (`Name` and `Age`)
- Binding DataGrid columns to indexed properties (`[0]` and `[1]`)
- Demonstration of two-way binding behavior
- Customizable DataGrid setup

## Binding Behavior

The project demonstrates two different binding approaches:

1. **Named Property Binding**: 
   - Columns bound to `Name` and `Age` properties
   - Responds correctly to PropertyChanged events
   - DataGrid automatically sets IsReadOnly based on the IList.IsReadOnly property

2. **Indexed Property Binding**:
   - Columns bound to `[0]` and `[1]` indexed properties
   - Updates the underlying data source but doesn't respond to PropertyChanged events
   - Requires manual setting of IsReadOnly to enable editing

## Usage

To use the DataTableGrid in your project:

1. Create an instance of `PeopleTable`
2. Wrap it in an `ObservableDataRowCollection<ObservableDataRow>`
3. Pass the collection to the `TableView` constructor

Example:

```csharp
var peopleTable = new PeopleTable();
var people = new ObservableDataRowCollection<ObservableDataRow>(peopleTable, row => new ObservableDataRow(row));
new TableView(people);