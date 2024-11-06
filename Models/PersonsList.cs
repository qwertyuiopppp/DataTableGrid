using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DataTableGrid.Models;

public sealed class PersonsList : ObservableCollection<Person>
{
    public PersonsList()
    {
        this.CollectionChanged += OnCollectionChanged;
        this.PropertyChanged += OnItemPropertyChanged;
    }

    public void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        Console.WriteLine($"Collection changed: {e.Action}");
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                // Handle item(s) added
                break;
            case NotifyCollectionChangedAction.Remove:
                // Handle item(s) removed
                break;
            case NotifyCollectionChangedAction.Replace:
                // Handle item(s) replaced
                break;
            case NotifyCollectionChangedAction.Move:
                // Handle item(s) moved
                break;
            case NotifyCollectionChangedAction.Reset:
                // Handle collection reset
                break;
        }
    }

    public void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        // Handle property changed for an item
        Person? person = sender as Person;
        string propertyName = e.PropertyName?? "";
        Console.WriteLine($"Property '{propertyName}' changed for person {person?.FirstName} {person?.LastName}");  
    }
}