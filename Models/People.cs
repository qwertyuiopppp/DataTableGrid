using System;
using System.Data;

namespace DataTableGrid.Models;


public class People
{
    private PersonsTable _people = new();
    private PersonsList peopleList = new();
    public People()
    {
        AddSamplePeople();
    }

    private void AddSamplePeople()
    {
        Populate_PeopleTable();
        Populate_PeopleList();
    }

    private void Populate_PeopleList()
    {
        peopleList.Clear();
        foreach (DataRow row in _people.Rows)
        {
            peopleList.Add(_people.GetPerson(row));
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
        return peopleList;
    }

}
