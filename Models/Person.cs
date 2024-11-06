using DataTableGrid.Models.MVVM;

namespace DataTableGrid.Models;

public partial class Person : ObservableObject
{
    private string firstName = string.Empty;
    private string lastName = string.Empty;
    private int age = 0;

    public string FirstName
    {
        get => GetField(ref firstName);
        set => SetField(ref firstName, value);
    }
    public string LastName
    {
        get => GetField(ref lastName);
        set => SetField(ref lastName, value);
    }
    public int Age
    {
        get => GetField(ref age);
        set => SetField(ref age, value);
    }

}
