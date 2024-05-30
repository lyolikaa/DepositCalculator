using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DepositCalculator.ViewModels;

public class CalcViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<PaymentType> PaymentTypes { get; set; } =
        new()
        {
            new() { Code = 0, Type = "Capitalization" },
            new() { Code = 1, Type = "Monthly payout" },
        };
    public ObservableCollection<CurencyType> CurrencyTypes { get; set; } =
    [
        new CurencyType { Code = 0, Type = "USD", Sign = "$"},
        new CurencyType { Code = 1, Type = "EUR", Sign = "\u20ac"},
        new CurencyType { Code = 2, Type = "UAH", Sign = "\u20b4"}
    ];}

public class PaymentType
{   public long Code { get; set; }
    public string Type { get; set; }
}

public class CurencyType
{   public long Code { get; set; }
    public string Type { get; set; }
    public string Sign { get; set; }
}