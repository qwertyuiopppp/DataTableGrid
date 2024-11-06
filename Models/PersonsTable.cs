using System.Data;

namespace DataTableGrid.Models;

public class PersonsTable : DataTable
{
    public PersonsTable()
    {
        Columns.Add(nameof(Person.FirstName), typeof(string));
        Columns.Add(nameof(Person.LastName), typeof(string));
        Columns.Add(nameof(Person.Age), typeof(int));
    }
    public void Add(string firstName, string lastName, int age)
    {
        Rows.Add(firstName, lastName, age);
    }
    // retrieve a Person object by index
    public Person GetPerson(DataRow row)
    {
        return new Person
        {
            FirstName = row.Field<string>(nameof(Person.FirstName)) ?? string.Empty,
            LastName = row.Field<string>(nameof(Person.LastName)) ?? string.Empty,
            Age = row.Field<int?>(nameof(Person.Age)) ?? 0,
        };
    }
    public Person GetPerson(int index)
    {
        return new Person
        {
            FirstName = Rows[index].Field<string>(nameof(Person.FirstName)) ?? string.Empty,
            LastName = Rows[index].Field<string>(nameof(Person.LastName)) ?? string.Empty,
            Age = Rows[index].Field<int?>(nameof(Person.Age)) ?? 0,
        };
    }
}