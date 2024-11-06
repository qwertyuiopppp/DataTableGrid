using System.Data;
using DataTableGrid.Models.MVVM;

namespace DataTableGrid.ViewModels;

public class DataRowWrapper(DataRow row) : ObservableObject
{
    public object this[string columnName]
    {
        get => row[columnName];
        set 
        {
            if (row[columnName] == value) return;
            OnPropertyChanging(columnName);
            row[columnName] = value;
            OnPropertyChanged(columnName);
        }
    }
}
