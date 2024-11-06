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

    public DataTable GetPeopleTable()
    {
        return _people;
    }
    public PersonsList GetPeopleList()
    {
        return _peopleList;
    }

}
