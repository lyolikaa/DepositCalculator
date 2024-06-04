using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
    ];
    
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
    public int Principal { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
    public int InterestRate { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
    public int TimePeriod { get; set; }

    public int PaymentType { get; set; }
    public int Currency { get; set; }

    public string ValidateInput()
    {
        if (Principal == 0)
            return "Principal";

        return null;
    }

    public double Calculate()
    {
            return Principal * (1 + InterestRate / 100 * TimePeriod);

    }
}