using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataTableGrid.Models.MVVM;

public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event PropertyChangingEventHandler? PropertyChanging;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected void OnPropertyChanging([CallerMemberName] string? propertyName = null)
    {
        PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }

    protected virtual T GetField<T>(ref T field, [CallerMemberName] string? propertyName = null)
    {
        return field;
    }

    protected virtual bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        OnPropertyChanging(propertyName);
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public interface IDisposable
    {
    }
}