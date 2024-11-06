using System;
using System.Data;

namespace DataTableGrid.Models;


public class People
{
    private readonly PersonsTable _people = new();
    private readonly PersonsList _peopleList = new();
    public People()
    {
        AddSamplePeople();
        _people.ColumnChanged += people_ColumnChanged;
        _people.ColumnChanging += people_ColumnChanging;

    }
    
    public PersonsList PeopleList => _peopleList;
    public DataTable PeopleTable => _people;

    private void AddSamplePeople()
    {
        Populate_PeopleTable();
        Populate_PeopleList();
    }

    private void Populate_PeopleList()
    {
        _peopleList.Clear();
        foreach (DataRow row in _people.Rows)
        {
            _peopleList.Add(_people.GetPerson(row));
        }
    }

    private void Populate_PeopleTable()
    {
        _people.Rows.Add("John", "Doe", 25);
        _people.Rows.Add("Jane", "Doe", 22);
        _people.Rows.Add("Tom", "Smith", 30);
        _people.Rows.Add("Sue", "Smith", 28);
    }

    private void people_ColumnChanging(object sender, DataColumnChangeEventArgs e)
    {
        string columnName = e.Column?.ColumnName?? "";
        Console.WriteLine($"Column '{columnName}' in row {e.Row} changing from {e.Row[e.Column]} to {e.ProposedValue}");
        // Perform any necessary actions based on the column change
        Populate_PeopleList();
    }
    private void people_ColumnChanged(object sender, DataColumnChangeEventArgs e)
    {
        string columnName = e.Column?.ColumnName?? "";
        Console.WriteLine($"Column '{columnName}' in row {e.Row} changed to {e.Row[e.Column]}");
        // Perform any necessary actions based on the column change
        Populate_PeopleList();
    }
    
    public DataTable GetPeopleTable()
    {
        return _people;
    }
    public PersonsList GetPeopleList()
    {
        return _peopleList;
    }

}
